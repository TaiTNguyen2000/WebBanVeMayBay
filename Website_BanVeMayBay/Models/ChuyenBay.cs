using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace Website_BanVeMayBay.Models
{
    [Table("ChuyenBay")]
    public partial class ChuyenBay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChuyenBay()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Display(Name = "Mã chuyến bay")]
        [Key]
        public int MaChuyenBay { get; set; }

        [Display(Name = "Giá bán")]
        public decimal? GiaBan { get; set; }

        [Display(Name = "Ảnh bìa")]
        [StringLength(50)]
        public string AnhBia { get; set; }

        [Display(Name = "Tình trạng")]
        public int? CoTheDat { get; set; }

        [Display(Name = "Sân bay đi")]
        public int? SanBayDi { get; set; }

        [Display(Name = "Sân bay đến")]
        public int? SanBayDen { get; set; }

        [Display(Name = "Thời gian đi")]
        [DataType(DataType.Date)]
        public DateTime? ThoiGianDi { get; set; }

        [Display(Name = "Thời gian đến")]
        [DataType(DataType.Date)]
        public DateTime? ThoiGianDen { get; set; }

        [Display(Name = "Hãng hàng không")]
        public int? MaHangHangKhong { get; set; }
        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual HangHangKhong HangHangKhong { get; set; }

        [ForeignKey("SanBayDi")]
        public virtual SanBay SanBay { get; set; }
    }
}