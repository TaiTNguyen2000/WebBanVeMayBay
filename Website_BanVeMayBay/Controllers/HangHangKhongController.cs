using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BanVeMayBay.Models;

namespace Website_BanVeMayBay.Controllers
{
    public class HangHangKhongController : Controller
    {
        // GET: HangHangKhong
        QuanLyBanVeMayBayModel db = new QuanLyBanVeMayBayModel();
        public ActionResult HangHangKhongPartial()
        {
            return PartialView(db.HangHangKhongs.Take(3).ToList());
        }

        public ViewResult ChuyenBayTheoHangHangKhong(int _MaHangHangKhong = 0)
        {
            HangHangKhong hhk = db.HangHangKhongs.SingleOrDefault(n => n.MaHangHangKhong == _MaHangHangKhong);
            if (hhk == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            List<ChuyenBay> lstCB = db.ChuyenBays.Where(n => n.MaHangHangKhong == _MaHangHangKhong && n.CoTheDat > 0).OrderBy(n => n.GiaBan).ToList();
            if (lstCB.Count == 0)
            {
                ViewBag.ChuyenBay = "Không có Chuyến bay nào thuộc Hãng hàng không này!";
            }
            return View(lstCB);
        }

        public ViewResult DanhMucHangHangKhong()
        {
            return View(db.HangHangKhongs.ToList());
        }
    }
}