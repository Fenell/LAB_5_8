using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_DAL.Context;
using A_DAL.DomainModels;

namespace A_DAL.Respositories
{
    public class DonhangRes
    {
        private QLBHContext _qlbhContext;

        public DonhangRes()
        {
            _qlbhContext = new QLBHContext();
        }

        public List<Donhang> GetAll()
        {
            return _qlbhContext.Donhangs.ToList();
        }

        public bool AddDonHang(Donhang donhang)
        {
            if (donhang == null)
            {
                return false;
            }

            _qlbhContext.Donhangs.Add(donhang);
            _qlbhContext.SaveChanges();
            return true;
        }

        public bool EditDonHang(Donhang obj)
        {
            var donhang = _qlbhContext.Donhangs.FirstOrDefault(c => c.DonhangId == obj.DonhangId);
            if (donhang == null)
            {
                return false;
            }

            donhang.KhachhangId = obj.KhachhangId;
            donhang.NhanvienId = obj.NhanvienId;
            donhang.ShipperId = obj.ShipperId;
            donhang.Ngaydathang = obj.Ngaydathang;
            _qlbhContext.Donhangs.Update(donhang);
            return true;
        }

        public bool DeleteDonHang(Donhang obj)
        {
            var donhang = _qlbhContext.Donhangs.FirstOrDefault(c => c.DonhangId == obj.DonhangId);
            if (donhang == null)
            {
                return false;
            }

            _qlbhContext.Donhangs.Remove(donhang);
            return true;
        }
    }
}
