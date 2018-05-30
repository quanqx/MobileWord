namespace MobileWorld.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [StringLength(50)]
        public string MaSP { get; set; }

        [Required]
        [StringLength(100)]
        public string TenSP { get; set; }

        [StringLength(50)]
        public string MaLoai { get; set; }

        [StringLength(50)]
        public string MaNhanHieu { get; set; }

        [StringLength(50)]
        public string MaBaoHanh { get; set; }

        [StringLength(200)]
        public string ThanMay { get; set; }

        [StringLength(200)]
        public string ManHinh { get; set; }

        [StringLength(50)]
        public string HDH { get; set; }

        [StringLength(200)]
        public string CPU { get; set; }

        [StringLength(50)]
        public string BoNhoTrong { get; set; }

        [StringLength(50)]
        public string BoNhoNgoai { get; set; }

        [StringLength(100)]
        public string CameraChinh { get; set; }

        [StringLength(100)]
        public string CameraPhu { get; set; }

        [StringLength(200)]
        public string Pin { get; set; }

        [StringLength(200)]
        public string AmThanh { get; set; }

        [StringLength(50)]
        public string MaKM { get; set; }

        [StringLength(100)]
        public string HinhAnh { get; set; }

        [StringLength(50)]
        public string MauSac { get; set; }

        [StringLength(50)]
        public string TinhTrang { get; set; }

        public int DonGia { get; set; }

        public DateTime NgayNhap { get; set; }

        public virtual BaoHanh BaoHanh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual KhuyenMai KhuyenMai { get; set; }

        public virtual Loai Loai { get; set; }

        public virtual NhanHieu NhanHieu { get; set; }
    }
}
