using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBookMVC.Models
{
    public class PhuongThucThanhToan
    {
        public long ID { get; set; }
        public String tenPhuongThuc { get; set; }
        public Boolean trangThai { get; set; }
    }
}