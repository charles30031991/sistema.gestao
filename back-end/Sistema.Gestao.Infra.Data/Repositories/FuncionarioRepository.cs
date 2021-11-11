
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Gestao.Domain.Entities;
using Sistema.Gestao.Domain.Interfaces.Repositories;
using Sistema.Gestao.Domain.ViewModel;

namespace Sistema.Gestao.Infra.Data.Repositories
{
    public class Funcionarioepository : RepositoryBase<Funcionario>, IFuncionarioRepository
    {
        public async Task Editar(Funcionario funcionario)
        {
            Db.Entry(funcionario).State = EntityState.Modified;
            await Db.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var obj = GetById(id);
            Db.Set<Funcionario>().Remove(obj);
            await Db.SaveChangesAsync();
        }

        public async Task<List<FuncionarioResponseViewModel>> ObterFuncionario(string nome)
        {
            return await (from e in Db.Funcionario
                          where (string.IsNullOrEmpty(nome) || e.Nome.Contains(nome))
                          select new FuncionarioResponseViewModel
                          {
                              Id = e.Id,
                              Cargo = e.Cargo,
                              Nome = e.Nome,
                              Salario = e.Salario,
                              EmpresaId = e.EmpresaId,
                              NomeEmpresa = e.Empresa.Nome,
                          }).ToListAsync();
        }

        public async Task<FuncionarioResponseViewModel> ObterPeloId(int id)
        {
            return await (from e in Db.Funcionario
                          where (e.Id == id)
                          select new FuncionarioResponseViewModel
                          {
                              Id = e.Id,
                              Cargo = e.Cargo,
                              Nome = e.Nome,
                              Salario = e.Salario,
                          }).FirstOrDefaultAsync();
        }

        public async Task Salvar(Funcionario funcionario)
        {
            Db.Funcionario.Add(funcionario);
            await Db.SaveChangesAsync();
        }
    }

}
