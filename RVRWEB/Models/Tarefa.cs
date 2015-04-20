using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using RVRWEB.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RVRWEB.Models
{
    public class Tarefa
    {
        public int TarefaID { get; set; }
        public string Titulo { get; set; }
        public bool Feito { get; set; }
        public virtual ApplicationUser _ApplicationUser { get; set; }

        //public Tarefa()
        //{
        //    this._ApplicationUser = new ApplicationUser { HttpContext.Current.User.Identity.GetUserId() };
        //}
    }
}