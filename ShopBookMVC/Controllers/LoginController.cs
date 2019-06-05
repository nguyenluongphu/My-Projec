using ShopBookMVC.Models.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ShopBookMVC.Controllers
{
    public class LoginController : Controller
    {
        DangNhapBO dn = new DangNhapBO();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

    }
}