using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopBookMVC.Models.DAO;

namespace ShopBookMVC.Models.BO
{
    public class KhachHangBO
    {
        KhachHangDAO kh = new KhachHangDAO();
        DangNhapBO dn = new DangNhapBO();
        public bool ThemKhachHang(KhachHang khachHang)
        {
            if (kh.ThemKhachHang(khachHang))
            {
                return dn.ThemTaiKhoan(khachHang);
            }
            return false;
        }

        public KhachHang getKhachHang(string user)
        {
            return kh.getKhachHang(user);
        }

        public string getName(string user)
        {
            return kh.getName(user);
        }

        public bool CapNhatThongTin(KhachHang info)
        {
            return kh.CapNhatThongTin(info);
        }

        public bool CapNhatMatKhau(string user, string pass)
        {
            DangNhapBO dn = new DangNhapBO();
            if (kh.CapNhatMatKhau(user, pass))
            {
                if (dn.CapNhatMatKhau(user, pass))
                    return true; //thành công
                return false;
            }
            return false;
        }

        public bool kiemTraMatKhau(string user, string mkc)
        {
            return kh.kiemTraMK(user, mkc);
        }
    }
}