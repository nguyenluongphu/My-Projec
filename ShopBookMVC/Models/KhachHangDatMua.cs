using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBookMVC.Models
{
    public class KhachHangDatMua
    {
        public string makh { get; set; }
        public string hoten { get; set; }
        public string diachi { get; set; }
        public string sodt { get; set; }
        public string tensach { get; set; }
        public long soluong { get; set; }
        public long gia { get; set; }
        public long maCTHD { get; set; }
        public bool tinhTrangThanhToan { get; set; }
        public long maHD { get; set; }
        public DateTime ngaymua { get; set; }
    }
}