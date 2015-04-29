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
    public class StopsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stops
        public async Task<ActionResult> Index()
        {
            var stops = db.Stops.Include(s => s.accessibleCode);
            return View(await stops.ToListAsync());
        }

        // GET: Stops/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stop stop = await db.Stops.FindAsync(id);
            if (stop == null)
            {
                return HttpNotFound();
            }
            return View(stop);
        }

        // GET: Stops/Create
        public ActionResult Create()
        {
            ViewBag.accessibleCodeId = new SelectList(db.AccessibleCodes, "id", "label");
            return View();
        }

        // POST: Stops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,code,name,description,latitude,longitude,zoneId,stopUrl,isConsideredStation,parentStation,timezone,accessibleCodeId")] Stop stop)
        {
            if (ModelState.IsValid)
            {
                db.Stops.Add(stop);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.accessibleCodeId = new SelectList(db.AccessibleCodes, "id", "label", stop.accessibleCodeId);
            return View(stop);
        }

        // GET: Stops/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stop stop = await db.Stops.FindAsync(id);
            if (stop == null)
            {
                return HttpNotFound();
            }
            ViewBag.accessibleCodeId = new SelectList(db.AccessibleCodes, "id", "label", stop.accessibleCodeId);
            return View(stop);
        }

        // POST: Stops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,code,name,description,latitude,longitude,zoneId,stopUrl,isConsideredStation,parentStation,timezone,accessibleCodeId")] Stop stop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stop).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.accessibleCodeId = new SelectList(db.AccessibleCodes, "id", "label", stop.accessibleCodeId);
            return View(stop);
        }

        // GET: Stops/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stop stop = await db.Stops.FindAsync(id);
            if (stop == null)
            {
                return HttpNotFound();
            }
            return View(stop);
        }

        // POST: Stops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Stop stop = await db.Stops.FindAsync(id);
            db.Stops.Remove(stop);
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
