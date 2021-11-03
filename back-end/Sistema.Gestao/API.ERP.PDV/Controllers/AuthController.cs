using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Sistema.Gestao.API.Helper;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Sistema.Gestao.Domain.ViewModel;
using Sistema.Gestao.Infra.Data.Contexto;
using Sistema.Gestao.Domain.Entities;
using Sistema.Gestao.Domain.Entities;

namespace Sistema.Gestao.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControladorBase
    {

        public AuthController()
        {

        }

        #region Login
        /// <summary>
        /// Loga um Empresa do sistema
        /// </summary>
        /// <response code="200">Retorna o usuário logado e o token de autorização</response>
        /// <response code="401">Se username não existir ou se a senha não for correta</response>
        [HttpPost("logar")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [AllowAnonymous]
        public async Task<IActionResult> Logar([FromBody] EmpresaViewModel empresaDados)
        {
            try
            {

                empresaDados.Senha = Cripty.Crypt.Encrypt(empresaDados.Senha, Cripty.Crypt.CHAVE_SEGURANCA, Cripty.CryptProvider.DES);

                Empresa empresa = null;
                using (var ctx = new SistemaContext())
                {
                    empresa = await ctx.Empresa.FirstOrDefaultAsync(w => w.Nome.ToLower().Trim() == empresaDados.Nome.ToLower().Trim()
                    && w.Senha == empresaDados.Senha);

                    if (empresa == null)
                        return Unauthorized();

                    return Ok(new
                    {
                        token = GerarToken(empresa.Id, empresa.Nome),
                        userInfo = new
                        {
                            nome = empresa.Nome,
                            Numero = empresa.Numero,
                            Bairro = empresa.Bairro,
                            CEP = empresa.CEP,
                            Complemento = empresa.Complemento,
                            Endereco = empresa.Endereco,
                            Localidade = empresa.Localidade,
                            Telefone = empresa.Telefone,
                        },
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public static string IP_Web(HttpRequest pRequest)
        {
            return pRequest.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        public static string GerarToken(int id, string usuarioNome)
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Name, usuarioNome),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(Startup.Token));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(Startup.PrescricaoTokenDias),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
