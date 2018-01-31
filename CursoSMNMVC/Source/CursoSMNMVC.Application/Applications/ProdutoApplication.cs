using CursoSMNMVC.Application.Models;
using CursoSMNMVC.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CursoSMNMVC.Application.Applications
{
    public class ProdutoApplication
    {
        private readonly string _enderecoApi = $"{ApiConfig.EnderecoApi}/produto";

        public Response<IEnumerable<ProdutoModel>> GetProduto()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync($"{_enderecoApi}/listaProduto").Result;
                return new Response<IEnumerable<ProdutoModel>>(response.Content.ReadAsStringAsync().Result, response.StatusCode);
            }
        }

        public object GetProdutos()
        {
            throw new NotImplementedException();
        }
    }
}
