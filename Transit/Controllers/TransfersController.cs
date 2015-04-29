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
    public class TransfersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transfers
        public async Task<ActionResult> Index()
        {
            var transfers = db.Transfers.Include(t => t.fromStop).Include(t => t.toStop).Include(t => t.type);
            return View(await transfers.ToListAsync());
        }

        // GET: Transfers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfer transfer = await db.Transfers.FindAsync(id);
            if (transfer == null)
            {
                return HttpNotFound();
            }
            return View(transfer);
        }

        // GET: Transfers/Create
        public ActionResult Create()
        {
            ViewBag.fromStopId = new SelectList(db.Stops, "id", "code");
            ViewBag.toStopId = new SelectList(db.Stops, "id", "code");
            ViewBag.typeId = new SelectList(db.TransferTypes, "id", "label");
            return View();
        }

        // POST: Transfers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,fromStopId,toStopId,typeId")] Transfer transfer)
        {
            if (ModelState.IsValid)
            {
                db.Transfers.Add(transfer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.fromStopId = new SelectList(db.Stops, "id", "code", transfer.fromStopId);
            ViewBag.toStopId = new SelectList(db.Stops, "id", "code", transfer.toStopId);
            ViewBag.typeId = new SelectList(db.TransferTypes, "id", "label", transfer.typeId);
            return View(transfer);
        }

        // GET: Transfers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfer transfer = await db.Transfers.FindAsync(id);
            if (transfer == null)
            {
                return HttpNotFound();
            }
            ViewBag.fromStopId = new SelectList(db.Stops, "id", "code", transfer.fromStopId);
            ViewBag.toStopId = new SelectList(db.Stops, "id", "code", transfer.toStopId);
            ViewBag.typeId = new SelectList(db.TransferTypes, "id", "label", transfer.typeId);
            return View(transfer);
        }

        // POST: Transfers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,fromStopId,toStopId,typeId")] Transfer transfer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transfer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.fromStopId = new SelectList(db.Stops, "id", "code", transfer.fromStopId);
            ViewBag.toStopId = new SelectList(db.Stops, "id", "code", transfer.toStopId);
            ViewBag.typeId = new SelectList(db.TransferTypes, "id", "label", transfer.typeId);
            return View(transfer);
        }

        // GET: Transfers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfer transfer = await db.Transfers.FindAsync(id);
            if (transfer == null)
            {
                return HttpNotFound();
            }
            return View(transfer);
        }

        // POST: Transfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Transfer transfer = await db.Transfers.FindAsync(id);
            db.Transfers.Remove(transfer);
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
