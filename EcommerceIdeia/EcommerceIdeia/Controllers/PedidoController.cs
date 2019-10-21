using EcommerceIdeia.DAO;
using EcommerceIdeia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteIdeiaNoAr.Util;

namespace EcommerceIdeia.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            return View(PedidoDAO.BuscarVendas());
        }

        #region Finalizar a Compra
        public ActionResult FinalizarCarrinho()
        {
          var pedido = new Pedido
            {
                Carrinhos = CarrinhoDAO.ListarVendaByGuid(Sessao.RetornarCarrinhoId()),
                valorTotal = CarrinhoDAO.TotalCarrinho(Sessao.RetornarCarrinhoId())
            };

                PedidoDAO.SalvarVenda(pedido);
                Sessao.CriarSessao();
                return RedirectToAction("Index", "Pedido");
        }
        #endregion
    }
}