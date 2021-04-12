using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BanVeMayBay.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace Website_BanVeMayBay.Controllers
{
    public class QuanLyChuyenBayController : Controller
    {
        // GET: QuanLyChuyenBay
        QuanLyBanVeMayBayModel db = new QuanLyBanVeMayBayModel();
        [AuthorizationController(new int[] { 1 })]
        public ActionResult Index(int? _Page)
        {
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            ViewBag.Quyen = user.Quyen;
            int PageNumber = (_Page ?? 1);
            int PageSize = 10;
            List<ChuyenBay> lstCB = db.ChuyenBays.ToList().OrderBy(n => n.MaChuyenBay).ToList();
            return View(db.ChuyenBays.ToList().OrderBy(n => n.MaChuyenBay).ToPagedList(PageNumber, PageSize));
        }

        [AuthorizationController(new int[] { 3 })]
        public ActionResult IndexVNA(int? _Page)
        {
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            ViewBag.Quyen = user.Quyen;
            List<ChuyenBay> lstCB = db.ChuyenBays.Where(n => n.MaHangHangKhong == 1).ToList();
            int PageNumber = (_Page ?? 1);
            int PageSize = 10;
            return View(lstCB.OrderBy(n => n.MaChuyenBay).ToPagedList(PageNumber, PageSize));
        }

        [AuthorizationController(new int[] { 4 })]
        public ActionResult IndexVJ(int? _Page)
        {
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            ViewBag.Quyen = user.Quyen;
            List<ChuyenBay> lstCB = db.ChuyenBays.Where(n => n.MaHangHangKhong == 2).ToList();
            int PageNumber = (_Page ?? 1);
            int PageSize = 10;
            return View(lstCB.OrderBy(n => n.MaChuyenBay).ToPagedList(PageNumber, PageSize));
        }

        [AuthorizationController(new int[] { 5 })]
        public ActionResult IndexJET(int? _Page)
        {
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            ViewBag.Quyen = user.Quyen;
            List<ChuyenBay> lstCB = db.ChuyenBays.Where(n => n.MaHangHangKhong == 3).ToList();
            int PageNumber = (_Page ?? 1);
            int PageSize = 10;
            return View(lstCB.OrderBy(n => n.MaChuyenBay).ToPagedList(PageNumber, PageSize));
        }

        [AuthorizationController(new int[] { 6 })]
        public ActionResult IndexBAMBOO(int? _Page)
        {
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            ViewBag.Quyen = user.Quyen;
            List<ChuyenBay> lstCB = db.ChuyenBays.Where(n => n.MaHangHangKhong == 4).ToList();
            int PageNumber = (_Page ?? 1);
            int PageSize = 10;
            return View(lstCB.OrderBy(n => n.MaChuyenBay).ToPagedList(PageNumber, PageSize));
        }

        [HttpGet]
        [AuthorizationController(new int[] { 1, 3, 4, 5, 6 })]
        public ActionResult ThemMoi()
        {
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            ViewBag.Quyen = user.Quyen;
            ViewBag.MaHangHangKhong = new SelectList(db.HangHangKhongs.ToList(), "MaHangHangKhong", "TenHangHangKhong");
            ViewBag.SanBayDi = new SelectList(db.SanBays.ToList(), "MaSanBay", "TenSanBay");
            ViewBag.SanBayDen = new SelectList(db.SanBays.ToList(), "MaSanBay", "TenSanBay");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [AuthorizationController(new int[] { 1, 3, 4, 5, 6 })]
        public ActionResult ThemMoi(ChuyenBay _ChuyenBay, FormCollection fc)
        {
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            DateTime NgayDi = DateTime.ParseExact(fc["txtNgayDi"], "dd/MM/yyyy", null);
            DateTime NgayDen = DateTime.ParseExact(fc["txtNgayDen"], "dd/MM/yyyy", null);
            if (user.Quyen == 1)
            {
                _ChuyenBay.AnhBia = (_ChuyenBay.MaHangHangKhong == 1 ? "VNA.jpg" : (_ChuyenBay.MaHangHangKhong == 2 ? "VJ.jpg" : (_ChuyenBay.MaHangHangKhong == 3 ? "JET.jpg" : "BAMBOO.jpg")));
            }
            else if (user.Quyen == 3)
            {
                _ChuyenBay.AnhBia = "VNA.jpg";
                _ChuyenBay.MaHangHangKhong = 1;
            }
            else if (user.Quyen == 4)
            {
                _ChuyenBay.AnhBia = "VJ.jpg";
                _ChuyenBay.MaHangHangKhong = 2;
            }
            else if (user.Quyen == 5)
            {
                _ChuyenBay.AnhBia = "JET.jpg";
                _ChuyenBay.MaHangHangKhong = 3;
            }
            else if (user.Quyen == 6)
            {
                _ChuyenBay.AnhBia = "BAMBOO.jpg";
                _ChuyenBay.MaHangHangKhong = 4;
            }

            _ChuyenBay.ThoiGianDi = NgayDi;
            _ChuyenBay.ThoiGianDen = NgayDen;
            if (!ModelState.IsValid)
            {
                return View(_ChuyenBay);
            }
            db.ChuyenBays.Add(_ChuyenBay);
            db.SaveChanges();
            
            if (user.Quyen == 3)
                return RedirectToAction("IndexVNA");
            else if (user.Quyen == 4)
                return RedirectToAction("IndexVJ");
            else if (user.Quyen == 5)
                return RedirectToAction("IndexJET");
            else if (user.Quyen == 6)
                return RedirectToAction("IndexBAMBOO");
            else
                return RedirectToAction("Index");
        }

        [HttpGet]
        [AuthorizationController(new int[] { 1, 3, 4, 5, 6 })]
        public ActionResult ChinhSua(int _MaChuyenBay)
        {
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            ViewBag.Quyen = user.Quyen;
            ChuyenBay chuyenbay = db.ChuyenBays.SingleOrDefault(n => n.MaChuyenBay == _MaChuyenBay);
            if (chuyenbay == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaHangHangKhong = new SelectList(db.HangHangKhongs.ToList(), "MaHangHangKhong", "TenHangHangKhong", chuyenbay.MaHangHangKhong);
            ViewBag.SanBayDi = new SelectList(db.SanBays.ToList(), "MaSanBay", "TenSanBay", chuyenbay.SanBayDi);
            ViewBag.SanBayDen = new SelectList(db.SanBays.ToList(), "MaSanBay", "TenSanBay", chuyenbay.SanBayDen);
            return View(chuyenbay);
        }

        [HttpPost]
        [AuthorizationController(new int[] { 1, 3, 4, 5, 6 })]
        [ValidateInput(false)]
        public ActionResult ChinhSua(ChuyenBay _ChuyenBay)
        {
            ViewBag.MaHangHangKhong = new SelectList(db.HangHangKhongs.ToList(), "MaHangHangKhong", "TenHangHangKhong", _ChuyenBay.MaHangHangKhong);
            ViewBag.SanBayDi = new SelectList(db.SanBays.ToList(), "MaSanBay", "TenSanBay", _ChuyenBay.SanBayDi);
            ViewBag.SanBayDen = new SelectList(db.SanBays.ToList(), "MaSanBay", "TenSanBay", _ChuyenBay.SanBayDen);
            if (!ModelState.IsValid)
            {
                return View(_ChuyenBay);
            }
            db.Entry(_ChuyenBay).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            if (user.Quyen == 3)
                return RedirectToAction("IndexVNA");
            else if (user.Quyen == 4)
                return RedirectToAction("IndexVJ");
            else if (user.Quyen == 5)
                return RedirectToAction("IndexJET");
            else if (user.Quyen == 6)
                return RedirectToAction("IndexBAMBOO");
            else
                return RedirectToAction("Index");
        }

        [AuthorizationController(new int[] { 1, 3, 4, 5, 6 })]
        public ActionResult HienThi(int _MaChuyenBay)
        {
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            ViewBag.Quyen = user.Quyen;
            ChuyenBay chuyenbay = db.ChuyenBays.SingleOrDefault(n => n.MaChuyenBay == _MaChuyenBay);
            ViewBag.SanBayDi = db.SanBays.SingleOrDefault(n => n.MaSanBay == chuyenbay.SanBayDi).TenSanBay;
            ViewBag.SanBayDen = db.SanBays.SingleOrDefault(n => n.MaSanBay == chuyenbay.SanBayDen).TenSanBay;
            if (chuyenbay == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chuyenbay);
        }

        [HttpGet]
        [AuthorizationController(new int[] { 1, 3, 4, 5, 6 })]
        public ActionResult Xoa(int _MaChuyenBay)
        {
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            ViewBag.Quyen = user.Quyen;
            ChuyenBay chuyenbay = db.ChuyenBays.SingleOrDefault(n => n.MaChuyenBay == _MaChuyenBay);
            if (chuyenbay == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chuyenbay);
        }

        [HttpPost, ActionName("Xoa")]
        [ValidateInput(false)]
        [AuthorizationController(new int[] { 1, 3, 4, 5, 6 })]
        public ActionResult XacNhanXoa(int _MaChuyenBay)
        {
            ChuyenBay chuyenbay = db.ChuyenBays.SingleOrDefault(n => n.MaChuyenBay == _MaChuyenBay);
            List<ChiTietDonHang> lstChiTietDonHang = db.ChiTietDonHangs.Where(n => n.MaChuyenBay == _MaChuyenBay).ToList();
            if ((chuyenbay == null) || (lstChiTietDonHang.Count > 0))
            {
                if (chuyenbay == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                if (lstChiTietDonHang.Count > 0)
                {
                    return View(chuyenbay);
                }
            }
            db.ChuyenBays.Remove(chuyenbay);
            db.SaveChanges();
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            if (user.Quyen == 3)
                return RedirectToAction("IndexVNA");
            else if (user.Quyen == 4)
                return RedirectToAction("IndexVJ");
            else if (user.Quyen == 5)
                return RedirectToAction("IndexJET");
            else if (user.Quyen == 6)
                return RedirectToAction("IndexBAMBOO");
            else
                return RedirectToAction("Index");
        }
    }
}