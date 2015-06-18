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
    public partial class FormHopDong : Form
    {
        private QLKhachHangDataContext data = new QLKhachHangDataContext(Connection.getConnectionString());
        private List<HOPDONG> _listHopDong;
        private List<NHANVIEN> _listNhanVien;
        private List<KHACHHANG> _listKhachHang;
        private HOPDONG _hopDong;
        private HOPDONG _selected;
        public FormHopDong()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát!", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        public string GenrMaHD()
        {
            string _maHD = "";
            data.GetTopMaHopDong(ref _maHD);
            Basic bs = new Basic(_maHD);
            return bs.GenerMaHopDong(_maHD);
        }

        private void showDataOnGridView()
        {
            dtgrid_HopDong.Rows.Clear();
            if (_listHopDong.Count == 0)
                dtgrid_HopDong.RowCount = 1;
            else
                dtgrid_HopDong.RowCount = _listHopDong.Count;


            for(int i = 0; i < _listHopDong.Count; i++)
            {
                dtgrid_HopDong.Rows[i].Cells["MaHD"].Value = _listHopDong[i].MaHD;
                dtgrid_HopDong.Rows[i].Cells["MaKH"].Value = _listHopDong[i].MaKH;
                dtgrid_HopDong.Rows[i].Cells["MaNV"].Value = _listHopDong[i].MaNV;
                dtgrid_HopDong.Rows[i].Cells["NgayBD"].Value = _listHopDong[i].NgayBD;
                dtgrid_HopDong.Rows[i].Cells["NgayKT"].Value = _listHopDong[i].NgayKT;
                dtgrid_HopDong.Rows[i].Cells["NgayKy"].Value = _listHopDong[i].NgayKy;
                dtgrid_HopDong.Rows[i].Cells["TenHD"].Value = _listHopDong[i].TenHD;
                dtgrid_HopDong.Rows[i].Cells["TinhTrang"].Value = _listHopDong[i].TinhTrang;
                dtgrid_HopDong.Rows[i].Cells["TriGia"].Value = _listHopDong[i].TriGia;

                foreach (NHANVIEN nv in _listNhanVien)
                {
                    if (nv.MaNV.Equals(_listHopDong[i].MaNV))
                    {
                        dtgrid_HopDong.Rows[i].Cells["TenNV"].Value = nv.TenNV;
                        break;
                    }
                }

                foreach (KHACHHANG kh in _listKhachHang)
                {
                    if (kh.MaKH.Equals(_listHopDong[i].MaKH))
                    {
                        dtgrid_HopDong.Rows[i].Cells["TenKH"].Value = kh.TenKH;
                        break;
                    }
                }
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = GenrMaHD();
            txtTenHD.Text = "";
            txtTinhTrang.Text = "";
            txtTriGia.Text = "";

            _listHopDong = data.HOPDONGs.ToList();
            showDataOnGridView();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                _hopDong = new HOPDONG();

                _hopDong.MaHD = txtMaHD.Text;
                _hopDong.MaKH = _listKhachHang[cbtTenKH.SelectedIndex].MaKH;
                _hopDong.MaNV = _listNhanVien[cbtTenNV.SelectedIndex].MaNV;
                _hopDong.TenHD = txtTenHD.Text;
                _hopDong.NgayBD = dTimeNgayBD.Value;
                _hopDong.NgayKT = dTimeNgayKT.Value;
                _hopDong.NgayKy = dTimeNgayKy.Value;
                _hopDong.TinhTrang = txtTinhTrang.Text;
                _hopDong.TriGia = Convert.ToDouble(txtTriGia.Text);

                data.HOPDONGs.InsertOnSubmit(_hopDong);
                data.SubmitChanges();

                MessageBox.Show("Thêm thành công", "Thông báo");
                btnTaoMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý khách hàng");
            }
        }

        private void dtgrid_HopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == _listHopDong.Count) _selected = null;
            else
            {
                _selected = new HOPDONG();

                _selected.MaHD = dtgrid_HopDong.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();
                _selected.MaKH = dtgrid_HopDong.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
                _selected.MaNV = dtgrid_HopDong.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
                _selected.TenHD = dtgrid_HopDong.Rows[e.RowIndex].Cells["TenHD"].Value.ToString();
                _selected.NgayBD = (DateTime)dtgrid_HopDong.Rows[e.RowIndex].Cells["NgayBD"].Value;
                _selected.NgayKT = (DateTime)dtgrid_HopDong.Rows[e.RowIndex].Cells["NgayKT"].Value;
                _selected.NgayKy = (DateTime)dtgrid_HopDong.Rows[e.RowIndex].Cells["NgayKy"].Value;
                _selected.TinhTrang = dtgrid_HopDong.Rows[e.RowIndex].Cells["TinhTrang"].Value.ToString();
                _selected.TriGia = Convert.ToDouble(dtgrid_HopDong.Rows[e.RowIndex].Cells["TriGia"].Value.ToString());

                txtMaHD.Text = _selected.MaHD;
                txtTenHD.Text = _selected.TenHD;
                txtTinhTrang.Text = _selected.TinhTrang;
                txtTriGia.Text = _selected.TriGia.ToString();
                cbtTenKH.Text = dtgrid_HopDong.Rows[e.RowIndex].Cells["TenKH"].Value.ToString();
                cbtTenNV.Text = dtgrid_HopDong.Rows[e.RowIndex].Cells["TenNV"].Value.ToString();
                dTimeNgayBD.Value = _selected.NgayBD.Value;
                dTimeNgayKT.Value = _selected.NgayKT.Value;
                dTimeNgayKy.Value = _selected.NgayKy.Value;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;

            try
            {
                _hopDong = data.HOPDONGs.Where(hd => hd.MaHD == _selected.MaHD).SingleOrDefault<HOPDONG>();
                if (_hopDong != null)
                {
                    data.HOPDONGs.DeleteOnSubmit(_hopDong);
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
                System.Windows.Forms.MessageBox.Show(ex.Message, "Quản lý hợp đồng");
            }
        }

        private void FormHopDong_Load(object sender, EventArgs e)
        {
            _listHopDong = data.HOPDONGs.ToList();
            _listKhachHang = data.KHACHHANGs.ToList();
            _listNhanVien = data.NHANVIENs.ToList();

            cbtTenKH.DataSource = _listKhachHang;
            cbtTenKH.DisplayMembers = "TenKH";
            cbtTenKH.ValueMember = "TenKH";

            cbtTenNV.DataSource = _listNhanVien;
            cbtTenNV.DisplayMembers = "TenNV";
            cbtTenNV.ValueMember = "TenNV";

            txtMaHD.Text = GenrMaHD();
            showDataOnGridView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                _hopDong = data.HOPDONGs.Where(hd => hd.MaHD == _selected.MaHD).SingleOrDefault<HOPDONG>();
                if (_hopDong != null)
                {
                    _hopDong.MaKH = _listKhachHang[cbtTenKH.SelectedIndex].MaKH;
                    _hopDong.MaNV = _listNhanVien[cbtTenNV.SelectedIndex].MaNV;
                    _hopDong.TenHD = txtTenHD.Text;
                    _hopDong.NgayBD = dTimeNgayBD.Value;
                    _hopDong.NgayKT = dTimeNgayKT.Value;
                    _hopDong.NgayKy = dTimeNgayKy.Value;
                    _hopDong.TinhTrang = txtTinhTrang.Text;
                    _hopDong.TriGia = Convert.ToDouble(txtTriGia.Text);

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
                MessageBox.Show(ex.Message, "Quản lý hợp đồng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
