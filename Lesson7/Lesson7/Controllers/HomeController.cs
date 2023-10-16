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
                return RedirectToAction("ShowDepartment", "Home");
            }

            return View(dept);
        }
        public ActionResult ShowEmployee()
        {
            return View(db.tbl_Employee.ToList());
        }
        //public ActionResult ShowEmployee(int id = 0)
        //{

        //    var department = db.tbl_Deparment.SingleOrDefault(d => d.DeptId == id);

        //    if (department == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    var employees = db.tbl_Employee.Include("tbl_Deparment").Where(e => e.DeptId == id).ToList();

        //    ViewBag.Department = employees;
        //    ViewBag.EmployeeCount = employees.Count;
        //    ViewBag.Employees = employees;
        //    return View(department);
        //}
        public ActionResult ShowEmployeeDetails()
        {
            return View(db.tbl_Employee.ToList());
        }
        public ActionResult CreateEmployee()
        {
            ViewBag.DeptId = new SelectList(db.tbl_Deparment, "DeptId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(tbl_Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("ShowEmployee", "Home");
            }
            return View(employee);
        }
        public ActionResult DeleteEmployee(int id)
        {
            tbl_Employee employee = db.tbl_Employee.Single(d => d.Id == id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }
        [HttpPost, ActionName("DeleteEmployee")]
        public ActionResult DeleteEmployeeComfirm(int id)
        {
            tbl_Employee employee = db.tbl_Employee.Single(d => d.Id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            db.Entry(employee).State = System.Data.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("ShowEmployee");

        }
        public ActionResult UpdateEmployee(int id = 0)
        {
            tbl_Employee employee = db.tbl_Employee.Single(d => d.Id == id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(tbl_Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Employee.Attach(employee);
                db.Entry(employee).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ShowEmployee", "Home");
            }

            return View(employee);
        }
        public ActionResult EmployeeDetails(int id)
        {
            tbl_Employee employee = db.tbl_Employee.SingleOrDefault(d => d.Id == id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }
        public ActionResult ShowDepartmentEmployee()
        {
            
            return View(db.tbl_Employee.Include("tbl_Deparment"));
        }



    }
}