using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_DAL.Context;
using A_DAL.DomainModels;

namespace A_DAL.Respositories
{
    public class SanphamRes
    {
        private QLBHContext _qlbhContext;

        public SanphamRes()
        {
            _qlbhContext = new QLBHContext();
        }

        public List<Sanpham> GetAll()
        {
            return _qlbhContext.Sanphams.ToList();
        }
    }
}
