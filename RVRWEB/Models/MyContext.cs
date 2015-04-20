using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RVRWEB.Models
{
    //public class MyContext : IdentityDbContext<ApplicationUser>
    //{
    //    public MyContext()
    //        : base("DefaultConnection", throwIfV1Schema: false)
    //    {
    //        //Database.SetInitializer<MyContext>(new DropCreateDatabaseAlways<MyContext>());
    //        Database.SetInitializer<MyContext>(new DropCreateDatabaseIfModelChanges<MyContext>());
    //    }

    //    public static MyContext Create()
    //    {
            
    //        return new MyContext();
    //    }

    //    public DbSet<Tarefa> Tarefas { get; set; }

    //}

    public class MyContext : IdentityDbContext<ApplicationUser>
    {
        public MyContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<MyContext>(new DropCreateDatabaseAlways<MyContext>());
            //Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public static MyContext Create()
        {
            return new MyContext();
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }

}