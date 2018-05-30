namespace MobileWorld.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [StringLength(50)]
        public string MaDonHang { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }
        
        public DateTime NgaySinh { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }
        
        public DateTime NgayDat { get; set; }
        
        public DateTime NgayGiao { get; set; }

        public bool DaThanhToan { get; set; }

        public bool TinhTrangGiaoHang { get; set; }

        public DonHang(String MaDonHang, String Email, String HoTen, String DiaChi, DateTime NgaySinh, String GioiTinh, String SDT, DateTime NgayDat, DateTime NgayGiao, bool DaThanhToan, bool TinhTrangGiaoHang)
        {
            this.MaDonHang = MaDonHang;
            this.Email = Email;
            this.HoTen = HoTen;
            this.DiaChi = DiaChi;
            this.NgaySinh = NgaySinh;
            this.GioiTinh = GioiTinh;
            this.SDT = SDT;
            this.NgayDat = NgayDat;
            this.NgayGiao = NgayGiao;
            this.DaThanhToan = DaThanhToan;
            this.TinhTrangGiaoHang = TinhTrangGiaoHang;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
