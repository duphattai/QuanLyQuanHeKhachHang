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
    public partial class FormNhapKhachHang : Form
    {
        private QLKhachHangDataContext data = new QLKhachHangDataContext(Connection.getConnectionString());

        private List<KHACHHANG> _listKhachHang;
        private List<NHOM_KH> _listNhomKhachHang;

        private KHACHHANG _khachHang;
        private KHACHHANG _selected;

        public FormNhapKhachHang()
        {
            InitializeComponent();
        }

        private void FormNhapKhachHang_Load(object sender, EventArgs e)
        {
            _listKhachHang = data.KHACHHANGs.ToList();
            _listNhomKhachHang = data.NHOM_KHs.ToList();

            cbtNhomKH.DataSource = _listNhomKhachHang;
            cbtNhomKH.DisplayMembers = "TenNhomKH";
            cbtNhomKH.ValueMember = "TenNhomKH";

            txtMaKH.Text = GenrMaKH();
            showDataOnGridView();
        }

        public string GenrMaKH()
        {
            string _maKH = "";
            data.GetTopMaKhachHang(ref _maKH);
            Basic bs = new Basic(_maKH);
            return bs.GenerMaKhachHang(_maKH);
        }

        void showDataOnGridView()
        {
            dataGridView.Rows.Clear();
            dataGridView.RowCount = _listKhachHang.Count;
            for (int i = 0; i < _listKhachHang.Count; i++)
            {
                dataGridView.Rows[i].Cells["STT"].Value = Convert.ToString(i+1);
                dataGridView.Rows[i].Cells["TenKH"].Value = _listKhachHang[i].TenKH;
                dataGridView.Rows[i].Cells["SoDienThoai"].Value = _listKhachHang[i].SoDienThoai;
                dataGridView.Rows[i].Cells["NgaySinh"].Value = _listKhachHang[i].NgaySinh;
                dataGridView.Rows[i].Cells["MaKH"].Value = _listKhachHang[i].MaKH;
                dataGridView.Rows[i].Cells["Email"].Value = _listKhachHang[i].Email;
                dataGridView.Rows[i].Cells["DiaChiKH"].Value = _listKhachHang[i].DiaChiKH;
                dataGridView.Rows[i].Cells["CMND"].Value = _listKhachHang[i].CMND;
                dataGridView.Rows[i].Cells["MaNhomKH"].Value = _listKhachHang[i].MaNhomKH;


                foreach(NHOM_KH nhom in _listNhomKhachHang)
                {
                    if(nhom.MaNhomKH.Equals(_listKhachHang[i].MaNhomKH))
                    {
                        dataGridView.Rows[i].Cells["TenNhomKH"].Value = nhom.TenNhomKH;
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                _khachHang = new KHACHHANG();

                _khachHang.MaKH = txtMaKH.Text;
                _khachHang.MaNhomKH = _listNhomKhachHang[cbtNhomKH.SelectedIndex].MaNhomKH;
                _khachHang.TenKH = txtTenKH.Text;
                _khachHang.SoDienThoai = Convert.ToInt32(txtSDT.Text);
                _khachHang.NgaySinh = dTimeNgaySinh.Value;
                _khachHang.Email = txtEmail.Text;
                _khachHang.DiaChiKH = txtDiaChi.Text;
                _khachHang.CMND = Convert.ToInt32(txtCMND.Text);

                data.KHACHHANGs.InsertOnSubmit(_khachHang);
                data.SubmitChanges();

                MessageBox.Show("Thêm thành công", "Thông báo");
                btnTaoMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý khách hàng");
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = GenrMaKH();
            txtCMND.Text = " ";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtCMND.Text = "";
            txtEmail.Text = "";

            _listKhachHang = data.KHACHHANGs.ToList();
            showDataOnGridView();
        }


        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == _listKhachHang.Count) _selected = null;
            else
            {
                _selected = new KHACHHANG();
                _selected.CMND = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["CMND"].Value);
                _selected.DiaChiKH = dataGridView.Rows[e.RowIndex].Cells["DiaChiKH"].Value.ToString();
                _selected.Email = dataGridView.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                _selected.MaKH = dataGridView.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
                _selected.MaNhomKH = dataGridView.Rows[e.RowIndex].Cells["MaNhomKH"].Value.ToString();
                _selected.NgaySinh = (DateTime)dataGridView.Rows[e.RowIndex].Cells["NgaySinh"].Value;
                _selected.SoDienThoai = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["SoDienThoai"].Value);
                _selected.TenKH = dataGridView.Rows[e.RowIndex].Cells["TenKH"].Value.ToString();


                txtCMND.Text = _selected.CMND.ToString();
                txtDiaChi.Text = _selected.DiaChiKH;
                txtEmail.Text = _selected.Email;
                txtMaKH.Text = _selected.MaKH;
                cbtNhomKH.Text = dataGridView.Rows[e.RowIndex].Cells["TenNhomKH"].Value.ToString();
                dTimeNgaySinh.Value = _selected.NgaySinh.Value;
                txtSDT.Text = _selected.SoDienThoai.ToString();
                txtTenKH.Text = _selected.TenKH;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;

            try
            {
                _khachHang = data.KHACHHANGs.Where(kh => kh.MaKH == _selected.MaKH).SingleOrDefault<KHACHHANG>();
                if (_khachHang != null)
                {
                    data.KHACHHANGs.DeleteOnSubmit(_khachHang);
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
                System.Windows.Forms.MessageBox.Show(ex.Message, "Quản lý giao dịch");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                _khachHang = data.KHACHHANGs.Where(kh => kh.MaKH == _selected.MaKH).SingleOrDefault<KHACHHANG>();
                if (_khachHang != null)
                {
                    _khachHang.MaNhomKH = _listNhomKhachHang[cbtNhomKH.SelectedIndex].MaNhomKH;
                    _khachHang.TenKH = txtTenKH.Text;
                    _khachHang.SoDienThoai = Convert.ToInt32(txtSDT.Text);
                    _khachHang.NgaySinh = dTimeNgaySinh.Value;
                    _khachHang.Email = txtEmail.Text;
                    _khachHang.DiaChiKH = txtDiaChi.Text;
                    _khachHang.CMND = Convert.ToInt32(txtCMND.Text);

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
                MessageBox.Show(ex.Message, "Quản lý khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
