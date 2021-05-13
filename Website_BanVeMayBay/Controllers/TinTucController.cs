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
    public class TinTucController : Controller
    {
        QuanLyBanVeMayBayModel db = new QuanLyBanVeMayBayModel();

        [HttpGet]
        public ActionResult Index(int? _Page)
        {
            List<TinTuc> lstTT = db.TinTucs.ToList();
            int pageNumber = (_Page ?? 1);
            int pageSize = 9;
            return View(lstTT.OrderByDescending(n => n.MaTinTuc).ToPagedList(pageNumber, pageSize));
        }

        public ViewResult XemTinTuc(int _MaTinTuc = 0)
        {
            TinTuc tt = db.TinTucs.SingleOrDefault(n => n.MaTinTuc == _MaTinTuc);
            if (tt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tt);
        }
    }
}