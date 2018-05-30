namespace MobileWorld.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MaDonHang { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MaSP { get; set; }

        public int SoLuong { get; set; }

        public ChiTietDonHang(String MaDonHang, String MaSP, int SoLuong)
        {
            this.MaDonHang = MaDonHang;
            this.MaSP = MaSP;
            this.SoLuong = SoLuong;
        }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
