using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWorld.DAO
{
    public class NhanHieuDAO
    {
        private Entities.Data data;

        public NhanHieuDAO()
        {
            data = new Entities.Data();
        }

        public List<Entities.NhanHieu> getAll()
        {
            return data.NhanHieus.ToList();
        }

        public List<Entities.NhanHieu> getNhanHieuByLoai(String maLoai)
        {
            return data.NhanHieus.Where(p => p.MaLoai == maLoai).ToList();
        }
        
        public String getName(String MaNhanHieu)
        {
            return data.NhanHieus.SingleOrDefault(p => p.MaNhanHieu == MaNhanHieu).TenNhanHieu;
        }
    }
}