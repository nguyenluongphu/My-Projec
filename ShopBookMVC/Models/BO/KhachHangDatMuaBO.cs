using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using ShopBookMVC.Models.DAO;

namespace ShopBookMVC.Models.BO
{
    public class KhachHangDatMuaBO
    {
        KhachHangDatMuaDAO kh = new KhachHangDatMuaDAO();
        public IEnumerable<KhachHangDatMua> getKhachHangDatMua(int page, int pageSize)
        {
            return kh.getKhachHangDatMua().ToPagedList(page, pageSize);
        }

        public IEnumerable<KhachHangDatMua> getKhachHangDatMuaTK(string tk, int page, int pageSize)
        {
            return kh.getKhachHangDatMuaTK(tk).ToPagedList(page, pageSize);
        }

        public IEnumerable<KhachHangChuaThanhToan> getKhachHangChuaThanhToan(int page, int pageSize)
        {
            return kh.getKhachHangChuaThanhToan().ToPagedList(page, pageSize);
        }

        public IEnumerable<KhachHangChuaThanhToan> getKhachHangChuaThanhToanTK(string tk, int page, int pageSize)
        {
            return kh.getKhachHangChuaThanhToanTK(tk).ToPagedList(page, pageSize);
        }

        public IEnumerable<KhachHangChuaThanhToan> getKhachHangDaThanhToan(int page, int pageSize)
        {
            return kh.getKhachHangDaThanhToan().ToPagedList(page, pageSize);
        }

        public IEnumerable<KhachHangChuaThanhToan> getKhachHangDaThanhToanTK(string tk, int page, int pageSize)
        {
            return kh.getKhachHangDaThanhToanTK(tk).ToPagedList(page, pageSize);
        }
    }
}