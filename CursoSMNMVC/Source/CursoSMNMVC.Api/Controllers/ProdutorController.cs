using CursoSMNMVC.Repository.Repositories;
using System.Web.Http;

namespace CursoSMNMVC.Api.Controllers
{
    public class ProdutorController : ApiController
    {
        private readonly ProdutoRepository _produtoRepository = new ProdutoRepository();

        public IHttpActionResult GetProdutos()
        {
            return Ok(_produtoRepository.GetProdutos());
        }
    }
}