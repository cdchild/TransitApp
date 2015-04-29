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
    public class ServiceDatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ServiceDates
        public async Task<ActionResult> Index()
        {
            var serviceDates = db.ServiceDates.Include(s => s.service);
            return View(await serviceDates.ToListAsync());
        }

        // GET: ServiceDates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceDate serviceDate = await db.ServiceDates.FindAsync(id);
            if (serviceDate == null)
            {
                return HttpNotFound();
            }
            return View(serviceDate);
        }

        // GET: ServiceDates/Create
        public ActionResult Create()
        {
            ViewBag.serviceId = new SelectList(db.Services, "id", "id");
            return View();
        }

        // POST: ServiceDates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,serviceId,date,exceptionNum")] ServiceDate serviceDate)
        {
            if (ModelState.IsValid)
            {
                db.ServiceDates.Add(serviceDate);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.serviceId = new SelectList(db.Services, "id", "id", serviceDate.serviceId);
            return View(serviceDate);
        }

        // GET: ServiceDates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceDate serviceDate = await db.ServiceDates.FindAsync(id);
            if (serviceDate == null)
            {
                return HttpNotFound();
            }
            ViewBag.serviceId = new SelectList(db.Services, "id", "id", serviceDate.serviceId);
            return View(serviceDate);
        }

        // POST: ServiceDates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,serviceId,date,exceptionNum")] ServiceDate serviceDate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceDate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.serviceId = new SelectList(db.Services, "id", "id", serviceDate.serviceId);
            return View(serviceDate);
        }

        // GET: ServiceDates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceDate serviceDate = await db.ServiceDates.FindAsync(id);
            if (serviceDate == null)
            {
                return HttpNotFound();
            }
            return View(serviceDate);
        }

        // POST: ServiceDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ServiceDate serviceDate = await db.ServiceDates.FindAsync(id);
            db.ServiceDates.Remove(serviceDate);
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
