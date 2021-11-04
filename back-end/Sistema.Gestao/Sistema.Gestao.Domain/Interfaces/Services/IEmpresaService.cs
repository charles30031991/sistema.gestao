using System.Collections.Generic;
using System.Threading.Tasks;
using Sistema.Gestao.Domain.Entities;
using Sistema.Gestao.Domain.ViewModel;

namespace Sistema.Gestao.Domain.Interfaces.Services
{
    public interface IEmpresaService : IServiceBase<Empresa>
    {
        Task Editar(Empresa empresa);
        Task Excluir(int id);
        Task<List<EmpresaResponseViewModel>> ObterEmpresa(string nome);
        Task<EmpresaResponseViewModel> ObterPeloId(int id);
        Task Salvar(Empresa empresa);
    }
}
