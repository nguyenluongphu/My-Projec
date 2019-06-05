using ShopBookMVC.Models.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBookMVC.Controllers
{
    public class QuanLyDonDatHangController : Controller
    {
        KhachHangDatMuaBO kh = new KhachHangDatMuaBO();
        // GET: QuanLyDonDatHang
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Admin");
            if (Request.QueryString["Index"] != null)
            {
                Session["tk"] = null;
            }

            if (Request.Form["txtTimKiem"] == null)
            {
                if (Session["tk"] == null)
                {
                    var model = kh.getKhachHangDatMua(page, pageSize);
                    return View(model);
                }
                else
                {
                    string tk = Session["tk"].ToString();
                    var model = kh.getKhachHangDatMuaTK(tk, page, pageSize);
                    return View(model);
                }
            }
            else
            {
                string tk = Request.Form["txtTimKiem"];
                Session["tk"] = tk;
                var model = kh.getKhachHangDatMuaTK(tk, page, pageSize);
                return View(model);
            }
        }
        public ActionResult DanhSachKhachHangChuaThanhToan(int page = 1, int pageSize = 10)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Admin");
            if (Request.QueryString["Index"] != null)
            {
                Session["tk"] = null;
            }

            if (Request.Form["txtTimKiem"] == null)
            {
                if (Session["tk"] == null)
                {
                    var model = kh.getKhachHangChuaThanhToan(page, pageSize);
                    return View(model);
                }
                else
                {
                    string tk = Session["tk"].ToString();
                    var model = kh.getKhachHangChuaThanhToanTK(tk, page, pageSize);
                    return View(model);
                }
            }
            else
            {
                string tk = Request.Form["txtTimKiem"];
                Session["tk"] = tk;
                var model = kh.getKhachHangChuaThanhToanTK(tk, page, pageSize);
                return View(model);
            }
        }
        public ActionResult DanhSachKhachHangDaThanhToan(int page = 1, int pageSize = 10)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Admin");
            if (Request.QueryString["Index"] != null)
            {
                Session["tk"] = null;
            }

            if (Request.Form["txtTimKiem"] == null)
            {
                if (Session["tk"] == null)
                {
                    var model = kh.getKhachHangDaThanhToan(page, pageSize);
                    return View(model);
                }
                else
                {
                    string tk = Session["tk"].ToString();
                    var model = kh.getKhachHangDaThanhToanTK(tk, page, pageSize);
                    return View(model);
                }
            }
            else
            {
                string tk = Request.Form["txtTimKiem"];
                Session["tk"] = tk;
                var model = kh.getKhachHangDaThanhToanTK(tk, page, pageSize);
                return View(model);
            }
        }
    }
}