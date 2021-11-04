using Sistema.Gestao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Gestao.Domain.ViewModel
{
    public class EmpresaRequestViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string Bairro { get; set; }
        public string Senha { get; set; }

        public Empresa ToEmpresa()
        {
            return new Empresa
            {
                Bairro = Bairro,
                CEP = CEP,
                Complemento = Complemento,
                Endereco = Endereco,
                Localidade = Localidade,
                Nome = Nome,
                Numero = Numero,
                Telefone = Telefone,
                UF = UF,
            };
        }
    }
}
