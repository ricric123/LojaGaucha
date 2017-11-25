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
using System.Web.Security;

namespace LojaGaucha.Controllers
{
    public class PessoaController : Controller
    {
        private Entities db = new Entities();

        // GET: Pessoa
        public ActionResult Index()
        {
            return View(db.Pessoas.ToList());
        }


        // GET: Pessoa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }
      public ActionResult HomeFuncionario()
        {
            return View();
        }

        // POST: Pessoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PessoaId,PessoaNome,PessoaEmail,ClienteSenha,ClienteCPF,ClienteTelefone,PessoaNivel,ConfimacaoSenha")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoa.PessoaNivel = 1;
                PessoaDAO.CadastrarPessoa(pessoa);
                return RedirectToAction("Login");
            }

            return View(pessoa);
        }



        public ActionResult Login()
        {



            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "PessoaEmail, ClienteSenha")]Pessoa pessoa)
        {
            if (PessoaDAO.BuscarPessoaPorEmailSenha(pessoa) != null)
            {
                pessoa = PessoaDAO.BuscarPessoaPorEmailSenha(pessoa);
                if (pessoa.PessoaNivel == 1)
                {
                    //Cria uma sessao onde fica salvo o IdDaPessoa
                    Session["IdPessoa"] = pessoa.PessoaId;
                    FormsAuthentication.SetAuthCookie(pessoa.PessoaEmail, false);
                    return RedirectToAction("HomeCliente", "Produto");
                }else
                {
                    Session["IdPessoa"] = pessoa.PessoaId;
                    FormsAuthentication.SetAuthCookie(pessoa.PessoaEmail, false);
                    return RedirectToAction("HomeFuncionario", "Pessoa");
                }
            }
            else
            {
                ModelState.AddModelError("", "E-mail ou senha não coincidem");
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();

           // var idPessoa = int.Parse(Session["IdPessoa"].ToString());


            return View();
        }





        // GET: Pessoa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PessoaId,PessoaNome,PessoaEmail,ClienteSenha,ClienteCPF,ClienteTelefone,PessoaNivel,ConfimacaoSenha")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoa);
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
