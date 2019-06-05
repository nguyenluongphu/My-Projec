using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBookMVC.Models
{
    public class KhachHangChuaThanhToan
    {
        public string maKH { get; set; }
        public string hoTen { get; set; }
        public string diaChi { get; set; }
        public string soDT { get; set; }
        public long maHD { get; set; }
        public DateTime ngaymua { get; set; }
        public bool tinhTrangThanhToan { get; set; }

    }
}