using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RVRWEB.Models
{
    public class MyInitialize :
        //System.Data.Entity.CreateDatabaseIfNotExists<ApplicationDbContext>
        //System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
        System.Data.Entity.DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //var tarefa_seed = new List<Tarefa>
            //{
            //    new Tarefa{ Titulo="admin", Feito=true},
            //    new Tarefa{ Titulo="add", Feito=true}
            //};
            //tarefa_seed.ForEach(s => context.Tarefa.Add(s));
            //context.SaveChanges();

            //var usuario_seed = new List<ApplicationUser>
            //{
            //    new ApplicationUser{ UserName="admin@admin.com", PasswordHash="Rr080187++", Email="admin@admin.com", SecurityStamp = Guid.NewGuid().ToString() },
            //    new ApplicationUser{ UserName="add@add.com", Email="add@add.com" }
            //};
            //usuario_seed.ForEach(s => context.Users.Add(s));
            //context.SaveChanges();
        


        var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

        string name = "admin@admin.com";
        string password = "Rr080187++";
        string test = "Admin";

        //Create Role Test and User Test
        RoleManager.Create(new IdentityRole(test));
        UserManager.Create(new ApplicationUser() { UserName = test });

        //Create Role Admin if it does not exist
        if (!RoleManager.RoleExists(name))
        {
            var roleresult = RoleManager.Create(new IdentityRole(name));
        }

        //Create User=Admin with password=123456
        var user = new ApplicationUser();
        user.UserName = name;
        var adminresult = UserManager.Create(user, password);

        //Add User Admin to Role Admin
        if (adminresult.Succeeded)
        {
            var result = UserManager.AddToRole(user.Id, name);
        }
        base.Seed(context);
        context.SaveChanges();



        var tarefa_seed = new List<Tarefa>
            {
                new Tarefa{_ApplicationUser=user, Titulo="admin", Feito=true},
                new Tarefa{_ApplicationUser=user, Titulo="admin 2", Feito=true}
            };

        tarefa_seed.ForEach(s => context.Tarefa.Add(s));
        context.SaveChanges();

        var tipopgt_seed = new List<TipoPgt>
            {
                new TipoPgt{ Nome="Crédito", _ApplicationUser=user},
                new TipoPgt{ Nome="Débito", _ApplicationUser=user},
                new TipoPgt{ Nome="Cash", _ApplicationUser=user}
            };

        tipopgt_seed.ForEach(s => context.TipoPgt.Add(s));
        context.SaveChanges();

        var financeiro_seed = new List<Financeiro>
            {
                new Financeiro{_ApplicationUser=user, Dia=DateTime.Now, Comprovante="Net", Descricao="Internet", Valor=100, TipoPgt=tipopgt_seed[0]}
            };

        financeiro_seed.ForEach(s => context.Financeiro.Add(s));
        context.SaveChanges();


        //    var tipopgt_seed = new IList<TipoPgt>
        //    {
        //        new TipoPgt{Financeiro=financeiro_seed, Nome="TipoPgt 1"}
        //    };
        //tipopgt_seed.ForEach(s => context.TipoPgt.Add(s));
        //context.SaveChanges();
        }
    }
}