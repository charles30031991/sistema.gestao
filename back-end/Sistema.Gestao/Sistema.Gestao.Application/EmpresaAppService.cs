
using System.Collections.Generic;
using Sistema.Gestao.Application.Interface;
using Sistema.Gestao.Domain.Entities;
using Sistema.Gestao.Domain.Interfaces.Services;

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
    }
}
