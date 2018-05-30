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
    public class NhanHieuxController : Controller
    {
        private Data db = new Data();

        // GET: Admin/NhanHieux
        public ActionResult Index()
        {
            var nhanHieus = db.NhanHieus.Include(n => n.Loai);
            return View(nhanHieus.ToList());
        }

        // GET: Admin/NhanHieux/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanHieu nhanHieu = db.NhanHieus.Find(id);
            if (nhanHieu == null)
            {
                return HttpNotFound();
            }
            return View(nhanHieu);
        }

        // GET: Admin/NhanHieux/Create
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.Loais, "MaLoai", "TenLoai");
            return View();
        }

        // POST: Admin/NhanHieux/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhanHieu,TenNhanHieu,MaLoai")] NhanHieu nhanHieu)
        {
            if (ModelState.IsValid)
            {
                db.NhanHieus.Add(nhanHieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoai = new SelectList(db.Loais, "MaLoai", "TenLoai", nhanHieu.MaLoai);
            return View(nhanHieu);
        }

        // GET: Admin/NhanHieux/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanHieu nhanHieu = db.NhanHieus.Find(id);
            if (nhanHieu == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.Loais, "MaLoai", "TenLoai", nhanHieu.MaLoai);
            return View(nhanHieu);
        }

        // POST: Admin/NhanHieux/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhanHieu,TenNhanHieu,MaLoai")] NhanHieu nhanHieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanHieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.Loais, "MaLoai", "TenLoai", nhanHieu.MaLoai);
            return View(nhanHieu);
        }

        // GET: Admin/NhanHieux/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanHieu nhanHieu = db.NhanHieus.Find(id);
            if (nhanHieu == null)
            {
                return HttpNotFound();
            }
            return View(nhanHieu);
        }

        // POST: Admin/NhanHieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanHieu nhanHieu = db.NhanHieus.Find(id);
            db.NhanHieus.Remove(nhanHieu);
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
