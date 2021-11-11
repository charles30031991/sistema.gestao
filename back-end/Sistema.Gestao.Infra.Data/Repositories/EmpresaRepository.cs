using Sistema.Gestao.Domain.Entities;
using Sistema.Gestao.Domain.Interfaces.Repositories;
using Sistema.Gestao.Domain.ViewModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;

namespace Sistema.Gestao.Infra.Data.Repositories
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        public async Task Editar(Empresa empresa)
        {
            Db.Entry(empresa).State = EntityState.Modified;
            await Db.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var empresa = GetById(id);
            Db.Set<Empresa>().Remove(empresa);
            await Db.SaveChangesAsync();
        }

        public async Task<List<EmpresaResponseViewModel>> ObterEmpresa(string nome)
        {
            return await (from e in Db.Empresa
                          where (string.IsNullOrEmpty(nome) || e.Nome.Contains(nome))
                          select new EmpresaResponseViewModel
                          {
                              Id = e.Id,
                              Nome = e.Nome,
                              Numero = e.Numero,
                              Telefone = e.Telefone,
                              UF = e.UF,
                              Bairro = e.Bairro,
                              CEP = e.CEP,
                              Complemento = e.Complemento,
                              Endereco = e.Endereco,
                              Funcionario = e.Funcionario,
                              Localidade = e.Localidade,
                          }).ToListAsync();
        }

        public async Task<EmpresaResponseViewModel> ObterPeloId(int id)
        {
            return await (from e in Db.Empresa
                          where (e.Id == id)
                          select new EmpresaResponseViewModel
                          {
                              Id = e.Id,
                              Nome = e.Nome,
                              Numero = e.Numero,
                              Telefone = e.Telefone,
                              UF = e.UF,
                              Bairro = e.Bairro,
                              CEP = e.CEP,
                              Complemento = e.Complemento,
                              Endereco = e.Endereco,
                              Funcionario = e.Funcionario,
                              Localidade = e.Localidade,
                          }).FirstOrDefaultAsync();
        }

        public async Task Salvar(Empresa empresa)
        {
            Db.Empresa.Add(empresa);
            await Db.SaveChangesAsync();
        }
    }
}
