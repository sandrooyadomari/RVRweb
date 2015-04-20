using System.Web.Mvc;

namespace RVRWEB.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                ////// Valores Default quando é criado a "AREA"
                //"Admin_default",
                //"Admin/{controller}/{action}/{id}",
                //new { action = "Index", id = UrlParameter.Optional }

                // Inserido o controler/view default para a "AREA"
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}