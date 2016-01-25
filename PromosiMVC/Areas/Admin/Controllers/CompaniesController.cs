using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PromosiMVC;
using PromosiMVC.Bases;

namespace PromosiMVC.Areas.Admin.Controllers
{
    public class CompaniesController : BaseController
    {

        // GET: Admin/Companies
        public async Task<ActionResult> Index()
        {
            var companySet = db.CompanySet.Include(c => c.Branch).Include(c => c.City);
            return View(await companySet.ToListAsync());
        }

        // GET: Admin/Companies/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = await db.CompanySet.FindAsync(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Admin/Companies/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.BranchSet, "Id", "Name");
            ViewBag.CityId = new SelectList(db.CitySet, "Id", "Name");
            return View();
        }

        // POST: Admin/Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,NIP,Adress,Phonenumber,Email,Password,ChannelName,BranchId,CityId")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.CompanySet.Add(company);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.BranchSet, "Id", "Name", company.BranchId);
            ViewBag.CityId = new SelectList(db.CitySet, "Id", "Name", company.CityId);
            return View(company);
        }

        // GET: Admin/Companies/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = await db.CompanySet.FindAsync(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.BranchSet, "Id", "Name", company.BranchId);
            ViewBag.CityId = new SelectList(db.CitySet, "Id", "Name", company.CityId);
            return View(company);
        }

        // POST: Admin/Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,NIP,Adress,Phonenumber,Email,Password,ChannelName,BranchId,CityId")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.BranchSet, "Id", "Name", company.BranchId);
            ViewBag.CityId = new SelectList(db.CitySet, "Id", "Name", company.CityId);
            return View(company);
        }

        // GET: Admin/Companies/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = await db.CompanySet.FindAsync(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Admin/Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Company company = await db.CompanySet.FindAsync(id);
            db.CompanySet.Remove(company);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
