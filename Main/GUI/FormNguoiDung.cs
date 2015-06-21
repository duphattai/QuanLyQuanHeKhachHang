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
    public partial class FormNguoiDung : Form
    {
        private DevComponents.DotNetBar.TabControl _tabControl;

        private QLKhachHangDataContext data = new QLKhachHangDataContext(Connection.getConnectionString());
        private List<NHANVIEN> _listNhanVien;
        private List<NHOM_ND> _listNhomND;
        private List<NGUOIDUNG> _listNguoiDung;


        private NGUOIDUNG _taiKhoan = new NGUOIDUNG();
        public FormNguoiDung(DevComponents.DotNetBar.TabControl tabControl)
        {
            InitializeComponent();
            _tabControl = tabControl;

            txtMatKhau1.UseSystemPasswordChar = true;
            txtMatKhau2.UseSystemPasswordChar = true;
        }

        private void FormNguoiDung_Load(object sender, EventArgs e)
        {
            _listNguoiDung = data.NGUOIDUNGs.ToList();
            _listNhanVien = data.NHANVIENs.ToList();
            _listNhomND = data.NHOM_NDs.ToList();

            cbbLoaiTK.DataSource = _listNhomND;
            cbbLoaiTK.DisplayMember = "TenNhomND";

            cbbTenNV.DataSource = _listNhanVien;
            cbbTenNV.DisplayMember = "TenNV";

            showDataOnGridView();
        }

        private void showDataOnGridView()
        {
            dt_GridNguoiDung.Rows.Clear();
            if (_listNguoiDung.Count == 0)
                dt_GridNguoiDung.RowCount = 1;
            else
                dt_GridNguoiDung.RowCount = _listNguoiDung.Count;


            for(int i = 0; i < _listNguoiDung.Count; i++)
            {
                dt_GridNguoiDung.Rows[i].Cells["Ten_ND"].Value = _listNguoiDung[i].Ten_ND;
                dt_GridNguoiDung.Rows[i].Cells["MaNhomND"].Value = _listNguoiDung[i].MaNhomND;
                dt_GridNguoiDung.Rows[i].Cells["MaNV"].Value = _listNguoiDung[i].MaNV;
                dt_GridNguoiDung.Rows[i].Cells["MatKhau"].Value = _listNguoiDung[i].MatKhau;

                foreach(NHANVIEN nv in _listNhanVien)
                {
                    if(nv.MaNV.Equals(_listNguoiDung[i].MaNV))
                    {
                        dt_GridNguoiDung.Rows[i].Cells["TenNV"].Value = nv.TenNV;
                        break;
                    }
                }

                foreach (NHOM_ND nnd in _listNhomND)
                {
                    if (nnd.MaNhomND.Equals(_listNguoiDung[i].MaNhomND))
                    {
                        dt_GridNguoiDung.Rows[i].Cells["TenNhomND"].Value = nnd.TenNhomND;
                        break;
                    }
                }
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                _taiKhoan = new NGUOIDUNG();
                _taiKhoan.Ten_ND = txtTenTK.Text;             
                if(!txtMatKhau1.Text.Equals(txtMatKhau2.Text))
                {
                    MessageBox.Show("Mật khẩu không trùng nhau", "Thông báo");
                    return;
                }

                _taiKhoan.MatKhau = txtMatKhau1.Text;
                _taiKhoan.MaNV = _listNhanVien[cbbTenNV.SelectedIndex].MaNV;
                _taiKhoan.MaNhomND = _listNhomND[cbbLoaiTK.SelectedIndex].MaNhomND;

                data.NGUOIDUNGs.InsertOnSubmit(_taiKhoan);
                data.SubmitChanges();

                MessageBox.Show("Tạo thành công!", "Thông báo");
                btnTaoMoi_Click(sender, e);
            }catch(Exception ex)
            {
                MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo");
                //MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtTenTK.ReadOnly = false;

            txtTenTK.Text = "";
            txtMatKhau1.Text = "";
            txtMatKhau2.Text = "";

            _listNguoiDung = data.NGUOIDUNGs.ToList();
            showDataOnGridView();
        }


        private void dt_GridNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            try
            {
                txtTenTK.Text = dt_GridNguoiDung.Rows[row].Cells["Ten_ND"].Value.ToString();
                txtMatKhau1.Text = dt_GridNguoiDung.Rows[row].Cells["MatKhau"].Value.ToString();
                txtMatKhau2.Text = dt_GridNguoiDung.Rows[row].Cells["MatKhau"].Value.ToString();
                cbbLoaiTK.SelectedText = dt_GridNguoiDung.Rows[row].Cells["TenNhomND"].Value.ToString();
                cbbTenNV.SelectedText = dt_GridNguoiDung.Rows[row].Cells["TenNV"].Value.ToString();

                txtTenTK.ReadOnly = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                _taiKhoan = data.NGUOIDUNGs.Where(tk => tk.Ten_ND == txtTenTK.Text).SingleOrDefault<NGUOIDUNG>();
                if (_taiKhoan != null)
                {
                    if(!txtMatKhau1.Text.Equals(txtMatKhau2.Text))
                    {
                        MessageBox.Show("Mật khẩu không trùng nhau", "Thông báo");
                        return;
                    }
                    _taiKhoan.MaNhomND = _listNhomND[cbbLoaiTK.SelectedIndex].MaNhomND;
                    _taiKhoan.MatKhau = txtMatKhau1.Text;
                    _taiKhoan.MaNV = _listNhanVien[cbbTenNV.SelectedIndex].MaNV;

                    data.SubmitChanges();
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnTaoMoi_Click(sender, e);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {

                _taiKhoan = data.NGUOIDUNGs.Where(tk => tk.Ten_ND == txtTenTK.Text).SingleOrDefault<NGUOIDUNG>();
                if (_taiKhoan != null)
                {
                    data.NGUOIDUNGs.DeleteOnSubmit(_taiKhoan);
                    data.SubmitChanges();
                    showDataOnGridView();
                    System.Windows.Forms.MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Không xóa được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Quản lý tài khoản");
            }
        }

        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxShowPass.Checked == true)
            {
                txtMatKhau1.UseSystemPasswordChar = false;
                txtMatKhau2.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau1.UseSystemPasswordChar = true;
                txtMatKhau2.UseSystemPasswordChar = true;
            }
        }
    }
}
