using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_DAL.Context;
using A_DAL.DomainModels;

namespace A_DAL.Respositories
{
    public class NhanvienRes
    {
        private QLBHContext _qlbhContext;

        public NhanvienRes()
        {
            _qlbhContext = new QLBHContext();
        }

        public List<Nhanvien> GetAll()
        {
            return _qlbhContext.Nhanviens.ToList();
        }
    }
}
