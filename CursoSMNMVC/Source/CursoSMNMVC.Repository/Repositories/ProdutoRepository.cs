using CursoSMNMVC.Domain.Entidades;
using CursoSMNMVC.Repository.DataBase;
using ProjetoCursoFeriasSMN.Repository.DataBase;
using System.Collections.Generic;


namespace CursoSMNMVC.Repository.Repositories
{
    public class ProdutoRepository : Execucao
    {
        private static readonly Conexao conexao = new Conexao();

        public ProdutoRepository() : base(conexao)
        {
        }

        public ProdutoRepository(Conexao conexao) : base(conexao)
        {
        }

        public IEnumerable<Produto> GetProdutos()
        {
            ExecuteProcedure("[dbo].[SP_SelProdutos]");

            var produtos = new List<Produto>();
            using ( var reader = ExecuteReader())
            {
                while (reader.Read())
                    produtos.Add(new Produto
                    {
                        CodigoProduto = reader.ReadAsInt("CodigoProduto"),
                        Nome = reader.ReadAsString("Nome"),
                        Preco = reader.ReadAsDecimal("Preco"),
                        Estoque = reader.ReadAsShort("Estoque")
                    });
            }
            return produtos;
        }

        public string CadastraProduto(Produto produto)
        {
            ExecuteProcedure("SP_InsProduto");
            AddParameter("@Nome", produto.Nome);
            AddParameter("@Preo",produto.Preco);
            AddParameter("@Estoque",produto.Estoque);

            var retorno = ExecuteNonQueryWithReturn();

            if (retorno == 1)
                return "Erro ao inserir produto";

            return null;
        }
    }
}
