using Sistema.Gestao.Domain.Entities;
using Sistema.Gestao.Domain.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema.Gestao.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository : IRepositoryBase<Funcionario>
    {
        Task Editar(Funcionario funcionario);
        Task Excluir(int id);
        Task<List<FuncionarioResponseViewModel>> ObterFuncionario(string nome);
        Task<FuncionarioResponseViewModel> ObterPeloId(int id);
        Task Salvar(Funcionario funcionario);
    }
}
