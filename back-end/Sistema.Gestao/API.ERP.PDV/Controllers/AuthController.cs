//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using PDVende.Domain.ApiViewModels;
//using Sistema.Gestao.API.Helper;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Data.Entity;
//using PDVende.Domain.EdmxApi;
//using PDVende.Domain.Singleton;
//using PDVende.Service.Telas.Util;
//using PDVende.Infra.Data.Negocio;

//namespace Sistema.Gestao.API.Controllers
//{
//    [Route("api/[controller]")]
//    public class AuthController : ControladorBase
//    {

//        public AuthController()
//        {

//        }

//        #region Login
//        /// <summary>
//        /// Loga um Empresa do sistema
//        /// </summary>
//        /// <response code="200">Retorna o usuário logado e o token de autorização</response>
//        /// <response code="401">Se username não existir ou se a senha não for correta</response>
//        [HttpPost("logar")]
//        [ProducesResponseType(200)]
//        [ProducesResponseType(401)]
//        [AllowAnonymous]
//        public async Task<IActionResult> Logar([FromBody] EmpresaViewModel empresaDados)
//        {
//            try
//            {
//                List<EmpresaDadosModelView> filiais = null;
//                EmpresaApi empresa = null;
//                AssinaturaEmpresaViewModel assinatura = null;

//                var senha = Cripty.Crypt.Encrypt(empresaDados.Senha, Cripty.Crypt.CHAVE_SEGURANCA, Cripty.CryptProvider.DES);
//                empresaDados.Senha = senha;

//                using (var ctx = new pdvendeBDApi())
//                {
//                    if (empresaDados.EhContador)
//                    {
//                        var contador = await ctx.TB_FIS_CONTADOR.FirstOrDefaultAsync(w => w.Login.ToLower().Trim() == empresaDados.Email.ToLower().Trim()
//                            && w.Senha == empresaDados.Senha && w.EhAtivo);

//                        if (contador == null)
//                            return Unauthorized();

//                        var empresaContador = contador.TB_FIS_CONTADOR_EMPRESA.Select(w => w.IdEmpresa).ToList();

//                        if (!empresaContador.Any())
//                            return Unauthorized();

//                        filiais = (from a in ctx.EmpresaApi
//                                   where (empresaContador.Contains(a.Id))
//                                   select new EmpresaDadosModelView
//                                   {
//                                       CodigoEmpresa = a.CodigoEmpresa,
//                                       Nome = (!string.IsNullOrEmpty(a.NomeCompleto) ? a.NomeCompleto : a.NomeRazaoSocial),
//                                       Cpf_cnpj = a.CNPJ_CPF,
//                                       Email = a.Email,
//                                   }).ToList();

//                        foreach (var item in filiais)
//                            item.Cpf_cnpj = Formatacao.FormatCNPJouCPF(item.Cpf_cnpj);


//                        empresa = contador.TB_FIS_CONTADOR_EMPRESA.FirstOrDefault().TB_CAD_EMPRESA;
//                    }
//                    else
//                    {
//                        empresa = await ctx.EmpresaApi.FirstOrDefaultAsync(w => w.Email.ToLower().Trim() == empresaDados.Email.ToLower().Trim()
//                       && w.Senha == empresaDados.Senha);

//                        if (empresa == null)
//                            return Unauthorized();

//                        assinatura = (from a in ctx.AssinaturaEmpresaApi
//                                      where (a.IdEmpresa == empresa.Id && a.EhAssinaturaAtual == true)
//                                      select new AssinaturaEmpresaViewModel
//                                      {
//                                          DataInicio = a.DataInicio,
//                                          DataFim = a.DataFim,
//                                          NomePlano = a.TB_ASS_PLANO.Nome,
//                                      }).FirstOrDefault();


//                        if (empresa.Email == "charlessdeveloper@gmail.com"
//                            || empresa.Email == "filipemarques234@gmail.com")
//                        {
//                            filiais = (from a in ctx.EmpresaApi
//                                       select new EmpresaDadosModelView
//                                       {
//                                           CodigoEmpresa = a.CodigoEmpresa,
//                                           Nome = (!string.IsNullOrEmpty(a.NomeCompleto) ? a.NomeCompleto : a.NomeRazaoSocial),
//                                           Cpf_cnpj = a.CNPJ_CPF,
//                                           Email = a.Email,
//                                       }).ToList();

//                            foreach (var item in filiais)
//                                item.Cpf_cnpj = Formatacao.FormatCNPJouCPF(item.Cpf_cnpj);
//                        }
//                    }

//                    //gerando Token
//                    return Ok(new
//                    {
//                        token = GerarToken(empresa.Id, empresa.NomeCompleto, empresa.Email),
//                        dtExpiry = PDVende.Helper.Helps.Rede.PegarHorarioBrasiliaAtual().AddDays(Startup.PrescricaoTokenDias).ToString("dd/MM/yyyy"),
//                        userInfo = new
//                        {
//                            codigoEmpresa = empresa.CodigoEmpresa,
//                            nome = (!string.IsNullOrEmpty(empresa.NomeCompleto) ? empresa.NomeCompleto : empresa.NomeRazaoSocial),
//                            cpf_cnpj = empresa.CNPJ_CPF,
//                            email = empresa.Email,
//                            telefone = empresa.Telefone,
//                            dataNascimento = empresa.DataNascimento,
//                            logradouro = empresa.EnderecoBDs.FirstOrDefault()?.DescricaoEndereco,
//                            cep = empresa.EnderecoBDs.FirstOrDefault()?.Cep,
//                            cidade = empresa.EnderecoBDs.FirstOrDefault()?.TB_END_MUNICIPIO?.Nome,
//                            numeroEndereco = empresa.EnderecoBDs.FirstOrDefault()?.Numero,
//                            complemento = empresa.EnderecoBDs.FirstOrDefault()?.Complemento,
//                            ufId = empresa.EnderecoBDs.FirstOrDefault()?.TB_END_UF?.Descricao,
//                            barro = empresa.EnderecoBDs.FirstOrDefault()?.Bairro,
//                            idPerfil = empresa.TB_SEG_API_PERFIL?.Id ?? empresa.TB_FIS_CONTADOR_EMPRESA.FirstOrDefault()?.TB_FIS_CONTADOR.IdPerfil
//                        },

//                        assinaturaEmpresa = new
//                        {
//                            assinatura?.DataInicio,
//                            assinatura?.DataFim,
//                            assinatura?.NomePlano,
//                        },

//                        filiais
//                    });
//                }
//            }
//            catch (Exception ex)
//            {
//                _ = Task.Run(() => LogApi.InserirLog(ex
//                        , LogApi.LogCategory.Error
//                        , LogApi.EndPoint.Auth_Logar
//                        , this.HttpContext.Connection.RemoteIpAddress.ToString()));
//                throw;
//            }
//        }

//        #endregion

//        public static string IP_Web(HttpRequest pRequest)
//        {
//            return pRequest.HttpContext.Connection.RemoteIpAddress.ToString();
//        }

//        public static string GerarToken(int usuarioId, string usuarioNome, string email)
//        {
//            var claims = new List<Claim>{
//                new Claim(ClaimTypes.NameIdentifier, usuarioId.ToString()),
//                new Claim(ClaimTypes.Name, usuarioNome),
//            };

//            if (!string.IsNullOrEmpty(email))
//                claims.Add(new Claim(ClaimTypes.SerialNumber, email));

//            var key = new SymmetricSecurityKey(Encoding.UTF8
//                .GetBytes(Startup.Token));

//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(claims),
//                Expires = DateTime.Now.AddDays(Startup.PrescricaoTokenDias),
//                SigningCredentials = creds
//            };

//            var tokenHandler = new JwtSecurityTokenHandler();

//            var token = tokenHandler.CreateToken(tokenDescriptor);

//            return tokenHandler.WriteToken(token);
//        }
//    }
//}
