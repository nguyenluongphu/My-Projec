using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBookMVC.Models
{
    public class Loai
    {
        [Display(Name = "Mã Loại") ]
        public string maLoai { get; set; }
        [Display(Name = "Tên Loại")]
        public string tenLoai { get; set; }
    }
}