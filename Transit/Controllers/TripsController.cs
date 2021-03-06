﻿using System;
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
    public class TripsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Trips
        public async Task<ActionResult> Index()
        {
            var trips = db.Trips.Include(t => t.accessibleCode).Include(t => t.bikeCode).Include(t => t.route).Include(t => t.service);
            return View(await trips.ToListAsync());
        }

        // GET: Trips/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = await db.Trips.FindAsync(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // GET: Trips/Create
        public ActionResult Create()
        {
            ViewBag.accessibleCodeId = new SelectList(db.AccessibleCodes, "id", "label");
            ViewBag.bikeCodeId = new SelectList(db.BikeCodes, "id", "label");
            ViewBag.routeId = new SelectList(db.Routes, "id", "label");
            ViewBag.serviceId = new SelectList(db.Services, "id", "id");
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,serviceId,routeId,label,direction,blockId,shapeId,accessibleCodeId,bikeCodeId")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Trips.Add(trip);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.accessibleCodeId = new SelectList(db.AccessibleCodes, "id", "label", trip.accessibleCodeId);
            ViewBag.bikeCodeId = new SelectList(db.BikeCodes, "id", "label", trip.bikeCodeId);
            ViewBag.routeId = new SelectList(db.Routes, "id", "label", trip.routeId);
            ViewBag.serviceId = new SelectList(db.Services, "id", "id", trip.serviceId);
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = await db.Trips.FindAsync(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            ViewBag.accessibleCodeId = new SelectList(db.AccessibleCodes, "id", "label", trip.accessibleCodeId);
            ViewBag.bikeCodeId = new SelectList(db.BikeCodes, "id", "label", trip.bikeCodeId);
            ViewBag.routeId = new SelectList(db.Routes, "id", "label", trip.routeId);
            ViewBag.serviceId = new SelectList(db.Services, "id", "id", trip.serviceId);
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,serviceId,routeId,label,direction,blockId,shapeId,accessibleCodeId,bikeCodeId")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trip).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.accessibleCodeId = new SelectList(db.AccessibleCodes, "id", "label", trip.accessibleCodeId);
            ViewBag.bikeCodeId = new SelectList(db.BikeCodes, "id", "label", trip.bikeCodeId);
            ViewBag.routeId = new SelectList(db.Routes, "id", "label", trip.routeId);
            ViewBag.serviceId = new SelectList(db.Services, "id", "id", trip.serviceId);
            return View(trip);
        }

        // GET: Trips/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = await db.Trips.FindAsync(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Trip trip = await db.Trips.FindAsync(id);
            db.Trips.Remove(trip);
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
