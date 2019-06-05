using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopBookMVC.Models.DAO;
using PagedList;

namespace ShopBookMVC.Models.BO
{
    public class SachBO
    {
        SachDAO sach = new SachDAO();
        public List<Sach> getSachMoiNhat()
        {
            return sach.getSachMoiNhat();
        }

        
        public IEnumerable<Sach> getTatCaSach(int page, int pageSize)
        {
            return sach.getSach().ToPagedList(page, pageSize);
        }

        public IEnumerable<Sach> getTatCaSach(string maloai, int page, int pageSize)
        {
            return sach.getSach(maloai).ToPagedList(page, pageSize);
        }

        public IEnumerable<Sach> getSachTK(string tk, int page, int pageSize)
        {
            return sach.getSachTimKiem(tk).ToPagedList(page, pageSize);
        }

        public int ThemSach(Sach s)
        {
            if (sach.checkMaSach(s.maSach))
            {
                return -1;
            }
            return sach.ThemSach(s);
        }

        public bool XoaSach(string id)
        {
            return sach.XoaSach(id);
        }

        public Sach getMotSach(string id)
        {
            return sach.getMotSach(id);
        }

        public bool CapNhatSach(Sach s)
        {
            return sach.CapNhatSach(s);
        }
    }
}