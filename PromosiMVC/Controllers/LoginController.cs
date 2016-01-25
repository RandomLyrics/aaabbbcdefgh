using PromosiMVC.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromosiMVC.Controllers
{
    public class LoginController : BaseController
    {
        // GET: User
        public ActionResult Index(string tok)
        {
            if (tok == null)
                return HttpNotFound();

            var user = db.UserSet.Where(x => x.DeviceToken.Equals(tok)).ToList()[0];
            if (user == null)
                return HttpNotFound();

            return RedirectToAction("Index", "User", new { userId = user.Id });
            
        }
    }
}