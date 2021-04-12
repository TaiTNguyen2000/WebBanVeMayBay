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
    public class HomeController : Controller
    {
        QuanLyBanVeMayBayModel db = new QuanLyBanVeMayBayModel();

        public ActionResult Index(int? _Page)
        {
            int PageSize = 9;
            int PageNumber = (_Page ?? 1);
            return View(db.ChuyenBays.Where(n => n.CoTheDat > 0).OrderBy(n => n.MaChuyenBay).ToPagedList(PageNumber, PageSize));
        }

        //public PartialViewResult ChuyenBayMoiPartial()
        //{
        //    var lstCBMoi = db.ChuyenBays.Take(15).ToList();
        //    return PartialView(lstCBMoi);
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}