using CursoSMNMVC.Domain.Entidades;
using CursoSMNMVC.Repository.DataBase;
using ProjetoCursoFeriasSMN.Repository.DataBase;
using System.Collections.Generic;


namespace CursoSMNMVC.Repository.Repositories
{
    public class ProdutoRepository : Execucao
    {
        private static readonly Conexao conexao = new Conexao();

        public ProdutoRepository() 
        {
        }

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
                        CodigoProduto = reader.ReadAsInt("CodigoProduto"),
                        Nome = reader.ReadAsString("Nome"),
                        Preco = reader.ReadAsDecimal("Preco"),
                        Estoque = reader.ReadAsInt("Estoque")
                    });
            }
            return produtos;
        }
    }
}
