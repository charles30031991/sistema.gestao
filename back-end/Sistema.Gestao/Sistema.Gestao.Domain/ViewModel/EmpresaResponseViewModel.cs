using Newtonsoft.Json;
using Sistema.Gestao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Gestao.Domain.ViewModel
{
    public class EmpresaResponseViewModel
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
        [JsonIgnore]
        public string Senha { get; set; }
        [JsonIgnore]
        public ICollection<Funcionario> Funcionario { get; set; }
    }
}
