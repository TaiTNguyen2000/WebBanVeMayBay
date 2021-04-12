using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace Website_BanVeMayBay.Models
{
    [Table("HangHangKhong")]
    public partial class HangHangKhong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HangHangKhong()
        {
            ChuyenBays = new HashSet<ChuyenBay>();
        }

        [Key]
        public int MaHangHangKhong { get; set; }

        [StringLength(50)]
        public string TenHangHangKhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChuyenBay> ChuyenBays { get; set; }
    }
}