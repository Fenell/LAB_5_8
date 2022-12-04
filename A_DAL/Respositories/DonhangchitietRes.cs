using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_DAL.Context;
using A_DAL.DomainModels;

namespace A_DAL.Respositories
{
    public class DonhangchitietRes
    {
        private QLBHContext _qlbhContext;

        public DonhangchitietRes()
        {
            _qlbhContext = new QLBHContext();
        }

        public List<DonhangChitiet> GetAll()
        {
            return _qlbhContext.DonhangChitiets.ToList();
        }

        public bool AddDonhangCt(DonhangChitiet obj)
        {
            if (obj == null) return false;

            _qlbhContext.DonhangChitiets.Add(obj);
            _qlbhContext.SaveChanges();
            return true;
        }

        public bool DeleteDonHangCT(DonhangChitiet obj)
        {
            var ctDonhang = _qlbhContext.DonhangChitiets.FirstOrDefault(c => c.DonhangChitietId == obj.DonhangChitietId);
            if (ctDonhang == null) return false;

            _qlbhContext.DonhangChitiets.Remove(ctDonhang);
            _qlbhContext.SaveChanges();
            return true;
        }

        public bool EditDonHangCT(DonhangChitiet obj)
        {
            var ctDonHang = _qlbhContext.DonhangChitiets.FirstOrDefault(c => c.DonhangChitietId == obj.DonhangChitietId);
            if (ctDonHang == null) return false;

            ctDonHang.DonhangId = obj.DonhangId;
            ctDonHang.SanphamId = obj.SanphamId;
            ctDonHang.Soluong = obj.Soluong;
            _qlbhContext.DonhangChitiets.Update(ctDonHang);
            return true;
        }
    }
}
