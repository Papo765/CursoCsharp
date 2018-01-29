using CursoSMNMVC.Domain.Entidades;
using CursoSMNMVC.Repository.DataBase;
using ProjetoCursoFeriasSMN.Repository.DataBase;
using System.Collections.Generic;


namespace CursoSMNMVC.Repository.Repositories
{
    public class ProdutoRepository : Execucao
    {
        private static readonly Conexao conexao = new Conexao();

        public ProdutoRepository(Conexao conexao) : base(conexao)
        {
        }

        public IEnumerable<Produto> GetProdutos()
        {
            ExecuteProcedure("[dbo].SelProdutos]");

            var produtos = new List<Produto>();
            using ( var reader = ExecuteReader())
            {
                while (reader.Read())
                    produtos.Add(new Produto
                    {
                        Nome = reader.ReadAsString("Nome")
                    });
            }
            return produtos;
        }
    }
}
