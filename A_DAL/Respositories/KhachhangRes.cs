using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_DAL.Context;
using A_DAL.DomainModels;

namespace A_DAL.Respositories
{
    public class KhachhangRes
    {
        private QLBHContext _qlbhContext;
        public KhachhangRes()
        {
            _qlbhContext = new QLBHContext();
        }

        public List<Khachhang> GetAll()
        {
            return _qlbhContext.Khachhangs.ToList();
        }
    }
}
