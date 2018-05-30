using MobileWorld.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWorld.DAO
{
    public class ChiTietDonHangDAO
    {
        private Data data;

        public ChiTietDonHangDAO()
        {
            data = new Data();
        }

        public void add(ChiTietDonHang chiTiet)
        {
            data.ChiTietDonHangs.Add(chiTiet);
            data.SaveChanges();
        }

        public List<ChiTietDonHang> getChiTietDonHangByEmail(String Email)
        {
            var lst = (from ctdh in data.ChiTietDonHangs
                      join dh in data.DonHangs
                      on ctdh.MaDonHang equals dh.MaDonHang
                      where dh.Email == Email
                      select ctdh).ToList();
            return lst;
        }
    }
}