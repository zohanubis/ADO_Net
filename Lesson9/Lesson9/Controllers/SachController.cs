using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using Lesson9.Models;

namespace Lesson9.Controllers
{
    public class SachController : Controller
    {
        QLBSDataContext db = new QLBSDataContext();

        // GET: Sach
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SachPartial()
        {
            var listSach = db.Saches.OrderBy(s => s.TenSach).ToList();
            return View("SachPartial", listSach);
        }

        public ActionResult XemChiTiet(int ms)
        {
            Sach sach = db.Saches.Single(s => s.MaSach == ms);
            if(sach == null) { return HttpNotFound(); }
            return View(sach);
        }
        public ActionResult SachTheoCD(int MaCD)
        {
            var ListSach = db.Saches.Where(s => s.MaChuDe == MaCD).OrderBy(s => s.GiaBan).ToList();
            if(ListSach.Count == 0)
            {
                ViewBag.TB = "Không có sách thuộc chủ đề này";
            }
            return View(ListSach);
        }
        public ActionResult SachTheoNXB(int MaNXB)
        {
            var ListSach = db.Saches.Where(s => s.MaNXB == MaNXB).OrderBy(s => s.GiaBan).ToList();
            if(ListSach.Count == 0)
            {
                ViewBag.TB = "Không có sách theo nhà xuất bản này";
            }
            return View(ListSach);
        }
    }

}