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
    public partial class FormHoTro : Form
    {
        private QLKhachHangDataContext data = new QLKhachHangDataContext(Connection.getConnectionString());
        private List<NHANVIEN> _listNhanVien;
        private List<KHACHHANG> _listKhachHang;
        private List<HOTRO> _listHoTro;

        private HOTRO _hoTro;
        private HOTRO _selected;
        public FormHoTro()
        {
            InitializeComponent();
        }

        private void FormHoTro_Load(object sender, EventArgs e)
        {
            _listHoTro = data.HOTROs.ToList();
            _listKhachHang = data.KHACHHANGs.ToList();
            _listNhanVien = data.NHANVIENs.ToList();

            cbtTenKH.DataSource = _listKhachHang;
            cbtTenKH.DisplayMembers = "TenKH";
            cbtTenKH.ValueMember = "TenKH";

            cbtTenNV.DataSource = _listNhanVien;
            cbtTenNV.DisplayMembers = "TenNV";
            cbtTenNV.ValueMember = "TenNV";

            txtMaHT.Text = GenerMaHT();
            showDataOnGridView();
        }

        private string GenerMaHT()
        {
            String maLH = "";
            data.GetTopMaHoTro(ref maLH);
            Basic bs = new Basic(maLH);
            return bs.GenerMaHoTro(maLH);
        }

        private void showDataOnGridView()
        {
            dtgrid_HoTro.Rows.Clear();
            if (_listHoTro.Count == 0)
                dtgrid_HoTro.RowCount = _listHoTro.Count + 1;
            else
                dtgrid_HoTro.RowCount = _listHoTro.Count;

            for(int i = 0; i < _listHoTro.Count; i++)
            {
                dtgrid_HoTro.Rows[i].Cells["MaHT"].Value = _listHoTro[i].MaHT;
                dtgrid_HoTro.Rows[i].Cells["MaKH"].Value = _listHoTro[i].MaKH;
                dtgrid_HoTro.Rows[i].Cells["MaNV"].Value = _listHoTro[i].MaNV;
                dtgrid_HoTro.Rows[i].Cells["NoiDung"].Value = _listHoTro[i].NoiDung;
                dtgrid_HoTro.Rows[i].Cells["TG_HT"].Value = _listHoTro[i].TG_HT;

                foreach(KHACHHANG kh in _listKhachHang)
                {
                    if(kh.MaKH.Equals(_listHoTro[i].MaKH))
                    {
                        dtgrid_HoTro.Rows[i].Cells["TenKH"].Value = kh.TenKH;
                        break;
                    }
                }

                foreach(NHANVIEN nv in _listNhanVien)
                {
                    if (nv.MaNV.Equals(_listHoTro[i].MaNV))
                    {
                        dtgrid_HoTro.Rows[i].Cells["TenNV"].Value = nv.TenNV;
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
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaHT.Text = GenerMaHT();
            txtNoiDung.Text = "";
            _listHoTro = data.HOTROs.ToList();
            showDataOnGridView();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                _hoTro = new HOTRO();

                _hoTro.MaHT = txtMaHT.Text;
                _hoTro.MaKH = _listKhachHang[cbtTenKH.SelectedIndex].MaKH;
                _hoTro.MaNV = _listNhanVien[cbtTenNV.SelectedIndex].MaNV;
                _hoTro.NoiDung = txtNoiDung.Text;
                _hoTro.TG_HT = dTimeThoiGian.Value;

                data.HOTROs.InsertOnSubmit(_hoTro);
                data.SubmitChanges();

                MessageBox.Show("Thêm thành công", "Thông báo");
                btnTaoMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý hỗ trợ");
            }
        }

        private void dtgrid_HoTro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == _listHoTro.Count) _selected = null;
            else
            {
                _selected = new HOTRO();
                _selected.MaHT = dtgrid_HoTro.Rows[e.RowIndex].Cells["MaHT"].Value.ToString();
                _selected.MaKH = dtgrid_HoTro.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
                _selected.MaNV = dtgrid_HoTro.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
                _selected.NoiDung = dtgrid_HoTro.Rows[e.RowIndex].Cells["NoiDung"].Value.ToString();
                _selected.TG_HT = (DateTime)dtgrid_HoTro.Rows[e.RowIndex].Cells["TG_HT"].Value;


                cbtTenKH.Text = dtgrid_HoTro.Rows[e.RowIndex].Cells["TenKH"].Value.ToString();
                cbtTenNV.Text = dtgrid_HoTro.Rows[e.RowIndex].Cells["TenNV"].Value.ToString();
                dTimeThoiGian.Value = _selected.TG_HT.Value;
                txtNoiDung.Text = _selected.NoiDung;
                txtMaHT.Text = _selected.MaHT;
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;

            try
            {
                _hoTro = data.HOTROs.Where(ht => ht.MaHT == _selected.MaHT).SingleOrDefault<HOTRO>();
                if (_hoTro != null)
                {
                    data.HOTROs.DeleteOnSubmit(_hoTro);
                    data.SubmitChanges();
                    
                    System.Windows.Forms.MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnTaoMoi_Click(sender, e);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Không xóa được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Quản lý lịch hẹn");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                _hoTro = data.HOTROs.Where(ht => ht.MaHT == _selected.MaHT).SingleOrDefault<HOTRO>();
                if (_hoTro != null)
                {
                    _hoTro.TG_HT = dTimeThoiGian.Value;
                    _hoTro.NoiDung = txtNoiDung.Text;
                    _hoTro.MaNV = _listNhanVien[cbtTenNV.SelectedIndex].MaNV;
                    _hoTro.MaKH = _listKhachHang[cbtTenKH.SelectedIndex].MaKH;

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
                MessageBox.Show(ex.Message, "Quản lý lịch hẹn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
    }

}
