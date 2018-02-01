using CursoSMNMVC.Application.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace CursoSMNMVC.Application.Applications
{
    public class ProdutoApplication
    {
        private readonly string _enderecoApi = $"{ApiConfig.EnderecoApi}/produto";

        public Response<IEnumerable<Produto>> GetProdutos()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync($"{_enderecoApi}/listaProduto").Result;
                return new Response<IEnumerable<Produto>>(response.Content.ReadAsStringAsync().Result, response.StatusCode);
            }
        }

        public Response<string> PostProduto(Produto produto)
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsync($"{_enderecoApi}/CadastraProduto", produto, new JsonMediaTypeFormatter()).Result;
                return new Response<string>(response.Content.ReadAsStreamAsync().Result, response.StatusCode);
            }
        }
    }
}
