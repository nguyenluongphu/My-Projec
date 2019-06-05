using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBookMVC.Models;
using ShopBookMVC.Models.BO;

namespace ShopBookMVC.Controllers
{
    public class LoaiController : Controller
    {
        SachBO sach = new SachBO();
        LoaiBO loai = new LoaiBO();
        // GET: Loai
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
                    var model = loai.getTatCaLoai(page, pageSize);
                    return View(model);
                }
                else
                {
                    string tk = Session["tk"].ToString();
                    var model = loai.getLoaiTK(tk, page, pageSize);
                    return View(model);
                }
            }
            else
            {
                string tk = Request.Form["txtTimKiem"];
                Session["tk"] = tk;
                var model = loai.getLoaiTK(tk, page, pageSize);
                return View(model);
            }
        }
        public ActionResult ThemLoai()
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Admin");
            return View();
        }
        public ActionResult ThemMoiLoai(Loai model)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Admin");
            int result = loai.ThemLoai(model);
            if (result == 1)
            {
                ViewBag.ThongBao = "Thêm thành công!";
                return RedirectToAction("Index");
            }
            else if (result == 0)
            {
                ViewBag.ThongBao = "Thêm thất bại!";
                return View("ThemLoai");
            }
            else
            {
                ViewBag.ThongBao = "Trùng mã loại!";
                return View("ThemLoai");
            }
        }
        public ActionResult XoaLoai(string id)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Admin");
            if (loai.XoaLoai(id))
            {
                return Json(new { message = "Xóa thành công!", code = 1 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { message = "Xóa thất bại!", code = -1 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ChiTiet(string id)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Admin");
            Loai l = loai.getMotLoai(id);
            return View(l);
        }
        public ActionResult CapNhat(Loai model)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Admin");
            if (loai.CapNhatLoai(model))
            {
                ViewBag.ThongBao = "Cập nhật thành công!";
                return RedirectToAction("Index");
            }
            ViewBag.ThongBao = "Cập nhật thất bại!";
            return RedirectToAction("ChiTiet");
        }
    }
}