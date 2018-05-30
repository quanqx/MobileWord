using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MobileWorld.Entities;

namespace MobileWorld.Areas.Admin.Controllers
{
    public class BaoHanhsController : Controller
    {
        private Data db = new Data();

        // GET: Admin/BaoHanhs
        public ActionResult Index()
        {
            return View(db.BaoHanhs.ToList());
        }

        // GET: Admin/BaoHanhs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoHanh baoHanh = db.BaoHanhs.Find(id);
            if (baoHanh == null)
            {
                return HttpNotFound();
            }
            return View(baoHanh);
        }

        // GET: Admin/BaoHanhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BaoHanhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBaoHanh,ChiTietBH")] BaoHanh baoHanh)
        {
            if (ModelState.IsValid)
            {
                db.BaoHanhs.Add(baoHanh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baoHanh);
        }

        // GET: Admin/BaoHanhs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoHanh baoHanh = db.BaoHanhs.Find(id);
            if (baoHanh == null)
            {
                return HttpNotFound();
            }
            return View(baoHanh);
        }

        // POST: Admin/BaoHanhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBaoHanh,ChiTietBH")] BaoHanh baoHanh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baoHanh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baoHanh);
        }

        // GET: Admin/BaoHanhs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoHanh baoHanh = db.BaoHanhs.Find(id);
            if (baoHanh == null)
            {
                return HttpNotFound();
            }
            return View(baoHanh);
        }

        // POST: Admin/BaoHanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BaoHanh baoHanh = db.BaoHanhs.Find(id);
            db.BaoHanhs.Remove(baoHanh);
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
