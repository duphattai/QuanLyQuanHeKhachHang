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
    public partial class FormHoaDon : Form
    {
        private DevComponents.DotNetBar.TabControl _tabControl;
        private QLKhachHangDataContext data = new QLKhachHangDataContext(Connection.getConnectionString());
        
        private HOPDONG _hopdong = new HOPDONG();
        private SANPHAM _sanpham = new SANPHAM();
        private CTHD _hoadon = new CTHD();

        private List<SANPHAM> _listSanPham;
        private List<HOPDONG> _listHopDong;
        private List<CTHD> _listCTHD;


        private CTHD _selected = null;
        public FormHoaDon(DevComponents.DotNetBar.TabControl tabControl)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            dtgrid_HoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Width = dtgrid_HoaDon.Width;
            _tabControl = tabControl;
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            _listHopDong = data.HOPDONGs.ToList();
            _listSanPham = data.SANPHAMs.ToList();
            _listCTHD = data.CTHDs.ToList();

            cbbTenHD.DataSource = _listHopDong;
            cbbTenHD.DisplayMember = "TenHD";

            cbbTenSP.DataSource = _listSanPham;
            cbbTenHD.DisplayMember = "TenSP";

            cbtTimKiem.DataSource = _listHopDong;
            cbtTimKiem.DisplayMember = "TenHD";

            txtGia.Text = TinhTien().ToString();
            Refresh();
        }
        public void Refresh()
        {
            dtgrid_HoaDon.Rows.Clear();
            if (_listCTHD.Count == 0)
                dtgrid_HoaDon.RowCount = _listCTHD.Count + 1;
            else
                dtgrid_HoaDon.RowCount = _listCTHD.Count;

            for(int i = 0; i < _listCTHD.Count; i++)
            {
                dtgrid_HoaDon.Rows[i].Cells["SoLuong"].Value = _listCTHD[i].SoLuong;
                dtgrid_HoaDon.Rows[i].Cells["ThanhTien"].Value = _listCTHD[i].ThanhTien;
                dtgrid_HoaDon.Rows[i].Cells["MaSP"].Value = _listCTHD[i].MaSP;
                dtgrid_HoaDon.Rows[i].Cells["MaHD"].Value = _listCTHD[i].MaHD;

                foreach(SANPHAM sp in _listSanPham)
                {
                    if(sp.MaSP.Equals(_listCTHD[i].MaSP))
                    {
                        dtgrid_HoaDon.Rows[i].Cells["TenSP"].Value = sp.TenSP;
                        break;
                    }
                }

                foreach (HOPDONG hd in _listHopDong)
                {
                    if (hd.MaHD.Equals(_listCTHD[i].MaHD))
                    {
                        dtgrid_HoaDon.Rows[i].Cells["TenHD"].Value = hd.TenHD;
                        break;
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(buttonLuu.Enabled == true)
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                cbbTenHD.Enabled = true;
                cbbTenHD.Enabled = true;
                buttonLuu.Enabled = false;
            }
            else
            {
                if (MessageBox.Show("Bạn muốn thoát!", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();
                    _tabControl.Tabs.Remove(_tabControl.SelectedTab);
                }
            }     
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                _hoadon.MaSP = _listSanPham.ElementAt(cbbTenHD.SelectedIndex).MaSP;
                _hoadon.MaHD = _listHopDong[cbbTenHD.SelectedIndex].MaHD;
                _hoadon.SoLuong = (int)txtSL.Value;
                _hoadon.ThanhTien = (float)Convert.ToDouble(txtGia.Text.ToString());

                data.CTHDs.InsertOnSubmit(_hoadon);
                data.SubmitChanges();

                MessageBox.Show("Them thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _listCTHD = data.CTHDs.ToList();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý hóa đơn");
            }
        }

      
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if(_selected != null)
                {
                    _hoadon = data.CTHDs.Where(hd => hd.MaHD == _selected.MaHD && hd.MaSP == _selected.MaSP).SingleOrDefault<CTHD>();
                    data.CTHDs.DeleteOnSubmit(_hoadon);
                    data.SubmitChanges();
                    MessageBox.Show("Xóa thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    _selected = null;
                    _listCTHD = data.CTHDs.ToList();
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
            if (cbbTenHD.SelectedIndex < 0) return 0;

            int Soluong = (int)txtSL.Value;
            _sanpham = data.SANPHAMs.Where(sp => sp.MaSP == _listSanPham[cbbTenHD.SelectedIndex].MaSP).SingleOrDefault<SANPHAM>();
            float Gia = (float)Convert.ToDouble(_sanpham.GiaSP);
            return  (float)Soluong * Gia;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            buttonLuu.Enabled = true;

            cbbTenHD.Enabled = false;
            cbbTenHD.Enabled = false;
        }

        private void dtgrid_HoaDon_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           //int row = e.RowIndex;
           //if (row < 0) return;
           //try {

           //        txtGia.Text = dtgrid_HoaDon.Rows[row].Cells["Gia"].Value.ToString().Trim();
           //        txtSL.Value = (int)Convert.ToInt32(dtgrid_HoaDon.Rows[row].Cells["SoLuong"].Value);
           //        cbtMHD.Text = dtgrid_HoaDon.Rows[row].Cells[""].Value.ToString().Trim();
           //        cbtMSP.Text = dtgrid_HoaDon.Rows[row].Cells[3].Value.ToString().Trim() ;
           // }
           // catch(Exception ex)
           //{
           //    MessageBox.Show(ex.Message, "Quản lý hóa đơn");
           //}
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            _listCTHD = (from hoadon in data.CTHDs
                       where (hoadon.MaHD.Contains(_listHopDong[cbtTimKiem.SelectedIndex].MaHD))
                       select hoadon).ToList<CTHD>();

            Refresh();
        }

        private void dtgrid_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _listCTHD.Count)
            {
                _selected = new CTHD();
                _selected.MaHD = dtgrid_HoaDon.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();
                _selected.MaSP = dtgrid_HoaDon.Rows[e.RowIndex].Cells["MaSP"].Value.ToString();
                _selected.SoLuong = Convert.ToInt32(dtgrid_HoaDon.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString());
                _selected.ThanhTien = Convert.ToInt32(dtgrid_HoaDon.Rows[e.RowIndex].Cells["ThanhTien"].Value.ToString());


                txtGia.Text = _selected.ThanhTien.ToString();
                txtSL.Value = _selected.SoLuong;
                cbbTenHD.Text = _selected.MaHD.ToString().Trim();
                cbbTenHD.Text = _selected.MaSP.ToString().Trim();
            }
            else
                _selected = null;
        }

        private void txtSL_ValueChanged(object sender, EventArgs e)
        {
            int Soluong = (int)txtSL.Value;   
            float Gia = (float)Convert.ToDouble(_sanpham.GiaSP) * Soluong;
            txtGia.Text = Gia.ToString();
        }

        private void cbtMSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGia.Text = TinhTien().ToString();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn cập nhật!", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;


            _hoadon = data.CTHDs.Where(hd => hd.MaHD == _selected.MaHD && hd.MaSP == _selected.MaSP).SingleOrDefault<CTHD>();
            try
            {
                if (_hoadon != null)
                {
                    _hoadon.SoLuong = (int)txtSL.Value;
                    _hoadon.ThanhTien = (float)Convert.ToDouble(txtGia.Text);

                    data.SubmitChanges();
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cbbTenHD.Enabled = true;
                    cbbTenHD.Enabled = true;
                    buttonLuu.Enabled = false;
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;

                    _listCTHD = data.CTHDs.ToList();
                    Refresh();
                }
                else
                    MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
