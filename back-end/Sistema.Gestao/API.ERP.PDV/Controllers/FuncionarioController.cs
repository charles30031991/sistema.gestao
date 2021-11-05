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
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioAppService _FuncionarioAppService;

        public FuncionarioController(IFuncionarioAppService FuncionarioAppService)
        {
            _FuncionarioAppService = FuncionarioAppService;
        }

        [HttpDelete("funcionario/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                await _FuncionarioAppService.Excluir(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro na tentativa de excluir o registo");
            }
        }

        [HttpGet("funcionario/{id}")]
        public async Task<IActionResult> ObterPeloId(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var erros = ModelState.Values.SelectMany(e => e.Errors);
                    return BadRequest(erros);
                }

                var Funcionario = await _FuncionarioAppService.ObterPeloId(id);
                return Ok(Funcionario);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao obter o registro! Tente novamente.");
            }
        }

        [HttpGet("funcionarios/{nome}")]
        public async Task<IActionResult> ObterFuncionario(string nome)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var erros = ModelState.Values.SelectMany(e => e.Errors);
                    return BadRequest(erros);
                }

                var Funcionario = await _FuncionarioAppService.ObterFuncionario(nome);
                return Ok(Funcionario);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao obter Funcionario! Tente novamente.");
            }
        }

        [HttpPut("funcionario")]
        public async Task<IActionResult> Editar(FuncionarioRequestViewModel Funcionario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var erros = ModelState.Values.SelectMany(e => e.Errors);
                    return BadRequest(erros);
                }

                await _FuncionarioAppService.Editar(Funcionario.ToFuncionario());

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao editar Funcionario! Tente novamente.");
            }
        }

        [HttpPost("funcionario")]
        public async Task<IActionResult> Salvar(FuncionarioRequestViewModel Funcionario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var erros = ModelState.Values.SelectMany(e => e.Errors);
                    return BadRequest(erros);
                }

                await _FuncionarioAppService.Salvar(Funcionario.ToFuncionario());

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao editar Funcionario! Tente novamente.");
            }
        }
    }
}
