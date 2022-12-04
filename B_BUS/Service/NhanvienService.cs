using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_DAL.DomainModels;
using A_DAL.Respositories;

namespace B_BUS.Service
{
    public class NhanvienService
    {
        private NhanvienRes _nhanvienRes;

        public NhanvienService()
        {
            _nhanvienRes = new NhanvienRes();
        }

        public List<Nhanvien> GetAll()
        {
            return _nhanvienRes.GetAll();
        }
    }
}
