using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website_BanVeMayBay.Models
{
    [MetadataTypeAttribute(typeof(ChuyenBayMetadata))]
    public partial class ChuyenBay//noi voi Class ChuyenBay trong Models
    {
        internal sealed class ChuyenBayMetadata
        {
            [Key]
            public int MaChuyenBay { get; set; }

            [Display(Name = "Giá bán")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            [Range(1000, 10000000, ErrorMessage = "{0} phải thuộc [1.000, 10.000.000]")]
            [DisplayFormat(DataFormatString = "{0:#,##0 vnđ}")]
            public decimal? GiaBan { get; set; }
            

            [Display(Name = "Ảnh bìa")]
            [StringLength(50, ErrorMessage = "{0} không quá 50 kí tự")]
            public string AnhBia { get; set; }

            [Display(Name = "Thời gian đi")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            [DataType(DataType.Date)]
            public DateTime? ThoiGianDi { get; set; }

            [Display(Name = "Thời gian về")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            [DataType(DataType.Date)]
            public DateTime? ThoiGianDen { get; set; }

            [Display(Name = "Tình trạng")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            [Range(0, 1, ErrorMessage = "{0} phải thuộc [0, 1]: 0: Hết vé, 1: Còn vé")]
            public int? CoTheDat { get; set; }

            [Display(Name = "Hãng hàng không")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            public int? MaHangHangKhong { get; set; }

            [Display(Name = "Sân bay đến")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            public int? SanBayDen { get; set; }

            [Display(Name = "Sân bay đi")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            public int? SanBayDi { get; set; }

            [Display(Name = "Loại vé")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            public int? LoaiChuyenBay { get; set; }
        }
    }
}