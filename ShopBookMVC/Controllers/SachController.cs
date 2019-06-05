using ShopBookMVC.Models;
using ShopBookMVC.Models.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteBanHangMVC.Controllers
{
    public class SachController : Controller
    {
        SachBO sach = new SachBO();
        LoaiBO loai = new LoaiBO();
        // GET: Sach
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Admin");

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

        [ValidateInput(false)]
        public ActionResult ThemSach()
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Admin");
            setViewBag();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoiSach(Sach s)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Admin");
            int result = sach.ThemSach(s);
            if (result == 1)
            {
                ViewBag.ThongBao = "Thêm sách thành công!";
                return RedirectToAction("Index", "Sach");
            }
            else if (result == 0)
            {
                setViewBag();
                ViewBag.ThongBao = "Thêm sách thất bại!";
                return View("ThemSach");
            }
            else
            {
                setViewBag();
                ViewBag.ThongBao = "Mã sách đã trùng!";
                return View("ThemSach");
            }
            //setViewBag();
            ////ViewBag.ThongBao = "Mã sách đã trùng!";
            //return View();
        }
        public void setViewBag(string maLoai = null)
        {
            ViewBag.maLoai = new SelectList(loai.getLoai(), "maloai","tenloai", maLoai);
        }
        [HttpPost]
        public string UpFile(HttpPostedFileBase file)
        {
            //validate:
            //xử lý upfile
            file.SaveAs(Server.MapPath("~/image_sach/" + file.FileName));
            return "image_sach/" + file.FileName;
        }
        public ActionResult XoaSach(string id)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Admin");
            if (sach.XoaSach(id))
            {
                return Json(new { message = "Xóa thành công!", code = 1 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { message = "Xóa thất bại!", code = -1 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ChiTietSach(string id)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Admin");
            if (id != null)
            {
                Sach s = sach.getMotSach(id);
                setViewBag();
                return View(s);
            }
            return RedirectToAction("Index");
        }
        [ValidateInput(false)]
        public ActionResult CapNhatSach(Sach s)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Admin");
            if (sach.CapNhatSach(s))
            {
                return RedirectToAction("Index", "Sach");
            }
            ViewBag.ThongBao = "Cập nhật thất bại!";
            setViewBag();
            return RedirectToAction("ChiTietSach");
        }

    }
}