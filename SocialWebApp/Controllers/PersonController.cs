using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SocialWebApp.DAL;
using SocialWebApp.Models;
using PagedList;
using SocialWebApp.ViewModels;

namespace SocialWebApp.Controllers
{
    public class PersonController : Controller
    {
        private RelationContext db = new RelationContext();

        // GET: Person
        public ViewResult Index(string SortOrder, string CurrentFilter,string SearchString, int? page, int? id, int? RelationshipTypeID)
        {
            ViewBag.CurrentSort = SortOrder;
            ViewBag.NameSortParam = String.IsNullOrEmpty(SortOrder) ? "name_desc" : "";

            if(SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }

            ViewBag.CurrentFilter = SearchString;
            
            var persons = from p in db.Persons select p;

            if(!String.IsNullOrEmpty(SearchString))
            {
                persons = persons.Where(p => p.FirstName.Contains(SearchString) || p.LastName.Contains(SearchString));
            }

            switch(SortOrder)
            {
                case "name_desc":
                    persons = persons.OrderByDescending(p => p.LastName);
                    break;
                default:
                    persons = persons.OrderBy(p => p.LastName);
                    break;
            }

            var viewModel = new PersonDetailsData();
            viewModel.Persons = db.Persons
                .Include(p => p.RelationshipTypes.Select(r => r.Related))
                .OrderBy(p => p.FirstName);               
            
            if(id != null)
            {
                ViewBag.PersonID = id.Value;
                viewModel.RelationshipType = viewModel.Persons.Where(
                    p => p.ID == id.Value).Single().RelationshipTypes;
            }
            
            if(RelationshipTypeID != null )
            {
                ViewBag.RelationshipTypeID = RelationshipTypeID.Value;
                viewModel.RelationshipType = viewModel.Persons.Where(
                    x => x.ID == RelationshipTypeID).Single().RelationshipTypes;
            } 

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            //return View(viewModel);
            return View(persons.ToPagedList(pageNumber, pageSize));
            
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Age,Gender")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Age,Gender")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Persons.Find(id);
            db.Persons.Remove(person);
            db.SaveChanges();
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
