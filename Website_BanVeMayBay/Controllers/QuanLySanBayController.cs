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
    [AuthorizationController(new int[] { 1})]
    public class QuanLySanBayController : Controller
    {
        // GET: QuanLySanBay
        QuanLyBanVeMayBayModel db = new QuanLyBanVeMayBayModel();
        public ActionResult Index(int? _Page)
        {
            int PageNumber = (_Page ?? 1);
            int PageSize = 10;
            return View(db.SanBays.ToList().OrderBy(n => n.MaSanBay).ToPagedList(PageNumber, PageSize));
        }

        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(SanBay _NhaXuatBan)
        {
            db.SanBays.Add(_NhaXuatBan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChinhSua(int _MaSanBay)
        {
            SanBay sanbay = db.SanBays.SingleOrDefault(n => n.MaSanBay == _MaSanBay);
            if (sanbay == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanbay);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(SanBay _NhaXuatBan)
        {
            if (!ModelState.IsValid)
            {
                return View(_NhaXuatBan);
            }
            db.Entry(_NhaXuatBan).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Xoa(int _MaSanBay)
        {
            SanBay sanbay = db.SanBays.SingleOrDefault(n => n.MaSanBay == _MaSanBay);
            if (sanbay == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanbay);
        }

        [HttpPost, ActionName("Xoa")]
        [ValidateInput(false)]
        public ActionResult XacNhanXoa(int _MaSanBay)
        {
            SanBay sanbay = db.SanBays.SingleOrDefault(n => n.MaSanBay == _MaSanBay);
            List<ChuyenBay> lstCB = db.ChuyenBays.Where(n => n.SanBayDi == _MaSanBay || n.SanBayDen == _MaSanBay).ToList();
            if ((sanbay == null) || (lstCB.Count > 0))
            {
                if (sanbay == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                if (lstCB.Count > 0)
                {
                    return View(sanbay);
                }
            }
            db.SanBays.Remove(sanbay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult HienThi(int _MaSanBay)
        {
            SanBay sanbay = db.SanBays.SingleOrDefault(n => n.MaSanBay == _MaSanBay);
            if (sanbay == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanbay);
        }
    }
}