using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBookMVC.Models.BO;

namespace ShopBookMVC.Controllers
{
    public class ChiTietHoaDonController : Controller
    {
        // GET: ChiTietHoaDon
        ChiTietHoaDonBO cthd = new ChiTietHoaDonBO();
        public ActionResult XoaChiTietHoaDon(long id)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Admin");
            if (cthd.XoaCTHD(id))
            {
                return Json(new { message = "Xóa thành công!", code = 1 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { message = "Xóa thất bại!", code = -1 }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}