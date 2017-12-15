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
    public class ResumeJobEntriesController : Controller
    {
        private kaylahSiteEntities db = new kaylahSiteEntities();

        // GET: ResumeJobEntries
        public ActionResult Index()
        {
            var resumeJobEntries = db.ResumeJobEntries.Include(r => r.Company).Include(r => r.Responsibility);
            return View(resumeJobEntries.ToList());
        }

        // GET: ResumeJobEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeJobEntry resumeJobEntry = db.ResumeJobEntries.Find(id);
            if (resumeJobEntry == null)
            {
                return HttpNotFound();
            }
            return View(resumeJobEntry);
        }

        // GET: ResumeJobEntries/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "Company_Name");
            ViewBag.EntryID = new SelectList(db.Responsibilities, "ResponsibilityID", "Responsibility1");
            return View();
        }

        // POST: ResumeJobEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntryID,CompanyID,DateBegin,DateEnd,isRelevant,Title")] ResumeJobEntry resumeJobEntry)
        {
            if (ModelState.IsValid)
            {
                db.ResumeJobEntries.Add(resumeJobEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "Company_Name", resumeJobEntry.CompanyID);
            ViewBag.EntryID = new SelectList(db.Responsibilities, "ResponsibilityID", "Responsibility1", resumeJobEntry.EntryID);
            return View(resumeJobEntry);
        }

        // GET: ResumeJobEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeJobEntry resumeJobEntry = db.ResumeJobEntries.Find(id);
            if (resumeJobEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "Company_Name", resumeJobEntry.CompanyID);
            ViewBag.EntryID = new SelectList(db.Responsibilities, "ResponsibilityID", "Responsibility1", resumeJobEntry.EntryID);
            return View(resumeJobEntry);
        }

        // POST: ResumeJobEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntryID,CompanyID,DateBegin,DateEnd,isRelevant,Title")] ResumeJobEntry resumeJobEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resumeJobEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "Company_Name", resumeJobEntry.CompanyID);
            ViewBag.EntryID = new SelectList(db.Responsibilities, "ResponsibilityID", "Responsibility1", resumeJobEntry.EntryID);
            return View(resumeJobEntry);
        }

        // GET: ResumeJobEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeJobEntry resumeJobEntry = db.ResumeJobEntries.Find(id);
            if (resumeJobEntry == null)
            {
                return HttpNotFound();
            }
            return View(resumeJobEntry);
        }

        // POST: ResumeJobEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResumeJobEntry resumeJobEntry = db.ResumeJobEntries.Find(id);
            db.ResumeJobEntries.Remove(resumeJobEntry);
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
