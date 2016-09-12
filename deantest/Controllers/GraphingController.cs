using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using deantest.Models;

namespace deantest.Controllers
{
    public class GraphingController : Controller
    {
        private deanduffEntities db = new deanduffEntities();

        // GET: Graphing
        public ActionResult Index()
        {
            return View(db.dummies.ToList());
        }

        // GET: Graphing/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dummy dummy = db.dummies.Find(id);
            if (dummy == null)
            {
                return HttpNotFound();
            }
            return View(dummy);
        }

        // GET: Graphing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Graphing/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "testID,name,x,y")] dummy dummy)
        {
            if (ModelState.IsValid)
            {
                db.dummies.Add(dummy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dummy);
        }

        // GET: Graphing/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dummy dummy = db.dummies.Find(id);
            if (dummy == null)
            {
                return HttpNotFound();
            }
            return View(dummy);
        }

        // POST: Graphing/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "testID,name,x,y")] dummy dummy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dummy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dummy);
        }

        // GET: Graphing/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dummy dummy = db.dummies.Find(id);
            if (dummy == null)
            {
                return HttpNotFound();
            }
            return View(dummy);
        }

        // POST: Graphing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dummy dummy = db.dummies.Find(id);
            db.dummies.Remove(dummy);
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
