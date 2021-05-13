using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace Website_BanVeMayBay.Models
{
    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        public int MaTinTuc { get; set; }

        [StringLength(50)]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }

        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

        [StringLength(50)]
        [Display(Name = "Tóm tắt")]
        public string TomTat { get; set; }

        [StringLength(50)]
        [Display(Name = "Hình")]
        public string Hinh { get; set; }

    }
}