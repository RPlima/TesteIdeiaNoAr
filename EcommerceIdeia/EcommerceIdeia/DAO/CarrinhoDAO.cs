using EcommerceIdeia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EcommerceIdeia.DAO
{
    public class CarrinhoDAO
    {
        private static Context ctx = Singleton.GetInstance();

        #region Buscar Carrinho pelo Guid
        public static Carrinho BuscarPeloGuidCar(string CarrinhoId)
        {
            return ctx.Carrinhos.Where(e => e.carrinhoGuid == CarrinhoId).FirstOrDefault();
        }
        #endregion

        #region Buscar Item pelo Id do Produto
        public static Carrinho BuscarByProduto(int id, string carrinhoId)
        {
            return ctx.Carrinhos.Include("Produto").Where(e => e.Produto.idProduto == id && e.carrinhoGuid == carrinhoId).FirstOrDefault();
        }
        #endregion

        #region Alterar Quantidade
        public static void AlteraQuantidade(Carrinho item, bool qtde)
        {
            if (qtde)
            {
                item.quantidade++;
            }
            else
            {
                item.quantidade--;
            }
            ctx.Entry(item).State = EntityState.Modified;
            ctx.SaveChanges();
        }
        #endregion

        #region Add no Carrinho
        public static bool CadastrarItem(Carrinho item)
        {
            if (item.Produto != null)
            {
                ctx.Carrinhos.Add(item);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region Valor Total no Carrinho
        public static decimal TotalCarrinho(string carrinhoId)
        {
            return BuscarCarrinhosGuid(carrinhoId).Sum(x => x.quantidade * x.valor);
        }
        #endregion

        #region Buscar lista de Carrinhos Pelo guid
        public static List<Carrinho> BuscarCarrinhosGuid(string CarrinhoId)
        {
            return ctx.Carrinhos.Where(e => e.carrinhoGuid.Equals(CarrinhoId)).ToList();
        }
        #endregion

        #region Listar toda Venda
        public static List<Carrinho> ListarVendaByGuid(string carrinhoGuid)
        {
            return ctx.Carrinhos.Include("Produto").Where(e => e.carrinhoGuid.Equals(carrinhoGuid)).ToList();
        }
        #endregion

        #region Remover Produto do Carrinho
        public static void RemoverProdutoCarrinho(int id)
        {
            Carrinho carrinho = new Carrinho();
            carrinho = BuscarById(id);
            ctx.Carrinhos.Remove(carrinho);
            ctx.SaveChanges();

        }
        #endregion

        #region Buscar Carrinho por id
        public static Carrinho BuscarById(int id)
        {
            return ctx.Carrinhos.FirstOrDefault(x => x.idCarrinho == id);
        }
        #endregion
    }
}