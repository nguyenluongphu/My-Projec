using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopBookMVC.Models.DAO
{
    public class KhachHangDatMuaDAO
    {
        ConnectDatabase con = new ConnectDatabase();
        public IEnumerable<KhachHangDatMua> getKhachHangDatMua()
        {
            string sql = "SELECT * FROM V_KhachHangMuaSach";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlDataReader rs = cmd.ExecuteReader();
            List<KhachHangDatMua> dskh = new List<KhachHangDatMua>();
            while (rs.Read())
            {
                KhachHangDatMua kh = new KhachHangDatMua();
                kh.makh = rs["makh"].ToString();
                kh.hoten = rs["hoten"].ToString();
                kh.diachi = rs["diachi"].ToString();
                kh.sodt = rs["sodt"].ToString();
                kh.tensach = rs["tensach"].ToString();
                kh.soluong = long.Parse(rs["SoLuongMua"].ToString());
                kh.gia = long.Parse(rs["gia"].ToString());
                kh.maCTHD = long.Parse(rs["MaChiTietHD"].ToString());
                kh.maHD = long.Parse(rs["MaHoaDon"].ToString());
                kh.tinhTrangThanhToan = bool.Parse(rs["TinhTrangThanhToan"].ToString());
                kh.ngaymua = DateTime.Parse(rs["NgayMua"].ToString());
                dskh.Add(kh);
            }
            rs.Close();
            return dskh;
        }

        public IEnumerable<KhachHangChuaThanhToan> getKhachHangDaThanhToanTK(string tk)
        {
            string sql = "SELECT * FROM V_KhachHangDaThanhToan WHERE sodt LIKE '%" + tk + "%' OR MaHoaDon LIKE '%" + tk + "%' OR hoten LIKE '%" + tk + "%' OR diachi LIKE '%" + tk + "%'";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlDataReader rs = cmd.ExecuteReader();
            List<KhachHangChuaThanhToan> dskh = new List<KhachHangChuaThanhToan>();
            while (rs.Read())
            {
                KhachHangChuaThanhToan kh = new KhachHangChuaThanhToan();
                kh.maKH = rs["makh"].ToString();
                kh.hoTen = rs["hoten"].ToString();
                kh.diaChi = rs["diachi"].ToString();
                kh.soDT = rs["sodt"].ToString();
                kh.maHD = long.Parse(rs["MaHoaDon"].ToString());
                kh.tinhTrangThanhToan = bool.Parse(rs["TinhTrangThanhToan"].ToString());
                kh.ngaymua = DateTime.Parse(rs["NgayMua"].ToString());
                dskh.Add(kh);
            }
            rs.Close();
            return dskh;
        }

        public IEnumerable<KhachHangChuaThanhToan> getKhachHangDaThanhToan()
        {
            string sql = "SELECT * FROM V_KhachHangDaThanhToan";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlDataReader rs = cmd.ExecuteReader();
            List<KhachHangChuaThanhToan> dskh = new List<KhachHangChuaThanhToan>();
            while (rs.Read())
            {
                KhachHangChuaThanhToan kh = new KhachHangChuaThanhToan();
                kh.maKH = rs["makh"].ToString();
                kh.hoTen = rs["hoten"].ToString();
                kh.diaChi = rs["diachi"].ToString();
                kh.soDT = rs["sodt"].ToString();
                kh.maHD = long.Parse(rs["MaHoaDon"].ToString());
                kh.tinhTrangThanhToan = bool.Parse(rs["TinhTrangThanhToan"].ToString());
                kh.ngaymua = DateTime.Parse(rs["NgayMua"].ToString());
                dskh.Add(kh);
            }
            rs.Close();
            return dskh;
        }

        public IEnumerable<KhachHangChuaThanhToan> getKhachHangChuaThanhToan()
        {
            string sql = "SELECT * FROM V_KhachHangChuaThanhToan";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlDataReader rs = cmd.ExecuteReader();
            List<KhachHangChuaThanhToan> dskh = new List<KhachHangChuaThanhToan>();
            while (rs.Read())
            {
                KhachHangChuaThanhToan kh = new KhachHangChuaThanhToan();
                kh.maKH = rs["makh"].ToString();
                kh.hoTen = rs["hoten"].ToString();
                kh.diaChi = rs["diachi"].ToString();
                kh.soDT = rs["sodt"].ToString();
                kh.maHD = long.Parse(rs["MaHoaDon"].ToString());
                kh.tinhTrangThanhToan = bool.Parse(rs["TinhTrangThanhToan"].ToString());
                kh.ngaymua = DateTime.Parse(rs["NgayMua"].ToString());
                dskh.Add(kh);
            }
            rs.Close();
            return dskh;
        }

        public IEnumerable<KhachHangChuaThanhToan> getKhachHangChuaThanhToanTK(string tk)
        {
            string sql = "SELECT * FROM V_KhachHangChuaThanhToan WHERE sodt LIKE '%" + tk + "%' OR MaHoaDon LIKE '%" + tk + "%' OR hoten LIKE '%" + tk + "%' OR diachi LIKE '%" + tk + "%'";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlDataReader rs = cmd.ExecuteReader();
            List<KhachHangChuaThanhToan> dskh = new List<KhachHangChuaThanhToan>();
            while (rs.Read())
            {
                KhachHangChuaThanhToan kh = new KhachHangChuaThanhToan();
                kh.maKH = rs["makh"].ToString();
                kh.hoTen = rs["hoten"].ToString();
                kh.diaChi = rs["diachi"].ToString();
                kh.soDT = rs["sodt"].ToString();
                kh.maHD = long.Parse(rs["MaHoaDon"].ToString());
                kh.tinhTrangThanhToan = bool.Parse(rs["TinhTrangThanhToan"].ToString());
                kh.ngaymua = DateTime.Parse(rs["NgayMua"].ToString());
                dskh.Add(kh);
            }
            rs.Close();
            return dskh;
        }
        public IEnumerable<KhachHangDatMua> getKhachHangDatMuaTK(string tk)
        {
            string sql = "SELECT * FROM V_KhachHangMuaSach WHERE tensach LIKE '%" + tk + "%' OR hoten LIKE '%" + tk + "%' OR diachi LIKE '%" + tk + "%'";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            
            SqlDataReader rs = cmd.ExecuteReader();
            List<KhachHangDatMua> dskh = new List<KhachHangDatMua>();
            while (rs.Read())
            {
                KhachHangDatMua kh = new KhachHangDatMua();
                kh.makh = rs["makh"].ToString();
                kh.hoten = rs["hoten"].ToString();
                kh.diachi = rs["diachi"].ToString();
                kh.sodt = rs["sodt"].ToString();
                kh.tensach = rs["tensach"].ToString();
                kh.soluong = long.Parse(rs["SoLuongMua"].ToString());
                kh.gia = long.Parse(rs["gia"].ToString());
                kh.maCTHD = long.Parse(rs["MaChiTietHD"].ToString());
                kh.maHD = long.Parse(rs["MaHoaDon"].ToString());
                kh.tinhTrangThanhToan = bool.Parse(rs["TinhTrangThanhToan"].ToString());
                kh.ngaymua = DateTime.Parse(rs["NgayMua"].ToString());
                dskh.Add(kh);
            }
            rs.Close();
            return dskh;
        }
    }
}