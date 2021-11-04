
using System.Collections.Generic;
using System.Threading.Tasks;
using Sistema.Gestao.Domain.Entities;
using Sistema.Gestao.Domain.ViewModel;

namespace Sistema.Gestao.Domain.Interfaces.Services
{
    public interface IFuncionarioService : IServiceBase<Funcionario>
    {
        Task Editar(Funcionario funcionario);
        Task Excluir(int id);
        Task<List<FuncionarioResponseViewModel>> ObterFuncionario(string nome);
        Task<FuncionarioResponseViewModel> ObterPeloId(int id);
        Task Salvar(Funcionario funcionario);
    }
}
