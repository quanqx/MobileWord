using MobileWorld.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWorld.DAO
{
    public class SanPhamDAO
    {

        private Data data;

        public SanPhamDAO()
        {
            data = new Data();
        }

        public List<SanPham> getAll()
        {
            return data.SanPhams.ToList();
        }

        public List<SanPham> getSanPhamByNhanHieu(String MaNhanHieu)
        {
            return data.SanPhams.Where(p => p.MaNhanHieu == MaNhanHieu).ToList();
        }

        public List<SanPham> getSanPhamByLoai(String MaLoai)
        {
            return data.SanPhams.Where(p => p.MaLoai == MaLoai).ToList();
        }

        public List<SanPham> getTop8NewSanPham()
        {
            return data.SanPhams.OrderByDescending(p => p.NgayNhap).Take(8).ToList();
        }

        public SanPham getSanPhamByID(String MaSP)
        {
            return data.SanPhams.Where(p => p.MaSP == MaSP).SingleOrDefault();
        }

        public List<SanPham> getSanPhamBanChay()
        {
            var sanPhamBanChay = (from ctdh in data.ChiTietDonHangs
                                 group ctdh by ctdh.MaSP into ctdhGroup
                                 select new
                                 {
                                     MaSP = ctdhGroup.Key,
                                     SoLuong = ctdhGroup.Sum(p => p.SoLuong)
                                 }).OrderByDescending(p=>p.SoLuong).Take(8);
            var chiTietSPBanChay = from sp in data.SanPhams
                                   where (from spbc in sanPhamBanChay
                                           select spbc.MaSP).Contains(sp.MaSP)
                                   select sp;
                                   
            return chiTietSPBanChay.ToList();
        }

        public String getKhuyenMaiByID(String MaSP)
        {
            var khuyenMai = (from sp in data.SanPhams
                            join km in data.KhuyenMais
                            on sp.MaKM equals km.MaKM
                            where sp.MaSP == MaSP
                            select km).SingleOrDefault();
            return khuyenMai.NoiDungKM;
        }

        public String getIDFirstSanPham()
        {
            return data.SanPhams.First().MaSP;
        }

        public List<SanPham> filterSanPham(String TenSP)
        {
            List<SanPham> lst = data.SanPhams.ToList();
            List<SanPham> result = new List<SanPham>();
            foreach(SanPham sp in lst)
            {
                if (sp.TenSP.ToLower().Contains(TenSP.ToLower()))// Iphone 6... ip>>>iphone.contains(ip)
                {
                    result.Add(sp);
                }
            }
            return result;
        }

    }
}