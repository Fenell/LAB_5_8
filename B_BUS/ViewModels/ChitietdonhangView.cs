using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using A_DAL.DomainModels;

namespace B_BUS.ViewModels
{
    public class ChitietdonhangView
    {
        public DonhangChitiet DonhangChitiet { get; set; }
        public Sanpham Sanpham { get; set; }
        public Cungcap Cungcap { get; set; }
        public Danhmuc Danhmuc { get; set; }

        public decimal? Thanhtien
        {
            get { return DonhangChitiet.Soluong  * Sanpham.Gia; }
        }
    }
}
