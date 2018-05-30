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
    public class AccountController : Controller
    {
        private SanPhamDAO sanPham = new SanPhamDAO();
        private LoaiDAO loai = new LoaiDAO();
        private NhanHieuDAO nhanHieu = new NhanHieuDAO();
        private AccountDAO account = new AccountDAO();

        public ActionResult Login()
        {
            if (Request.Cookies["Login"] != null)
            {
                ViewBag.Login = account.getAccountByEmail(Request.Cookies["Login"].Value);
            }
            ViewBag.listDienThoai = nhanHieu.getNhanHieuByLoai("L001");
            ViewBag.listMayTinhBang = nhanHieu.getNhanHieuByLoai("L002");
            ViewBag.listPhuKien = nhanHieu.getNhanHieuByLoai("L003");
            return View();
        }

        [HttpPost]
        public ActionResult Login(string txtMail, string txtPass)
        {
            AccountDAO account = new AccountDAO();
            if(account.checkAccount(txtMail, txtPass))
            {
                HttpCookie httpCookie = new HttpCookie("Login");
                httpCookie.Value = txtMail;
                httpCookie.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(httpCookie);
                Session["Login"] = account.getAccountByEmail(txtMail);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult DangXuat()
        {
            Response.Cookies["Login"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            if (Request.Cookies["Login"] != null)
            {
                ViewBag.Login = account.getAccountByEmail(Request.Cookies["Login"].Value);
            }
            ViewBag.listDienThoai = nhanHieu.getNhanHieuByLoai("L001");
            ViewBag.listMayTinhBang = nhanHieu.getNhanHieuByLoai("L002");
            ViewBag.listPhuKien = nhanHieu.getNhanHieuByLoai("L003");
            return View();
        }

        [HttpPost]
        public ActionResult Register(String Email, String Password, String HoTen, String DiaChi, String SDT, DateTime NgaySinh, String GioiTinh)
        {
            if (account.EmailIsExists(Email))
            {
                ViewBag.message = "Email này đã tồn tại! Vui lòng thử lại.";
                ViewBag.listDienThoai = nhanHieu.getNhanHieuByLoai("L001");
                ViewBag.listMayTinhBang = nhanHieu.getNhanHieuByLoai("L002");
                ViewBag.listPhuKien = nhanHieu.getNhanHieuByLoai("L003");
                return View();
            }
            Account acc = new Account(Email, Password, HoTen, DiaChi, NgaySinh, GioiTinh, SDT);
            account.add(acc);
            return RedirectToAction("Login", "Account");
        }

        public List<GioHang> getGioHang()
        {
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang == null)
            {
                listGioHang = new List<GioHang>();
                Session["GioHang"] = listGioHang;
            }
            return listGioHang;
        }

        public ActionResult AccountInfo()
        {
            if (Request.Cookies["Login"] != null)
            {
                ViewBag.Login = account.getAccountByEmail(Request.Cookies["Login"].Value);
            }
            ViewBag.listDienThoai = nhanHieu.getNhanHieuByLoai("L001");
            ViewBag.listMayTinhBang = nhanHieu.getNhanHieuByLoai("L002");
            ViewBag.listPhuKien = nhanHieu.getNhanHieuByLoai("L003");
            GioHang gh = new GioHang();
            List<GioHang> lst = gh.getGioHangByEmail(GioHangController.currentEmail);
            return View(lst);
        }

    }
}