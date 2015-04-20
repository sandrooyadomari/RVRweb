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
    public class TipoPgtsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<ApplicationUser> Manager;

        // GET: Admin/TipoPgts
        public ActionResult Index()
        {
            var model = db.TipoPgt.ToList().Where(e => e._ApplicationUser.Id == User.Identity.GetUserId());

            return View(model);
        }

        // GET: Admin/TipoPgts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPgt tipoPgt = db.TipoPgt.Find(id);
            if (tipoPgt == null)
            {
                return HttpNotFound();
            }
            return View(tipoPgt);
        }

        // GET: Admin/TipoPgts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TipoPgts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoPgtID,Nome")] TipoPgt tipoPgt)
        {
            Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var currentUser = Manager.FindById(User.Identity.GetUserId());

            if (ModelState.IsValid)
            {
                tipoPgt._ApplicationUser = currentUser;
                db.TipoPgt.Add(tipoPgt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPgt);
        }

        // GET: Admin/TipoPgts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPgt tipoPgt = db.TipoPgt.Find(id);
            if (tipoPgt == null)
            {
                return HttpNotFound();
            }
            return View(tipoPgt);
        }

        // POST: Admin/TipoPgts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoPgtID,Nome")] TipoPgt tipoPgt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPgt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPgt);
        }

        // GET: Admin/TipoPgts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPgt tipoPgt = db.TipoPgt.Find(id);
            if (tipoPgt == null)
            {
                return HttpNotFound();
            }
            return View(tipoPgt);
        }

        // POST: Admin/TipoPgts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPgt tipoPgt = db.TipoPgt.Find(id);
            db.TipoPgt.Remove(tipoPgt);
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
