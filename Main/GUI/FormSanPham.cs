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
    public partial class FormSanPham : Form
    {
        private QLKhachHangDataContext data = new QLKhachHangDataContext(Connection.getConnectionString());
        private SANPHAM _sanpham = new SANPHAM();
        private List<SANPHAM> _listSanPham;

        private SANPHAM _selected;

        public FormSanPham()
        {
            InitializeComponent();
            dtNSX.CustomFormat = "dd/MM/yyyy";
            dtgrid_SanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.Width = dtgrid_SanPham.Width;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        

        public void showDataOnGridView()
        {
            dtgrid_SanPham.DataSource = _listSanPham;
        }
       
        public string GenerMaSP()
        {
            string _masp = "";
            data.GetTopMaSanPham(ref _masp);

            Basic bs = new Basic(_masp);
            return bs.GenerMaSanPham(_masp);
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {
            _listSanPham = data.SANPHAMs.ToList();
            showDataOnGridView();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMSP.Text = GenerMaSP();
            txtDV.Text = "";
            txtGSP.Text = "";
            txtNSX.Text = "";
            txtTSP.Text ="";
            dtNSX.Text = "";

            _listSanPham = data.SANPHAMs.ToList();
            showDataOnGridView();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                _sanpham.MaSP = txtMSP.Text;
                _sanpham.TenSP = txtTSP.Text;
                _sanpham.GiaSP = (float)Convert.ToDouble(txtGSP.Text);
                _sanpham.NgaySX = dtNSX.Value;
                _sanpham.NuocSX = txtNSX.Text;
                _sanpham.DonVi = txtDV.Text;
                data.SANPHAMs.InsertOnSubmit(_sanpham);
                data.SubmitChanges();
                    
                System.Windows.Forms.MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnTaoMoi_Click(sender, e);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý sản phẩm");
            }
            showDataOnGridView();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            _sanpham = data.SANPHAMs.Where(sp => sp.MaSP == txtMSP.Text).SingleOrDefault<SANPHAM>();
            try
            {
                if(_sanpham != null)
                {
                    data.SANPHAMs.DeleteOnSubmit(_sanpham);
                    data.SubmitChanges();

                    MessageBox.Show("Xóa thành công", "Thông báo");
                    btnTaoMoi_Click(sender, e);
                }

            }catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Quản lý sản phẩm");
                MessageBox.Show("Không thể xóa do sản phẩm đã được giao dịch hoặc thực hiện hợp đồng", "Quản lý sản phẩm");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                _sanpham = data.SANPHAMs.Where(sp => sp.MaSP == txtMSP.Text).SingleOrDefault<SANPHAM>();
                if(_sanpham != null)
                {
                    _sanpham.TenSP = txtTSP.Text;
                    _sanpham.GiaSP = (float)Convert.ToDouble(txtGSP.Text);
                    _sanpham.NgaySX = dtNSX.Value;
                    _sanpham.DonVi = txtDV.Text;
                    _sanpham.NuocSX = txtNSX.Text;
                    data.SubmitChanges();


                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnTaoMoi_Click(sender, e);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý sản phẩm");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát!", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            _listSanPham = (from sanpham in data.SANPHAMs
                       where (sanpham.MaSP.Contains(txtTimKiem.Text) || sanpham.TenSP.Contains(txtTimKiem.Text))
                       select sanpham).ToList<SANPHAM>();

            showDataOnGridView();
        }

        private void dtgrid_SanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == _listSanPham.Count)
                _selected = null;
            else
            {
                int row = e.RowIndex;
                _selected = new SANPHAM();

                _selected.MaSP = dtgrid_SanPham.Rows[row].Cells["MaSP"].Value.ToString();
                _selected.TenSP = dtgrid_SanPham.Rows[row].Cells["TenSP"].Value.ToString();
                _selected.NuocSX = dtgrid_SanPham.Rows[row].Cells["NuocSX"].Value.ToString();
                _selected.GiaSP = Convert.ToDouble(dtgrid_SanPham.Rows[row].Cells["GiaSP"].Value.ToString());
                _selected.DonVi = dtgrid_SanPham.Rows[row].Cells["DonVi"].Value.ToString();
                _selected.NgaySX = (DateTime)(dtgrid_SanPham.Rows[row].Cells["NgaySX"].Value);


                txtMSP.Text = dtgrid_SanPham.Rows[row].Cells["MaSP"].Value.ToString();
                txtTSP.Text = dtgrid_SanPham.Rows[row].Cells["TenSP"].Value.ToString();
                txtNSX.Text = dtgrid_SanPham.Rows[row].Cells["NuocSX"].Value.ToString();
                txtGSP.Text = dtgrid_SanPham.Rows[row].Cells["GiaSP"].Value.ToString();
                txtDV.Text = dtgrid_SanPham.Rows[row].Cells["DonVi"].Value.ToString();
                dtNSX.Text = Convert.ToDateTime(dtgrid_SanPham.Rows[row].Cells["NgaySX"].Value).ToString("dd/MM/yyyy");
            }
        }
        

    }
}
