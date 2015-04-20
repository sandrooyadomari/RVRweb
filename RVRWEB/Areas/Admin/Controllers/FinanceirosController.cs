using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RVRWEB.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RVRWEB.Areas.Admin.Controllers
{
    public class FinanceirosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<ApplicationUser> Manager;

        // GET: Admin/Financeiros
        public ActionResult Index()
        {
            var model = db.Financeiro.ToList().Where(e => e._ApplicationUser.Id == User.Identity.GetUserId());

            return View(model);
        }

        // GET: Admin/Financeiros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financeiro financeiro = db.Financeiro.Find(id);
            if (financeiro == null)
            {
                return HttpNotFound();
            }
            return View(financeiro);
        }

        // GET: Admin/Financeiros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Financeiros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FinanceiroID,Dia,Comprovante,Descricao,Valor,TipoPgt")] Financeiro financeiro)
        {
            Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var currentUser = Manager.FindById(User.Identity.GetUserId());

            if (ModelState.IsValid)
            {

                financeiro._ApplicationUser = currentUser;
                db.Financeiro.Add(financeiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(financeiro);
        }

        // GET: Admin/Financeiros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financeiro financeiro = db.Financeiro.Find(id);
            if (financeiro == null)
            {
                return HttpNotFound();
            }
            return View(financeiro);
        }

        // POST: Admin/Financeiros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FinanceiroID,Dia,Comprovante,Descricao,Valor")] Financeiro financeiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(financeiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(financeiro);
        }

        // GET: Admin/Financeiros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financeiro financeiro = db.Financeiro.Find(id);
            if (financeiro == null)
            {
                return HttpNotFound();
            }
            return View(financeiro);
        }

        // POST: Admin/Financeiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Financeiro financeiro = db.Financeiro.Find(id);
            db.Financeiro.Remove(financeiro);
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
