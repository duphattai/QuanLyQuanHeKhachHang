using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.GUI
{
    public partial class FormSanPham : Form
    {
        public FormSanPham()
        {
            InitializeComponent();
            dtNSX.CustomFormat = "dd/MM/yyyy";
            dtgrid_SanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.Width = dtgrid_SanPham.Width;
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        QLKhachHangDataContext data = new QLKhachHangDataContext();
        SANPHAM _sanpham = new SANPHAM();

        public void Refresh()
        {
            var listsp = from lay in data.SANPHAMs
                         select lay;
            dtgrid_SanPham.DataSource = listsp;
        }
        String _masp;
        public string GenerMa()
        {
            data.GetTopMaSanPham(ref _masp);

            Basic bs = new Basic();
            return bs.GenerMa(_masp);

        }
        private void FormSanPham_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMSP.Text = GenerMa();
            txtMSP.Enabled = false;
            txtDV.Text = "";
            txtGSP.Text = "";
            txtNSX.Text = "";
            txtTSP.Text ="";
            dtNSX.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            txtMSP.Enabled = false;
           
            try
            {
               
              
                    _sanpham.MASP = txtMSP.Text;
                    _sanpham.TENSP = txtTSP.Text;
                    _sanpham.GIASP = (float)Convert.ToDouble(txtGSP.Text);
                    _sanpham.NGAYSX = dtNSX.Text;
                    _sanpham.NUOCSX = txtNSX.Text;
                    _sanpham.DONVI = txtDV.Text;
                    data.SANPHAMs.InsertOnSubmit(_sanpham);
                    data.SubmitChanges();
                    
                    System.Windows.Forms.MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý sản phẩm");
            }
            Refresh();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMSP.Enabled = false;
            _sanpham = data.SANPHAMs.Where(sp => sp.MASP == txtMSP.Text).SingleOrDefault<SANPHAM>();
            try
            {
                if(_sanpham != null)
                {
                    data.SANPHAMs.DeleteOnSubmit(_sanpham);
                    data.SubmitChanges();
                    
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý sản phẩm");
                }
            Refresh();
            }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMSP.Enabled = false;
            _sanpham = data.SANPHAMs.Where(sp => sp.MASP == txtMSP.Text).SingleOrDefault<SANPHAM>();
            try
            {
                if(_sanpham != null)
                {
                    _sanpham.TENSP = txtTSP.Text;
                    _sanpham.GIASP = (float)Convert.ToDouble(txtGSP.Text);
                    _sanpham.NGAYSX = dtNSX.Text;
                    _sanpham.DONVI = txtDV.Text;
                    _sanpham.NUOCSX = txtNSX.Text;
                    data.SubmitChanges();
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý sản phẩm");
            }
            Refresh();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            var list = from sanpham in data.SANPHAMs
                       where (sanpham.MASP.Contains(txtTimKiem.Text) || sanpham.TENSP.Contains(txtTimKiem.Text))
                       select sanpham;
            dtgrid_SanPham.DataSource = list;
        }

        private void dtgrid_SanPham_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMSP.Enabled = false;

            txtMSP.Text = dtgrid_SanPham.Rows[row].Cells[0].Value.ToString();
            txtTSP.Text = dtgrid_SanPham.Rows[row].Cells[1].Value.ToString();
            txtNSX.Text = dtgrid_SanPham.Rows[row].Cells[2].Value.ToString();
            txtGSP.Text = dtgrid_SanPham.Rows[row].Cells[3].Value.ToString();
            txtDV.Text = dtgrid_SanPham.Rows[row].Cells[4].Value.ToString();
            dtNSX.Text = Convert.ToDateTime(dtgrid_SanPham.Rows[row].Cells[5].Value).ToString("dd/MM/yyyy");


        }
        

    }
}
