using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Sistema.Gestao.API.Helper
{
    public class Cripty
    {
        public enum CryptProvider
        {
            /// <summary>
            /// Representa a classe base para implementações criptografia dos algoritmos simétricos Rijndael.
            /// </summary>
            Rijndael,
            /// <summary>
            /// Representa a classe base para implementações do algoritmo RC2.
            /// </summary>
            RC2,
            /// <summary>
            /// Representa a classe base para criptografia de dados padrões (DES - Data Encryption Standard).
            /// </summary>
            DES,
            /// <summary>
            /// Representa a classe base (TripleDES - Triple Data Encryption Standard).
            /// </summary>
            TripleDES
        }


        /// <summary>
        /// Classe auxiliar com métodos para criptografia de dados.
        /// </summary>
        public class Crypt
        {
            public const string CHAVE_SEGURANCA = "1%¨&a@.,MWER dD87SF JN23;";
            public const string CHAVE_QRCODE = "8";

            private static void SetIV(CryptProvider pCryptProvider, SymmetricAlgorithm pAlgorithm)
            {
                switch (pCryptProvider)
                {
                    case CryptProvider.Rijndael:
                        pAlgorithm.IV = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0x5, 0x46, 0x9c, 0xea, 0xa8, 0x4b, 0x73, 0xcc };
                        break;
                    default:
                        pAlgorithm.IV = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9 };
                        break;
                }
            }

            private static SymmetricAlgorithm GetAlgorithm(CryptProvider pCryptProvider)
            {
                SymmetricAlgorithm oAlgorithm;
                switch (pCryptProvider)
                {
                    case CryptProvider.Rijndael:
                        oAlgorithm = new RijndaelManaged();
                        break;
                    case CryptProvider.RC2:
                        oAlgorithm = new RC2CryptoServiceProvider();
                        break;
                    case CryptProvider.DES:
                        oAlgorithm = new DESCryptoServiceProvider();
                        break;
                    case CryptProvider.TripleDES:
                        oAlgorithm = new TripleDESCryptoServiceProvider();
                        break;
                    default:
                        oAlgorithm = new RijndaelManaged();
                        break;

                }
                oAlgorithm.Mode = CipherMode.CBC;
                return oAlgorithm;
            }

            /// <summary>
            /// Gera a chave de criptografia válida dentro do array.
            /// </summary>
            /// <returns>Chave com array de bytes.</returns>
            private static byte[] GetKey(string pKey, SymmetricAlgorithm pAlgorithm)
            {
                string salt = string.Empty;

                // Ajuta o tamanho da chave se necessário e retorna uma chave válida
                if (pAlgorithm.LegalKeySizes.Length > 0)
                {
                    // Tamanho das chaves em bits
                    int keySize = pKey.Length * 8;
                    int minSize = pAlgorithm.LegalKeySizes[0].MinSize;
                    int maxSize = pAlgorithm.LegalKeySizes[0].MaxSize;
                    int skipSize = pAlgorithm.LegalKeySizes[0].SkipSize;

                    if (keySize > maxSize)
                    {
                        // Busca o valor máximo da chave
                        pKey = pKey.Substring(0, maxSize / 8);
                    }
                    else if (keySize < maxSize)
                    {
                        // Seta um tamanho válido
                        int validSize = (keySize <= minSize) ? minSize : (keySize - keySize % skipSize) + skipSize;
                        if (keySize < validSize)
                        {
                            // Preenche a chave com arterisco para corrigir o tamanho
                            pKey = pKey.PadRight(validSize / 8, '*');
                        }
                    }
                }
                PasswordDeriveBytes key = new PasswordDeriveBytes(pKey, ASCIIEncoding.ASCII.GetBytes(salt));
                return key.GetBytes(pKey.Length);
            }
            /// <summary>
            /// Encripta o dado solicitado.
            /// </summary>
            /// <param name="plainText">Texto a ser criptografado.</param>
            /// <returns>Texto criptografado.</returns>
            public static string Encrypt(string plainText, string pKey, CryptProvider pCryptProvider)
            {
                SymmetricAlgorithm oAlgorithm = GetAlgorithm(pCryptProvider);
                byte[] plainByte = ASCIIEncoding.ASCII.GetBytes(plainText);
                byte[] keyByte = GetKey(pKey, oAlgorithm);

                // Seta a chave privada
                oAlgorithm.Key = keyByte;
                SetIV(pCryptProvider, oAlgorithm);

                // Interface de criptografia / Cria objeto de criptografia
                ICryptoTransform cryptoTransform = oAlgorithm.CreateEncryptor();

                MemoryStream _memoryStream = new MemoryStream();

                CryptoStream _cryptoStream = new CryptoStream(_memoryStream, cryptoTransform, CryptoStreamMode.Write);

                // Grava os dados criptografados no MemoryStream
                _cryptoStream.Write(plainByte, 0, plainByte.Length);
                _cryptoStream.FlushFinalBlock();

                // Busca o tamanho dos bytes encriptados
                byte[] cryptoByte = _memoryStream.ToArray();

                // Converte para a base 64 string para uso posterior em um xml
                return Convert.ToBase64String(cryptoByte, 0, cryptoByte.GetLength(0));
            }
            /// <summary>
            /// Desencripta o dado solicitado.
            /// </summary>
            /// <param name="cryptoText">Texto a ser descriptografado.</param>
            /// <returns>Texto descriptografado.</returns>
            public static string Decrypt(string cryptoText, string pKey, CryptProvider pCryptProvider)
            {
                try
                {
                    SymmetricAlgorithm oAlgorithm = GetAlgorithm(pCryptProvider);
                    byte[] cryptoByte = Convert.FromBase64String(cryptoText);
                    byte[] keyByte = GetKey(pKey, oAlgorithm);

                    // Seta a chave privada
                    oAlgorithm.Key = keyByte;
                    SetIV(pCryptProvider, oAlgorithm);

                    // Interface de criptografia / Cria objeto de descriptografia
                    ICryptoTransform cryptoTransform = oAlgorithm.CreateDecryptor();

                    MemoryStream _memoryStream = new MemoryStream(cryptoByte, 0, cryptoByte.Length);

                    CryptoStream _cryptoStream = new CryptoStream(_memoryStream, cryptoTransform, CryptoStreamMode.Read);

                    // Busca resultado do CryptoStream
                    StreamReader _streamReader = new StreamReader(_cryptoStream);
                    return _streamReader.ReadToEnd();
                }
                catch 
                {
                   throw new Exception("QrCode invalido!");
                }
            }
        }
    }
}
