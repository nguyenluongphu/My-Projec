using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBookMVC.Models
{
    public class Sach
    {
        [Display(Name = "Mã Sách")]
        public string maSach { get; set; }
        [Display(Name = "Tên sách")]
        public string tenSach { get; set; }
        [Display(Name = "Tác giả")]
        public string tacGia { get; set; }
        [Display(Name = "Số lượng")]
        public long soLuong { get; set; }
        [Display(Name = "Giá")]
        public long gia { get; set; }
        [Display(Name = "Số tập")]
        public string soTap { get; set; }
        [Display(Name = "Ngày nhập")]
        public DateTime ngayNhap { get; set; }
        [Display(Name = "Ảnh")]
        public string anh { get; set; }
        [Display(Name = "Thuộc loại")]
        public string maLoai { get; set; }
        [Display(Name = "Mô tả")]
        public string moTa { get; set; }
    }
}