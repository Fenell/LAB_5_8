using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_DAL.DomainModels;

namespace B_BUS.ViewModels
{
    public class DonhangView
    {
        public Donhang Donhang { get; set; }
        public Khachhang Khachhang { get; set; }
        public Nhanvien Nhanvien { get; set; }
        public Shipper Shipper { get; set; }
    }
}
