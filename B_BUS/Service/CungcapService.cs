using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_DAL.DomainModels;
using A_DAL.Respositories;

namespace B_BUS.Service
{
    public class CungcapService
    {
        private CungcapRes _cungcapRes;

        public CungcapService()
        {
            _cungcapRes = new CungcapRes();
        }

        public List<Cungcap> GetAll()
        {
            return _cungcapRes.GetAll();
        }
    }
}
