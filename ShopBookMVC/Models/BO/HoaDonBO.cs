using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopBookMVC.Models.DAO;
using PagedList;

namespace ShopBookMVC.Models.BO
{
    public class HoaDonBO
    {
        HoaDonDAO hoaDon = new HoaDonDAO();
        ChiTietHoaDonBO cthd = new ChiTietHoaDonBO();
        public bool ThemHoaDon(string maKH, List<GioHang> gh)
        {
            if (hoaDon.ThemHoaDon(maKH))
            {
                long maHD = hoaDon.getMa();
                if (cthd.ThemCTHD(maHD, gh))
                    return true;
                return false;
            }
            return false;
        }

        public bool XoaHD(long id)
        {
            return hoaDon.XoaHD(id);
        }

        public IEnumerable<GioHang> getHang(string maKH, int page, int pageSize)
        {
            return hoaDon.getHang(maKH).ToPagedList(page, pageSize);
        }

        internal bool XacNhanThanhToan(long id)
        {
            return hoaDon.XacNhanThanhToan(id);
        }
    }
}