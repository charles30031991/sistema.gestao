

using System.Collections.Generic;
using Sistema.Gestao.Application.Interface;
using Sistema.Gestao.Domain.Entities;
using Sistema.Gestao.Domain.Interfaces.Services;

namespace Sistema.Gestao.Application
{
    public class FuncionarioAppService : AppServiceBase<Funcionario>, IFuncionarioAppService
    {
        private readonly IFuncionarioService _FuncionarioService;

        public FuncionarioAppService(IFuncionarioService FuncionarioService)
            : base(FuncionarioService)
        {
            _FuncionarioService = FuncionarioService;
        }
    }
}
