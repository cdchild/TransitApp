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
    public class MySchedulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MySchedules
        public async Task<ActionResult> Index()
        {
			var userSetSchedules = db.UserSetSchedules
				.Include(u => u.routeLegs.Select(l => l.legStops))
				.Include(u => u.routeLegs.Select(l => l.route))
				.Where(u => u.user.UserName == User.Identity.Name);
            return View(await userSetSchedules.ToListAsync());
        }

        // GET: MySchedules/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			UserSetSchedule userSetSchedule = await db.UserSetSchedules
				.Include(u => u.routeLegs.Select(l => l.route))
				.Include(u => u.routeLegs.Select(l => l.legStops.Select(ls => ls.stop.stopTimes)))
				.FirstOrDefaultAsync(u => u.id == id);
            if (userSetSchedule == null)
            {
                return HttpNotFound();
            }
            return View(userSetSchedule);
        }

        // GET: MySchedules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MySchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "label,description,fromTime,toTime")] UserSetSchedule userSetSchedule)
        {
            if (ModelState.IsValid)
            {
                db.UserSetSchedules.Add(userSetSchedule);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userSetSchedule);
        }

        // GET: MySchedules/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSetSchedule userSetSchedule = await db.UserSetSchedules.FindAsync(id);
            if (userSetSchedule == null)
            {
                return HttpNotFound();
            }
            return View(userSetSchedule);
        }

        // POST: MySchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,label,description,fromTime,toTime")] UserSetSchedule userSetSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userSetSchedule).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userSetSchedule);
        }

        // GET: MySchedules/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSetSchedule userSetSchedule = await db.UserSetSchedules.FindAsync(id);
            if (userSetSchedule == null)
            {
                return HttpNotFound();
            }
            return View(userSetSchedule);
        }

        // POST: MySchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserSetSchedule userSetSchedule = await db.UserSetSchedules.FindAsync(id);
            db.UserSetSchedules.Remove(userSetSchedule);
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
