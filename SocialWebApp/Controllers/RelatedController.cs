using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SocialWebApp.DAL;
using SocialWebApp.Models;

namespace SocialWebApp.Controllers
{
    public class RelatedController : Controller
    {
        private RelationContext db = new RelationContext();

        // GET: Related
        public async Task<ActionResult> Index()
        {
            return View(await db.Relateds.ToListAsync());
        }

        // GET: Related/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Related related = await db.Relateds.FindAsync(id);
            if (related == null)
            {
                return HttpNotFound();
            }
            return View(related);
        }

        // GET: Related/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Related/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RelatedID,FirstName,LastName,Relation")] Related related)
        {
            if (ModelState.IsValid)
            {
                db.Relateds.Add(related);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(related);
        }

        // GET: Related/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Related related = await db.Relateds.FindAsync(id);
            if (related == null)
            {
                return HttpNotFound();
            }
            return View(related);
        }

        // POST: Related/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RelatedID,FirstName,LastName,Relation")] Related related)
        {
            if (ModelState.IsValid)
            {
                db.Entry(related).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(related);
        }

        // GET: Related/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Related related = await db.Relateds.FindAsync(id);
            if (related == null)
            {
                return HttpNotFound();
            }
            return View(related);
        }

        // POST: Related/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Related related = await db.Relateds.FindAsync(id);
            db.Relateds.Remove(related);
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
