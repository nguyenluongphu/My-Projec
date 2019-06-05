using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopBookMVC.Models.DAO
{
    public class HoaDonDAO
    {
        ConnectDatabase con = new ConnectDatabase();
        public bool ThemHoaDon(string maKH)
        {
            string sql = "INSERT INTO hoadon VALUES(@maKH, GETDATE(), 1, 0)";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter ma = new SqlParameter("@maKH", maKH);
            cmd.Parameters.Add(ma);
            int res = cmd.ExecuteNonQuery();
            if (res != 0)
                return true;
            return false;
        }
        public long getMa()
        {
            string sql = "select max(MaHoaDon) from hoadon";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            long MAX = (long)cmd.ExecuteScalar();
            return MAX;
        }

        public bool XoaHD(long id)
        {
            string sql = "DELETE FROM hoadon WHERE MaHoaDon = @ma";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter mal = new SqlParameter("@ma", id);
            cmd.Parameters.Add(mal);
            int rs = cmd.ExecuteNonQuery();
            if (rs != 0)
                return true;
            return false;
        }

        internal bool XacNhanThanhToan(long id)
        {
            
            string sql = "UPDATE hoadon SET TinhTrangThanhToan = 1 WHERE MaHoaDon = @ma";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter mal = new SqlParameter("@ma", id);
            cmd.Parameters.Add(mal);
            int rs = cmd.ExecuteNonQuery();
            if (rs != 0)
                return true;
            return false;
        }

        public IEnumerable<GioHang> getHang(string maKH)
        {
            string sql = "SELECT sach.masach, sach.tensach, sach.gia, ChiTietHoaDon.SoLuongMua, sach.anh, ChiTietHoaDon.ThanhTien FROM ChiTietHoaDon INNER JOIN sach ON ChiTietHoaDon.MaSach = sach.masach INNER JOIN hoadon ON ChiTietHoaDon.MaHoaDon = hoadon.MaHoaDon INNER JOIN KhachHang ON hoadon.makh = KhachHang.makh WHERE hoadon.makh = @maKH";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter mal = new SqlParameter("@maKH", maKH);
            cmd.Parameters.Add(mal);
            SqlDataReader rs = cmd.ExecuteReader();
            List<GioHang> dssach = new List<GioHang>();

            while (rs.Read())
            {
                string masach = rs["masach"].ToString();
                string tensach = rs["tensach"].ToString();
                long soluong = long.Parse(rs["SoLuongMua"].ToString());
                long gia = long.Parse(rs["gia"].ToString());
                string anh = rs["anh"].ToString();
                long thanhTien = long.Parse(rs["ThanhTien"].ToString());

                GioHang gio = new GioHang();
                gio.maSach = masach;
                gio.tenSach = tensach;
                gio.gia = gia;
                gio.soLuong = soluong;
                gio.anh = anh;
                gio.thanhTien = thanhTien;
                dssach.Add(gio);
            }
            rs.Close();
            return dssach;
        }
    }
}