using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopBookMVC.Models.DAO
{
    public class ChiTietHoaDonDAO
    {
        ConnectDatabase con = new ConnectDatabase();
        public int ThemCTHD(long maHD, GioHang gio)
        {
            string sql = "insert into ChiTietHoaDon values(@masach, @slm, @tt, @mahd)";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            //Tạo tham số
            SqlParameter mh = new SqlParameter("@masach", gio.maSach);
            SqlParameter s = new SqlParameter("@slm", gio.soLuong);
            SqlParameter tt = new SqlParameter("@tt", gio.thanhTien);
            SqlParameter mhd = new SqlParameter("@mahd", maHD);

            cmd.Parameters.Add(mh);
            cmd.Parameters.Add(s);
            cmd.Parameters.Add(tt);
            cmd.Parameters.Add(mhd);
            return cmd.ExecuteNonQuery();
        }

        public bool XoaCTHD(long id)
        {
            string sql = "DELETE FROM ChiTietHoaDon WHERE MaChiTietHD = @ma";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter ma = new SqlParameter("@ma", id);
            cmd.Parameters.Add(ma);
            int rs = cmd.ExecuteNonQuery();
            if (rs != 0)
                return true;
            return false;
        }
    }
}