using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BanVeMayBay.Models;

namespace Website_BanVeMayBay.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        QuanLyBanVeMayBayModel db = new QuanLyBanVeMayBayModel();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(FormCollection fc, NguoiDung _NguoiDung)
        {
            int TuKhoa1 = int.Parse(fc["cmbGioiTinh"]);
            if (!ModelState.IsValid)
            {
                return View();
            }
            NguoiDung user = db.NguoiDungs.SingleOrDefault(n => n.TaiKhoan == _NguoiDung.TaiKhoan);
            if (user != null)
            {
                ViewBag.ThongBao = "Tên Người dùng đã tồn tại";
                return View();
            }
            _NguoiDung.Quyen = 0;
            _NguoiDung.GioiTinh = TuKhoa1;
            db.NguoiDungs.Add(_NguoiDung);
            db.SaveChanges();
            Session["TaiKhoan"] = _NguoiDung;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection fc)
        {
            string textTaiKhoan = fc["txtTaiKhoan"].ToString();
            string textMatKhau = fc["txtMatKhau"].ToString();
            NguoiDung _NguoiDung = db.NguoiDungs.SingleOrDefault(n => n.TaiKhoan == textTaiKhoan && n.MatKhau == textMatKhau);
            if (_NguoiDung != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công";
                Session["TaiKhoan"] = _NguoiDung;
                Console.WriteLine(Session["TaiKhoan"]);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ThongBao = "Sai Tài khoản hoặc Mật khẩu";
            return View();
        }

        [HttpGet]
        public ActionResult ChinhSua(int _MaNguoiDung)
        {
            NguoiDung user = db.NguoiDungs.SingleOrDefault(n => n.MaNguoiDung == _MaNguoiDung);
            if (user == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(user);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(NguoiDung _NguoiDung)
        {
            if (!ModelState.IsValid)
            {
                return View(_NguoiDung);
            }
            db.Entry(_NguoiDung).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult HienThi(int _MaNguoiDung)
        {
            NguoiDung user = db.NguoiDungs.SingleOrDefault(n => n.MaNguoiDung == _MaNguoiDung);
            if (user == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.GioiTinh = user.GioiTinh;
            return View(user);
        }

        public ActionResult NguoiDungPartial()
        {
            if ((Session["TaiKhoan"] == null) || (Session["TaiKhoan"].ToString() == ""))
            {
                return PartialView();
            }
            ViewBag.NguoiDung = (NguoiDung)Session["TaiKhoan"];
            return PartialView();
        }

        public ActionResult DangXuat()
        {
            if ((Session["TaiKhoan"] == null) || (Session["TaiKhoan"].ToString() == ""))
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            Session["TaiKhoan"] = null;
            Session["GioHang"] = null;
            return RedirectToAction("Index", "Home");
        }
        
    }
}