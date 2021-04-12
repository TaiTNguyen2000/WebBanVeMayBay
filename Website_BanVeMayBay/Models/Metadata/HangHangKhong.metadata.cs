using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_BanVeMayBay.Models
{
    [MetadataTypeAttribute(typeof(HangHangKhongMetadata))]
    public partial class HangHangKhong//noi voi Class HangHangKhong trong Models
    {
        internal sealed class HangHangKhongMetadata
        {
            [Key]
            public int MaHangHangKhong { get; set; }
            

            [Display(Name = "Tên Hãng hàng không")]
            public string TenHangHangKhong { get; set; }
        }
    }
}