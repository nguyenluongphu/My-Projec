using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBookMVC.Models;
using ShopBookMVC.Models.BO;

namespace ShopBookMVC.Controllers
{
    public class GioHangController : Controller
    {
        //lấy giỏ hàng
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = null;
            lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        //Thêm vào giỏ hàng

        // GET: GioHang
        public ActionResult XemGioHang()
        {
            List<GioHang> gh = LayGioHang();
            if (gh.Count() <= 0)
            {
                ViewBag.ThongBao = "Bạn không có hàng nào trong giỏ!";
            }
            long tt = 0;
            foreach (GioHang gio in gh)
            {
                tt += gio.thanhTien;
            }
            ViewBag.TongTien = tt;
            return View(gh);

        }
        public ActionResult LichSuMuaHang(int page = 1, int pageSize = 6)
        {
            HoaDonBO hd = new HoaDonBO();
            if (Session["User"] == null)
                return RedirectToAction("Index", "Home");
            else
            {
                string maKH = Session["User"].ToString();
                IEnumerable<GioHang> gh = hd.getHang(maKH, page, pageSize);
                return View(gh);
            }
            

        }
        //để thêm vào giỏ hàng
        public ActionResult ThemGioHang(string maSach, string tenSach, string gia, string anh, string stUrl)
        {
            //lấy ra giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //kiểm tra xem hàng này đã tồn tại trong giỏ chưa
            var gh = lstGioHang.SingleOrDefault(p => p.maSach.Equals(maSach));
            //trường hợp đã tồn tại thì cộng thêm số lượng
            if (gh != null)
            {
                gh.soLuong++;
                gh.thanhTien = gh.gia * gh.soLuong;
            }
            else
            {
                GioHang gio = new GioHang();
                gio.maSach = maSach;
                gio.tenSach = tenSach;
                gio.gia = long.Parse(gia);
                gio.soLuong = 1;
                gio.anh = anh;
                gio.thanhTien = gio.gia * gio.soLuong;
                lstGioHang.Add(gio);
            }
            //Session["GioHang"] = lstGioHang;
            return Redirect(stUrl);
        }
        public ActionResult GioHangPartial()
        {

            if (Session["GioHang"] == null)
            {
                ViewBag.SoLuongHang = 0;
                ViewBag.TongTien = 0;
            }
            else
            {
                List<GioHang> lst = Session["GioHang"] as List<GioHang>;
                long soluong = lst.Count();
                ViewBag.SoLuongHang = soluong;
                long tongTien = 0;
                foreach (GioHang item in lst)
                {
                    tongTien += item.thanhTien;
                }
                ViewBag.TongTien = tongTien;
            }
            return PartialView();
        }
        [HttpPost]
        public ActionResult CapNhatSoLuong(FormCollection f)
        {
            //string masach = Request.QueryString["ma"];
            long soluong = long.Parse(f["txtsoluong"].ToString());
            string masach = f["txtmasach"].ToString();

            List<GioHang> lst = Session["GioHang"] as List<GioHang>;
            foreach (GioHang item in lst)
            {
                if (item.maSach.Equals(masach))
                {
                    if (soluong == 0)
                    {
                        lst.Remove(item);
                        break;
                    }
                    item.soLuong = soluong;
                    item.thanhTien = item.soLuong * item.gia;
                    break;
                }
            }
            return RedirectToAction("XemGioHang", "GioHang");
        }
        public ActionResult TraHang(int idTra, string maSach)
        {
            if (Session["GioHang"] != null)
            {
                if (idTra == 1)
                {
                    List<GioHang> lst = Session["GioHang"] as List<GioHang>;
                    foreach (GioHang item in lst)
                    {
                        if (item.maSach.Equals(maSach))
                        {
                            lst.Remove(item);
                            break;
                        }
                    }
                }
                else
                {
                    Session["GioHang"] = null;
                }

            }
            return RedirectToAction("XemGioHang", "GioHang");
        }
        [HttpPost]
        public JsonResult TraMotHang(string id)
        {
            bool result = false;
            if (Session["GioHang"] != null)
            {
                List<GioHang> lst = Session["GioHang"] as List<GioHang>;
                foreach (GioHang item in lst)
                {
                    if (item.maSach.Equals(id))
                    {
                        lst.Remove(item);
                        result = true;
                        break;
                    }
                }
            }

            return Json(new
            {
                status = result
            });

        }
        public ActionResult ThanhToan()
        {
            if (Session["User"] == null)
            {
                ViewBag.ThongBao = "Bạn chưa đăng nhập xin mời bạn đăng nhập!";
                return View(LayGioHang());
            }
            else
            {
                List<GioHang> gh = LayGioHang();
                HoaDonBO hoaDon = new HoaDonBO();
                if (gh.Count() <= 0)
                {
                    ViewBag.ThongBao = "Bạn không có hàng nào để thanh toán!";
                    return View(gh);
                }
                if (hoaDon.ThemHoaDon(Session["User"].ToString(), gh))
                {
                    Session["GioHang"] = null;
                    gh = LayGioHang();
                    ViewBag.ThongBao = "Thanh toán thành công, chờ admin duyệt hàng!";
                    return View(gh);
                }
                else
                {
                    ViewBag.ThongBao = "Thanh toán thất bại!";
                    return View(gh);
                }

            }
            
            
        }
    }
}