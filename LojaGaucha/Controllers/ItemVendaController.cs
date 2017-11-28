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
    public class ItemVendaController : Controller
    {
        private Entities db = new Entities();

        // GET: ItemVenda
        public ActionResult Index()
        {
            var itensVenda = db.ItensVenda.Include(i => i.ItemVendaProduto);
            return View(itensVenda.ToList());
        }
        // GET: ItemVenda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemVenda itemVenda = db.ItensVenda.Find(id);
            if (itemVenda == null)
            {
                return HttpNotFound();
            }
            return View(itemVenda);
        }
        public ActionResult Create(int idProduto)
        {

            idProduto = Convert.ToInt32(Request.QueryString["idProduto"]);
            ItemVendaDAO.AdicionarItemVenda(idProduto);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "ProdutoNome");
            return RedirectToAction("Index");
        }


        // POST: ItemVenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemVendaId,ProdutoId,ItemVendaPreco,ItemVendaQuantidade,IdCarrinho,DataDaAdicao")] ItemVenda itemVenda)
        {
            if (ModelState.IsValid)
            {
                db.ItensVenda.Add(itemVenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "ProdutoNome", itemVenda.ProdutoId);
            return View(itemVenda);
        }

        // GET: ItemVenda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemVenda itemVenda = db.ItensVenda.Find(id);
            if (itemVenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "ProdutoNome", itemVenda.ProdutoId);
            return View(itemVenda);
        }

        // POST: ItemVenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemVendaId,ProdutoId,ItemVendaPreco,ItemVendaQuantidade,IdCarrinho,DataDaAdicao")] ItemVenda itemVenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemVenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "ProdutoNome", itemVenda.ProdutoId);
            return View(itemVenda);
        }

        // GET: ItemVenda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemVenda itemVenda = db.ItensVenda.Find(id);
            if (itemVenda == null)
            {
                return HttpNotFound();
            }
            return View(itemVenda);
        }

        // POST: ItemVenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemVenda itemVenda = db.ItensVenda.Find(id);
            db.ItensVenda.Remove(itemVenda);
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
