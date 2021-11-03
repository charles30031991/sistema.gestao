

using System.Collections.Generic;
using System.Linq;
using Sistema.Gestao.Domain.Entities;
using Sistema.Gestao.Domain.Interfaces.Repositories;
using Sistema.Gestao.Domain.Interfaces.Services;

namespace Sistema.Gestao.Domain.Services
{
    public class FuncionarioService : ServiceBase<Funcionario>, IFuncionarioService
    {
        private readonly IFuncionarioRepository _FuncionarioRepository;

        public FuncionarioService(IFuncionarioRepository FuncionarioRepository)
            : base(FuncionarioRepository)
        {
            _FuncionarioRepository = FuncionarioRepository;
        }
    }
}
