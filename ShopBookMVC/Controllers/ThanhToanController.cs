using ShopBookMVC.Models.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBookMVC.Controllers
{
    public class ThanhToanController : Controller
    {
        PhuongThucThanhToanBO PTTT = new PhuongThucThanhToanBO();
        // GET: ThanhToan
        public ActionResult Index()
        {
            ViewBag.lstPTTT = PTTT.getAll();
            return View();
        }
    }
}