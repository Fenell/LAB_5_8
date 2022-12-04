using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_DAL.Context;
using A_DAL.DomainModels;

namespace A_DAL.Respositories
{
    public class ShipperRes
    {
        private QLBHContext _qlbhContext;

        public ShipperRes()
        {
            _qlbhContext = new QLBHContext();
        }

        public List<Shipper> GetAll()
        {
            return _qlbhContext.Shippers.ToList();
        }
    }
}
