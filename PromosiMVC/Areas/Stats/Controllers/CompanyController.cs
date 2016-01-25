using PromosiMVC.Areas.Stats.Models;
using PromosiMVC.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PromosiMVC.Areas.Stats.Controllers
{
    public class CompanyController : BaseController
    {
        // GET: Stats/Company
        public ActionResult Login(string nip)
        {
            if (nip == null)
                return HttpNotFound();
            if (db.CompanySet.Where(x => x.NIP.Equals(nip)).ToList().Count <= 0)
                return HttpNotFound();
            var login = new Login();
            login.Nip = nip;
            return View(login);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Nip,Email,Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                var c = db.CompanySet.Where(x => x.Email.Equals(login.Email) && x.Password.Equals(login.Password) && x.NIP.Equals(login.Nip)).ToList();

                if (c.Count == 0)
                    return View("Login");
                var company = c[0];

                return this.Statistics(company);
            }

            return View("Login");
        }
        [NonAction]
        public ActionResult Statistics(Company company)
        {
            var stats = new Statistics();
            stats.Company = company;
            stats.Clients = company.Followings.Count();
            stats.Pushes = company.Push.Count;
            return View("Statistics", stats);
        }
    }
}