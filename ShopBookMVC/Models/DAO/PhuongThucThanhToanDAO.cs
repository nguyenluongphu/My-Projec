using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopBookMVC.Models.DAO
{
    public class PhuongThucThanhToanDAO
    {
        ConnectDatabase con = new ConnectDatabase();
        public List<PhuongThucThanhToan> getAll()
        {
            con.GetConnect();
            string sql = "SELECT * FROM loai";
            SqlCommand cmd = new SqlCommand(sql, con.GetConnect());
            SqlDataReader rs = cmd.ExecuteReader();
            List<PhuongThucThanhToan> lst = new List<PhuongThucThanhToan>();
            while (rs.Read())
            {
                long ID = long.Parse(rs["ID"].ToString());
                string tenPhuongThuc = rs["TenPhuongThuc"].ToString();
                Boolean trangThai = Boolean.Parse(rs["TrangThai"].ToString());
                PhuongThucThanhToan PTTT = new PhuongThucThanhToan();
                PTTT.ID = ID;
                PTTT.tenPhuongThuc = tenPhuongThuc;
                PTTT.trangThai = trangThai;
                lst.Add(PTTT);
            }
            rs.Close();
            return lst;

        }
    }
}