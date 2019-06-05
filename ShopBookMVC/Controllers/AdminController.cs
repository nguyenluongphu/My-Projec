using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBookMVC.Models;
using ShopBookMVC.Models.BO;

namespace ShopBookMVC.Controllers
{
    public class AdminController : Controller
    {
        DangNhapBO dn = new DangNhapBO();
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["admin"] == null)
                return View("Login");
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(DangNhap admin)
        {
            if (ModelState.IsValid)
            {
                if (dn.KiemTraDangNhapAdmin(admin))
                {
                    Session["admin"] = "Admin";
                    return RedirectToAction("Index");
                }else
                {
                    ViewBag.ThongBao = "Đăng nhập thất bại!";
                    return View("Login");
                }
            }
            else
            {
                ViewBag.ThongBao = "Đăng nhập thất bại!";
                return View("Login");
            }
            
        }
        public ActionResult Logout()
        {
            Session["admin"] = null;
            return View("Login");
        }
        public ActionResult LuuFie()
        {
            HttpPostedFileBase f = Request.Files["tf"];
            if (string.IsNullOrEmpty(f.FileName)) return View("UpFile");
            string path = Server.MapPath(@"\image_sach\" + f.FileName);
            f.SaveAs(path);
            ViewBag.kq = "Up thanh cong";
            return View("Index");
        }
    }
}