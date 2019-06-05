using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBookMVC.Models
{
    public class DangNhap
    {
        //[Required(ErrorMessage ="Tên đăng nhập không được trống!")]

        //[EmailAddress(ErrorMessage = "Email không hợp lệ")]

        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "số điện thoại không hợp lệ.")]

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Date")]
        //[Required(ErrorMessage = "ngày nhập không đúng")]

        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Email không hợp lệ!")]
        [Required(ErrorMessage = "Tên đăng nhập không được trống!")]
        public string tenDangNhap { get; set; }
        [Required(ErrorMessage ="Mật Khẩu không được trống!")]
        public string matKhau { get; set; }
        public bool quyen { get; set; }

    }
}