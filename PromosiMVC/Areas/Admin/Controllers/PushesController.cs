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
    public class PushesController : BaseController
    {

        // GET: Admin/Pushes
        public async Task<ActionResult> Index()
        {
            var pushSet = db.PushSet.Include(p => p.Company);
            return View(await pushSet.ToListAsync());
        }

        // GET: Admin/Pushes/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Push push = await db.PushSet.FindAsync(id);
            if (push == null)
            {
                return HttpNotFound();
            }
            return View(push);
        }

        // GET: Admin/Pushes/Create
        public ActionResult Create()
        {
            var t = db.CompanySet.OrderBy(x => x.Name);
            ViewBag.CompanyId = new SelectList(t, "Id", "Name");
            var tp = new Push();
            tp.DateBegin = DateTime.Now;
            tp.DateEnd = DateTime.Now.AddHours(32);
            tp.Available = true;
            return View(tp);
        }

        // POST: Admin/Pushes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Text,Description,DateBegin,DateEnd,Available,CompanyId")] Push push)
        {
            if (ModelState.IsValid)
            {
                db.PushSet.Add(push);
                await db.SaveChangesAsync();

                var users = from u in db.UserSet
                             join f in db.FollowingsSet
                             on u.Id equals f.UserId
                             where (f.CompanyId == push.CompanyId)
                             select u;
                foreach (var item in users)
                {
                    var p = new Pushes();
                    p.Checked = false;
                    p.Push = push;
                    p.User = item;
                    db.PushesSet.Add(p);
                }
                await db.SaveChangesAsync();
                //TODO send gcm push SendGCMPush(push);
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.CompanySet, "Id", "Name", push.CompanyId);
            return View(push);
        }

        // GET: Admin/Pushes/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Push push = await db.PushSet.FindAsync(id);
            if (push == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.CompanySet, "Id", "Name", push.CompanyId);
            return View(push);
        }

        // POST: Admin/Pushes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Text,Description,DateBegin,DateEnd,Available,CompanyId")] Push push)
        {
            if (ModelState.IsValid)
            {
                db.Entry(push).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.CompanySet, "Id", "Name", push.CompanyId);
            return View(push);
        }

        // GET: Admin/Pushes/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Push push = await db.PushSet.FindAsync(id);
            if (push == null)
            {
                return HttpNotFound();
            }
            return View(push);
        }

        // POST: Admin/Pushes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Push push = await db.PushSet.FindAsync(id);
            db.PushSet.Remove(push);
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
