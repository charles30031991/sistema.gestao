using System.Collections.Generic;
using System.Threading.Tasks;
using Sistema.Gestao.Application.Interface;
using Sistema.Gestao.Domain.Entities;
using Sistema.Gestao.Domain.Interfaces.Services;
using Sistema.Gestao.Domain.ViewModel;

namespace Sistema.Gestao.Application
{
    public class FuncionarioAppService : AppServiceBase<Funcionario>, IFuncionarioAppService
    {
        private readonly IFuncionarioService _FuncionarioService;

        public FuncionarioAppService(IFuncionarioService FuncionarioService)
            : base(FuncionarioService)
        {
            _FuncionarioService = FuncionarioService;
        }

        public async Task Editar(Funcionario funcionario)
        {
            await _FuncionarioService.Editar(funcionario);
        }

        public async Task Excluir(int id)
        {
            await _FuncionarioService.Excluir(id);
        }

        public async Task<List<FuncionarioResponseViewModel>> ObterFuncionario(string nome)
        {
            return await _FuncionarioService.ObterFuncionario(nome);
        }

        public async Task<FuncionarioResponseViewModel> ObterPeloId(int id)
        {
            return await _FuncionarioService.ObterPeloId(id);
        }

        public async Task Salvar(Funcionario funcionario)
        {
            await _FuncionarioService.Salvar(funcionario);
        }
    }
}
