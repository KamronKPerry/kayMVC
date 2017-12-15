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
    public class GraphicsSamplesController : Controller
    {
        private kaylahSiteEntities db = new kaylahSiteEntities();

        // GET: GraphicsSamples
        public ActionResult Index()
        {
            return View(db.GraphicsSamples.ToList());
        }

        // GET: GraphicsSamples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GraphicsSample graphicsSample = db.GraphicsSamples.Find(id);
            if (graphicsSample == null)
            {
                return HttpNotFound();
            }
            return View(graphicsSample);
        }

        // GET: GraphicsSamples/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GraphicsSamples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GraphicID,ImageName,IsActive,Information,GraphicTitle")] GraphicsSample graphicsSample)
        {
            if (ModelState.IsValid)
            {
                db.GraphicsSamples.Add(graphicsSample);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(graphicsSample);
        }

        // GET: GraphicsSamples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GraphicsSample graphicsSample = db.GraphicsSamples.Find(id);
            if (graphicsSample == null)
            {
                return HttpNotFound();
            }
            return View(graphicsSample);
        }

        // POST: GraphicsSamples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GraphicID,ImageName,IsActive,Information,GraphicTitle")] GraphicsSample graphicsSample)
        {
            if (ModelState.IsValid)
            {
                db.Entry(graphicsSample).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(graphicsSample);
        }

        // GET: GraphicsSamples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GraphicsSample graphicsSample = db.GraphicsSamples.Find(id);
            if (graphicsSample == null)
            {
                return HttpNotFound();
            }
            return View(graphicsSample);
        }

        // POST: GraphicsSamples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GraphicsSample graphicsSample = db.GraphicsSamples.Find(id);
            db.GraphicsSamples.Remove(graphicsSample);
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
