using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using A_DAL.DomainModels;
using A_DAL.Respositories;

namespace B_BUS.Service
{
    public class DanhmucService
    {
        private DanhmucRes _danhmucRes;

        public DanhmucService()
        {
            _danhmucRes = new DanhmucRes();
        }

        public List<Danhmuc> GetAll()
        {
            return _danhmucRes.GetAll();
        }
    }
}
