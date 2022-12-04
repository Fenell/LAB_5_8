using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_DAL.DomainModels;
using A_DAL.Respositories;

namespace B_BUS.Service
{
    public class ShipperService
    {
        private ShipperRes _shipperRes;

        public ShipperService()
        {
            _shipperRes = new ShipperRes();
        }

        public List<Shipper> GetAlList()
        {
            return _shipperRes.GetAll();
        }
    }
}
