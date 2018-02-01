using CursoSMNMVC.Domain.Entidades;
using CursoSMNMVC.Repository.Repositories;
using System.Web.Http;

namespace CursoSMNMVC.Api.Controllers
{
    [RoutePrefix("api/produto")]
    public class ProdutorController : ApiController
    {
        private readonly ProdutoRepository _produtoRepository = new ProdutoRepository();

       [HttpGet, Route("listaProduto")]
        public IHttpActionResult GetProdutos()
        {
            try
            {
                return Ok(_produtoRepository.GetProdutos());
            }
            catch
            {
                return BadRequest("Erro ao listar produtos");
            }            
        }

        [HttpPost, Route("CadastraProduto")]
        public IHttpActionResult PostProduto(Produto produto)
        {
            try
            {
                var retorno = _produtoRepository.CadastraProduto(produto);

                if (retorno != null)
                {
                    return BadRequest(retorno);
                }

                return Ok("Produto foi cadastrado com sucesso");
            }
            catch
            {
                return BadRequest("Algo deu errado!");
            }
        }
    }
}