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
    }
}