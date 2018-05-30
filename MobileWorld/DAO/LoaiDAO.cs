using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWorld.DAO
{
    public class LoaiDAO
    {
        private Entities.Data data;

        public LoaiDAO()
        {
            data = new Entities.Data();
        }

        public List<Entities.Loai> getAll()
        {
            return data.Loais.ToList();
        }
    }
}