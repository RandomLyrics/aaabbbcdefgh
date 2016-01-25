using PromosiMVC.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PromosiMVC.Areas.User.Controllers
{
    public class UserController : BaseController
    {
        // GET: User/User
        public ActionResult Index(long id)
        {
            return View(db.UserSet.Find(id));
        }

        public ActionResult SearchForCompany(long id, string cname, string cityId, string branchId)
        {
            ViewBag.userId = id;
           
            ViewBag.CityId = new SelectList(db.CitySet, "Id", "Name");
            ViewBag.BranchId = new SelectList(db.BranchSet, "Id", "Name");

            var companies = from c in db.CompanySet
                            join f in db.FollowingsSet
                                on new { c.Id, UserId = id }
                                equals new { Id = f.CompanyId, f.UserId } into joins
                            from f in joins.DefaultIfEmpty()
                            where f.UserId == null
                            select c;

            var dd = companies.ToList();
            if (!String.IsNullOrWhiteSpace(cname))
            {
                companies = companies.Where(c => c.Name.Contains(cname));
            }
            if (!String.IsNullOrWhiteSpace(branchId))
            {
                var bid = Convert.ToInt64(branchId);
                companies = companies.Where(c => c.BranchId.Equals(bid));
            }
            if (!String.IsNullOrWhiteSpace(cityId))
            {
                var cid = Convert.ToInt64(cityId);
                companies = companies.Where(c => c.CityId.Equals(cid));
            }
            return View(companies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddCompany(long id, long cid)
        {
            var user = db.UserSet.Find(id);
            if ( !user.Followings.Any(x => x.CompanyId == cid))
            {
                var company = db.CompanySet.Find(cid);
                var follow = new Followings();
                follow.Company = company;
                follow.User =user;
                company.Followings.Add(follow);
                await db.SaveChangesAsync();
            }
           
            return RedirectToAction("Index", new { id = id });
        }
    }
}