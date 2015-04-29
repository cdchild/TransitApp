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
    public class FeedsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Feeds
        public async Task<ActionResult> Index()
        {
            return View(await db.Feeds.ToListAsync());
        }

        // GET: Feeds/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feed feed = await db.Feeds.FindAsync(id);
            if (feed == null)
            {
                return HttpNotFound();
            }
            return View(feed);
        }

        // GET: Feeds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,publisher,url,language,start,end,version")] Feed feed)
        {
            if (ModelState.IsValid)
            {
                db.Feeds.Add(feed);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(feed);
        }

        // GET: Feeds/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feed feed = await db.Feeds.FindAsync(id);
            if (feed == null)
            {
                return HttpNotFound();
            }
            return View(feed);
        }

        // POST: Feeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,publisher,url,language,start,end,version")] Feed feed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feed).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(feed);
        }

        // GET: Feeds/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feed feed = await db.Feeds.FindAsync(id);
            if (feed == null)
            {
                return HttpNotFound();
            }
            return View(feed);
        }

        // POST: Feeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Feed feed = await db.Feeds.FindAsync(id);
            db.Feeds.Remove(feed);
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
