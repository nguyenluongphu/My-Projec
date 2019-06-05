using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ShopBookMVC.Models.Commons;

namespace ShopBookMVC.Models.DAO
{
    public class DangNhapDAO
    {
        ConnectDatabase con = new ConnectDatabase();
        MaHoaMD5 maHoa = new MaHoaMD5();
        public string KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            string sql = "SELECT * FROM DangNhap WHERE TenDangNhap = @tdn AND MatKhau = @mk AND Quyen = 0";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter tdn = new SqlParameter("@tdn", tenDangNhap);
            SqlParameter mk = new SqlParameter("@mk", matKhau);//maHoa.MaHoaMK("123", matKhau)
            cmd.Parameters.Add(tdn);
            cmd.Parameters.Add(mk);
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                return rs["TenDangNhap"].ToString();
            }
            return null;
        }

        public bool KiemTraDangNhapAdmin(DangNhap admin)
        {
            
            string sql = "SELECT * FROM DangNhap WHERE TenDangNhap = @tdn AND MatKhau = @mk AND Quyen = 1";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter tdn = new SqlParameter("@tdn", admin.tenDangNhap);
            SqlParameter mk = new SqlParameter("@mk", admin.matKhau);//maHoa.MaHoaMK("123", admin.matKhau)
            cmd.Parameters.Add(tdn);
            cmd.Parameters.Add(mk);
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                return true;
            }
            return false;
        }

        public bool CapNhatMatKhau(string user, string pass)
        {
            string sql = "UPDATE  DangNhap SET MatKhau =@pass WHERE TenDangNhap =@ma";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter mal = new SqlParameter("@ma", user);
            SqlParameter pas = new SqlParameter("@pass", maHoa.MaHoaMK("123", pass));
            cmd.Parameters.Add(mal);
            cmd.Parameters.Add(pas);
            int res = cmd.ExecuteNonQuery();
            if (res != 0)
                return true;//thành công
            return false; //thât bại
        }

        //public bool KiemTraMatKhauCu(string maKh, string mkc)
        //{
        //    string sql = "SELECT * FROM DangNhap WHERE TenDangNhap = @tdn";
        //    SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
        //    SqlParameter tdn = new SqlParameter("@tdn", data);
        //    cmd.Parameters.Add(tdn);
        //    SqlDataReader rs = cmd.ExecuteReader();
        //    if (rs.Read())
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public bool ThemTaiKhoan(KhachHang khachHang)
        {
            string sql = "INSERT INTO DangNhap (TenDangNhap, MatKhau, Quyen) VALUES(@ma,@pass, 0)";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter ma = new SqlParameter("@ma", khachHang.maKH);
            SqlParameter pass = new SqlParameter("@pass", maHoa.MaHoaMK("123", khachHang.matKhau));
            cmd.Parameters.Add(ma);
            cmd.Parameters.Add(pass);
            int res = cmd.ExecuteNonQuery();
            if (res != 0)
                return true;
            return false;
        }
        public bool KiemTraDangNhap(string data)
        {
            string sql = "SELECT * FROM DangNhap WHERE TenDangNhap = @tdn";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter tdn = new SqlParameter("@tdn", data);
            cmd.Parameters.Add(tdn);
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                return true;
            }
            return false;
        }
    }
}