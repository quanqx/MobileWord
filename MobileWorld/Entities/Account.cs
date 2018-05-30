namespace MobileWorld.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Pass { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }
        
        public DateTime NgaySinh { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        public Account() { }

        public Account(string email, string pass, string hoTen, string diaChi, DateTime ngaySinh, string gioiTinh, string sDT)
        {
            Email = email;
            Pass = pass;
            HoTen = hoTen;
            DiaChi = diaChi;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            SDT = sDT;
        }
    }
}
