using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopBookMVC.Models.DAO;
using PagedList;
namespace ShopBookMVC.Models.BO
{
    public class LoaiBO
    {
        LoaiDAO loai = new LoaiDAO();
        public List<Loai> getLoai()
        {
            return loai.getLoai();
        }

        public IEnumerable<Loai> getTatCaLoai(int page, int pageSize)
        {
            return loai.getTatCaLoai().ToPagedList(page, pageSize);
        }

        public IEnumerable<Loai> getLoaiTK(string tk, int page, int pageSize)
        {
            return loai.getLoaiTK(tk).ToPagedList(page, pageSize);
        }

        public int ThemLoai(Loai l)
        {
            if (loai.kiemTraTrungMa(l.maLoai))
            {
                return -1;
            }
            else
            {
                if (loai.ThemLoai(l))
                {
                    return 1;
                }
                return 0;
            }
        }

        public bool XoaLoai(string id)
        {
            return loai.XoaLoai(id);
        }

        public Loai getMotLoai(string id)
        {
            return loai.getMotLoai(id);
        }

        public bool CapNhatLoai(Loai model)
        {
            return loai.CapNhatLoai(model);
        }
    }
}