
using System.Collections.Generic;
using System.Threading.Tasks;
using Sistema.Gestao.Application.Interface;
using Sistema.Gestao.Domain.Entities;
using Sistema.Gestao.Domain.Interfaces.Services;
using Sistema.Gestao.Domain.ViewModel;

namespace Sistema.Gestao.Application
{
    public class EmpresaAppService : AppServiceBase<Empresa>, IEmpresaAppService
    {
        private readonly IEmpresaService _EmpresaService;

        public EmpresaAppService(IEmpresaService EmpresaService)
            : base(EmpresaService)
        {
            _EmpresaService = EmpresaService;
        }

        public async Task Editar(Empresa empresa)
        {
            await _EmpresaService.Editar(empresa);
        }

        public async Task Excluir(int id)
        {
            await _EmpresaService.Excluir(id);
        }

        public async Task<List<EmpresaResponseViewModel>> ObterEmpresa(string nome)
        {
            return await _EmpresaService.ObterEmpresa(nome);
        }

        public async Task<EmpresaResponseViewModel> ObterPeloId(int id)
        {
            return await _EmpresaService.ObterPeloId(id);
        }

        public async Task Salvar(Empresa empresa)
        {
            await _EmpresaService.Salvar(empresa);
        }
    }
}
