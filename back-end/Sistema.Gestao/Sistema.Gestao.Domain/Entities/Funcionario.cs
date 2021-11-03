
using Sistema.Gestao.Domain.Entities;

namespace Sistema.Gestao.Domain.Entities
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public EnumCargo Cargo { get; set; }
        public decimal Salario { get; set; }
        public Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }
    }
}
