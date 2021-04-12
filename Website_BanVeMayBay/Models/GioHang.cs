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
        public int _SoLuong { get; set; }
        public double _ThanhTien
        {
            get { return _SoLuong * _DonGia; }
        }
        public GioHang(int _MaChuyenBay)
        {
            this._MaChuyenBay = _MaChuyenBay;
            ChuyenBay cb = db.ChuyenBays.Single(n => n.MaChuyenBay == _MaChuyenBay);
            _AnhBia = cb.AnhBia;
            _NgayDi = cb.ThoiGianDi;
            _NgayDen = cb.ThoiGianDen;
            _DonGia = Convert.ToDouble(cb.GiaBan);
            _SoLuong = 1;
        }
    }
}