using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopBookMVC.Models.DAO;

namespace ShopBookMVC.Models.BO
{
    public class DangNhapBO
    {
        DangNhapDAO dangNhap = new DangNhapDAO();
        public string KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            return dangNhap.KiemTraDangNhap(tenDangNhap, matKhau);
        }

        public bool KiemTraDangNhap(string data)
        {
            return dangNhap.KiemTraDangNhap(data);
        }

        public bool ThemTaiKhoan(KhachHang khachHang)
        {
            return dangNhap.ThemTaiKhoan(khachHang);
        }

        internal bool KiemTraDangNhapAdmin(DangNhap admin)
        {
            return dangNhap.KiemTraDangNhapAdmin(admin);
        }

        public bool CapNhatMatKhau(string user, string pass)
        {
            return dangNhap.CapNhatMatKhau(user, pass);
        }

        //public bool KiemTraMatKhauCu(string maKh, string mkc)
        //{
        //    return dangNhap.KiemTraMatKhauCu(maKh, mkc);
        //}
    }
}