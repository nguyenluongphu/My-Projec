using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBookMVC.Models
{
    public class HoaDon
    {
        public long maHD { get; set; }
        public string maKH { get; set; }
        public DateTime ngaymua { get; set; }
        public bool daMua { get; set; }
        public bool tinhTrangThanhToan { get; set; }
    }
}