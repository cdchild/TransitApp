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
    public class TripFrequenciesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TripFrequencies
        public async Task<ActionResult> Index()
        {
            var tripFrequencies = db.TripFrequencies.Include(t => t.trip);
            return View(await tripFrequencies.ToListAsync());
        }

        // GET: TripFrequencies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripFrequency tripFrequency = await db.TripFrequencies.FindAsync(id);
            if (tripFrequency == null)
            {
                return HttpNotFound();
            }
            return View(tripFrequency);
        }

        // GET: TripFrequencies/Create
        public ActionResult Create()
        {
            ViewBag.tripId = new SelectList(db.Trips, "id", "label");
            return View();
        }

        // POST: TripFrequencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,tripId,start,end,exactTime")] TripFrequency tripFrequency)
        {
            if (ModelState.IsValid)
            {
                db.TripFrequencies.Add(tripFrequency);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.tripId = new SelectList(db.Trips, "id", "label", tripFrequency.tripId);
            return View(tripFrequency);
        }

        // GET: TripFrequencies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripFrequency tripFrequency = await db.TripFrequencies.FindAsync(id);
            if (tripFrequency == null)
            {
                return HttpNotFound();
            }
            ViewBag.tripId = new SelectList(db.Trips, "id", "label", tripFrequency.tripId);
            return View(tripFrequency);
        }

        // POST: TripFrequencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,tripId,start,end,exactTime")] TripFrequency tripFrequency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tripFrequency).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.tripId = new SelectList(db.Trips, "id", "label", tripFrequency.tripId);
            return View(tripFrequency);
        }

        // GET: TripFrequencies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripFrequency tripFrequency = await db.TripFrequencies.FindAsync(id);
            if (tripFrequency == null)
            {
                return HttpNotFound();
            }
            return View(tripFrequency);
        }

        // POST: TripFrequencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TripFrequency tripFrequency = await db.TripFrequencies.FindAsync(id);
            db.TripFrequencies.Remove(tripFrequency);
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
