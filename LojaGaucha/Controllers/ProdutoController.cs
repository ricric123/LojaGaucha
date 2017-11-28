using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LojaGaucha.Models;
using LojaGaucha.DAL;

namespace LojaGaucha.Controllers
{
    public class ProdutoController : Controller
    {
        private Entities db = new Entities();


        // GET: Produto
        public ActionResult HomeCliente()
        {
            var produtos = db.Produtos.Include(p => p.Categoria);
            return View(produtos.ToList());
        }
        public ActionResult Estoque()
        {
            var produtos = db.Produtos.Include(p => p.Categoria);
            return View(produtos.ToList());
        }
        // GET: Produto
        public ActionResult Index()
        {
            var produtos = db.Produtos.Include(p => p.Categoria);
            return View(produtos.ToList());
        }

        // GET: Produto/Details/5
        public ActionResult Details(int? idProduto)
        {
            if (idProduto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(idProduto);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
        //Session["IdPessoa"] = pessoa.PessoaId;
        // GET: Produto/Create
        public ActionResult Create()
        {
           
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNome");
            return View();
        }
        // GET: Produto/Edit/5
        public ActionResult EditQuantidade(int? id)
        {
            Session["IdProduto"] = id;
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNome" );
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoId,ProdutoNome,ProdutoDescricao,ProdutoPreco,ProdutoQuantidade,ProdutoImagem,CategoriaId,Peso")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                //ver view

                ProdutoDAO.CadastrarProduto(produto);
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNome", produto.CategoriaId);
            return View(produto);
        }


        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoId,ProdutoNome,ProdutoDescricao,ProdutoPreco,ProdutoQuantidade,ProdutoImagem,CategoriaId,Peso")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNome", produto.CategoriaId);
            return View(produto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuantidade([Bind(Include = "ProdutoId,ProdutoQuantidade")] Produto produto)
        {
            produto.ProdutoId = Convert.ToInt32(Session["IdProduto"]);
            ProdutoDAO.AumentarQuantidadeDeProdutoAoAdicionaloAoCarrinho(produto.ProdutoId, produto.ProdutoQuantidade);
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNome", produto.CategoriaId);
            return View();
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
