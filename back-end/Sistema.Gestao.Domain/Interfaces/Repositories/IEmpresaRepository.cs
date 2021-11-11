using System.Collections.Generic;
using System.Threading.Tasks;
using Sistema.Gestao.Domain.Entities;
using Sistema.Gestao.Domain.ViewModel;

namespace Sistema.Gestao.Domain.Interfaces.Repositories
{
    public interface IEmpresaRepository : IRepositoryBase<Empresa>
    {
        Task Excluir(int id);
        Task<List<EmpresaResponseViewModel>> ObterEmpresa(string nome);
        Task<EmpresaResponseViewModel> ObterPeloId(int id);
        Task Salvar(Empresa empresa);
        Task Editar(Empresa empresa);
    }
}
