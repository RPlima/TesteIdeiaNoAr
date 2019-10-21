using EcommerceIdeia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceIdeia.DAO
{
    public class PedidoDAO
    {
        private static Context ctx = Singleton.GetInstance();

        #region Salvar Venda 
        public static bool SalvarVenda(Pedido novoPedido)
        {
            if (novoPedido.Carrinhos != null)
            {
                ctx.Pedidos.Add(novoPedido);
                ctx.SaveChanges();
                return true;
            }

            return false;
        }
        #endregion

        #region Buscar Vendas
        public static List<Pedido> BuscarVendas()
        {
            return ctx.Pedidos.Include("Carrinhos").ToList();
        }
        #endregion

    }
}