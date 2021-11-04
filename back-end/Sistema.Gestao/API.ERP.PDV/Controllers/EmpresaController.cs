using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema.Gestao.Application.Interface;
using Sistema.Gestao.Domain.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Gestao.API.Controllers
{
    [Authorize]
    [Route("v1/[controller]")]
    [ApiController]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaAppService _empresaAppService;

        public EmpresaController(IEmpresaAppService empresaAppService)
        {
            _empresaAppService = empresaAppService;
        }

        [HttpDelete("empresa/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                await _empresaAppService.Excluir(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro na tentativa de excluir o registo");
            }
        }

        [HttpGet("empresa/{id}")]
        public async Task<IActionResult> ObterPeloId(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var erros = ModelState.Values.SelectMany(e => e.Errors);
                    return BadRequest(erros);
                }

                var empresa = await _empresaAppService.ObterPeloId(id);
                return Ok(empresa);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao obter o registro! Tente novamente.");
            }
        }

        [HttpPost("empresas")]
        public async Task<IActionResult> ObterEmpresa(EmpresaRequestViewModel filtro)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var erros = ModelState.Values.SelectMany(e => e.Errors);
                    return BadRequest(erros);
                }

                var empresa = await _empresaAppService.ObterEmpresa(filtro);
                return Ok(empresa);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao obter empresa! Tente novamente.");
            }
        }

        [HttpPut("empresa")]
        public async Task<IActionResult> Editar(EmpresaRequestViewModel empresa)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var erros = ModelState.Values.SelectMany(e => e.Errors);
                    return BadRequest(erros);
                }

                await _empresaAppService.Editar(empresa.ToEmpresa());

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao editar empresa! Tente novamente.");
            }
        }

        [HttpPost("empresa")]
        public async Task<IActionResult> Salvar(EmpresaRequestViewModel empresa)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var erros = ModelState.Values.SelectMany(e => e.Errors);
                    return BadRequest(erros);
                }

                await _empresaAppService.Salvar(empresa.ToEmpresa());

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao editar Empresa! Tente novamente.");
            }
        }
    }
}
