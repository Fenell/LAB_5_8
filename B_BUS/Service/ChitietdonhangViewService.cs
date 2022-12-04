using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_DAL.Respositories;
using B_BUS.ViewModels;

namespace B_BUS.Service
{
    public class ChitietdonhangViewService
    {
        private DonhangchitietRes _donhangChitiet;
        private SanphamRes _sanphamRes;
        private CungcapRes _cungcapRes;
        private DanhmucService _danhmucRes;
        public ChitietdonhangViewService()
        {
            _danhmucRes = new DanhmucService();
            _cungcapRes = new CungcapRes();
            _sanphamRes = new SanphamRes();
            _donhangChitiet = new DonhangchitietRes();
        }

        public string AddCtDonHang(ChitietdonhangView obj)
        {
            if (_donhangChitiet.AddDonhangCt(obj.DonhangChitiet))
            {
                return "Thêm thành công";
            }

            return "Thêm thất bại";
        }

        public string DeleteCtDonHang(ChitietdonhangView obj)
        {
            if (_donhangChitiet.DeleteDonHangCT(obj.DonhangChitiet))
            {
                return "Xóa thành công";
            }

            return "Xóa thất bại";
        }

        public string EditCTtDonHang(ChitietdonhangView obj)
        {
            if (_donhangChitiet.EditDonHangCT(obj.DonhangChitiet))
            {
                return "Sửa thành công";
            }

            return "Sửa thất bại";
        }

        public List<ChitietdonhangView> GetAll(int idDonHang)
        {
            List<ChitietdonhangView> lst = new List<ChitietdonhangView>();
            lst = (from donhangChitiet in _donhangChitiet.GetAll()
                   join sanpham in _sanphamRes.GetAll() on donhangChitiet.SanphamId equals sanpham.SanphamId
                   join danhmuc in _danhmucRes.GetAll() on sanpham.DanhmucId equals danhmuc.DanhmucId
                   join cungcap in _cungcapRes.GetAll() on sanpham.CungcapId equals cungcap.CungcapId
                   select new ChitietdonhangView()
                   {
                       Cungcap = cungcap,
                       Danhmuc = danhmuc,
                       DonhangChitiet = donhangChitiet,
                       Sanpham = sanpham
                   }).Where(c => c.DonhangChitiet.DonhangId == idDonHang).ToList();

            return lst;
        }
    }
}
