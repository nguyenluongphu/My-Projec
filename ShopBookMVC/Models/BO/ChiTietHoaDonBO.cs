using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopBookMVC.Models.DAO;

namespace ShopBookMVC.Models.BO
{
    public class ChiTietHoaDonBO
    {
        ChiTietHoaDonDAO cthd = new ChiTietHoaDonDAO();
        public bool ThemCTHD(long maHD, List<GioHang> gh)
        {
            foreach(GioHang gio in gh)
            {
                if (cthd.ThemCTHD(maHD, gio) == 0)
                {
                    break;
                }
                    
            }
            return true;
        }

        public bool XoaCTHD(long id)
        {
            return cthd.XoaCTHD(id);
        }
    }
}