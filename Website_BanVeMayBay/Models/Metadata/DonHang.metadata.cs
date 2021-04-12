using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Website_BanVeMayBay.Models
{
    [MetadataTypeAttribute(typeof(DonHangMetadata))]
    public partial class DonHang//noi voi Class DonHang trong Models
    {
        internal sealed class DonHangMetadata
        {
            [Display(Name = "Mã Đơn hàng")]
            [Key]
            public int MaDonHang { get; set; }

            [Display(Name = "Tổng tiền")]
            [DisplayFormat(DataFormatString = "{0:#,##0 vnđ}")]
            public int? DaThanhToan { get; set; }

            [Display(Name = "Tình trạng")]
            [Range(0, 1, ErrorMessage = "{0} phải thuộc [0, 1] 0: Chưa xong, 1: Hoàn thành")]
            public int? TinhTrang { get; set; }

            [Display(Name = "Ngày đặt")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            [DataType(DataType.Date)]
            public DateTime? NgayDat { get; set; }

            [Display(Name = "Mã Người dùng")]
            public int? MaNguoiDung { get; set; }
        }
    }
}