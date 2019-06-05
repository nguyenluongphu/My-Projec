using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBookMVC.Models.BO;

namespace ShopBookMVC.Controllers
{
    public class HoaDonController : Controller
    {
        // GET: HoaDon
        HoaDonBO hd = new HoaDonBO();
        public ActionResult XoaHoaDon(long id)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Admin");
            if (hd.XoaHD(id))
            {
                return Json(new { message = "Xóa thành công!", code = 1 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { message = "Xóa thất bại!", code = -1 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult XacNhanThanhToan(long id)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Admin");
            if (hd.XacNhanThanhToan(id))
            {
                return Json(new { message = "Xác nhận thành công!", code = 1 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { message = "Xác nhận thất bại!", code = -1 }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}