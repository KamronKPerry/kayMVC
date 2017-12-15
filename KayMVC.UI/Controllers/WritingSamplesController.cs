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
    public class WritingSamplesController : Controller
    {
        private kaylahSiteEntities db = new kaylahSiteEntities();

        // GET: WritingSamples
        public ActionResult Index()
        {
            var writingSamples = db.WritingSamples.Include(w => w.GraphicsSample);
            return View(writingSamples.ToList());
        }

        // GET: WritingSamples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WritingSample writingSample = db.WritingSamples.Find(id);
            if (writingSample == null)
            {
                return HttpNotFound();
            }
            return View(writingSample);
        }

        // GET: WritingSamples/Create
        public ActionResult Create()
        {
            ViewBag.GraphicPairing = new SelectList(db.GraphicsSamples, "GraphicID", "ImageName");
            return View();
        }

        // POST: WritingSamples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SampleID,SampleTitle,SampleContext,SampleAdditionalContext,GraphicPairing")] WritingSample writingSample)
        {
            if (ModelState.IsValid)
            {
                db.WritingSamples.Add(writingSample);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GraphicPairing = new SelectList(db.GraphicsSamples, "GraphicID", "ImageName", writingSample.GraphicPairing);
            return View(writingSample);
        }

        // GET: WritingSamples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WritingSample writingSample = db.WritingSamples.Find(id);
            if (writingSample == null)
            {
                return HttpNotFound();
            }
            ViewBag.GraphicPairing = new SelectList(db.GraphicsSamples, "GraphicID", "ImageName", writingSample.GraphicPairing);
            return View(writingSample);
        }

        // POST: WritingSamples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SampleID,SampleTitle,SampleContext,SampleAdditionalContext,GraphicPairing")] WritingSample writingSample)
        {
            if (ModelState.IsValid)
            {
                db.Entry(writingSample).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GraphicPairing = new SelectList(db.GraphicsSamples, "GraphicID", "ImageName", writingSample.GraphicPairing);
            return View(writingSample);
        }

        // GET: WritingSamples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WritingSample writingSample = db.WritingSamples.Find(id);
            if (writingSample == null)
            {
                return HttpNotFound();
            }
            return View(writingSample);
        }

        // POST: WritingSamples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WritingSample writingSample = db.WritingSamples.Find(id);
            db.WritingSamples.Remove(writingSample);
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
