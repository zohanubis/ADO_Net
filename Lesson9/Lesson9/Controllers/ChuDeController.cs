﻿using System;
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
    public class ChuDeController : Controller
    {
        QLBSDataContext db = new QLBSDataContext();

        public ActionResult ChuDePartial()
        {
            return View(db.ChuDes.Take(7).ToList());
        }
        public ActionResult SachTheoChuDe (int MaCD)
        {
            var SCD = db.Saches.Where(s => s.MaChuDe == MaCD).ToList();
            if(SCD == null)
            {
                return HttpNotFound();  
            }
            return View(SCD);
        }
    }
}
