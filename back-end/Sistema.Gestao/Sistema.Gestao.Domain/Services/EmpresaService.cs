
using System.Collections.Generic;
using Sistema.Gestao.Domain.Entities;
using Sistema.Gestao.Domain.Interfaces.Repositories;
using Sistema.Gestao.Domain.Interfaces.Services;

namespace Sistema.Gestao.Domain.Services
{
    public class EmpresaService : ServiceBase<Empresa>, IEmpresaService
    {
        private readonly IEmpresaRepository _EmpresaRepository;

        public EmpresaService(IEmpresaRepository EmpresaRepository)
            : base(EmpresaRepository)
        {
            _EmpresaRepository = EmpresaRepository;
        }
    }
}
