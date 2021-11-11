using Sistema.Gestao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Gestao.Domain.ViewModel
{
    public class FuncionarioResponseViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Cargo { get; set; }
        public decimal Salario { get; set; }
        public int EmpresaId { get; set; }
        public string NomeEmpresa { get; set; }
        public string NomeCargo { get; internal set; }
    }
}
