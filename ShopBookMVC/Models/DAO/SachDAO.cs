using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopBookMVC.Models.DAO
{
    public class SachDAO
    {
        ConnectDatabase con = new ConnectDatabase();
        public List<Sach> getSachMoiNhat()
        {
            string sql = "SELECT * FROM dbo.sach ORDER BY NgayNhap DESC OFFSET 0 ROWS FETCH NEXT 9 ROWS ONLY";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlDataReader rs = cmd.ExecuteReader();
            List<Sach> dssach = new List<Sach>();

            while (rs.Read())
            {
                string masach = rs["masach"].ToString();
                string tensach = rs["tensach"].ToString();
                long soluong = long.Parse(rs["soluong"].ToString());
                long gia = long.Parse(rs["gia"].ToString());
                string maloai = rs["maloai"].ToString();
                string sotap = rs["sotap"].ToString();
                string anh = rs["anh"].ToString();
                DateTime ngaynhap = DateTime.Parse(rs["ngaynhap"].ToString());
                string tacgia = rs["tacgia"].ToString();

                Sach sach = new Sach();
                sach.maSach = masach;
                sach.tenSach = tensach;
                sach.soLuong = soluong;
                sach.gia = gia;
                sach.maLoai = maloai;
                sach.soTap = sotap;
                sach.anh = anh;
                sach.ngayNhap = ngaynhap;
                sach.tacGia = tacgia;
                dssach.Add(sach);
            }
            rs.Close();
            return dssach;
        }
        
        public bool CapNhatSach(Sach s)
        {
            try
            {
                string sql = "UPDATE sach SET tensach =@ten, soluong =@soluong, gia =@gia, maloai =@maloai, sotap =@sotap, anh =@anh, NgayNhap =@ngaynhap, tacgia =@tacgia, mota =@mota WHERE masach = @ma";
                SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
                SqlParameter ma = new SqlParameter("@ma", s.maSach);
                SqlParameter ten = new SqlParameter("@ten", s.tenSach);
                SqlParameter sl = new SqlParameter("@soluong", s.soLuong);
                SqlParameter gia = new SqlParameter("@gia", s.gia);
                SqlParameter maloai = new SqlParameter("@maloai", s.maLoai);
                SqlParameter sotap = new SqlParameter("@sotap", s.soTap);
                SqlParameter anh = new SqlParameter("@anh", s.anh);
                SqlParameter ngaynhap = new SqlParameter("@ngaynhap", s.ngayNhap);
                SqlParameter tacgia = new SqlParameter("@tacgia", s.tacGia);
                SqlParameter mota = new SqlParameter("@mota", s.moTa);
                cmd.Parameters.Add(ma);
                cmd.Parameters.Add(ten);
                cmd.Parameters.Add(sl);
                cmd.Parameters.Add(gia);
                cmd.Parameters.Add(maloai);
                cmd.Parameters.Add(sotap);
                cmd.Parameters.Add(anh);
                cmd.Parameters.Add(ngaynhap);
                cmd.Parameters.Add(tacgia);
                cmd.Parameters.Add(mota);
                int res = cmd.ExecuteNonQuery();
                if (res != 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public Sach getMotSach(string id)
        {
            string sql = "SELECT * FROM dbo.sach WHERE masach = @masach";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter mal = new SqlParameter("@masach", id);
            cmd.Parameters.Add(mal);
            SqlDataReader rs = cmd.ExecuteReader();
            Sach s = new Sach();
            if (rs.Read())
            {
               s.maSach = rs["masach"].ToString();
                s.tenSach = rs["tensach"].ToString();
                s.soLuong = long.Parse(rs["soluong"].ToString());
                s.gia = long.Parse(rs["gia"].ToString());
                s.maLoai = rs["maloai"].ToString();
                s.soTap = rs["sotap"].ToString();
                s.anh = rs["anh"].ToString();
                s.ngayNhap = DateTime.Parse(rs["ngaynhap"].ToString());
                s.tacGia = rs["tacgia"].ToString();
                s.moTa = rs["mota"].ToString();
            }
            rs.Close();
            return s;
        }
        public bool XoaSach(string id)
        {
            string sql = "DELETE FROM sach WHERE masach = @ma";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter ma = new SqlParameter("@ma", id);
            cmd.Parameters.Add(ma);
            int res = cmd.ExecuteNonQuery();
            if (res != 0)
                return true;
            return false;
        }

        public int ThemSach(Sach s)
        {
            string sql = "INSERT INTO sach(masach, tensach, soluong, gia, maloai, sotap, anh, NgayNhap, tacgia, mota) VALUES(@ma,@ten,@soluong,@gia,@maloai,@sotap,@anh,@ngaynhap,@tacgia,@mota)";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter ma = new SqlParameter("@ma", s.maSach);
            SqlParameter ten = new SqlParameter("@ten", s.tenSach);
            SqlParameter sl = new SqlParameter("@soluong", s.soLuong);
            SqlParameter gia = new SqlParameter("@gia", s.gia);
            SqlParameter maloai = new SqlParameter("@maloai", s.maLoai);
            SqlParameter sotap = new SqlParameter("@sotap", s.soTap);
            SqlParameter anh = new SqlParameter("@anh", s.anh);
            SqlParameter ngaynhap = new SqlParameter("@ngaynhap", s.ngayNhap);
            SqlParameter tacgia = new SqlParameter("@tacgia", s.tacGia);
            SqlParameter mota = new SqlParameter("@mota", s.moTa);
            cmd.Parameters.Add(ma);
            cmd.Parameters.Add(ten);
            cmd.Parameters.Add(sl);
            cmd.Parameters.Add(gia);
            cmd.Parameters.Add(maloai);
            cmd.Parameters.Add(sotap);
            cmd.Parameters.Add(anh);
            cmd.Parameters.Add(ngaynhap);
            cmd.Parameters.Add(tacgia);
            cmd.Parameters.Add(mota);
            int res = cmd.ExecuteNonQuery();
            if (res != 0)
                return 1;
            return 0;
        }

        public bool checkMaSach(string maSach)
        {
            string sql = "SELECT * FROM dbo.sach WHERE masach = @masach";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter mal = new SqlParameter("@masach", maSach);
            cmd.Parameters.Add(mal);
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                rs.Close();
                return true;
            }
            rs.Close();
            return false;
        }
        public IEnumerable<Sach> getSachTimKiem(string tk)
        {
            string sql = "SELECT * FROM dbo.sach WHERE tensach LIKE '%"+tk+ "%' OR tacgia LIKE '%" + tk + "%' ORDER BY NgayNhap DESC";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            //SqlParameter mal = new SqlParameter("@tk", "'%"+tk+"%'");
            //cmd.Parameters.Add(mal);
            SqlDataReader rs = cmd.ExecuteReader();
            List<Sach> dssach = new List<Sach>();

            while (rs.Read())
            {
                string masach = rs["masach"].ToString();
                string tensach = rs["tensach"].ToString();
                long soluong = long.Parse(rs["soluong"].ToString());
                long gia = long.Parse(rs["gia"].ToString());
                string maloai = rs["maloai"].ToString();
                string sotap = rs["sotap"].ToString();
                string anh = rs["anh"].ToString();
                DateTime ngaynhap = DateTime.Parse(rs["ngaynhap"].ToString());
                string tacgia = rs["tacgia"].ToString();

                Sach sach = new Sach();
                sach.maSach = masach;
                sach.tenSach = tensach;
                sach.soLuong = soluong;
                sach.gia = gia;
                sach.maLoai = maloai;
                sach.soTap = sotap;
                sach.anh = anh;
                sach.ngayNhap = ngaynhap;
                sach.tacGia = tacgia;
                dssach.Add(sach);
            }
            rs.Close();
            return dssach;
        }

        public IEnumerable<Sach> getSach(string ma)
        {
            string sql = "SELECT * FROM dbo.sach WHERE maloai = @maloai ORDER BY NgayNhap DESC";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter mal = new SqlParameter("@maloai", ma);
            cmd.Parameters.Add(mal);
            SqlDataReader rs = cmd.ExecuteReader();
            List<Sach> dssach = new List<Sach>();

            while (rs.Read())
            {
                string masach = rs["masach"].ToString();
                string tensach = rs["tensach"].ToString();
                long soluong = long.Parse(rs["soluong"].ToString());
                long gia = long.Parse(rs["gia"].ToString());
                string maloai = rs["maloai"].ToString();
                string sotap = rs["sotap"].ToString();
                string anh = rs["anh"].ToString();
                DateTime ngaynhap = DateTime.Parse(rs["ngaynhap"].ToString());
                string tacgia = rs["tacgia"].ToString();

                Sach sach = new Sach();
                sach.maSach = masach;
                sach.tenSach = tensach;
                sach.soLuong = soluong;
                sach.gia = gia;
                sach.maLoai = maloai;
                sach.soTap = sotap;
                sach.anh = anh;
                sach.ngayNhap = ngaynhap;
                sach.tacGia = tacgia;
                dssach.Add(sach);
            }
            rs.Close();
            return dssach;
        }

        public IEnumerable<Sach> getSach()
        {
            string sql = "SELECT * FROM dbo.sach ORDER BY NgayNhap DESC";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlDataReader rs = cmd.ExecuteReader();
            List<Sach> dssach = new List<Sach>();

            while (rs.Read())
            {
                string masach = rs["masach"].ToString();
                string tensach = rs["tensach"].ToString();
                long soluong = long.Parse(rs["soluong"].ToString());
                long gia = long.Parse(rs["gia"].ToString());
                string maloai = rs["maloai"].ToString();
                string sotap = rs["sotap"].ToString();
                string anh = rs["anh"].ToString();
                DateTime ngaynhap = DateTime.Parse(rs["ngaynhap"].ToString());
                string tacgia = rs["tacgia"].ToString();

                Sach sach = new Sach();
                sach.maSach = masach;
                sach.tenSach = tensach;
                sach.soLuong = soluong;
                sach.gia = gia;
                sach.maLoai = maloai;
                sach.soTap = sotap;
                sach.anh = anh;
                sach.ngayNhap = ngaynhap;
                sach.tacGia = tacgia;
                dssach.Add(sach);
            }
            rs.Close();
            return dssach;
        }

    }
}