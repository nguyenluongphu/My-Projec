using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBookMVC.Models
{
    public class GioHang
    {
        public string maSach { get; set; }
        public string tenSach { get; set; }
        public long gia { get; set; }
        public long soLuong { get; set; }
        public string anh { get; set; }
        public long thanhTien { get; set; }
    }
}