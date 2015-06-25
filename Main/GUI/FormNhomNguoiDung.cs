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
    public partial class FormNhomNguoiDung : Form
    {
        private DevComponents.DotNetBar.TabControl _tabControl;
		QLKhachHangDataContext _data = new QLKhachHangDataContext(Connection.getConnectionString());

        private NHOM_ND _nhomnd = new NHOM_ND();
        private NHOM_ND _select = new NHOM_ND();
        private List<NHOM_ND> _listnhomnd;
        public FormNhomNguoiDung(DevComponents.DotNetBar.TabControl tabControl)
        {
            InitializeComponent();
			txtManhomND.Enabled = false;
            _tabControl = tabControl;
        }

	 private void showDataOnGridView()
        {
             
             dtgrid_NhomND.Rows.Clear();
             if(_listnhomnd.Count == 0)
                 dtgrid_NhomND.RowCount = _listnhomnd.Count + 1;
             else
                 dtgrid_NhomND.RowCount = _listnhomnd.Count;
             for(int i = 0; i < _listnhomnd.Count; i++)
             {
                 dtgrid_NhomND.Rows[i].Cells["STT"].Value = Convert.ToString(i + 1);
                 dtgrid_NhomND.Rows[i].Cells["ManhomND"].Value = _listnhomnd[i].MaNhomND.ToString();
                 dtgrid_NhomND.Rows[i].Cells["TennhomND"].Value = _listnhomnd[i].TenNhomND.ToString();
             }
          }
        private string GenerMaNhom()
         {
             string _manhomnd = "";
             _data.GetTopMaNhomNguoiDung(ref _manhomnd);
             Basic bs = new Basic(_manhomnd);
             return bs.GenerMaNhomNguoiDung(_manhomnd);
         }
        private void FormNhomNguoiDung_Load(object sender, EventArgs e)
        {
			_listnhomnd = _data.NHOM_NDs.ToList();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                _nhomnd = _data.NHOM_NDs.Where(nnd => nnd.MaNhomND == _select.MaNhomND).SingleOrDefault<NHOM_ND>();
                if(_nhomnd != null)
                {
                    _nhomnd.TenNhomND = txtTennhomND.Text;
                    _data.SubmitChanges();

                    _listnhomnd = _data.NHOM_NDs.ToList();
                    showDataOnGridView();
                      MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    System.Windows.Forms.MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Nhóm người dùng");
            }
        }

        private void btntaomoi_Click(object sender, EventArgs e)
        {
            txtManhomND.Text = GenerMaNhom();
            txtTennhomND.Text = "";

            _listnhomnd = _data.NHOM_NDs.ToList();
            showDataOnGridView();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                _nhomnd = new NHOM_ND();
                _nhomnd.MaNhomND = txtManhomND.Text;
                _nhomnd.TenNhomND = txtTennhomND.Text;

                _data.NHOM_NDs.InsertOnSubmit(_nhomnd);
                _data.SubmitChanges();
                MessageBox.Show("Thêm thành công", "Thông báo");
                _listnhomnd = _data.NHOM_NDs.ToList();
                showDataOnGridView();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Nhóm người dùng");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                _nhomnd = _data.NHOM_NDs.Where(nnd => nnd.MaNhomND == _select.MaNhomND).SingleOrDefault<NHOM_ND>();
                if(_nhomnd != null)
                {
                    _data.NHOM_NDs.DeleteOnSubmit(_nhomnd);
                    _data.SubmitChanges();

                    _listnhomnd = _data.NHOM_NDs.ToList();
                    showDataOnGridView();
                     System.Windows.Forms.MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Không xóa được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Nhóm người dùng");
            }
        }

        private void dtgrid_NhomND_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
            if (e.RowIndex < 0 || e.RowIndex == _listnhomnd.Count) _select = null;
            else
            {
                _select.MaNhomND = dtgrid_NhomND.Rows[e.RowIndex].Cells["ManhomND"].Value.ToString();
                _select.TenNhomND = dtgrid_NhomND.Rows[e.RowIndex].Cells["TennhomND"].Value.ToString();

                txtManhomND.Text = _select.MaNhomND;
                txtTennhomND.Text = _select.TenNhomND;
               
            }
        }
    }
}
