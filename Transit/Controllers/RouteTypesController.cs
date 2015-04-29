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
    public class RouteTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RouteTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.RouteTypes.ToListAsync());
        }

        // GET: RouteTypes/Details/5
        public async Task<ActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteType routeType = await db.RouteTypes.FindAsync(id);
            if (routeType == null)
            {
                return HttpNotFound();
            }
            return View(routeType);
        }

        // GET: RouteTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RouteTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,label,description")] RouteType routeType)
        {
            if (ModelState.IsValid)
            {
                db.RouteTypes.Add(routeType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(routeType);
        }

        // GET: RouteTypes/Edit/5
        public async Task<ActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteType routeType = await db.RouteTypes.FindAsync(id);
            if (routeType == null)
            {
                return HttpNotFound();
            }
            return View(routeType);
        }

        // POST: RouteTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,label,description")] RouteType routeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routeType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(routeType);
        }

        // GET: RouteTypes/Delete/5
        public async Task<ActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteType routeType = await db.RouteTypes.FindAsync(id);
            if (routeType == null)
            {
                return HttpNotFound();
            }
            return View(routeType);
        }

        // POST: RouteTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(byte id)
        {
            RouteType routeType = await db.RouteTypes.FindAsync(id);
            db.RouteTypes.Remove(routeType);
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
