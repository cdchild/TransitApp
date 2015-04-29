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
    public class RoutesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Routes
        public async Task<ActionResult> Index()
        {
            var routes = db.Routes.Include(r => r.agency).Include(r => r.type);
            return View(await routes.ToListAsync());
        }

        // GET: Routes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = await db.Routes.FindAsync(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // GET: Routes/Create
        public ActionResult Create()
        {
            ViewBag.agencyId = new SelectList(db.Agencies, "id", "name");
            ViewBag.typeId = new SelectList(db.RouteTypes, "id", "label");
            return View();
        }

        // POST: Routes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,agencyId,label,fullName,description,typeId,url,color,textColor")] Route route)
        {
            if (ModelState.IsValid)
            {
                db.Routes.Add(route);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.agencyId = new SelectList(db.Agencies, "id", "name", route.agencyId);
            ViewBag.typeId = new SelectList(db.RouteTypes, "id", "label", route.typeId);
            return View(route);
        }

        // GET: Routes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = await db.Routes.FindAsync(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            ViewBag.agencyId = new SelectList(db.Agencies, "id", "name", route.agencyId);
            ViewBag.typeId = new SelectList(db.RouteTypes, "id", "label", route.typeId);
            return View(route);
        }

        // POST: Routes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,agencyId,label,fullName,description,typeId,url,color,textColor")] Route route)
        {
            if (ModelState.IsValid)
            {
                db.Entry(route).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.agencyId = new SelectList(db.Agencies, "id", "name", route.agencyId);
            ViewBag.typeId = new SelectList(db.RouteTypes, "id", "label", route.typeId);
            return View(route);
        }

        // GET: Routes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = await db.Routes.FindAsync(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Route route = await db.Routes.FindAsync(id);
            db.Routes.Remove(route);
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
