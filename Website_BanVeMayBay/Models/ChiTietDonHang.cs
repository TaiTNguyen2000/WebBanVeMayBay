﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace Website_BanVeMayBay.Models
{
    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        public int MaChiTietDonHang { get; set; }

        [Display(Name = "Mã đơn hàng")]
        public int MaDonHang { get; set; }


        [Display(Name = "Mã chuyến bay")]
        public int MaChuyenBay { get; set; }


        [Display(Name = "Số lượng người lớn")]
        public int? SoLuongNguoiLon { get; set; }

        [Display(Name = "Số lượng trẻ em")]
        public int? SoLuongTreEm { get; set; }

        [Display(Name = "Danh sách người lớn")]
        public string DanhSachNguoiLon { get; set; }

        [Display(Name = "Danh sách trẻ em")]
        public string DanhSachTreEm { get; set; }

        [StringLength(10)]
        [Display(Name = "Đơn giá")]
        public string DonGia { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual ChuyenBay ChuyenBay { get; set; }
    }
}