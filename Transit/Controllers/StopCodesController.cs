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
    public class StopCodesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StopCodes
        public async Task<ActionResult> Index()
        {
            return View(await db.StopCodes.ToListAsync());
        }

        // GET: StopCodes/Details/5
        public async Task<ActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StopCode stopCode = await db.StopCodes.FindAsync(id);
            if (stopCode == null)
            {
                return HttpNotFound();
            }
            return View(stopCode);
        }

        // GET: StopCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StopCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,label,description")] StopCode stopCode)
        {
            if (ModelState.IsValid)
            {
                db.StopCodes.Add(stopCode);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(stopCode);
        }

        // GET: StopCodes/Edit/5
        public async Task<ActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StopCode stopCode = await db.StopCodes.FindAsync(id);
            if (stopCode == null)
            {
                return HttpNotFound();
            }
            return View(stopCode);
        }

        // POST: StopCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,label,description")] StopCode stopCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stopCode).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(stopCode);
        }

        // GET: StopCodes/Delete/5
        public async Task<ActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StopCode stopCode = await db.StopCodes.FindAsync(id);
            if (stopCode == null)
            {
                return HttpNotFound();
            }
            return View(stopCode);
        }

        // POST: StopCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(byte id)
        {
            StopCode stopCode = await db.StopCodes.FindAsync(id);
            db.StopCodes.Remove(stopCode);
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
