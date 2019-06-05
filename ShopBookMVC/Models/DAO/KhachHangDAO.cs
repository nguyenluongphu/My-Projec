using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ShopBookMVC.Models.Commons;

namespace ShopBookMVC.Models.DAO
{
    public class KhachHangDAO
    {
        ConnectDatabase con = new ConnectDatabase();
        MaHoaMD5 maHoa = new MaHoaMD5();
        public bool ThemKhachHang(KhachHang khachHang)
        {
            string sql = "INSERT INTO KhachHang (makh, hoten, diachi, sodt, email, pass) VALUES(@ma,@ten,@diachi,@sdt,@email,@pass)";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter ma = new SqlParameter("@ma", khachHang.maKH);
            SqlParameter ten = new SqlParameter("@ten", khachHang.hoTen);
            SqlParameter diachi = new SqlParameter("@diachi", khachHang.diaChi);
            SqlParameter sdt = new SqlParameter("@sdt", khachHang.soDT);
            SqlParameter email = new SqlParameter("@email", khachHang.email);
            SqlParameter pass = new SqlParameter("@pass", maHoa.MaHoaMK("123",khachHang.matKhau));
            cmd.Parameters.Add(ma);
            cmd.Parameters.Add(ten);
            cmd.Parameters.Add(diachi);
            cmd.Parameters.Add(sdt);
            cmd.Parameters.Add(email);
            cmd.Parameters.Add(pass);
            int res = cmd.ExecuteNonQuery();
            if (res != 0)
                return true;
            return false;
        }

        public bool kiemTraMK(string user, string pass)
        {
            string sql = "SELECT * FROM dbo.KhachHang WHERE makh = @ma AND pass = @pass";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter mal = new SqlParameter("@ma", user);
            SqlParameter pas = new SqlParameter("@pass", maHoa.MaHoaMK("123", pass));
            cmd.Parameters.Add(mal);
            cmd.Parameters.Add(pas);
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                rs.Close();
                return true;
            }
            rs.Close();
            return false;
        }

        public bool CapNhatMatKhau(string user, string pass)
        {
            string sql = "UPDATE  KhachHang SET pass =@pass WHERE makh =@ma";
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

        public bool CapNhatThongTin(KhachHang info)
        {
            string sql = "UPDATE  KhachHang SET hoten =@ht, diachi =@dc, sodt =@sdt, email =@em WHERE makh =@ma";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter ma = new SqlParameter("@ma", info.maKH);
            SqlParameter ten = new SqlParameter("@ht", info.hoTen);
            SqlParameter diachi = new SqlParameter("@dc", info.diaChi);
            SqlParameter sdt = new SqlParameter("@sdt", info.soDT);
            SqlParameter email = new SqlParameter("@em", info.email);
            cmd.Parameters.Add(ma);
            cmd.Parameters.Add(ten);
            cmd.Parameters.Add(diachi);
            cmd.Parameters.Add(sdt);
            cmd.Parameters.Add(email);
            int res = cmd.ExecuteNonQuery();
            if (res != 0)
                return true;
            return false;
        }

        public string getName(string user)
        {
            string sql = "SELECT * FROM dbo.KhachHang WHERE makh = @ma";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter mal = new SqlParameter("@ma", user);
            cmd.Parameters.Add(mal);
            SqlDataReader rs = cmd.ExecuteReader();
            string name = null;
            if (rs.Read())
            {
                name = rs["hoten"].ToString();
            }
            rs.Close();
            return name;
        }

        public KhachHang getKhachHang(string user)
        {
            string sql = "SELECT * FROM dbo.KhachHang WHERE makh = @ma";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter mal = new SqlParameter("@ma", user);
            cmd.Parameters.Add(mal);
            SqlDataReader rs = cmd.ExecuteReader();
            KhachHang khach = new KhachHang();
            while (rs.Read())
            {
                khach.maKH = rs["makh"].ToString();
                khach.hoTen = rs["hoten"].ToString();
                khach.diaChi= rs["diachi"].ToString();
                khach.soDT = rs["sodt"].ToString();
                khach.email = rs["email"].ToString();
                khach.ghiChu = rs["ghichu"].ToString();
                khach.matKhau = rs["pass"].ToString();
            }
            rs.Close();
            return khach;
        }
    }
}