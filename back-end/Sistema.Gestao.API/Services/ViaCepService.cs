using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sistema.Gestao.API.Services
{
    public class ViaCepService
    {
        public static async Task<ViaCepResult> ObterEndereco(string cep)
        {
            using (HttpClient http = new HttpClient())
            {
                var response = http.GetAsync($"https://viacep.com.br/ws/{cep}/json/").Result;
                var _reponse = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var erro = $"StatusCode:{response.StatusCode} Message: {response.ReasonPhrase} Response: {responseContent}";
                    throw new Exception("Erro ao obter o endereço na API de integração do ViaCep.", new Exception(erro));
                }

                ViaCepResult result = Newtonsoft.Json.JsonConvert.DeserializeObject<ViaCepResult>(_reponse);
                return result;
            }
        }
    }

    public class ViaCepResult
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Unidade { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
    }
}
