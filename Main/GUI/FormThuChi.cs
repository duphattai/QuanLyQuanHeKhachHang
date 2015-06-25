using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Main.BUS;
namespace Main.GUI
{
    public partial class FormThuChi : Form
    {
        QLKhachHangDataContext _data = new QLKhachHangDataContext(Connection.getConnectionString());
        private DevComponents.DotNetBar.TabControl _tabControl;
        private List<THUCHI> _listthuchi;

        private List<HOPDONG> _listhopdong;
        private List<NHANVIEN> _listnhanvien;

        private THUCHI _thuchi = new THUCHI();
        private THUCHI _select;
        private GIAODICH _giaodich = new GIAODICH();
        private HOPDONG _hopdong = new HOPDONG();


        public delegate void SendMessage(string value);
        public SendMessage value;
        public FormThuChi(DevComponents.DotNetBar.TabControl tabControl)
        {
            InitializeComponent();
            _tabControl = tabControl;
            txtMa_GD.Enabled = false;
            txtMaKhoan.Enabled = false;
            txtNVGD.Enabled = false;
            value = new SendMessage(GetMessage);
        }
        private void GetMessage(string message)
        {
            txtMa_GD.Text = message;
        }
        private string GenrMaTK()
        {
            String _matk = "";
            _data.GetTopMaThuChi(ref _matk);
            Basic bs = new Basic(_matk);
            return bs.GenerMaThuChi(_matk);

        }
        public void showdatagridview()
        {
            dtgrid_thuchi.Rows.Clear();
            if (_listthuchi.Count == 0)
                dtgrid_thuchi.RowCount = _listthuchi.Count + 1;
            else
                dtgrid_thuchi.RowCount = _listthuchi.Count;
            for (int i = 0; i < _listthuchi.Count; i++)
            {
                dtgrid_thuchi.Rows[i].Cells["STT"].Value = Convert.ToString(i + 1);
                dtgrid_thuchi.Rows[i].Cells["MaKhoan"].Value = _listthuchi[i].MaKhoan;
                dtgrid_thuchi.Rows[i].Cells["MaGD"].Value = _listthuchi[i].Ma_GD;
                dtgrid_thuchi.Rows[i].Cells["Tenkhoan"].Value = _listthuchi[i].TenKhoan;
                dtgrid_thuchi.Rows[i].Cells["Ngaythu"].Value = _listthuchi[i].NgayTH;
                dtgrid_thuchi.Rows[i].Cells["Tien"].Value = _listthuchi[i].Tien;
                dtgrid_thuchi.Rows[i].Cells["Nguoithu"].Value = _listthuchi[i].NguoiTH;
                dtgrid_thuchi.Rows[i].Cells["Nguoinhan"].Value = _listthuchi[i].NguoiNhan;
                dtgrid_thuchi.Rows[i].Cells["TenGD"].Value = _data.GIAODICHes.Where(gd => gd.Ma_GD == _listthuchi[i].Ma_GD).SingleOrDefault<GIAODICH>().TenGD;
            }

        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát!", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
                _tabControl.Tabs.Remove(_tabControl.SelectedTab);
            }
        }

        private void FormThuChi_Load(object sender, EventArgs e)
        {

            _giaodich = _data.GIAODICHes.Where(gd => gd.Ma_GD == txtMa_GD.Text.ToString()).SingleOrDefault<GIAODICH>();
            _hopdong = _data.HOPDONGs.Where(hd => hd.MaHD == _giaodich.MaHD).SingleOrDefault<HOPDONG>();

            _listhopdong = _data.HOPDONGs.ToList();
            _listnhanvien = _data.NHANVIENs.ToList();
            _listthuchi = _data.THUCHIs.ToList();

            txtMaKhoan.Text = GenrMaTK();
            dtNgayThu.Value = (DateTime)_giaodich.NgayGD;
            txtNVGD.Text = _hopdong.MaNV;


            cbtnhanvien.DataSource = _listnhanvien;
            cbtnhanvien.DisplayMembers = "MaNV";
            cbtnhanvien.DisplayMembers = "MaNV";

            showdatagridview();


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                _thuchi = new THUCHI();
                _thuchi.MaKhoan = txtMaKhoan.Text;
                _thuchi.Ma_GD = txtMa_GD.Text;
                _thuchi.TenKhoan = txtTenKhoan.Text;
                _thuchi.NgayTH = dtNgayThu.Value;
                _thuchi.NguoiNhan = _listnhanvien[cbtnhanvien.SelectedIndex].MaNV;
                _thuchi.NguoiTH = txtNVGD.Text;
                _thuchi.Tien = Convert.ToDouble(txtTienGD.Text);

                _data.THUCHIs.InsertOnSubmit(_thuchi);
                _data.SubmitChanges();
                _listthuchi = _data.THUCHIs.ToList();
                showdatagridview();
                MessageBox.Show("Thêm thành công", "Thông báo");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý thu chi");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                _thuchi = _data.THUCHIs.Where(tc => tc.MaKhoan == txtMaKhoan.Text).SingleOrDefault<THUCHI>();
                if (_thuchi != null)
                {
                    _thuchi.TenKhoan = txtTenKhoan.Text;
                    _thuchi.Tien = Convert.ToDouble(txtTienGD.Text);

                    _data.SubmitChanges();
                    _listthuchi = _data.THUCHIs.ToList();
                    showdatagridview();
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý thu chi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_select == null) return;
            try
            {
                _thuchi = _data.THUCHIs.Where(tc => tc.MaKhoan == _select.MaKhoan).SingleOrDefault<THUCHI>();
                if (_thuchi != null)
                {
                    _data.THUCHIs.DeleteOnSubmit(_thuchi);
                    _data.SubmitChanges();
                    _listthuchi = _data.THUCHIs.ToList();
                    showdatagridview();
                    System.Windows.Forms.MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Không xóa được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý thu chi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtgrid_thuchi_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.RowIndex == _listthuchi.Count) _select = null;
            else
            {
                _select = new THUCHI();
                _select.MaKhoan = dtgrid_thuchi.Rows[e.RowIndex].Cells["MaKhoan"].Value.ToString();
                _select.TenKhoan = dtgrid_thuchi.Rows[e.RowIndex].Cells["Tenkhoan"].Value.ToString();
                _select.Ma_GD = dtgrid_thuchi.Rows[e.RowIndex].Cells["MaGD"].Value.ToString();
                _select.NgayTH = (DateTime)dtgrid_thuchi.Rows[e.RowIndex].Cells["Ngaythu"].Value;
                _select.NguoiNhan = dtgrid_thuchi.Rows[e.RowIndex].Cells["Nguoinhan"].Value.ToString();
                _select.NguoiTH = dtgrid_thuchi.Rows[e.RowIndex].Cells["Nguoithu"].Value.ToString();
                _select.Tien = Convert.ToDouble(dtgrid_thuchi.Rows[e.RowIndex].Cells["Tien"].Value.ToString());

                txtMa_GD.Text = _select.Ma_GD;
                txtMaKhoan.Text = _select.MaKhoan;
                txtTenKhoan.Text = _select.TenKhoan;
                dtNgayThu.Value = (DateTime)_select.NgayTH;
                txtNVGD.Text = _select.NguoiTH;
                cbtnhanvien.Text = _select.NguoiNhan;
                txtTienGD.Text = _select.Tien.ToString();
            }

        }
    }
}
