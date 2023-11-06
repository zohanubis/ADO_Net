using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.ComponentModel;
using Lesson9.Models;
namespace Lesson9.Controllers
{
    public class GioHangController : Controller
    {
        QLBSDataContext db = new QLBSDataContext();

        // GET: GioHang
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return View(lstGioHang);
        }
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(int ms, string strURL)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang SanPham = lstGioHang.Find(sp => sp.iMaSach == ms);
            if (SanPham == null) 
            {
                SanPham = new GioHang(ms);
                lstGioHang.Add(SanPham);
                return Redirect(strURL);
            }
            else
            {
                SanPham.iSoLuong++;
                return Redirect(strURL);

            }
        }
        private int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tsl = lstGioHang.Sum(sp => sp.iSoLuong);
            }
            return tsl;
        }
        private double TongThanhTien()
        {
            double ttt = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                ttt = lstGioHang.Sum(sp => sp.dThanhTien);
            }
            return ttt;
        }
        public ActionResult XoaALLGioHang()
        {
            List<GioHang> lstGioHang = LayGioHang();
            lstGioHang.Clear(); // Clear the shopping cart (remove all items)

            // Optionally, you can add a message to indicate that the cart is cleared.
            ViewBag.ClearMessage = "Your shopping cart is now empty";

            // Redirect back to the shopping cart or any other page
            return RedirectToAction("GioHang", "GioHang");
        }

        public ActionResult XoaGioHang(int MaSP)
        {
            List<GioHang> lstGioHang = LayGioHang();

            GioHang sp = lstGioHang.Single(s => s.iMaSach == MaSP);

            if(sp != null)
            {
                lstGioHang.RemoveAll(s => s.iMaSach == MaSP);
                return RedirectToAction("GioHang", "GioHang");
            }
            if(lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang", "GioHang");
        }
        public ActionResult capNhatGioHang(int MaSp, FormCollection f)
        {
            //lấy giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //kiểm tra xem sách cần cập nhật có trong giá hàng không
            GioHang sp = lstGioHang.Single(s=>s.iMaSach==MaSp);
            //nếu có thì tiến hành cập nhật
            if (sp != null)
            {
                sp.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang", "GioHang");
        }
    }
}