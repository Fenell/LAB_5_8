using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_DAL.DomainModels;
using A_DAL.Respositories;

namespace B_BUS.Service
{
    public class KhachhangService
    {
        private KhachhangRes _khachhangRes;

        public KhachhangService()
        {
            _khachhangRes = new KhachhangRes();
        }

        public List<Khachhang> GetAll()
        {
            return _khachhangRes.GetAll();
        }
    }
}
