using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromosiMVC.Bases
{
    public abstract class BaseController : Controller
    {
        public BaseController()
        {
            db = new PromosiDBModelContainer();
        }

        protected PromosiDBModelContainer db { get; set; }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}