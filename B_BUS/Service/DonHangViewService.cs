using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_DAL.DomainModels;
using A_DAL.Respositories;
using B_BUS.ViewModels;

namespace B_BUS.Service
{
    public class DonHangViewService
    {
        private DonhangRes _donhangRes;
        private KhachhangRes _khachhangRes;
        private NhanvienRes _nhanvienRes;
        private ShipperRes _shipperRes;

        public DonHangViewService()
        {
            _donhangRes = new DonhangRes();
            _khachhangRes = new KhachhangRes();
            _shipperRes = new ShipperRes();
            _nhanvienRes = new NhanvienRes();
        }

        public string AddDonHangView(DonhangView obj)
        {
            if (_donhangRes.AddDonHang(obj.Donhang))
            {
                return "Thêm thành công";
            }

            return "Thêm thất bại";
        }

        public string EditDonHangView(DonhangView obj)
        {
            if (_donhangRes.EditDonHang(obj.Donhang))
            {
                return "Sửa thành công";
            }

            return "Sửa thất bại";
        }

        public string DeleleDonHangView(DonhangView obj)
        {
            if (_donhangRes.DeleteDonHang(obj.Donhang))
            {
                return "Xóa thành công";
            }

            return "Xóa thất bại";
        }

        public List<DonhangView> GetAll()
        {
            List<DonhangView> list = new List<DonhangView>();
            list = (from donhang in _donhangRes.GetAll()
                    join khachhang in _khachhangRes.GetAll() on donhang.KhachhangId equals khachhang.KhachhangId
                    join nhanvien in _nhanvienRes.GetAll() on donhang.NhanvienId equals nhanvien.NhanviennId
                    join shipper in _shipperRes.GetAll() on donhang.ShipperId equals shipper.ShipperId
                    select new DonhangView()
                    {
                        Donhang = donhang,
                        Khachhang = khachhang,
                        Nhanvien = nhanvien,
                        Shipper = shipper
                    }).ToList();
            return list;
        }

        public List<DonhangView> SearchDonhang(string value1, string value2, string value3, DateTime dateTime)
        {
            var lst = GetAll().Where(c => c.Nhanvien.Ten == value1 || c.Khachhang.HoTen == value2 || c.Shipper.Hoten == value3 || c.Donhang.Ngaydathang == dateTime).ToList();

            return lst;
        }
    }
}
