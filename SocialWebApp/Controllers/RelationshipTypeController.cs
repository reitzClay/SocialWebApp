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
    public class RelationshipTypeController : Controller
    {
        private RelationContext db = new RelationContext();

        // GET: RelationshipType
        public async Task<ActionResult> Index()
        {
            var relationshipTypes = db.RelationshipTypes.Include(r => r.Person).Include(r => r.Related);
            return View(await relationshipTypes.ToListAsync());
        }

        // GET: RelationshipType/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelationshipType relationshipType = await db.RelationshipTypes.FindAsync(id);
            if (relationshipType == null)
            {
                return HttpNotFound();
            }
            return View(relationshipType);
        }

        // GET: RelationshipType/Create
        public ActionResult Create()
        {
            ViewBag.PersonID = new SelectList(db.Persons, "ID", "FirstName");
            ViewBag.RelatedID = new SelectList(db.Relateds, "RelatedID", "FirstName");
            return View();
        }

        // POST: RelationshipType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RelationshipTypeID,PersonID,RelatedID,Relations")] RelationshipType relationshipType)
        {
            if (ModelState.IsValid)
            {
                db.RelationshipTypes.Add(relationshipType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.Persons, "ID", "FirstName", relationshipType.PersonID);
            ViewBag.RelatedID = new SelectList(db.Relateds, "RelatedID", "FirstName", relationshipType.RelatedID);
            return View(relationshipType);
        }

        // GET: RelationshipType/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelationshipType relationshipType = await db.RelationshipTypes.FindAsync(id);
            if (relationshipType == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(db.Persons, "ID", "FirstName", relationshipType.PersonID);
            ViewBag.RelatedID = new SelectList(db.Relateds, "RelatedID", "FirstName", relationshipType.RelatedID);
            return View(relationshipType);
        }

        // POST: RelationshipType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RelationshipTypeID,PersonID,RelatedID,Relations")] RelationshipType relationshipType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relationshipType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PersonID = new SelectList(db.Persons, "ID", "FirstName", relationshipType.PersonID);
            ViewBag.RelatedID = new SelectList(db.Relateds, "RelatedID", "FirstName", relationshipType.RelatedID);
            return View(relationshipType);
        }

        // GET: RelationshipType/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelationshipType relationshipType = await db.RelationshipTypes.FindAsync(id);
            if (relationshipType == null)
            {
                return HttpNotFound();
            }
            return View(relationshipType);
        }

        // POST: RelationshipType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RelationshipType relationshipType = await db.RelationshipTypes.FindAsync(id);
            db.RelationshipTypes.Remove(relationshipType);
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
