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
            return View(listSach);
        }
        public ActionResult XemChiTiet(int ms)
        {
            return View(ms);
        }
    }

}