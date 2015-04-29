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
    public class BikeCodesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BikeCodes
        public async Task<ActionResult> Index()
        {
            return View(await db.BikeCodes.ToListAsync());
        }

        // GET: BikeCodes/Details/5
        public async Task<ActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BikeCode bikeCode = await db.BikeCodes.FindAsync(id);
            if (bikeCode == null)
            {
                return HttpNotFound();
            }
            return View(bikeCode);
        }

        // GET: BikeCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BikeCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,label,description")] BikeCode bikeCode)
        {
            if (ModelState.IsValid)
            {
                db.BikeCodes.Add(bikeCode);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bikeCode);
        }

        // GET: BikeCodes/Edit/5
        public async Task<ActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BikeCode bikeCode = await db.BikeCodes.FindAsync(id);
            if (bikeCode == null)
            {
                return HttpNotFound();
            }
            return View(bikeCode);
        }

        // POST: BikeCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,label,description")] BikeCode bikeCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bikeCode).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bikeCode);
        }

        // GET: BikeCodes/Delete/5
        public async Task<ActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BikeCode bikeCode = await db.BikeCodes.FindAsync(id);
            if (bikeCode == null)
            {
                return HttpNotFound();
            }
            return View(bikeCode);
        }

        // POST: BikeCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(byte id)
        {
            BikeCode bikeCode = await db.BikeCodes.FindAsync(id);
            db.BikeCodes.Remove(bikeCode);
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
