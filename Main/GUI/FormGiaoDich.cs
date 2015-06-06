using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.GUI
{
    public partial class FormGiaoDich : Form
    {

        QLKhachHangDataContext data = new QLKhachHangDataContext();
       
        GIAODICH _giaodich = new GIAODICH();
        HOPDONG _hopdong = new HOPDONG();
        public FormGiaoDich()
        {
            InitializeComponent();
            dtNGD.CustomFormat = "dd/MM/yyyy";

            dtgrid_GiaoDich.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Width = dtgrid_GiaoDich.Width;
          
        }
        public void Refresh()
        {
            data.DeferredLoadingEnabled = false;
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<HOPDONG>(_hd => _hd.MAHD);
            data.LoadOptions = dlo;
            var list = from giaodich in data.GIAODICHes
                       select giaodich;
            
            dtgrid_GiaoDich.DataSource = list;
            dtgrid_GiaoDich.Columns["MA_GD"].HeaderText = "Mã giao dịch";
            dtgrid_GiaoDich.Columns["MAHD"].HeaderText = "Mã hợp đồng";
            dtgrid_GiaoDich.Columns["TEN_GD"].HeaderText = "Tên giao dịch";
            dtgrid_GiaoDich.Columns["NGAYGD"].HeaderText = "Ngày giao dịch";
            dtgrid_GiaoDich.Columns["DIADIEMGD"].HeaderText = "Địa điểm";
            

          

            var hd = from hopdong in data.HOPDONGs
                     select hopdong;

            cbtMHD.DataSource = hd;

            cbtMHD.DisplayMembers = "MAHD";
            cbtMHD.ValueMember = "MAHD";
        }
        string _magd;
        public string  GenrMaGD()
        {
            data.GetTopGiaoDich(ref _magd);
            Basic bs = new Basic();
            return bs.GenerMa(_magd);
        }
        private void FormGiaoDich_Load(object sender, EventArgs e)
        {
            
            Refresh();
        }

        private void dtgrid_GiaoDich_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMGD.Enabled = false;
            int row = e.RowIndex;
          
            try
            { 

                txtMGD.Text = dtgrid_GiaoDich.Rows[row].Cells[0].Value.ToString().Trim();
                String text = dtgrid_GiaoDich.Rows[row].Cells[1].Value.ToString().Trim();
                cbtMHD.Text = text;
                dtNGD.Text = Convert.ToDateTime(dtgrid_GiaoDich.Rows[row].Cells[3].Value).ToString("dd/MM/yyyy");
                txtTGD.Text = dtgrid_GiaoDich.Rows[row].Cells[2].Value.ToString().Trim();
                txtDDGD.Text = dtgrid_GiaoDich.Rows[row].Cells[4].Value.ToString().Trim();
                
            } catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Quản lý giao dịch re");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMGD.Enabled = false;
            try
            {

                _giaodich = data.GIAODICHes.Where(nv => nv.MA_GD == txtMGD.Text).SingleOrDefault<GIAODICH>();
                if (_giaodich != null)
                {
                    data.GIAODICHes.DeleteOnSubmit(_giaodich);
                    data.SubmitChanges();
                    Refresh();
                    System.Windows.Forms.MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Không xóa được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Quản lý giao dịch");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
            txtMGD.Text = GenrMaGD();
            txtDDGD.Text =" ";
            cbtMHD.Text = "";           
            txtTGD.Text = "";
            cbtMHD.Text = "";
            
            txtMGD.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            txtMGD.Enabled = false;
            try{
                _giaodich.MA_GD = txtMGD.Text;
                _giaodich.MAHD = cbtMHD.ValueMember;
                _giaodich.NGAYGD = dtNGD.Text;
                _giaodich.TEN_GD = txtTGD.Text;
                _giaodich.DIADIEMGD = txtDDGD.Text;

                data.GIAODICHes.InsertOnSubmit(_giaodich);
                data.SubmitChanges();

                Refresh();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Quản lý giao dịch");
            }
            Refresh();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMGD.Enabled = false;
            try
            {
                _giaodich = data.GIAODICHes.Where(gd => gd.MA_GD == txtMGD.Text).SingleOrDefault<GIAODICH>();
                if(_giaodich != null)
                {
                    _giaodich.DIADIEMGD = txtDDGD.Text;
                    _giaodich.MAHD = cbtMHD.Text;
                    _giaodich.NGAYGD = dtNGD.Text;
                    _giaodich.TEN_GD = txtTGD.Text;

                    data.SubmitChanges();
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                else
                {
                    System.Windows.Forms.MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý giao dịch", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Refresh();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            var list = from _giaodich in data.GIAODICHes
                       where (_giaodich.MA_GD.Contains(txtTimKiem.Text) || _giaodich.TEN_GD.Contains(txtTimKiem.Text))
                       select _giaodich;
            dtgrid_GiaoDich.DataSource = list;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

    }
}
