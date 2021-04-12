using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BanVeMayBay.Models;

namespace Website_BanVeMayBay.Controllers
{
    public class SanBayController : Controller
    {
        // GET: SanBay
        QuanLyBanVeMayBayModel db = new QuanLyBanVeMayBayModel();
        public PartialViewResult SanBayPartial()
        {
            return PartialView(db.SanBays.OrderBy(sanbay => sanbay.MaSanBay).ToList());
        }
        
    }
}