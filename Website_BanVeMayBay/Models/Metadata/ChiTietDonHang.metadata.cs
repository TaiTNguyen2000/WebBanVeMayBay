using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_BanVeMayBay.Models
{
    [MetadataTypeAttribute(typeof(ChiTietDonHangMetadata))]
    public partial class ChiTietDonHang
    {
        internal sealed class ChiTietDonHangMetadata
        {
            [Key]
            [Display(Name = "Mã Chi tiết Đơn hàng")]
            public int MaChiTietDonHang { get; set; }

            [Display(Name = "Mã Đơn hàng")]
            public int MaDonHang { get; set; }

            [Display(Name = "Đơn giá")]
            [DisplayFormat(DataFormatString = "{0:#,##0 vnđ}")]
            public int? DonGia { get; set; }

            [Display(Name = "Số lượng")]
            public int? SoLuong { get; set; }

            [Display(Name = "Mã chuyến bay")]
            public int? MaChuyenBay { get; set; }
        }
    }
}