using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KayMVC.DATA;

namespace KayMVC.UI.Controllers
{
    public class ResponsibilitiesController : Controller
    {
        private kaylahSiteEntities db = new kaylahSiteEntities();

        // GET: Responsibilities
        public ActionResult Index()
        {
            var responsibilities = db.Responsibilities.Include(r => r.ResumeJobEntry);
            return View(responsibilities.ToList());
        }

        // GET: Responsibilities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsibility responsibility = db.Responsibilities.Find(id);
            if (responsibility == null)
            {
                return HttpNotFound();
            }
            return View(responsibility);
        }

        // GET: Responsibilities/Create
        public ActionResult Create()
        {
            ViewBag.ResponsibilityID = new SelectList(db.ResumeJobEntries, "EntryID", "Title");
            return View();
        }

        // POST: Responsibilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResponsibilityID,EntryID,Responsibility1")] Responsibility responsibility)
        {
            if (ModelState.IsValid)
            {
                db.Responsibilities.Add(responsibility);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResponsibilityID = new SelectList(db.ResumeJobEntries, "EntryID", "Title", responsibility.ResponsibilityID);
            return View(responsibility);
        }

        // GET: Responsibilities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsibility responsibility = db.Responsibilities.Find(id);
            if (responsibility == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResponsibilityID = new SelectList(db.ResumeJobEntries, "EntryID", "Title", responsibility.ResponsibilityID);
            return View(responsibility);
        }

        // POST: Responsibilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResponsibilityID,EntryID,Responsibility1")] Responsibility responsibility)
        {
            if (ModelState.IsValid)
            {
                db.Entry(responsibility).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResponsibilityID = new SelectList(db.ResumeJobEntries, "EntryID", "Title", responsibility.ResponsibilityID);
            return View(responsibility);
        }

        // GET: Responsibilities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsibility responsibility = db.Responsibilities.Find(id);
            if (responsibility == null)
            {
                return HttpNotFound();
            }
            return View(responsibility);
        }

        // POST: Responsibilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Responsibility responsibility = db.Responsibilities.Find(id);
            db.Responsibilities.Remove(responsibility);
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
