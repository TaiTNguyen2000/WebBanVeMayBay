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
    [AuthorizationController(new int[] { 1 })]
    public class QuanLyHangHangKhongController : Controller
    {
        //GET: QuanLyChuDe
        QuanLyBanVeMayBayModel db = new QuanLyBanVeMayBayModel();
        public ActionResult Index(int? _Page)
        {
            int PageNumber = (_Page ?? 1);
            int PageSize = 10;
            return View(db.HangHangKhongs.ToList().OrderBy(n => n.MaHangHangKhong).ToPagedList(PageNumber, PageSize));
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(HangHangKhong _HangHangKhong)
        {
            db.HangHangKhongs.Add(_HangHangKhong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChinhSua(int _MaHangHangKhong)
        {
            HangHangKhong hhk = db.HangHangKhongs.SingleOrDefault(n => n.MaHangHangKhong == _MaHangHangKhong);
            if (hhk == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(hhk);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(HangHangKhong _HangHangKhong)
        {
            if (!ModelState.IsValid)
            {
                return View(_HangHangKhong);
            }
            db.Entry(_HangHangKhong).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Xoa(int _MaHangHangKhong)
        {
            HangHangKhong hhk = db.HangHangKhongs.SingleOrDefault(n => n.MaHangHangKhong == _MaHangHangKhong);
            if (hhk == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(hhk);
        }

        [HttpPost, ActionName("Xoa")]
        [ValidateInput(false)]
        public ActionResult XacNhanXoa(int _MaHangHangKhong)
        {
            HangHangKhong hhk = db.HangHangKhongs.SingleOrDefault(n => n.MaHangHangKhong == _MaHangHangKhong);
            List<ChuyenBay> lstCB = db.ChuyenBays.Where(n => n.MaHangHangKhong == _MaHangHangKhong).ToList();
            if ((hhk == null) || (lstCB.Count > 0))
            {
                if (hhk == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                if (lstCB.Count > 0)
                {
                    return View(hhk);
                }
            }
            db.HangHangKhongs.Remove(hhk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}