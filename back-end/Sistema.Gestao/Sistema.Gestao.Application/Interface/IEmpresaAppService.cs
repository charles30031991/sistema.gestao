
using System.Collections.Generic;
using System.Threading.Tasks;
using Sistema.Gestao.Domain.Entities;
using Sistema.Gestao.Domain.ViewModel;

namespace Sistema.Gestao.Application.Interface
{
    public interface IEmpresaAppService : IAppServiceBase<Empresa>
    {
        Task Excluir(int id);
        Task<List<EmpresaResponseViewModel>> ObterEmpresa(EmpresaRequestViewModel filtro);
        Task<EmpresaResponseViewModel> ObterPeloId(int id);
        Task Editar(Empresa empresa);
        Task Salvar(Empresa empresa);
    }
}
