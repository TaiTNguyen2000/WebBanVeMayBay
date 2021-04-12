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
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        QuanLyBanVeMayBayModel db = new QuanLyBanVeMayBayModel();
      
        [HttpPost]
        public ActionResult KetQuaTimKiemSB(FormCollection fc, int? _Page)
        {
            int TuKhoa1 = int.Parse(fc["cmbTimKiemDi"]);
            ViewBag.TuKhoa1 = TuKhoa1;
            int TuKhoa2 = int.Parse(fc["cmbTimKiemDen"]);
            ViewBag.TuKhoa2 = TuKhoa2;
            DateTime NgayDi = DateTime.ParseExact(fc["txtNgayDi"], "dd/MM/yyyy", null);
            List<ChuyenBay> lstCB = db.ChuyenBays.Where(n => n.SanBayDi == (TuKhoa1) && n.SanBayDen == (TuKhoa2)
            && n.ThoiGianDi == NgayDi
            && n.CoTheDat > 0).ToList();
            int pageNumber = (_Page ?? 1);
            int pageSize = 9;
            if (lstCB.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy Chuyến bay bạn yêu cầu !";
                return View(lstCB.ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstCB.Count.ToString() + " chuyến bay :";
            return View(lstCB.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult KetQuaTimKiemSB(string _TuKhoa, int? _Page)
        {
            ViewBag.TuKhoa = _TuKhoa;
            List<ChuyenBay> lstCB = db.ChuyenBays.Where(n => n.CoTheDat > 0).ToList();
            int pageNumber = (_Page ?? 1);
            int pageSize = 9;
            if (lstCB.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy Chuyến bay bạn yêu cầu !";
                return View(db.ChuyenBays.ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstCB.Count.ToString() + " chuyến bay :";
            return View(lstCB.ToPagedList(pageNumber, pageSize));
        }
    }
}