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
    public class HomeController : Controller
    {
        private static string guid = Sessao.RetornarCarrinhoId();

        public ActionResult Index()
        {
            try
            {
                return View(ProdutoDAO.ReturnProdutos());
            }
            catch (Exception ex)
            {

                return View(ex);
            }
        }

        #region Adicionar ao carrinho
        public ActionResult AdicionarAoCarrinho(int id)
        {
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            string CarrinhoId = Sessao.RetornarCarrinhoId();
            Carrinho item = CarrinhoDAO.BuscarPeloGuidCar(CarrinhoId);

            if (item != null)
            {
                Carrinho carrinho = CarrinhoDAO.BuscarByProduto(produto.idProduto, CarrinhoId);

                if (carrinho != null)
                {
                    if (carrinho.Produto.idProduto == produto.idProduto)
                    {
                        bool add = true;
                        if(carrinho.quantidade < 10)
                        CarrinhoDAO.AlteraQuantidade(carrinho, add);
                    }
                }
                else if (item.carrinhoGuid == null)
                {
                    carrinho = new Carrinho
                    {
                        Produto = produto,
                        quantidade = 1,
                        valor = produto.preco,
                        carrinhoGuid = Sessao.RetornarCarrinhoId()
                    };
                    CarrinhoDAO.CadastrarItem(carrinho);

                }
                else
                {
                     carrinho = new Carrinho
                    {
                        Produto = produto,
                        quantidade = 1,
                        valor = produto.preco,
                        carrinhoGuid = Sessao.RetornarCarrinhoId()
                    };
                    CarrinhoDAO.CadastrarItem(carrinho);

                }
            }
            else
            {
                Carrinho carrinho = new Carrinho
                {
                    Produto = produto,
                    quantidade = 1,
                    valor = produto.preco,
                    carrinhoGuid = Sessao.RetornarCarrinhoId()
                };
                CarrinhoDAO.CadastrarItem(carrinho);

            }

            ValorCar();
            return RedirectToAction("CarrinhoCompras", "Home");
        }
        #endregion


        #region Valor Total no Carrinho
        public void ValorCar()
        {
            string CarrinhoId = Sessao.RetornarCarrinhoId();
            TempData["ValorTotal"] = CarrinhoDAO.TotalCarrinho(CarrinhoId);
        }
        #endregion

        #region Listar produtos no Carrinho -> Carrinho de Compras
        public ActionResult CarrinhoCompras()
        {
            ValorCar();
            return View(CarrinhoDAO.ListarVendaByGuid(Sessao.RetornarCarrinhoId()));
        }
        #endregion

        #region Remover do carrinho

        public ActionResult RemoverQtde(int id)
        {
            string CarrinhoId = Sessao.RetornarCarrinhoId();
            Carrinho item = CarrinhoDAO.BuscarPeloGuidCar(CarrinhoId);
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            Carrinho carrinho = CarrinhoDAO.BuscarByProduto(produto.idProduto, CarrinhoId);
            bool remove = false;

            if (carrinho.quantidade != 1)
            {
                CarrinhoDAO.AlteraQuantidade(carrinho, remove);
            }
            else
            {
                CarrinhoDAO.AlteraQuantidade(carrinho, remove);
                CarrinhoDAO.RemoverProdutoCarrinho(carrinho.idCarrinho);
            }
            ValorCar();
            return RedirectToAction("CarrinhoCompras", "Home");
        }
        #endregion

        #region Adicionar Itens no Carrinho
        public ActionResult AddQtde(int id)
        {
            string CarrinhoId = Sessao.RetornarCarrinhoId();
            Carrinho item = CarrinhoDAO.BuscarPeloGuidCar(CarrinhoId);
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            Carrinho carrinho = CarrinhoDAO.BuscarByProduto(produto.idProduto, CarrinhoId);
            bool add = true;
            CarrinhoDAO.AlteraQuantidade(carrinho, add);
            ValorCar();
            return RedirectToAction("CarrinhoCompras", "Home");
        }
        #endregion
    }
}