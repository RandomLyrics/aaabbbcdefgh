﻿using System.Web.Mvc;

namespace PromosiMVC.Areas.User
{
    public class UserAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "User";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "User_default",
                "{controller}/{id}/{action}",
                new { controller = "User", action = "Index", id = UrlParameter.Optional },
                new { id = @"\d+" }
            );
        }
    }
}