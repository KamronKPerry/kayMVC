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
    public class ResumeUploadsController : Controller
    {
        private kaylahSiteEntities db = new kaylahSiteEntities();

        // GET: ResumeUploads
        public ActionResult Index()
        {
            return View(db.ResumeUploads.ToList());
        }

        // GET: ResumeUploads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeUpload resumeUpload = db.ResumeUploads.Find(id);
            if (resumeUpload == null)
            {
                return HttpNotFound();
            }
            return View(resumeUpload);
        }

        // GET: ResumeUploads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResumeUploads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResumeID,ResumeName,isCurrent,UploadDate")] ResumeUpload resumeUpload)
        {
            if (ModelState.IsValid)
            {
                db.ResumeUploads.Add(resumeUpload);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resumeUpload);
        }

        // GET: ResumeUploads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeUpload resumeUpload = db.ResumeUploads.Find(id);
            if (resumeUpload == null)
            {
                return HttpNotFound();
            }
            return View(resumeUpload);
        }

        // POST: ResumeUploads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResumeID,ResumeName,isCurrent,UploadDate")] ResumeUpload resumeUpload)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resumeUpload).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resumeUpload);
        }

        // GET: ResumeUploads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeUpload resumeUpload = db.ResumeUploads.Find(id);
            if (resumeUpload == null)
            {
                return HttpNotFound();
            }
            return View(resumeUpload);
        }

        // POST: ResumeUploads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResumeUpload resumeUpload = db.ResumeUploads.Find(id);
            db.ResumeUploads.Remove(resumeUpload);
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
