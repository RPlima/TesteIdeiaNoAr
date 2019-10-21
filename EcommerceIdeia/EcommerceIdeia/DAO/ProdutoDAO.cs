using EcommerceIdeia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceIdeia.DAO
{
    public class ProdutoDAO
    {
        private static Context ctx = Singleton.GetInstance();

        #region Listar Produtos
        public static List<Produto> ReturnProdutos()
        {
            return ctx.Produtos.ToList();
        }
        #endregion

        #region Cadastrar Produto
        public static bool CadastrarProduto(Produto Produto)
        {
            if (BuscarProdutoPorNome(Produto) == null)
            {
                ctx.Produtos.Add(Produto);
                ctx.SaveChanges();
                return true;
            }

            return false;
        }
        #endregion

        #region Buscando produto por nome
        public static Produto BuscarProdutoPorNome(Produto Produto)
        {
            return ctx.Produtos.FirstOrDefault(x => x.nomeProduto.Equals(Produto.nomeProduto));
        }
        #endregion

        #region Buscar produto por Id
        public static Produto BuscarProdutoPorId(int id)
        {
            return ctx.Produtos.Find(id);
        }
        #endregion
    }
}