using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_DAL.Context;
using A_DAL.DomainModels;

namespace A_DAL.Respositories
{
    public class DanhmucRes
    {
        private QLBHContext _qlbhContext;

        public DanhmucRes()
        {
            _qlbhContext = new QLBHContext();
        }

        public List<Danhmuc> GetAll()
        {
            return _qlbhContext.Danhmucs.ToList();
        }
    }
}
