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
    public class QuanLyTinTucController : Controller
    {
        QuanLyBanVeMayBayModel db = new QuanLyBanVeMayBayModel();
        [AuthorizationController(new int[] { 1 })]
        // GET: QuanLyTinTuc
        public ActionResult Index(int? _Page)
        {
            int PageNumber = (_Page ?? 1);
            int PageSize = 10;
            return View(db.TinTucs.ToList().OrderByDescending(n => n.MaTinTuc).ToPagedList(PageNumber, PageSize));
        }

        [HttpGet]
        [AuthorizationController(new int[] { 1 })]
        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [AuthorizationController(new int[] { 1 })]
        public ActionResult ThemMoi(TinTuc _TinTuc, HttpPostedFileBase FileUpload)
        {
            if (!ModelState.IsValid)
            {
                return View(_TinTuc);
            }
            var FileName = Path.GetFileName(FileUpload.FileName);
            var DuongDan = Path.Combine(Server.MapPath("~/HinhAnh"), FileName);
            if (!System.IO.File.Exists(DuongDan))
            {
                FileUpload.SaveAs(DuongDan);
            }
            _TinTuc.Hinh = FileUpload.FileName;
            db.TinTucs.Add(_TinTuc);
            db.SaveChanges();
            
                return RedirectToAction("Index");
        }

        [HttpGet]
        [AuthorizationController(new int[] { 1 })]
        public ActionResult Xoa(int _MaTinTuc)
        {
            TinTuc tintuc = db.TinTucs.SingleOrDefault(n => n.MaTinTuc == _MaTinTuc);
            if (tintuc == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tintuc);
        }

        [HttpPost, ActionName("Xoa")]
        [ValidateInput(false)]
        [AuthorizationController(new int[] { 1 })]
        public ActionResult XacNhanXoa(int _MaTinTuc)
        {
            TinTuc tintuc = db.TinTucs.SingleOrDefault(n => n.MaTinTuc == _MaTinTuc);
            if ((tintuc == null))
            {
                    Response.StatusCode = 404;
                    return null;
            }
            db.TinTucs.Remove(tintuc);
            db.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}