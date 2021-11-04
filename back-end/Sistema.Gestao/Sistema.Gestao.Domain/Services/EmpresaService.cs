
using System.Collections.Generic;
using System.Threading.Tasks;
using Sistema.Gestao.Domain.Entities;
using Sistema.Gestao.Domain.Interfaces.Repositories;
using Sistema.Gestao.Domain.Interfaces.Services;
using Sistema.Gestao.Domain.ViewModel;

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

        public async Task Editar(Empresa empresa)
        {
            var obj = _EmpresaRepository.GetById(empresa.Id);
            obj.Bairro = empresa.Bairro;
            obj.CEP = empresa.CEP;
            obj.Complemento = empresa.Complemento;
            obj.Endereco = empresa.Endereco;
            obj.Localidade = empresa.Localidade;
            obj.Nome = empresa.Nome;
            obj.Numero = empresa.Numero;
            obj.Telefone = empresa.Telefone;
            obj.UF = empresa.UF;
            await _EmpresaRepository.Editar(obj);
        }

        public async Task Excluir(int id)
        {
            await _EmpresaRepository.Excluir(id);
        }

        public async Task<List<EmpresaResponseViewModel>> ObterEmpresa(string nome)
        {
            return await _EmpresaRepository.ObterEmpresa(nome);
        }

        public async Task<EmpresaResponseViewModel> ObterPeloId(int id)
        {
            return await _EmpresaRepository.ObterPeloId(id);
        }

        public async Task Salvar(Empresa empresa)
        {
            await _EmpresaRepository.Salvar(empresa);
        }
    }
}
