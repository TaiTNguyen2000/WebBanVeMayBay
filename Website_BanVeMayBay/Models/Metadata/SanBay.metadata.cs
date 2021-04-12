using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Website_BanVeMayBay.Models
{
    [MetadataTypeAttribute(typeof(SanBayMetadata))]
    public partial class SanBay//noi voi Class SanBay trong Models
    {
        internal sealed class SanBayMetadata
        {
            [Key]
            public int MaSanBay { get; set; }

            [Display(Name = "Tên Sân bay")]
            [Required(ErrorMessage = "{0} không được để trống")]
            [StringLength(50, ErrorMessage = "{0} không quá 50 kí tự")]
            public string TenSanBay { get; set; }
        }
    }
}