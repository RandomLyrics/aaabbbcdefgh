using System.Web.Mvc;

namespace PromosiMVC.Areas.Stats
{
    public class StatsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Stats";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Login",
                "Company/Login/{nip}",
                new { controller = "Company", action = "Login", nip ="" }
               // new { nip = @"\s" }
            );
        }
    }
}