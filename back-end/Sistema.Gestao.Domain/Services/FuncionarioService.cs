

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Gestao.Domain.Entities;
using Sistema.Gestao.Domain.Interfaces.Repositories;
using Sistema.Gestao.Domain.Interfaces.Services;
using Sistema.Gestao.Domain.ViewModel;

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

        public async Task Editar(Funcionario funcionario)
        {
            await _FuncionarioRepository.Editar(funcionario);
        }

        public async Task Excluir(int id)
        {
            await _FuncionarioRepository.Excluir(id);
        }

        public async Task<List<FuncionarioResponseViewModel>> ObterFuncionario(string nome)
        {
            var resultado = await _FuncionarioRepository.ObterFuncionario(nome);

            foreach (var item in resultado)
            {
                switch (item.Cargo)
                {
                    case (int)Cargo.Programador:
                        item.NomeCargo = "Programador";
                        break;
                    case (int)Cargo.Designer:
                        item.NomeCargo = "Designer";
                        break;
                    case (int)Cargo.Administração:
                        item.NomeCargo = "Administração";
                        break;
                }

                item.SalarioFormatado = item.Salario.ToString("C", CultureInfo.CurrentCulture);
            }

            return resultado;
        }

        public async Task<FuncionarioResponseViewModel> ObterPeloId(int id)
        {
            return await _FuncionarioRepository.ObterPeloId(id);
        }

        public async Task Salvar(Funcionario funcionario)
        {
            await _FuncionarioRepository.Salvar(funcionario);
        }

        public enum Cargo
        {
            Programador = 1,
            Designer = 2,
            Administração = 3
        }

    }
}
