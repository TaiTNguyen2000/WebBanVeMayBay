using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BanVeMayBay.Models;

namespace Website_BanVeMayBay.Controllers
{
    public class ChuyenBayController : Controller
    {
        // GET: ChuyenBay
        QuanLyBanVeMayBayModel db = new QuanLyBanVeMayBayModel();
        //public PartialViewResult ChuyenBayMoiPartial()
        //{
        //    var lstCBMoi = db.ChuyenBays.Where(n => n.CoTheDat > 0).Take(3).ToList();
        //    return PartialView(lstCBMoi);
        //}

        public PartialViewResult SanBayPartial()
        {
            return PartialView();
        }

        public ViewResult XemChitiet(int _MaChuyenBay = 0)
        {
            ChuyenBay cb = db.ChuyenBays.SingleOrDefault(n => n.MaChuyenBay == _MaChuyenBay);
            if (cb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.LoaiVe = cb.LoaiChuyenBay;
            ViewBag.TenHangHangKhong = db.HangHangKhongs.Single(n => n.MaHangHangKhong == cb.MaHangHangKhong).TenHangHangKhong;
            ViewBag.SanBayDi = db.SanBays.SingleOrDefault(n => n.MaSanBay == cb.SanBayDi).TenSanBay;
            ViewBag.SanBayDen = db.SanBays.SingleOrDefault(n => n.MaSanBay == cb.SanBayDen).TenSanBay;
            return View(cb);
        }
    }
}