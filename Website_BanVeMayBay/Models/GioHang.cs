using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website_BanVeMayBay.Models
{
    public class GioHang
    {
        QuanLyBanVeMayBayModel db = new QuanLyBanVeMayBayModel();
        public int _MaChuyenBay { get; set; }
        public string _AnhBia { get; set; }
        public double _DonGia { get; set; }
        public DateTime? _NgayDi { get; set; }
        public DateTime? _NgayDen { get; set; }
        public int _SoLuongNguoiLon { get; set; }
        public int _SoLuongTreEm { get; set; }
        public double _ThanhTien
        {
            get { return (_SoLuongNguoiLon + _SoLuongTreEm) * _DonGia; }
        }
        public GioHang(int _MaChuyenBay)
        {
            this._MaChuyenBay = _MaChuyenBay;
            ChuyenBay cb = db.ChuyenBays.Single(n => n.MaChuyenBay == _MaChuyenBay);
            _AnhBia = cb.AnhBia;
            _NgayDi = cb.ThoiGianDi;
            if (cb.ThoiGianDen == null)
                _NgayDen = null;
            else
                _NgayDen = cb.ThoiGianDen;
            _DonGia = Convert.ToDouble(cb.GiaBan);
            _SoLuongNguoiLon = 1;
        }
    }
}