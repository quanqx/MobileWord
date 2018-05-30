using MobileWorld.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWorld.Models
{
    public class GioHang
    {

        //private String MaSP;

        //public string MaSP1 { get => MaSP; set => MaSP = value; }

        private Data data = new Data();

        public String MaSP { get; set; }
        public String TenSP { get; set; }
        public String HinhAnh { get; set; }
        public int DonGia { get; set; }
        public int SoLuong { get; set; }
        public int ThanhTien
        {
            get { return SoLuong * DonGia; }
        }

        public GioHang() { }

        public GioHang(String MaSP, String TenSP, String HinhAnh, int DonGia, int SoLuong)
        {
            this.MaSP = MaSP;
            this.TenSP = TenSP;
            this.HinhAnh = HinhAnh;
            this.DonGia = DonGia;
            this.SoLuong = SoLuong;
        }

        public GioHang(String MaSP)
        {
            this.MaSP = MaSP;
            SanPham sanPham = data.SanPhams.SingleOrDefault(p => p.MaSP == MaSP);
            TenSP = sanPham.TenSP;
            HinhAnh = sanPham.HinhAnh;
            DonGia = sanPham.DonGia;
            SoLuong = 1;
        }

        public List<GioHang> getGioHangByEmail(String Email)
        {
            var lst = from ctdh in data.ChiTietDonHangs
                      join dh in data.DonHangs
                      on ctdh.MaDonHang equals dh.MaDonHang
                      join sp in data.SanPhams
                      on ctdh.MaSP equals sp.MaSP
                      where dh.Email == Email
                      select new
                      {
                          sp.MaSP,
                          sp.TenSP,
                          sp.HinhAnh,
                          sp.DonGia,
                          ctdh.SoLuong
                      };
            List<GioHang> lstGioHang = new List<GioHang>();
            if (lst != null)
                foreach (var item in lst)
                {
                    GioHang gh = new GioHang(item.MaSP, item.TenSP, item.HinhAnh, item.DonGia, item.SoLuong);
                    lstGioHang.Add(gh);
                }
            return lstGioHang;
        }

    }
}