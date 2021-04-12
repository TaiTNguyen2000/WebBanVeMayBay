using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Website_BanVeMayBay.Models
{
    [MetadataTypeAttribute(typeof(NguoiDungMetadata))]
    public partial class NguoiDung//noi voi Class NguoiDung trong Models
    {
        internal sealed class NguoiDungMetadata
        {
            [Key]
            [Display(Name = "Mã Người dùng")]
            public int MaNguoiDung { get; set; }

            [Display(Name = "Họ và Tên")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            [StringLength(50, ErrorMessage = "{0} không quá 50 kí tự")]
            public string HoTen { get; set; }

            [Display(Name = "Tài khoản")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            [StringLength(50, ErrorMessage = "{0} không quá 50 kí tự")]
            public string TaiKhoan { get; set; }

            [Display(Name = "Mật khẩu")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            [StringLength(50, ErrorMessage = "{0} không quá 50 kí tự")]
            public string MatKhau { get; set; }

            [Display(Name = "Email")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            [StringLength(100, ErrorMessage = "{0} không quá 100 kí tự")]
            [RegularExpression(@"^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "{0} không hợp lệ")]
            public string Email { get; set; }

            [Display(Name = "Địa chỉ")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            [StringLength(200, ErrorMessage = "{0} không quá 200 kí tự")]
            public string DiaChi { get; set; }

            [Display(Name = "Số điện thoại")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            [StringLength(50, ErrorMessage = "{0} không quá 50 kí tự")]
            public string DienThoai { get; set; }
            
            [Display(Name = "Giới tính")]
            [Range(0, 2, ErrorMessage = "{0} phải thuộc [0, 2] 0: Nam, 1: Nữ, 2: Khác")]
            public int? GioiTinh { get; set; }

            [Display(Name = "Ngày sinh")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            [DataType(DataType.Date)]
            public DateTime? NgaySinh { get; set; }

            [Display(Name = "Quyền hạn")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            [Range(0, 6, ErrorMessage = "{0} phải thuộc [0, 6] 0: Khách hàng, 1: Admin, 2: Nhân viên, 3: Vietnam Airlines, 4: Vietjet, 5: JetStar, 6: Bamboo")]
            public int Quyen { get; set; }
        }
    }
}