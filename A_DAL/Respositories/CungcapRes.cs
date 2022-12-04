using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_DAL.Context;
using A_DAL.DomainModels;

namespace A_DAL.Respositories
{
    public class CungcapRes
    {
        private QLBHContext _qlbhContext;

        public CungcapRes()
        {
            _qlbhContext = new QLBHContext();
        }

        public List<Cungcap> GetAll()
        {
            return _qlbhContext.Cungcaps.ToList();
        }
    }
}
