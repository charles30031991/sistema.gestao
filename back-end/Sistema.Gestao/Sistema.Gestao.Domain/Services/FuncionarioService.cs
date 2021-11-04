

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Gestao.Domain.Entities;
using Sistema.Gestao.Domain.Interfaces.Repositories;
using Sistema.Gestao.Domain.Interfaces.Services;
using Sistema.Gestao.Domain.ViewModel;

namespace Sistema.Gestao.Domain.Services
{
    public class FuncionarioService : ServiceBase<Funcionario>, IFuncionarioService
    {
        private readonly IFuncionarioRepository _FuncionarioRepository;

        public FuncionarioService(IFuncionarioRepository FuncionarioRepository)
            : base(FuncionarioRepository)
        {
            _FuncionarioRepository = FuncionarioRepository;
        }

        public async Task Editar(Funcionario funcionario)
        {
            await _FuncionarioRepository.Editar(funcionario);
        }

        public async Task Excluir(int id)
        {
            await _FuncionarioRepository.Excluir(id);
        }

        public async Task<List<FuncionarioResponseViewModel>> ObterFuncionario(string nome)
        {
            return await _FuncionarioRepository.ObterFuncionario(nome);
        }

        public async Task<FuncionarioResponseViewModel> ObterPeloId(int id)
        {
            return await _FuncionarioRepository.ObterPeloId(id);
        }

        public async Task Salvar(Funcionario funcionario)
        {
            await _FuncionarioRepository.Salvar(funcionario);
        }
    }
}
