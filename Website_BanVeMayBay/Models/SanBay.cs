using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace Website_BanVeMayBay.Models
{
    [Table("SanBay")]
    public partial class SanBay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanBay()
        {
            ChuyenBays = new HashSet<ChuyenBay>();
        }

        [Key]
        public int MaSanBay { get; set; }

        [StringLength(50)]
        public string TenSanBay { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChuyenBay> ChuyenBays { get; set; }
    }
}