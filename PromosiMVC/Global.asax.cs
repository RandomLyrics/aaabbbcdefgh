using PromosiMVC.App_Start;
using PromosiMVC.Test;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PromosiMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //ExtendedRazorViewEngine engine = new ExtendedRazorViewEngine();
            //engine.AddViewLocationFormat("~/MyThemes/{1}/{0}.cshtml");
            //ViewEngines.Engines.Add()


            CultureConfig.SetupCulture();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            //var gen = new DataGenerator(new PromosiDBModelContainer());
            //gen.Generate();
        }
    }
}
