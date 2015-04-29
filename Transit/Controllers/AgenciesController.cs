using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Transit.Models;

namespace Transit.Controllers
{
    public class AgenciesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Agencies
        public async Task<ActionResult> Index()
        {
            var agencies = db.Agencies.Include(a => a.timeZoneObj);
            return View(await agencies.ToListAsync());
        }

        // GET: Agencies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agency agency = await db.Agencies.FindAsync(id);
            if (agency == null)
            {
                return HttpNotFound();
            }
            return View(agency);
        }

        // GET: Agencies/Create
        public ActionResult Create()
        {
            ViewBag.timeZoneObjId = new SelectList(db.TimeZones, "id", "countryCode");
            return View();
        }

        // POST: Agencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name,url,timeZone,timeZoneObjId,language,phone,fareUrl")] Agency agency)
        {
            if (ModelState.IsValid)
            {
                db.Agencies.Add(agency);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.timeZoneObjId = new SelectList(db.TimeZones, "id", "countryCode", agency.timeZoneObjId);
            return View(agency);
        }

        // GET: Agencies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agency agency = await db.Agencies.FindAsync(id);
            if (agency == null)
            {
                return HttpNotFound();
            }
            ViewBag.timeZoneObjId = new SelectList(db.TimeZones, "id", "countryCode", agency.timeZoneObjId);
            return View(agency);
        }

        // POST: Agencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,url,timeZone,timeZoneObjId,language,phone,fareUrl")] Agency agency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agency).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.timeZoneObjId = new SelectList(db.TimeZones, "id", "countryCode", agency.timeZoneObjId);
            return View(agency);
        }

        // GET: Agencies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agency agency = await db.Agencies.FindAsync(id);
            if (agency == null)
            {
                return HttpNotFound();
            }
            return View(agency);
        }

        // POST: Agencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Agency agency = await db.Agencies.FindAsync(id);
            db.Agencies.Remove(agency);
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
