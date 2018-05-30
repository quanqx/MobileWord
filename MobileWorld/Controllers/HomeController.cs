using MobileWorld.DAO;
using MobileWorld.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MobileWorld.Controllers
{
    public class HomeController : Controller
    {

        private LoaiDAO loai = new LoaiDAO();
        private NhanHieuDAO nhanHieu = new NhanHieuDAO();
        private SanPhamDAO sanPham = new SanPhamDAO();
        private AccountDAO account = new AccountDAO();

        // GET: Home
        public ActionResult Index()
        {
            if(Request.Cookies["Login"] != null)
            {
                ViewBag.Login = account.getAccountByEmail(Request.Cookies["Login"].Value);
            }
            ViewBag.listSanPhamMoi = sanPham.getTop8NewSanPham();
            ViewBag.listSanPhamBanChay = sanPham.getSanPhamBanChay();
            return View();
        }

        public ActionResult detailProduct(String MaSP = "iphone_6")
        {
            if (Request.Cookies["Login"] != null)
            {
                ViewBag.Login = account.getAccountByEmail(Request.Cookies["Login"].Value);
            }
            SanPham sp = sanPham.getSanPhamByID(MaSP);
            ViewBag.KMSanPham = sanPham.getKhuyenMaiByID(MaSP);
            return View(sp);
        }

        public ActionResult SanPham(String Loai, int? page = 1)
        {
            if (Request.Cookies["Login"] != null)
            {
                ViewBag.Login = account.getAccountByEmail(Request.Cookies["Login"].Value);
            }
            int pageSize = 16;
            var lstSanPham = sanPham.getSanPhamByLoai(Loai);
            int count = lstSanPham.Count;
            int pageNum = (page ?? 1);
            ViewBag.Loai = Loai;
            return View(lstSanPham.OrderBy(p=>p.NgayNhap).ToPagedList(pageNum, pageSize));
        }

        public ActionResult SanPhamByNhanHieu(String NhanHieu, int? page = 1)
        {
            if (Request.Cookies["Login"] != null)
            {
                ViewBag.Login = account.getAccountByEmail(Request.Cookies["Login"].Value);
            }
            int pageSize = 16;
            var lstSanPham = sanPham.getSanPhamByNhanHieu(NhanHieu);
            int count = lstSanPham.Count;
            int pageNum = (page ?? 1);
            ViewBag.NhanHieu = nhanHieu.getName(NhanHieu);
            return View(lstSanPham.OrderBy(p => p.NgayNhap).ToPagedList(pageNum, pageSize));
        }

        public ActionResult Search(String search, int? page = 1)
        {
            List<SanPham> lstSanPham = sanPham.filterSanPham(search);
            int pageSize = 16;
            int count = lstSanPham.Count;
            int pageNum = (page ?? 1);
            ViewBag.search = search;
            if (count == 0)
            {
                ViewBag.message = "Không tìm thấy!";
                return View(new List<SanPham>().ToPagedList(pageNum, pageSize));
            }
            return View(lstSanPham.OrderBy(p=>p.NgayNhap).ToPagedList(pageNum, pageSize));
        }

        public  ActionResult NavPatial()
        {
            ViewBag.listDienThoai = nhanHieu.getNhanHieuByLoai("L001");
            ViewBag.listMayTinhBang = nhanHieu.getNhanHieuByLoai("L002");
            ViewBag.listPhuKien = nhanHieu.getNhanHieuByLoai("L003");
            return PartialView();
        }

        public ActionResult FooterPartial()
        {
            ViewBag.listDienThoai = nhanHieu.getNhanHieuByLoai("L001");
            return PartialView();
        }

        public ActionResult Download()
        {
            return File(@"C:\Users\quand\source\repos\MobileWorld\MobileWorld\Images\banner1.jpg", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "anh.jpg");
        }

    }
}