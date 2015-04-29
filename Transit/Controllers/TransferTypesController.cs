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
    public class TransferTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TransferTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.TransferTypes.ToListAsync());
        }

        // GET: TransferTypes/Details/5
        public async Task<ActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransferType transferType = await db.TransferTypes.FindAsync(id);
            if (transferType == null)
            {
                return HttpNotFound();
            }
            return View(transferType);
        }

        // GET: TransferTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransferTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,label,description")] TransferType transferType)
        {
            if (ModelState.IsValid)
            {
                db.TransferTypes.Add(transferType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(transferType);
        }

        // GET: TransferTypes/Edit/5
        public async Task<ActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransferType transferType = await db.TransferTypes.FindAsync(id);
            if (transferType == null)
            {
                return HttpNotFound();
            }
            return View(transferType);
        }

        // POST: TransferTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,label,description")] TransferType transferType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transferType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(transferType);
        }

        // GET: TransferTypes/Delete/5
        public async Task<ActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransferType transferType = await db.TransferTypes.FindAsync(id);
            if (transferType == null)
            {
                return HttpNotFound();
            }
            return View(transferType);
        }

        // POST: TransferTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(byte id)
        {
            TransferType transferType = await db.TransferTypes.FindAsync(id);
            db.TransferTypes.Remove(transferType);
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
