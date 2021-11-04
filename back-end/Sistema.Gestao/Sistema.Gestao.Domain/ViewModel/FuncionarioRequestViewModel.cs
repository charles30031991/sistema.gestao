using Sistema.Gestao.Domain.Entities;
using System;

namespace Sistema.Gestao.Domain.ViewModel
{
    public class FuncionarioRequestViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Cargo { get; set; }
        public decimal Salario { get; set; }
        public int EmpresaId { get; set; }

        public Funcionario ToFuncionario()
        {
            return new Funcionario
            {
                Id = Id,
                Cargo = Cargo,
                Salario = Salario,
            };
        }
    }
}
