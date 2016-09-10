using Csystems.Aula02.Dominio.Entidades;
using Csystems.Aula02.Persistencia.Dados.SQLServer;
using Csystems.Aula02.Repositorio.Classes;
using Csystems.Aula02.Web.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Csystems.Aula02.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private PdvDbContexto _contex;
        private RepositorioProdutos _repo;
        private RepositorioCategorias _categorias;

        public ProdutosController()
        {
            _contex = new PdvDbContexto();
            _repo = new RepositorioProdutos(_contex);
            _categorias = new RepositorioCategorias(_contex);

            ViewBag.Categorias = _categorias.ObterTodos().Select(c => new { c.CategoriaId, c.Descricao });
        }
        // GET: Produtos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista()
        {
            var produtos = _repo.ObterTodos().Select(x => new ProdutoViewModel { ProdutoId = x.ProdutoId, Categoria = x.Categoria, CategoriaId = x.CategoriaId, Descricao = x.Descricao } );
            return View(produtos);
        }

        public ActionResult Incluir()
        {
            
            var viewModel = new ProdutoViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Incluir(ProdutoViewModel produto)
        {

            Produto dados = new Produto()
            {
                Descricao = produto.Descricao,
                Categoria = produto.Categoria,
                CategoriaId = produto.CategoriaId
            };

            _repo.Incluir(dados);
            _contex.Commit();

            return RedirectToAction("Lista");
        }

        public ActionResult Alterar(int Id)
        {
            var produto = _repo.Obter(p => p.ProdutoId == Id);

            ProdutoViewModel prodView = new ProdutoViewModel()
            {
                ProdutoId = produto.ProdutoId,
                Categoria = produto.Categoria,
                CategoriaId = produto.CategoriaId,
                Descricao = produto.Descricao
            };

            return View(prodView);
        }

    }
}