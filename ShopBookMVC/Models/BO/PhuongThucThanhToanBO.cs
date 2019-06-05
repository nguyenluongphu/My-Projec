using ShopBookMVC.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBookMVC.Models.BO
{
    public class PhuongThucThanhToanBO
    {
        PhuongThucThanhToanDAO PTTT = new PhuongThucThanhToanDAO();
        public List<PhuongThucThanhToan> getAll()
        {
            return PTTT.getAll();
        }
    }
}