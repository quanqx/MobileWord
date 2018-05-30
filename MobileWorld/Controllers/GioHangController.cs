using MobileWorld.DAO;
using MobileWorld.Entities;
using MobileWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileWorld.Controllers
{
    public class GioHangController : Controller
    {

        private SanPhamDAO sanPham = new SanPhamDAO();
        private LoaiDAO loai = new LoaiDAO();
        private NhanHieuDAO nhanHieu = new NhanHieuDAO();
        private DonHangDAO donHang = new DonHangDAO();
        private ChiTietDonHangDAO chiTietDonHang = new ChiTietDonHangDAO();
        private AccountDAO account = new AccountDAO();
        public static String currentEmail;

        public List<GioHang> getGioHang()
        {
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if(listGioHang == null)
            {
                listGioHang = new List<GioHang>();
                Session["GioHang"] = listGioHang;
            }
            return listGioHang;
        }

        public ActionResult AddGioHang(String MaSP)
        {
            SanPham sp = sanPham.getSanPhamByID(MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = getGioHang();
            GioHang gioHang = lstGioHang.Find(p => p.MaSP == MaSP);
            if(gioHang == null)
            {
                gioHang = new GioHang(MaSP);
                lstGioHang.Add(gioHang);
                return RedirectToAction("GioHang", "GioHang");
            }
            else
            {
                gioHang.SoLuong++;
                return RedirectToAction("GioHang", "GioHang");
            }
        }

        public ActionResult UpdateGioHang(String MaSP, FormCollection form)
        {
            SanPham sp = sanPham.getSanPhamByID(MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = getGioHang();
            GioHang gioHang = lstGioHang.SingleOrDefault(p => p.MaSP == MaSP);
            if (gioHang != null)
            {
                gioHang.SoLuong = int.Parse(form["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult DeleteGioHang(String MaSP)
        {
            SanPham sp = sanPham.getSanPhamByID(MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = getGioHang();
            GioHang gioHang = lstGioHang.SingleOrDefault(p => p.MaSP == MaSP);
            if (gioHang != null)
            {
                lstGioHang.RemoveAll(p => p.MaSP == gioHang.MaSP);
            }
            //if(lstGioHang.Count == 0)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            return RedirectToAction("GioHang");
        }

        public ActionResult GioHang()
        {
            if (Request.Cookies["Login"] != null)
            {
                ViewBag.Login = account.getAccountByEmail(Request.Cookies["Login"].Value);
            }
            ViewBag.listDienThoai = nhanHieu.getNhanHieuByLoai("L001");
            ViewBag.listMayTinhBang = nhanHieu.getNhanHieuByLoai("L002");
            ViewBag.listPhuKien = nhanHieu.getNhanHieuByLoai("L003");
            ViewBag.TongTien = TongTien();
            //if (Session["GioHang"] == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            List<GioHang> lstGioHang = getGioHang();
            return View(lstGioHang);
        }

        private int TongSoLuong()
        {
            int tongSL = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tongSL = lstGioHang.Sum(p => p.SoLuong);
            }
            return tongSL;
        }

        private int TongTien()
        {
            int tongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tongTien = lstGioHang.Sum(p => p.ThanhTien);
            }
            return tongTien;
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }

        public ActionResult DatHang()
        {
            List<GioHang> lstGioHang = getGioHang();
            if(lstGioHang.Count == 0)
            {
                return RedirectToAction("GioHang", "GioHang");
            }
            if (Request.Cookies["Login"] != null)
            {
                ViewBag.Login = account.getAccountByEmail(Request.Cookies["Login"].Value);
            }
            ViewBag.listDienThoai = nhanHieu.getNhanHieuByLoai("L001");
            ViewBag.listMayTinhBang = nhanHieu.getNhanHieuByLoai("L002");
            ViewBag.listPhuKien = nhanHieu.getNhanHieuByLoai("L003");
            ViewBag.TongTien = TongTien();
            //if (Request.Cookies["Login"] != null)
            //{
            //    Account acc = account.getAccountByEmail(Request.Cookies["Login"].Value)
            //    ViewBag.Account = acc;
            //}
            return View(lstGioHang);
        }

        [HttpPost]
        public ActionResult AddDonHang(String Email, String HoTen, String SDT, String DiaChi, DateTime NgaySinh, String GioiTinh)
        {
            DonHang dh = new DonHang(genMaDonHang(), Email, HoTen, DiaChi, NgaySinh, GioiTinh, SDT, DateTime.Now, DateTime.Now.AddDays(4), false, false);
            donHang.addDonHang(dh);
            currentEmail = Email;
            //ChiTietDonHang ct = new ChiTietDonHang(dh.MaDonHang, )
            List<GioHang> lstGioHang = getGioHang();
            foreach(GioHang item in lstGioHang)
            {
                ChiTietDonHang ct = new ChiTietDonHang(dh.MaDonHang, item.MaSP, item.SoLuong);
                chiTietDonHang.add(ct);
            }
            lstGioHang.Clear();
            return RedirectToAction("AccountInfo", "Account");
        }

        [NonAction]
        private String genMaDonHang()
        {
            String MaDonHang = "DH";
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;
            MaDonHang += year + "" + month + "" + day + "" + hour + "" + minute + "" + second;
            return MaDonHang;
        }

    }
}