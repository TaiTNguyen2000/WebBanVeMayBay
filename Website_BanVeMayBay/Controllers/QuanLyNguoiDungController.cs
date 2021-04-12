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
    public class QuanLyNguoiDungController : Controller
    {
        // GET: QuanLyNguoiDung
        QuanLyBanVeMayBayModel db = new QuanLyBanVeMayBayModel();
        [AuthorizationController(new int[] { 1, 2})]
        public ActionResult Index(int? _Page)
        {
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            ViewBag.Quyen = user.Quyen;
            int PageNumber = (_Page ?? 1);
            int PageSize = 10;
            return View(db.NguoiDungs.ToList().OrderBy(n => n.MaNguoiDung).ToPagedList(PageNumber, PageSize));
        }

        [HttpGet]
        [AuthorizationController(new int[] { 1 })]
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
        [AuthorizationController(new int[] { 1 })]
        public ActionResult ChinhSua(NguoiDung _NguoiDung)
        {
            if (!ModelState.IsValid)
            {
                return View(_NguoiDung);
            }
            db.Entry(_NguoiDung).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AuthorizationController(new int[] { 1, 2 })]
        public ActionResult HienThi(int _MaNguoiDung)
        {
            NguoiDung user = (NguoiDung)Session["TaiKhoan"];
            ViewBag.Quyen = user.Quyen;
            NguoiDung users = db.NguoiDungs.SingleOrDefault(n => n.MaNguoiDung == _MaNguoiDung);
            ViewBag.GioiTinh = users.GioiTinh;
            if (users == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(users);
        }

        [HttpGet]
        [AuthorizationController(new int[] { 1})]
        public ActionResult Xoa(int _MaNguoiDung)
        {
            NguoiDung user = db.NguoiDungs.SingleOrDefault(n => n.MaNguoiDung == _MaNguoiDung);
            if (user == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(user);
        }

        [HttpPost, ActionName("Xoa")]
        [ValidateInput(false)]
        [AuthorizationController(new int[] { 1 })]
        public ActionResult XacNhanXoa(int _MaNguoiDung)
        {
            NguoiDung user = db.NguoiDungs.SingleOrDefault(n => n.MaNguoiDung == _MaNguoiDung);
            List<DonHang> lstDonHang = db.DonHangs.Where(n => n.MaNguoiDung == _MaNguoiDung).ToList();
            if ((user == null) || (lstDonHang.Count > 0) || (_MaNguoiDung == 1))
            {
                if (user == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                if ((lstDonHang.Count > 0) || (_MaNguoiDung == 1))
                {
                    return View(user);
                }
            }
            db.NguoiDungs.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}