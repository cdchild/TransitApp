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
    public class StopTimesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StopTimes
        public async Task<ActionResult> Index()
        {
            var stopTimes = db.StopTimes.Include(s => s.dropoffType).Include(s => s.pickupType).Include(s => s.stop).Include(s => s.trip);
            return View(await stopTimes.ToListAsync());
        }

        // GET: StopTimes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StopTime stopTime = await db.StopTimes.FindAsync(id);
            if (stopTime == null)
            {
                return HttpNotFound();
            }
            return View(stopTime);
        }

        // GET: StopTimes/Create
        public ActionResult Create()
        {
            ViewBag.dropoffTypeId = new SelectList(db.StopCodes, "id", "label");
            ViewBag.pickupTypeId = new SelectList(db.StopCodes, "id", "label");
            ViewBag.stopId = new SelectList(db.Stops, "id", "code");
            ViewBag.tripId = new SelectList(db.Trips, "id", "label");
            return View();
        }

        // POST: StopTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,tripId,stopId,arrival,departure,label,pickupTypeId,dropoffTypeId,shapeDistanceTraveled")] StopTime stopTime)
        {
            if (ModelState.IsValid)
            {
                db.StopTimes.Add(stopTime);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.dropoffTypeId = new SelectList(db.StopCodes, "id", "label", stopTime.dropoffTypeId);
            ViewBag.pickupTypeId = new SelectList(db.StopCodes, "id", "label", stopTime.pickupTypeId);
            ViewBag.stopId = new SelectList(db.Stops, "id", "code", stopTime.stopId);
            ViewBag.tripId = new SelectList(db.Trips, "id", "label", stopTime.tripId);
            return View(stopTime);
        }

        // GET: StopTimes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StopTime stopTime = await db.StopTimes.FindAsync(id);
            if (stopTime == null)
            {
                return HttpNotFound();
            }
            ViewBag.dropoffTypeId = new SelectList(db.StopCodes, "id", "label", stopTime.dropoffTypeId);
            ViewBag.pickupTypeId = new SelectList(db.StopCodes, "id", "label", stopTime.pickupTypeId);
            ViewBag.stopId = new SelectList(db.Stops, "id", "code", stopTime.stopId);
            ViewBag.tripId = new SelectList(db.Trips, "id", "label", stopTime.tripId);
            return View(stopTime);
        }

        // POST: StopTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,tripId,stopId,arrival,departure,label,pickupTypeId,dropoffTypeId,shapeDistanceTraveled")] StopTime stopTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stopTime).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.dropoffTypeId = new SelectList(db.StopCodes, "id", "label", stopTime.dropoffTypeId);
            ViewBag.pickupTypeId = new SelectList(db.StopCodes, "id", "label", stopTime.pickupTypeId);
            ViewBag.stopId = new SelectList(db.Stops, "id", "code", stopTime.stopId);
            ViewBag.tripId = new SelectList(db.Trips, "id", "label", stopTime.tripId);
            return View(stopTime);
        }

        // GET: StopTimes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StopTime stopTime = await db.StopTimes.FindAsync(id);
            if (stopTime == null)
            {
                return HttpNotFound();
            }
            return View(stopTime);
        }

        // POST: StopTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StopTime stopTime = await db.StopTimes.FindAsync(id);
            db.StopTimes.Remove(stopTime);
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
