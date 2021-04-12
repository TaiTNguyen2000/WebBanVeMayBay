using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BanVeMayBay.Models;
using PagedList;
using PagedList.Mvc;

namespace Website_BanVeMayBay.Controllers
{
    [AuthorizationController(new int[] { 1, 2})]
    public class QuanLyDonHangController : Controller
    {
        // GET: QuanLyDonHang
        QuanLyBanVeMayBayModel db = new QuanLyBanVeMayBayModel();
        public ActionResult Index(int? _Page)
        {
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            ViewBag.Quyen = user.Quyen;
            int PageNumber = (_Page ?? 1);
            int PageSize = 10;
            return View(db.DonHangs.ToList().OrderBy(n => n.MaDonHang).ToPagedList(PageNumber, PageSize));
        }

        public ActionResult ChiTiet(int _MaDonHang)
        {
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            ViewBag.Quyen = user.Quyen;
            ChiTietDonHang ctdh = db.ChiTietDonHangs.SingleOrDefault(n => n.MaDonHang == _MaDonHang);
            if (ctdh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ctdh);
        }

        [HttpGet]
        public ActionResult ChinhSua(int _MaDonHang)
        {
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            ViewBag.Quyen = user.Quyen;
            DonHang donhang = db.DonHangs.SingleOrDefault(n => n.MaDonHang == _MaDonHang);
            if (donhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(donhang);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(DonHang _DonHang)
        {
            if (!ModelState.IsValid)
            {
                return View(_DonHang);
            }
            db.Entry(_DonHang).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChinhSuaMaChuyenBay(int _MaDonHang)
        {
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            ViewBag.Quyen = user.Quyen;
            ChiTietDonHang ctdh = db.ChiTietDonHangs.SingleOrDefault(n => n.MaDonHang == _MaDonHang);
            if (ctdh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ctdh);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSuaMaChuyenBay(ChiTietDonHang _ChiTietDonHang)
        {
            if (!ModelState.IsValid)
            {
                return View(_ChiTietDonHang);
            }
            db.Entry(_ChiTietDonHang).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}