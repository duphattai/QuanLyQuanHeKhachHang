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
    public partial class FormHoaDon : Form
    {

        QLKhachHangDataContext data = new QLKhachHangDataContext();
        CTHD _hoadon = new CTHD();
        HOPDONG _hopdong = new HOPDONG();
        SANPHAM _sanpham = new SANPHAM();

   

        public FormHoaDon()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            dtgrid_HoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Width = dtgrid_HoaDon.Width;

            txtGia.Text = TinhTien().ToString();
        }
         public void Refresh()
        {
            txtMHD.Enabled = false;
            var list = from hoadon in data.CTHDs
                       select hoadon;

           dtgrid_HoaDon.DataSource = list;
           var sanp = from sanpham in data.SANPHAMs
                      select sanpham;
           cbtMSP.DataSource = sanp;
           cbtMSP.DisplayMembers = "MASP";
           cbtMSP.ValueMember = "MASP";

           var hd = from hopdong in data.HOPDONGs
                    select hopdong;
           cbtMHD.DataSource = hd;
           cbtMHD.DisplayMembers = "MAHD";
           cbtMHD.ValueMember = "MAHD";
}
         string _mahd;
        public string generMa()
         {
             data.GetTopMaCTHD(ref _mahd);
             Basic bs = new Basic();
             return bs.GenerMa(_mahd);
         }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            cbtMHD.Text = "";
            cbtMSP.Text = "";
            txtGia.Text = "";
            txtMHD.Text = generMa(); ;
            txtSL.Value = 0;
            
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            txtMHD.Enabled = false;
            try
            {
                _hoadon.MACTHD = txtMHD.Text;
                _hoadon.MASP = cbtMSP.Text;
                _hoadon.MAHD = cbtMHD.Text;
                _hoadon.SOLUONG = (int)txtSL.Value;
                _hoadon.THANHTIEN = (float)Convert.ToDouble(txtGia.Text.ToString());

                data.CTHDs.InsertOnSubmit(_hoadon);
                data.SubmitChanges();
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý hóa đơn");
            }
            Refresh();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMHD.Enabled = false;
            _hoadon = data.CTHDs.Where(hd => hd.MACTHD == txtMHD.Text).SingleOrDefault<CTHD>();
            try
            {
                if(_hoadon != null)
                {
                    data.CTHDs.DeleteOnSubmit(_hoadon);
                    data.SubmitChanges();
                    MessageBox.Show("Xóa thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }else
                    MessageBox.Show("Xóa thất bại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            catch(Exception  ex)
            {
                MessageBox.Show(ex.Message, "Quản lý hóa đơn");
            }
            Refresh();
        }
        public float TinhTien()
        {
            int Soluong = (int)txtSL.Value;
            float Gia = (float)Convert.ToDouble(data.SANPHAMs.Where(sp=> sp.MASP == cbtMSP.Text).SingleOrDefault<SANPHAM>());
            return  (float)Soluong * Gia;

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMHD.Enabled = false;
            
            _hoadon = data.CTHDs.Where(hd => hd.MACTHD == txtMHD.Text).SingleOrDefault<CTHD>();
            try
            {
                if (_hoadon != null)
                {
                    _hoadon.MAHD = cbtMHD.Text;
                    _hoadon.MASP = cbtMSP.Text;
                    _hoadon.SOLUONG = (int)txtSL.Value;

                    _hoadon.THANHTIEN = (float)Convert.ToDouble(txtGia.Text);

                    data.SubmitChanges();
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Refresh();
        }

        private void dtgrid_HoaDon_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMHD.Enabled = false;
            int row = e.RowIndex;
           try {

               txtMHD.Text = dtgrid_HoaDon.Rows[row].Cells[0].Value.ToString().Trim();
               txtGia.Text = dtgrid_HoaDon.Rows[row].Cells[4].Value.ToString().Trim();
               txtSL.Value = (int)Convert.ToInt32(dtgrid_HoaDon.Rows[row].Cells[3].Value);
               cbtMHD.Text = dtgrid_HoaDon.Rows[row].Cells[2].Value.ToString().Trim();
               cbtMSP.Text = dtgrid_HoaDon.Rows[row].Cells[3].Value.ToString().Trim() ;
            }
            catch(Exception ex)
           {
               MessageBox.Show(ex.Message, "Quản lý hóa đơn");
           }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            var list = from hoadon in data.CTHDs
                       where (hoadon.MACTHD.Contains(txtTimKiem.Text) || hoadon.MAHD.Contains(txtTimKiem.Text) || hoadon.MASP.Contains(txtTimKiem.Text))
                       select hoadon;
            dtgrid_HoaDon.DataSource = list;
        }
    }
}
