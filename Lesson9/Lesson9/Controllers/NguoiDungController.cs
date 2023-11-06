using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lesson9.Models;

namespace Lesson9.Controllers
{
    public class NguoiDungController : Controller
    {
        QLBSDataContext db = new QLBSDataContext();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KhachHang kh, FormCollection f)
        {
            var hoTen = f["HoTenKH"];
            var tenDN = f["TenDN"];
            var matKhau = f["MatKhau"];
            var reMatKhau = f["ReMatKhau"];
            var dienThoai = f["DienThoai"];
            var ngaySinh = String.Format("{0:MM/DD/YYYY}", f["NgaySinh"]);
            var email = f["email"];
            var diaChi = f["DiaChi"];
            if (String.IsNullOrEmpty(hoTen))
            {
                ViewBag["Loi1"] = "Họ Tên Không Được Bỏ Trống";
            }
            if (String.IsNullOrEmpty(tenDN))
            {
                ViewBag["Loi2"] = "Tên Đăng Nhập Không Được Bỏ Trống";
            }
            if (String.IsNullOrEmpty(matKhau))
            {
                ViewBag["Loi3"] = "Vui Lòng Nhập Mật Khẩu";
            }
            if (String.IsNullOrEmpty(reMatKhau))
            {
                ViewBag["Loi4"] = "Vui Lòng Nhập Mật Khẩu";
            }
            if (String.IsNullOrEmpty(dienThoai))
            {
                ViewBag["Loi5"] = "Vui Lòng Nhập Số Điện Thoại";
            }
            kh.HoTen = hoTen;
            kh.TaiKhoan = tenDN;
            kh.MatKhau = matKhau;
            kh.NgaySinh = DateTime.Parse(ngaySinh);
            kh.DiaChi = diaChi;
            kh.Email = email;
            db.KhachHangs.InsertOnSubmit(kh);
            db.SubmitChanges();
            return RedirectToAction("DangNhap", "NguoiDung");
        }
        [HttpPost]
        public ActionResult DangNhap()
        {
            return View();
        }
    }
}