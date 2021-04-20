using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BanVeMayBay.Models;

namespace Website_BanVeMayBay.Controllers
{
    public class GioHangController : Controller
    {

        QuanLyBanVeMayBayModel db = new QuanLyBanVeMayBayModel();

        #region Gio hang
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        public ActionResult ThemGioHang(int __MaChuyenBay, string strURL)
        {
            ChuyenBay cb = db.ChuyenBays.SingleOrDefault(n => n.MaChuyenBay == __MaChuyenBay);
            if (cb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang _GioHang = lstGioHang.Find(n => n._MaChuyenBay == __MaChuyenBay);
            if (_GioHang == null)
            {
                _GioHang = new GioHang(__MaChuyenBay);
                lstGioHang.Add(_GioHang);
                return RedirectToAction("Index", "Home");
                //return Redirect(strURL);
            }
            else
            {
                    _GioHang._SoLuong++;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult CapNhatGioHang(int __MaChuyenBay, FormCollection fc)
        {
            ChuyenBay cb = db.ChuyenBays.SingleOrDefault(n => n.MaChuyenBay == __MaChuyenBay);
            if (cb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang giohang = lstGioHang.SingleOrDefault(n => n._MaChuyenBay == __MaChuyenBay);
            if (giohang != null)
            {
                int SoLuong = Convert.ToInt32(fc["txtSoLuong"].ToString());
                if (SoLuong > 0)
                {
                        giohang._SoLuong = SoLuong;
                }
                else
                {
                    lstGioHang.RemoveAll(n => n._MaChuyenBay == __MaChuyenBay);
                }
                if (lstGioHang.Count == 0)
                {
                    Session["GioHang"] = null;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("GioHang");
                }
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult XoaGioHang(int __MaChuyenBay)
        {
            ChuyenBay cb = db.ChuyenBays.SingleOrDefault(n => n.MaChuyenBay == __MaChuyenBay);
            if (cb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang giohang = lstGioHang.SingleOrDefault(n => n._MaChuyenBay == __MaChuyenBay);
            if (giohang != null)
            {
                lstGioHang.RemoveAll(n => n._MaChuyenBay == __MaChuyenBay);
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }

        private int TongSoLuong()
        {
            int _TongsoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                _TongsoLuong = lstGioHang.Sum(n => n._SoLuong);
            }
            return _TongsoLuong;
        }

        private double TongTien()
        {
            double _TongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                _TongTien = lstGioHang.Sum(n => n._ThanhTien);
            }
            return _TongTien;
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            return PartialView();
        }

        public ActionResult GioHangTongTien()
        {
            if (TongTien() <= 0)
            {
                return PartialView();
            }
            ViewBag.TongTien = TongTien();
            return PartialView();
        }

        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        #endregion

        #region Dat hang
        [HttpPost]
        public ActionResult DatHang()
        {
            if ((Session["TaiKhoan"] == null) || (Session["TaiKhoan"].ToString() == ""))
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            DonHang dh = new DonHang();
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            List<GioHang> gh = LayGioHang();
            dh.MaNguoiDung = user.MaNguoiDung;
            dh.DaThanhToan = Convert.ToInt32(TongTien());
            dh.TinhTrang = 0;
            dh.NgayDat = DateTime.Now;
            //dh.NgayGiao = DateTime.Now;
            db.DonHangs.Add(dh);
            db.SaveChanges();
            foreach (var item in gh)
            {
                ChiTietDonHang ctdh = new ChiTietDonHang();
                ctdh.MaDonHang = dh.MaDonHang;
                ctdh.MaChuyenBay = item._MaChuyenBay;
                ctdh.SoLuong = item._SoLuong;
                ctdh.DonGia = item._DonGia.ToString();
                db.ChiTietDonHangs.Add(ctdh);

                ChuyenBay cb = db.ChuyenBays.SingleOrDefault(n => n.MaChuyenBay == item._MaChuyenBay);
            }
            db.SaveChanges();
            Session["GioHang"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult HoaDon()
        {
            if ((Session["TaiKhoan"] == null) || (Session["TaiKhoan"].ToString() == ""))
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.NguoiDung = (NguoiDung)Session["TaiKhoan"];
            return View(lstGioHang);
        }
        #endregion
    }
}