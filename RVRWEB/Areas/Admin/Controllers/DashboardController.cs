using RVRWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data;
using System.Data.Entity;

namespace RVRWEB.Areas.Admin.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            //var profileModel = db.Users.First(e => e.UserName == WebSecurity.CurrentUserName);
            var tarefamodel = db.Tarefa.ToList().Where(e => e._ApplicationUser.Id == User.Identity.GetUserId() & e.Feito == false);
            var financeiromodel = db.Financeiro.ToList().Where(e => e._ApplicationUser.Id == User.Identity.GetUserId() );

            var AdminViewModelObject = new AdminViewModel
            {
                TarefaObject = tarefamodel,
                FinanceiroObject = financeiromodel
            };

            return View(AdminViewModelObject);
        }

        public ActionResult teste()
        {
            var teste = User.Identity.GetUserId();

            return View(teste);
        }
    }
}