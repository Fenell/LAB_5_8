using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using A_DAL.DomainModels;
using B_BUS.Service;
using B_BUS.ViewModels;

namespace C_GUI
{
    public partial class FrmChiTietDonHang : Form
    {
        public int IdDonHang { get; set; }
        public string TenKhachHang { get; set; }

        private ChitietdonhangViewService _ctDonhangViewService;
        private SanphamService _sanphamService;
        private int _idDonHangCTWhenClick;
        public FrmChiTietDonHang()
        {
            InitializeComponent();
            this.CenterToScreen();
            _sanphamService = new SanphamService();
            _ctDonhangViewService = new ChitietdonhangViewService();
        }

        private void FrmChiTietDonHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            lblDonGia.Text = "";
            lblThanhTien.Text = "";

            lblTenKhachHang.Text = TenKhachHang;

            cbbSanPham.DisplayMember = "TenSanpham";
            cbbSanPham.ValueMember = "SanphamId";
            cbbSanPham.DataSource = _sanphamService.GetAll();

            dgvCtDonHang.ColumnCount = 10;
            dgvCtDonHang.Columns[0].Visible = false;
            dgvCtDonHang.Columns[1].Name = "STT";
            dgvCtDonHang.Columns[1].Width = 30;
            dgvCtDonHang.Columns[2].Name = "Tên sản phẩm";
            dgvCtDonHang.Columns[3].Name = "Danh mục";
            dgvCtDonHang.Columns[4].Name = "Nhà cung cấp";
            dgvCtDonHang.Columns[5].Name = "Đơn vị tính";
            dgvCtDonHang.Columns[6].Name = "Số lượng";
            dgvCtDonHang.Columns[7].Name = "Đơn giá";
            dgvCtDonHang.Columns[8].Name = "Thành tiền";
            dgvCtDonHang.Columns[9].Visible = false;

            int stt = 1;
            dgvCtDonHang.Rows.Clear();
            foreach (var item in _ctDonhangViewService.GetAll(IdDonHang))
            {
                dgvCtDonHang.Rows.Add(item.DonhangChitiet.DonhangChitietId, stt++, item.Sanpham.TenSanpham,
                    item.Danhmuc.TenDanhMuc, item.Cungcap.TenLienhe, item.Sanpham.Donvi, item.DonhangChitiet.Soluong,
                    item.Sanpham.Gia, item.Thanhtien, item.Sanpham.SanphamId);
            }
        }

        private void dgvCtDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == -1 || rowIndex == _ctDonhangViewService.GetAll(IdDonHang).Count)
                return;

            _idDonHangCTWhenClick = int.Parse(dgvCtDonHang.Rows[rowIndex].Cells[0].Value.ToString());

            lblDonGia.Text = $"{dgvCtDonHang.Rows[rowIndex].Cells[7].Value: 0.##}đ";
            lblThanhTien.Text = $"{dgvCtDonHang.Rows[rowIndex].Cells[8].Value: 0.##}đ";
            numUpDown.Value = decimal.Parse(dgvCtDonHang.Rows[rowIndex].Cells[6].Value.ToString());
            cbbSanPham.SelectedValue = dgvCtDonHang.Rows[rowIndex].Cells[9].Value;
        }

        private ChitietdonhangView GetDataFromGui()
        {
            ChitietdonhangView ctdonhang = new ChitietdonhangView();
            ctdonhang.DonhangChitiet = new DonhangChitiet()
            {
                DonhangId = IdDonHang,
                SanphamId = int.Parse(cbbSanPham.GetItemText(cbbSanPham.SelectedValue)),
                Soluong = int.Parse(numUpDown.Value.ToString()),
            };
            return ctdonhang;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thêm mới đơn hàng này không?", "Hỏi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show(_ctDonhangViewService.AddCtDonHang(GetDataFromGui()), "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var donHangCT = GetDataFromGui();
            donHangCT.DonhangChitiet.DonhangChitietId = _idDonHangCTWhenClick;
            if (MessageBox.Show("Bạn có muốn sửa đơn hàng này không?", "Hỏi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show(_ctDonhangViewService.EditCTtDonHang(donHangCT), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (donHangCT.DonhangChitiet.Soluong == 0)
                {
                    MessageBox.Show(_ctDonhangViewService.DeleteCtDonHang(donHangCT), "Thông báo", MessageBoxButtons.OK);
                }
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var donHangCt = GetDataFromGui();
            donHangCt.DonhangChitiet.DonhangChitietId = _idDonHangCTWhenClick;
            if (MessageBox.Show("Bạn có muốn xóa đơn hàng này không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show(_ctDonhangViewService.DeleteCtDonHang(donHangCt), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
