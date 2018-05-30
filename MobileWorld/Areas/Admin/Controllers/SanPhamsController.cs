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
    public class SanPhamsController : Controller
    {
        private Data db = new Data();

        // GET: Admin/SanPhams
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.BaoHanh).Include(s => s.KhuyenMai).Include(s => s.Loai).Include(s => s.NhanHieu);
            return View(sanPhams.ToList());
        }

        // GET: Admin/SanPhams/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaBaoHanh = new SelectList(db.BaoHanhs, "MaBaoHanh", "ChiTietBH");
            ViewBag.MaKM = new SelectList(db.KhuyenMais, "MaKM", "NoiDungKM");
            ViewBag.MaLoai = new SelectList(db.Loais, "MaLoai", "TenLoai");
            ViewBag.MaNhanHieu = new SelectList(db.NhanHieus, "MaNhanHieu", "TenNhanHieu");
            return View();
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,MaLoai,MaNhanHieu,MaBaoHanh,ThanMay,ManHinh,HDH,CPU,BoNhoTrong,BoNhoNgoai,CameraChinh,CameraPhu,Pin,AmThanh,MaKM,HinhAnh,MauSac,TinhTrang,DonGia,NgayNhap")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBaoHanh = new SelectList(db.BaoHanhs, "MaBaoHanh", "ChiTietBH", sanPham.MaBaoHanh);
            ViewBag.MaKM = new SelectList(db.KhuyenMais, "MaKM", "NoiDungKM", sanPham.MaKM);
            ViewBag.MaLoai = new SelectList(db.Loais, "MaLoai", "TenLoai", sanPham.MaLoai);
            ViewBag.MaNhanHieu = new SelectList(db.NhanHieus, "MaNhanHieu", "TenNhanHieu", sanPham.MaNhanHieu);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBaoHanh = new SelectList(db.BaoHanhs, "MaBaoHanh", "ChiTietBH", sanPham.MaBaoHanh);
            ViewBag.MaKM = new SelectList(db.KhuyenMais, "MaKM", "NoiDungKM", sanPham.MaKM);
            ViewBag.MaLoai = new SelectList(db.Loais, "MaLoai", "TenLoai", sanPham.MaLoai);
            ViewBag.MaNhanHieu = new SelectList(db.NhanHieus, "MaNhanHieu", "TenNhanHieu", sanPham.MaNhanHieu);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,MaLoai,MaNhanHieu,MaBaoHanh,ThanMay,ManHinh,HDH,CPU,BoNhoTrong,BoNhoNgoai,CameraChinh,CameraPhu,Pin,AmThanh,MaKM,HinhAnh,MauSac,TinhTrang,DonGia,NgayNhap")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBaoHanh = new SelectList(db.BaoHanhs, "MaBaoHanh", "ChiTietBH", sanPham.MaBaoHanh);
            ViewBag.MaKM = new SelectList(db.KhuyenMais, "MaKM", "NoiDungKM", sanPham.MaKM);
            ViewBag.MaLoai = new SelectList(db.Loais, "MaLoai", "TenLoai", sanPham.MaLoai);
            ViewBag.MaNhanHieu = new SelectList(db.NhanHieus, "MaNhanHieu", "TenNhanHieu", sanPham.MaNhanHieu);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
