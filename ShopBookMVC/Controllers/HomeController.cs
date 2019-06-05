using CaptchaMvc.HtmlHelpers;
using ShopBookMVC.Models;
using ShopBookMVC.Models.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBookMVC.Controllers
{
    public class HomeController : Controller
    {
        SachBO sach = new SachBO();
        LoaiBO loai = new LoaiBO();
        DangNhapBO dangNhap = new DangNhapBO();
        KhachHangBO kh = new KhachHangBO();
        public ActionResult Index(int page = 1, int pageSize = 8)
        {
            //lấy dữ lieuj từ form về


            if (Request.QueryString["Index"] != null)
            {
                Session["MaLoai"] = null;
                Session["tk"] = null;
            }

            if (Request.QueryString["MaLoai"] == null)
            {
                if (Session["MaLoai"] == null)
                {
                    if (Request.Form["txtTimKiem"] == null)
                    {
                        if (Session["tk"] == null)
                        {
                            var model = sach.getTatCaSach(page, pageSize);
                            return View(model);
                        }
                        else
                        {
                            string tk = Session["tk"].ToString();
                            var model = sach.getSachTK(tk, page, pageSize);
                            return View(model);
                        }
                    }
                    else
                    {
                        string tk = Request.Form["txtTimKiem"];
                        Session["tk"] = tk;
                        var model = sach.getSachTK(tk, page, pageSize);
                        return View(model);
                    }
                }
                else
                {
                    string maloai = Session["MaLoai"].ToString();
                    var model = sach.getTatCaSach(maloai, page, pageSize);
                    return View(model);
                }
            }
            else
            {
                Session["MaLoai"] = Request.QueryString["MaLoai"];
                string maloai = Request.QueryString["MaLoai"];
                var model = sach.getTatCaSach(maloai, page, pageSize);
                return View(model);
            }

        }
        [HttpPost]
        public ActionResult Login(DangNhap model)
        {
            //kiểm tra session count đã tồn tại chưa..nếu lần đầu thì chưa tồn tại
            //trường hợp lần đầu:
            int a = -1;
            if(Session["count"] == null)
            {
                string user = dangNhap.KiemTraDangNhap(model.tenDangNhap, model.matKhau);
                if (user != null)
                {
                    Session["Name"] = kh.getName(user);
                    Session["User"] = user;
                    return Json(new { message = "Đăng Nhập Thành Công!", code = 1 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Session["count"] = -1;
                    return Json(new { message = "Đăng Nhập Không Thành Công!", code = a }, JsonRequestBehavior.AllowGet);
                }
                
            }
            else // trường hợp đăng nhập sai từ 2 lần trở lên
            {
                //trường hợp đăng nhập sai < 3 lần
                if ((int)Session["count"] >= -3)
                {
                    string user = dangNhap.KiemTraDangNhap(model.tenDangNhap, model.matKhau);
                    if (user != null)
                    {
                        Session["Name"] = kh.getName(user);
                        Session["User"] = user;
                        Session["count"] = null;
                        return Json(new { message = "Đăng Nhập Thành Công!", code = 1 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        Session["count"] = (int)Session["count"] - 1;
                        return Json(new { message = "Đăng Nhập Không Thành Công!", code = -2 }, JsonRequestBehavior.AllowGet);
                    }
                }
                else //trường hợp đăng nhập sai trên 3 lần
                {
                    if (this.IsCaptchaValid("Validate your captcha"))
                    {
                        string user = dangNhap.KiemTraDangNhap(model.tenDangNhap, model.matKhau);
                        if (user != null)
                        {
                            Session["Name"] = kh.getName(user);
                            Session["User"] = user;
                            Session["count"] = null;
                            return Json(new { message = "Đăng Nhập Thành Công!", code = 1 }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { message = "Đăng Nhập Không Thành Công!", code = -4 }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { message = "Mã xác nhận không đúng!", code = -100 }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
        }
        public ActionResult Logout()
        {
            Session["Name"] = null;
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [AllowAnonymous]
        //[CaptchaValidation("CapktchaCode", "registerCapcha", "Mã xác nhận không đúng!")]
        public ActionResult Register(KhachHang khachHang)
        {
            DangNhapBO dangNhap = new DangNhapBO();
            KhachHangBO kh = new KhachHangBO();
            
            //string captcha = Request.Form["CaptchaInputText"];
            if (this.IsCaptchaValid("Validate your captcha"))
            {
                if (dangNhap.KiemTraDangNhap(khachHang.maKH) == false)
                {
                    if (kh.ThemKhachHang(khachHang))
                    {
                        return Json(new { message = "Đăng ký thành công! Mời bạn đăng nhập!", code = 1 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { message = "Đăng ký thất bại!", code = -1 }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { message = "Tài khoản đã tồn tại!", code = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { message = "Mã xác nhận không đúng!", code = -2 }, JsonRequestBehavior.AllowGet);
            }

            //}
            //else
            //{
            //    return Json(new { message = "Bạn chưa xác nhận!", code = -2 }, JsonRequestBehavior.AllowGet);
            //}
        }
        [HttpPost]
        public ActionResult UpdateInfo(KhachHang info)
        {
            if (Session["User"] == null)
                return RedirectToAction("Index", "Home");
            KhachHangBO kh = new KhachHangBO();
            if (kh.CapNhatThongTin(info))
            {
                return Json(new { message = "Cập nhật thông tin thành công!", code = 1 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { message = "Cập nhật thông tin thất bại!", code = -1 }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult UpdatePass()
        {
            if (Session["User"] == null)
                return RedirectToAction("Index", "Home");
            string user = Session["User"].ToString();
            string mkc = Request.Form["txtMatKhauCu1"];
            string mkm = Request.Form["txtMatKhauMoi1"];
            string xnmkm = Request.Form["txtXacNhanMatKhau"];

            KhachHangBO kh = new KhachHangBO();
            //int kt = kh.CapNhatMatKhau(user, mkm);
            if (kh.kiemTraMatKhau(user, mkc))
            {
                if (kh.CapNhatMatKhau(user, mkm))
                {
                    return Json(new { message = "Cập nhật mật khẩu thành công!", code = 1 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { message = "Cập nhật mật khẩu thất bại!", code = -1 }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { message = "Cập nhật mật khẩu thất bại!", code = 0 }, JsonRequestBehavior.AllowGet); // sai mật khẩu cũ
            }
        }
        [HttpPost]
        public ActionResult KiemTraTaiKhoan(string id)
        {
            //string kq = Request.QueryString["data"];
            //kq = id;
            DangNhapBO dangNhap = new DangNhapBO();
            if (dangNhap.KiemTraDangNhap(id))
            {
                return Json(new { message = "Tài khoản đã tồn tại!", code = 0 }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { message = "Tài khoản hợp lệ", code = 1 }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult MenuTraiPartial()
        {
            return PartialView();
        }
        public ActionResult SachMoiNhatPartial()
        {
            return PartialView(sach.getSachMoiNhat());
        }
        public ActionResult getLoaiPartial()
        {
            return PartialView(loai.getLoai());
        }
        public ActionResult slidePartial()
        {
            return PartialView();
        }
        public ActionResult LoginPartial()
        {
            return PartialView();
        }
        public ActionResult RegisterPartial()
        {
            return PartialView();
        }
        public ActionResult ThongTinKhachHangPartial()
        {
            string user = "";
            if (Session["User"] != null)
            {
                user = Session["User"].ToString();
                KhachHangBO kh = new KhachHangBO();
                return PartialView(kh.getKhachHang(user));
            }
            return PartialView(null);
        }
    }
}