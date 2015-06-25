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
    public partial class FormNhomKhachHang : Form
    {
        private DevComponents.DotNetBar.TabControl _tabControl;
        private QLKhachHangDataContext _data = new QLKhachHangDataContext(Connection.getConnectionString());


        private List<NHOM_KH> _listnhomkh;
        private NHOM_KH _nhomkh = new NHOM_KH();
        private NHOM_KH _select;
        public FormNhomKhachHang(DevComponents.DotNetBar.TabControl tabControl)
        {
            InitializeComponent();
            txtMaNhomKH.Enabled = false;
            _tabControl = tabControl;
        }

        private void showDataOnGridView()
        {

            // dtgrid_NhomKH.DataSource = _listnhomkh;
            dtgrid_NhomKH.Rows.Clear();

            dtgrid_NhomKH.RowCount = _listnhomkh.Count;

            for (int i = 0; i < _listnhomkh.Count; i++)
            {
                dtgrid_NhomKH.Rows[i].Cells["STT"].Value = Convert.ToString(i + 1);
                dtgrid_NhomKH.Rows[i].Cells["MaNhomKH"].Value = _listnhomkh[i].MaNhomKH;
                dtgrid_NhomKH.Rows[i].Cells["TenNhomKH"].Value = _listnhomkh[i].TenNhomKH;

            }


        }
        private void FormNhomKhachHang_Load(object sender, EventArgs e)
        {
            _listnhomkh = _data.NHOM_KHs.ToList();

            showDataOnGridView();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát!", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
                _tabControl.Tabs.Remove(_tabControl.SelectedTab);
            }
        }
        private string GenrMaNhomKH()
        {
            String _manhomkh = "";
            _data.GetTopMaNhomKhachHang(ref _manhomkh);
            Basic bs = new Basic(_manhomkh);
            return bs.GenerMaNhomKhachHang(_manhomkh);

        }

        private void btntaomoi_Click(object sender, EventArgs e)
        {
            txtMaNhomKH.Text = GenrMaNhomKH();
            txtMaNhomKH.Enabled = false;
            txtTenNhomKH.Text = "";
            _listnhomkh = _data.NHOM_KHs.ToList();
            showDataOnGridView();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                _nhomkh = new NHOM_KH();
                _nhomkh.MaNhomKH = txtMaNhomKH.Text;
                _nhomkh.TenNhomKH = txtTenNhomKH.Text;

                _data.NHOM_KHs.InsertOnSubmit(_nhomkh);
                _data.SubmitChanges();
                showDataOnGridView();
                MessageBox.Show("Thêm thành công", "Thông báo");
                btntaomoi_Click(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Nhóm khách hàng");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {

                _nhomkh = _data.NHOM_KHs.Where(nkh => nkh.MaNhomKH == _select.MaNhomKH).SingleOrDefault<NHOM_KH>();

                if (_nhomkh != null)
                {
                    _nhomkh.MaNhomKH = txtMaNhomKH.Text;
                    _nhomkh.TenNhomKH = txtTenNhomKH.Text;

                    _data.SubmitChanges();
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    System.Windows.Forms.MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Nhóm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            showDataOnGridView();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_select == null) return;
            try
            {
                _nhomkh = _data.NHOM_KHs.Where(nkh => nkh.MaNhomKH == _select.MaNhomKH).SingleOrDefault<NHOM_KH>();
                if (_nhomkh != null)
                {
                    _data.NHOM_KHs.DeleteOnSubmit(_nhomkh);
                    _data.SubmitChanges();

                    _listnhomkh = _data.NHOM_KHs.ToList();
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
                MessageBox.Show(ex.Message, "Nhóm khách hàng");
            }

        }

        private void dtgrid_NhomKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.RowIndex == _listnhomkh.Count) _select = null;
            else
            {
                _select.MaNhomKH = dtgrid_NhomKH.Rows[e.RowIndex].Cells["MaNhomKH"].Value.ToString();
                _select.TenNhomKH = dtgrid_NhomKH.Rows[e.RowIndex].Cells["TenNhomKH"].Value.ToString();

                txtMaNhomKH.Text = _select.MaNhomKH;
                txtTenNhomKH.Text = _select.TenNhomKH;
            }
        }
    }
}
