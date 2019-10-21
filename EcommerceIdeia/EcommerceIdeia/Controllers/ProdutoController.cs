using EcommerceIdeia.DAO;
using EcommerceIdeia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceIdeia.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return View(ProdutoDAO.ReturnProdutos());
        }

        #region Pag Cadastrar Produto
        public ActionResult CadastrarProduto()
        {
            return View();
        }
        #endregion

        #region Cadastrando Produto
        [HttpPost]
        public ActionResult CadastrarProduto([Bind(Include ="nomeProduto,preco")]Produto produto)
        {
         
            if (ModelState.IsValid)
            {
                if (ProdutoDAO.CadastrarProduto(produto))
                {
                    return RedirectToAction("Index", "Produto");
                }
                else
                {
                    ModelState.AddModelError("", "Produto já cadastrado");
                    return View(produto);
                }
            }
            else
            {
                return View(produto);
            }

        }
        #endregion
    }
}