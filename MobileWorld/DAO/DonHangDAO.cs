using MobileWorld.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWorld.DAO
{
    public class DonHangDAO
    {
        private Data data;

        public DonHangDAO()
        {
            data = new Data();
        }

        public void addDonHang(DonHang donHang)
        {
            data.DonHangs.Add(donHang);
            data.SaveChanges();
        }
    }
}