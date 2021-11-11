
using System.Collections.Generic;
using System.Threading.Tasks;
using Sistema.Gestao.Domain.Entities;
using Sistema.Gestao.Domain.ViewModel;

namespace Sistema.Gestao.Application.Interface
{
    public interface IFuncionarioAppService : IAppServiceBase<Funcionario>
    {
        Task Excluir(int id);
        Task<FuncionarioResponseViewModel> ObterPeloId(int id);
        Task<List<FuncionarioResponseViewModel>> ObterFuncionario(string nome);
        Task Editar(Funcionario funcionario);
        Task Salvar(Funcionario funcionario);
    }
}
