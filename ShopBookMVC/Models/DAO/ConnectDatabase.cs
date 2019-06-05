using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopBookMVC.Models.DAO
{
    public class ConnectDatabase
    {
        public static SqlConnection conn;
        public SqlConnection GetConnect()
        {
            try
            {
                //
                string ConnectionString = string.Format("Data Source=Phu-IT\\SQLEXPRESS;Initial Catalog=Qlsach;User ID=sa; Password=phuphu");
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}