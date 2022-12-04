using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_DAL.DomainModels;
using A_DAL.Respositories;

namespace B_BUS.Service
{
    public class SanphamService
    {
        private SanphamRes _sanphamRes;

        public SanphamService()
        {
            _sanphamRes = new SanphamRes();
        }

        public List<Sanpham> GetAll()
        {
            return _sanphamRes.GetAll();
        }
    }
}
