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
    public class AccessibleCodesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AccessibleCodes
        public async Task<ActionResult> Index()
        {
            return View(await db.AccessibleCodes.ToListAsync());
        }

        // GET: AccessibleCodes/Details/5
        public async Task<ActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessibleCode accessibleCode = await db.AccessibleCodes.FindAsync(id);
            if (accessibleCode == null)
            {
                return HttpNotFound();
            }
            return View(accessibleCode);
        }

        // GET: AccessibleCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccessibleCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,label,description")] AccessibleCode accessibleCode)
        {
            if (ModelState.IsValid)
            {
                db.AccessibleCodes.Add(accessibleCode);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(accessibleCode);
        }

        // GET: AccessibleCodes/Edit/5
        public async Task<ActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessibleCode accessibleCode = await db.AccessibleCodes.FindAsync(id);
            if (accessibleCode == null)
            {
                return HttpNotFound();
            }
            return View(accessibleCode);
        }

        // POST: AccessibleCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,label,description")] AccessibleCode accessibleCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessibleCode).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(accessibleCode);
        }

        // GET: AccessibleCodes/Delete/5
        public async Task<ActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessibleCode accessibleCode = await db.AccessibleCodes.FindAsync(id);
            if (accessibleCode == null)
            {
                return HttpNotFound();
            }
            return View(accessibleCode);
        }

        // POST: AccessibleCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(byte id)
        {
            AccessibleCode accessibleCode = await db.AccessibleCodes.FindAsync(id);
            db.AccessibleCodes.Remove(accessibleCode);
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
