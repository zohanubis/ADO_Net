using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lesson7.Models;

namespace Lesson7.Controllers
{
    public class HomeController : Controller
    {
        QL_NhanSuNEntitie db = new QL_NhanSuNEntitie();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowDepartment()
        {
            return View(db.tbl_Deparment.ToList());
        }
        public ActionResult CreateDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDepartment(tbl_Deparment dept)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Deparment.Add(dept);
                db.SaveChanges();
                return RedirectToAction("ShowDepartment", "Home");
            }
            return View(dept);
        }
        public ActionResult UpdateDepartment(int id = 0)
        {
            tbl_Deparment dept = db.tbl_Deparment.Single(d => d.DeptId == id);

            if (dept == null)
            {
                return HttpNotFound();
            }

            return View(dept);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(tbl_Deparment dept)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Deparment.Attach(dept);
                db.Entry(dept).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ShowDepartment","Home");
            }

            return View(dept);
        }
        public ActionResult ShowEmployee(int id = 0)
        {

            var department = db.tbl_Deparment.SingleOrDefault(d => d.DeptId == id);

            if (department == null)
            {
                return HttpNotFound();
            }

            var employees = db.tbl_Employee.Include("tbl_Deparment").Where(e => e.DeptId == id).ToList();

            ViewBag.Department = employees;
            ViewBag.EmployeeCount = employees.Count;
            ViewBag.Employees = employees;
            return View(department);
        }
    }
}