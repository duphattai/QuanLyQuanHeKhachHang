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
using Main.BUS;

namespace Main.GUI
{
    public partial class FormGiaoDich : Form
    {
        private DevComponents.DotNetBar.TabControl _tabControl;


        private QLKhachHangDataContext data = new QLKhachHangDataContext(Connection.getConnectionString());
       
        GIAODICH _giaodich = new GIAODICH();
        HOPDONG _hopdong = new HOPDONG();
        private List<GIAODICH> _listGiaoDich;
        private List<HOPDONG> _listHopDong;
        public FormGiaoDich(DevComponents.DotNetBar.TabControl tabControl)
        {
            InitializeComponent();
            dtNGD.CustomFormat = "dd/MM/yyyy";

            dtgrid_GiaoDich.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Width = dtgrid_GiaoDich.Width;
            _tabControl = tabControl;
        }
        public void showDataOnGridView()
        {
            dtgrid_GiaoDich.DataSource = _listGiaoDich;
            dtgrid_GiaoDich.Columns["Ma_GD"].HeaderText = "Mã giao dịch";
            dtgrid_GiaoDich.Columns["MaHD"].HeaderText = "Mã hợp đồng";
            dtgrid_GiaoDich.Columns["TenGD"].HeaderText = "Tên giao dịch";
            dtgrid_GiaoDich.Columns["NgayGD"].HeaderText = "Ngày giao dịch";
            dtgrid_GiaoDich.Columns["DiaDiemGD"].HeaderText = "Địa điểm";
            dtgrid_GiaoDich.Columns["HOPDONG"].Visible = false;
        }
        
        public String  GenrMaGD()
        {
            String _magd = "";
            data.GetTopGiaoDich(ref _magd);
            Basic bs = new Basic(_magd);
            return bs.GenerMaGiaoDich(_magd);
        }
        private void FormGiaoDich_Load(object sender, EventArgs e)
        {
            _listGiaoDich = data.GIAODICHes.ToList();
            _listHopDong = data.HOPDONGs.ToList();
            _listGiaoDich = data.GIAODICHes.ToList();

            cbbMHD.DataSource = _listHopDong;
            cbbMHD.DisplayMember = "MaHD";

            cbbTimKiem.DataSource = _listHopDong;
            cbbTimKiem.DisplayMember = "MaHD";


            showDataOnGridView();
            txtMGD.Text = GenrMaGD();
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMGD.Enabled = false;
            try
            {

                _giaodich = data.GIAODICHes.Where(nv => nv.Ma_GD == txtMGD.Text).SingleOrDefault<GIAODICH>();
                if (_giaodich != null)
                {
                    data.GIAODICHes.DeleteOnSubmit(_giaodich);
                    data.SubmitChanges();
                    showDataOnGridView();
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
            cbbMHD.Text = "";           
            txtTGD.Text = "";
            cbbMHD.Text = "";

            _listGiaoDich = data.GIAODICHes.ToList();
            showDataOnGridView();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try{
                _giaodich.Ma_GD = txtMGD.Text;
                _giaodich.MaHD =  _listHopDong.ElementAt(cbbMHD.SelectedIndex).MaHD;
                _giaodich.NgayGD = dtNGD.Value;
                _giaodich.TenGD = txtTGD.Text;
                _giaodich.DiaDiemGD = txtDDGD.Text;

                data.GIAODICHes.InsertOnSubmit(_giaodich);
                //data.SubmitChanges();

                showDataOnGridView();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Quản lý giao dịch");
            }
            showDataOnGridView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMGD.Enabled = false;
            try
            {
                _giaodich = data.GIAODICHes.Where(gd => gd.Ma_GD == txtMGD.Text).SingleOrDefault<GIAODICH>();
                if(_giaodich != null)
                {
                    _giaodich.DiaDiemGD = txtDDGD.Text;
                    _giaodich.MaHD = _listHopDong.ElementAt(cbbMHD.SelectedIndex).MaHD;
                    _giaodich.NgayGD = dtNGD.Value;
                    _giaodich.TenGD = txtTGD.Text;

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

            showDataOnGridView();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (cbbTimKiem.SelectedIndex < 0) return;

            _listGiaoDich = (from _giaodich in data.GIAODICHes
                       where (_giaodich.MaHD.Contains(cbbTimKiem.Text))
                       select _giaodich).ToList<GIAODICH>();

            showDataOnGridView();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn muốn thoát!", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
                _tabControl.Tabs.Remove(_tabControl.SelectedTab);
            }
        }

        private void dtgrid_GiaoDich_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0 || row >= _listGiaoDich.Count) return;

            try
            {
                txtMGD.Text = dtgrid_GiaoDich.Rows[row].Cells[0].Value.ToString().Trim();
                String text = dtgrid_GiaoDich.Rows[row].Cells[1].Value.ToString().Trim();
                cbbMHD.Text = text;
                dtNGD.Text = Convert.ToDateTime(dtgrid_GiaoDich.Rows[row].Cells[3].Value).ToString("dd/MM/yyyy");
                txtTGD.Text = dtgrid_GiaoDich.Rows[row].Cells[2].Value.ToString().Trim();
                txtDDGD.Text = dtgrid_GiaoDich.Rows[row].Cells[4].Value.ToString().Trim();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Quản lý giao dịch");
            }
        }

    }
}
