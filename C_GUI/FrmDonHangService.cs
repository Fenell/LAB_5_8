using A_DAL.DomainModels;
using B_BUS.Service;
using B_BUS.ViewModels;

namespace C_GUI
{
    public partial class FrmDonHangService : Form
    {
        private DonHangViewService _donHangView;
        private KhachhangService _khachhangService;
        private NhanvienService _nhanvienService;
        private ShipperService _shipperService;
        private int _idDonhangWhenClick;
        private string _tenKhachHang;

        public FrmDonHangService()
        {
            _donHangView = new DonHangViewService();
            _khachhangService = new KhachhangService();
            _nhanvienService = new NhanvienService();
            _shipperService = new ShipperService();
            InitializeComponent();
            this.CenterToScreen();
        }

        private void FrmDonHangService_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {

            cbbBuyer.DisplayMember = "HoTen";
            cbbBuyer.ValueMember = "KhachhangID";
            cbbBuyer.DataSource = _khachhangService.GetAll();
            cbbBuyer.Text = "";

            cbbSeller.DisplayMember = "Ten";
            cbbSeller.ValueMember = "NhanviennId";
            cbbSeller.DataSource = _nhanvienService.GetAll();
            cbbSeller.Text = "";

            cbbShipper.DisplayMember = "Hoten";
            cbbShipper.ValueMember = "ShipperId";
            cbbShipper.DataSource = _shipperService.GetAlList();
            cbbShipper.Text = "";

            dgvDonhang.ColumnCount = 9;
            dgvDonhang.Columns[0].Name = "STT";
            dgvDonhang.Columns[0].Width = 30;
            dgvDonhang.Columns[1].Name = "Người bán";
            dgvDonhang.Columns[2].Name = "Người mua";
            dgvDonhang.Columns[3].Name = "Ngày bán";
            dgvDonhang.Columns[4].Name = "Người giao";
            dgvDonhang.Columns[5].Visible = false;
            dgvDonhang.Columns[6].Visible = false;
            dgvDonhang.Columns[7].Visible = false;
            dgvDonhang.Columns[8].Visible = false;

            dgvDonhang.Rows.Clear();
            int stt = 1;
            foreach (var item in _donHangView.GetAll())
            {
                dgvDonhang.Rows.Add(stt++, item.Nhanvien.Ten, item.Khachhang.HoTen, item.Donhang.Ngaydathang, item.Shipper.Hoten, item.Donhang.DonhangId, item.Nhanvien.NhanviennId, item.Khachhang.KhachhangId, item.Shipper.ShipperId);
            }
        }

        private void dgvDonhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == -1 || rowIndex == _donHangView.GetAll().Count)
                return;

            _tenKhachHang = dgvDonhang.Rows[rowIndex].Cells[2].Value.ToString();
            _idDonhangWhenClick = int.Parse(dgvDonhang.Rows[rowIndex].Cells[5].Value.ToString());
            cbbSeller.SelectedValue = dgvDonhang.Rows[rowIndex].Cells[6].Value;
            cbbBuyer.SelectedValue = dgvDonhang.Rows[rowIndex].Cells[7].Value;
            cbbShipper.SelectedValue = dgvDonhang.Rows[rowIndex].Cells[8].Value;
            dtime.Value = DateTime.Parse(dgvDonhang.Rows[rowIndex].Cells[3].Value.ToString());
        }

        private DonhangView GetDataFromGui()
        {
            DonhangView donhangView = new DonhangView();
            donhangView.Donhang = new Donhang
            {
                KhachhangId = Convert.ToInt16(cbbBuyer.GetItemText(cbbBuyer.SelectedValue)),
                NhanvienId = Convert.ToInt16(cbbSeller.GetItemText(cbbSeller.SelectedValue)),
                ShipperId = Convert.ToInt16(cbbShipper.GetItemText(cbbShipper.SelectedValue)),
                Ngaydathang = dtime.Value
            };
            return donhangView;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thêm đơn hàng không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show(_donHangView.AddDonHangView(GetDataFromGui()));
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa đơn hàng này không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var donhang = GetDataFromGui();
                donhang.Donhang.DonhangId = _idDonhangWhenClick;
                MessageBox.Show(_donHangView.EditDonHangView(donhang), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa đơn hàng này không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var donhang = GetDataFromGui();
                donhang.Donhang.DonhangId = _idDonhangWhenClick;
                MessageBox.Show(_donHangView.DeleleDonHangView(donhang), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvDonhang.ColumnCount = 9;
            dgvDonhang.Columns[0].Name = "STT";
            dgvDonhang.Columns[0].Width = 30;
            dgvDonhang.Columns[1].Name = "Người bán";
            dgvDonhang.Columns[2].Name = "Người mua";
            dgvDonhang.Columns[3].Name = "Ngày giao";
            dgvDonhang.Columns[4].Name = "Người giao";
            dgvDonhang.Columns[5].Visible = false;
            dgvDonhang.Columns[6].Visible = false;
            dgvDonhang.Columns[7].Visible = false;
            dgvDonhang.Columns[8].Visible = false;

            dgvDonhang.Rows.Clear();
            int stt = 1;
            foreach (var item in _donHangView.SearchDonhang(cbbSeller.Text, cbbBuyer.Text, cbbShipper.Text, dtime.Value))
            {
                dgvDonhang.Rows.Add(stt++, item.Nhanvien.Ten, item.Khachhang.HoTen, item.Donhang.Ngaydathang, item.Shipper.Hoten, item.Donhang.DonhangId, item.Nhanvien.NhanviennId, item.Khachhang.KhachhangId, item.Shipper.ShipperId);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            FrmChiTietDonHang ctDonhang = new FrmChiTietDonHang();
            ctDonhang.IdDonHang = _idDonhangWhenClick;
            if (_idDonhangWhenClick == 0)
            {
                MessageBox.Show("Chọn đơn hàng cần xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ctDonhang.TenKhachHang = _tenKhachHang;
            ctDonhang.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình không?", "Hỏi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


    }
}