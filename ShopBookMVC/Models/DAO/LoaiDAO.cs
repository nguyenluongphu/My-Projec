using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopBookMVC.Models.DAO
{
    public class LoaiDAO
    {
        ConnectDatabase con = new ConnectDatabase();
        public List<Loai> getLoai()
        {
            con.GetConnect();
            string sql = "SELECT * FROM loai";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlDataReader rs = cmd.ExecuteReader();
            List<Loai> dsloai = new List<Loai>();
            while (rs.Read())
            {
                string maloai = rs["maloai"].ToString();
                string tenloai = rs["tenloai"].ToString();

                Loai loai = new Loai();
                loai.maLoai = maloai;
                loai.tenLoai = tenloai;
                dsloai.Add(loai);
            }
            rs.Close();
            return dsloai;
        }

        public bool kiemTraTrungMa(string maLoai)
        {
            con.GetConnect();
            string sql = "SELECT * FROM loai WHERE maloai = @ma";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter ma = new SqlParameter("@ma", maLoai);
            cmd.Parameters.Add(ma);
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                rs.Close();
                return true;
            }
            return false;
        }

        public bool CapNhatLoai(Loai model)
        {
            string sql = "UPDATE loai SET tenloai =@ten WHERE maloai = @ma";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter ten = new SqlParameter("@ten", model.tenLoai);
            SqlParameter ma = new SqlParameter("@ma", model.maLoai);
            cmd.Parameters.Add(ma);
            cmd.Parameters.Add(ten);
            int res = cmd.ExecuteNonQuery();
            if (res != 0)
                return true;
            return false;
        }

        public Loai getMotLoai(string id)
        {
            string sql = "SELECT * FROM loai WHERE maloai = @ma";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter ma = new SqlParameter("@ma", id);
            cmd.Parameters.Add(ma);
            SqlDataReader rs = cmd.ExecuteReader();
            Loai loai = new Loai();
            //loai = null;
            if (rs.Read())
            {
                loai.maLoai = rs["maloai"].ToString();
                loai.tenLoai = rs["tenloai"].ToString();
            }
            return loai;
        }

        public bool XoaLoai(string id)
        {
            string sql = "DELETE FROM loai WHERE maloai = @ma";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter ma = new SqlParameter("@ma", id);
            cmd.Parameters.Add(ma);
            int res = cmd.ExecuteNonQuery();
            if (res != 0)
                return true;
            return false;
        }

        public bool ThemLoai(Loai l)
        {
            con.GetConnect();
            string sql = "INSERT INTO loai(maloai, tenloai) VALUES(@ma,@ten)";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlParameter ma = new SqlParameter("@ma", l.maLoai);
            SqlParameter ten = new SqlParameter("@ten", l.tenLoai);
            cmd.Parameters.Add(ma);
            cmd.Parameters.Add(ten);
            int res = cmd.ExecuteNonQuery();
            if (res != 0)
                return true;
            return false;
        }

        public IEnumerable<Loai> getLoaiTK(string tk)
        {
            con.GetConnect();
            string sql = "SELECT * FROM loai WHERE tenloai LIKE '%" + tk + "%'";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlDataReader rs = cmd.ExecuteReader();
            List<Loai> dsloai = new List<Loai>();
            while (rs.Read())
            {
                string maloai = rs["maloai"].ToString();
                string tenloai = rs["tenloai"].ToString();

                Loai loai = new Loai();
                loai.maLoai = maloai;
                loai.tenLoai = tenloai;
                dsloai.Add(loai);
            }
            rs.Close();
            return dsloai;
        }

        public IEnumerable<Loai> getTatCaLoai()
        {
            con.GetConnect();
            string sql = "SELECT * FROM loai";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlDataReader rs = cmd.ExecuteReader();
            List<Loai> dsloai = new List<Loai>();
            while (rs.Read())
            {
                string maloai = rs["maloai"].ToString();
                string tenloai = rs["tenloai"].ToString();

                Loai loai = new Loai();
                loai.maLoai = maloai;
                loai.tenLoai = tenloai;
                dsloai.Add(loai);
            }
            rs.Close();
            return dsloai;
        }
    }
}