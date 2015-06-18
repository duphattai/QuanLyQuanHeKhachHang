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
    public partial class FormLichHen : Form
    {
        private QLKhachHangDataContext data = new QLKhachHangDataContext(Connection.getConnectionString());

        private List<LICHHEN> _listLichHen;
        private List<NHANVIEN> _listNhanVien;
        private List<KHACHHANG> _listKhachHang;

        private LICHHEN _selected;
        private LICHHEN _lichHen;
        public FormLichHen()
        {
            InitializeComponent();
        }

        private void FormLichHen_Load(object sender, EventArgs e)
        {
            _listLichHen = data.LICHHENs.ToList();
            _listNhanVien = data.NHANVIENs.ToList();
            _listKhachHang = data.KHACHHANGs.ToList();

            cbtTenKH.DataSource = _listKhachHang;
            cbtTenKH.DisplayMembers = "TenKH";
            cbtTenKH.ValueMember = "TenKH";

            cbtTenNV.DataSource = _listNhanVien;
            cbtTenNV.DisplayMembers = "TenNV";
            cbtTenNV.ValueMember = "TenNV";

            txtMaLH.Text = GenerMaLH();
            showDataOnGridView();
        }

        private void showDataOnGridView()
        {
            dtgrid_LichHen.Rows.Clear();
            if (_listLichHen.Count == 0)
                dtgrid_LichHen.RowCount = _listLichHen.Count + 1;
            else
                dtgrid_LichHen.RowCount = _listLichHen.Count;


            for(int i = 0; i < _listLichHen.Count; i++)
            {
                dtgrid_LichHen.Rows[i].Cells["STT"].Value = Convert.ToString(i + 1);
                dtgrid_LichHen.Rows[i].Cells["MaLH"].Value = _listLichHen[i].Ma_LH;
                dtgrid_LichHen.Rows[i].Cells["MaKH"].Value = _listLichHen[i].MaKH;
                dtgrid_LichHen.Rows[i].Cells["MaNV"].Value = _listLichHen[i].MaNV;
                dtgrid_LichHen.Rows[i].Cells["NgayGap"].Value = _listLichHen[i].NgayGap;
                dtgrid_LichHen.Rows[i].Cells["NgayHen"].Value = _listLichHen[i].NgayHen;
                dtgrid_LichHen.Rows[i].Cells["NoiDung_LH"].Value = _listLichHen[i].NoiDung_LH;

                foreach(NHANVIEN nv in _listNhanVien)
                {
                    if(nv.MaNV.Equals(_listLichHen[i].MaNV))
                    {
                        dtgrid_LichHen.Rows[i].Cells["TenNV"].Value = nv.TenNV;
                        break;
                    }
                }

                foreach (KHACHHANG kh in _listKhachHang)
                {
                    if (kh.MaKH.Equals(_listLichHen[i].MaKH))
                    {
                        dtgrid_LichHen.Rows[i].Cells["TenKH"].Value = kh.TenKH;
                        break;
                    }
                }
            }
            
        }



        private string GenerMaLH()
        {
            String maLH = "";
            data.GetTopMaLH(ref maLH);
            Basic bs = new Basic(maLH);
            return bs.GenerMaLichHen(maLH);
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaLH.Text = GenerMaLH();
            txtNoiDung.Text = "";
            _listLichHen = data.LICHHENs.ToList();
            showDataOnGridView();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                _lichHen = new LICHHEN();

                _lichHen.Ma_LH = txtMaLH.Text;
                _lichHen.MaKH = _listKhachHang[cbtTenKH.SelectedIndex].MaKH;
                _lichHen.MaNV = _listNhanVien[cbtTenNV.SelectedIndex].MaNV;
                _lichHen.NoiDung_LH = txtNoiDung.Text;
                _lichHen.NgayGap = dTimeNgayGap.Value;
                _lichHen.NgayHen = dTimeNgayHen.Value;

                data.LICHHENs.InsertOnSubmit(_lichHen);
                data.SubmitChanges();

                MessageBox.Show("Thêm thành công", "Thông báo");
                btnTaoMoi_Click(sender, e);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý lịch hẹn");
            }
        }

        private void dtgrid_LichHen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == _listLichHen.Count) _selected = null;
            else
            {
                _selected = new LICHHEN();
                _selected.Ma_LH = dtgrid_LichHen.Rows[e.RowIndex].Cells["MaLH"].Value.ToString();
                _selected.MaKH = dtgrid_LichHen.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
                _selected.MaNV = dtgrid_LichHen.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
                _selected.NoiDung_LH = dtgrid_LichHen.Rows[e.RowIndex].Cells["NoiDung_LH"].Value.ToString();
                _selected.NgayGap = (DateTime)dtgrid_LichHen.Rows[e.RowIndex].Cells["NgayGap"].Value;
                _selected.NgayHen = (DateTime)dtgrid_LichHen.Rows[e.RowIndex].Cells["NgayHen"].Value;


                cbtTenKH.Text = dtgrid_LichHen.Rows[e.RowIndex].Cells["TenKH"].Value.ToString();
                cbtTenNV.Text = dtgrid_LichHen.Rows[e.RowIndex].Cells["TenNV"].Value.ToString();
                dTimeNgayGap.Value = _selected.NgayGap.Value;
                dTimeNgayHen.Value = _selected.NgayHen.Value;
                txtNoiDung.Text = _selected.NoiDung_LH;
                txtMaLH.Text = _selected.Ma_LH;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;

            try
            {
                _lichHen = data.LICHHENs.Where(lh => lh.Ma_LH == _selected.Ma_LH).SingleOrDefault<LICHHEN>();
                if (_lichHen != null)
                {
                    data.LICHHENs.DeleteOnSubmit(_lichHen);
                    data.SubmitChanges();

                    _listLichHen = data.LICHHENs.ToList();
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
                System.Windows.Forms.MessageBox.Show(ex.Message, "Quản lý lịch hẹn");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát!", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                _lichHen = data.LICHHENs.Where(lh => lh.Ma_LH == txtMaLH.Text).SingleOrDefault<LICHHEN>();
                if (_lichHen != null)
                {
                    _lichHen.NgayGap = dTimeNgayGap.Value;
                    _lichHen.NgayHen = dTimeNgayHen.Value;
                    _lichHen.NoiDung_LH = txtNoiDung.Text;
                    _lichHen.MaNV = _listNhanVien[cbtTenNV.SelectedIndex].MaNV;
                    _lichHen.MaKH = _listKhachHang[cbtTenKH.SelectedIndex].MaKH;

                    data.SubmitChanges();
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            showDataOnGridView();
        }
    }
}
