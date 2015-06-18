using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Main.BUS;

namespace Main.GUI
{
    public partial class FormNhanVien : Form
    {
        QLKhachHangDataContext data = new QLKhachHangDataContext(Connection.getConnectionString());
        NHANVIEN _nhanvien = new NHANVIEN();
        FileStream stream;
        String _pathOld;

        private List<NHANVIEN> _listNhanVien;

        public  FormNhanVien()
        {
            InitializeComponent();
            
            dtNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.StartPosition = FormStartPosition.CenterScreen;
            dtgrid_NhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.Width = dtgrid_NhanVien.Width;
            pbAnhNV.SizeMode = PictureBoxSizeMode.StretchImage;
        }

     
        public void showDataOnGridView()
        {
            dtgrid_NhanVien.DataSource = _listNhanVien;
            dtgrid_NhanVien.Columns["MaNV"].HeaderText = "Mã nhân viên";
            dtgrid_NhanVien.Columns["TenNV"].HeaderText = "Tên nhân viên";
            dtgrid_NhanVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dtgrid_NhanVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dtgrid_NhanVien.Columns["SDT"].HeaderText = "Số điện thoại";
            dtgrid_NhanVien.Columns["CMND"].HeaderText = "Chứng minh nhân dân";
            dtgrid_NhanVien.Columns["Anh"].HeaderText = "Ảnh đại diện";
            dtgrid_NhanVien.Columns["Luong"].HeaderText = "Lương";
            dtgrid_NhanVien.Columns["Email"].HeaderText = "Email";        
        }
        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            _listNhanVien = data.NHANVIENs.ToList();
            showDataOnGridView();
        }


        public string GenerMaNV()
        {
            string _manv = "";
            data.GetTopMaNV(ref _manv);
            Basic bc = new Basic(_manv);
            return bc.GenerMaNhanVien(_manv);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            txtCMND.Text ="";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtLuong.Text = "";
            txtMaNv.Text = GenerMaNV();
            txtSDT.Text = "";
            txtTenNV.Text = "";
            dtNgaySinh.Text = "";
            txtMaNv.Enabled = false;
        }

  
        private void dtgrid_NhanVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
           
            try
            {
               txtMaNv.Text = dtgrid_NhanVien.Rows[row].Cells[0].Value.ToString().Trim();
                txtTenNV.Text = dtgrid_NhanVien.Rows[row].Cells[1].Value.ToString().Trim();
                dtNgaySinh.Text = Convert.ToDateTime(dtgrid_NhanVien.Rows[row].Cells[2].Value).ToString("dd/MM/yyyy");
                txtDiaChi.Text = dtgrid_NhanVien.Rows[row].Cells[3].Value.ToString().Trim();
                txtSDT.Text = dtgrid_NhanVien.Rows[row].Cells[4].Value.ToString().Trim();
                txtCMND.Text = dtgrid_NhanVien.Rows[row].Cells[5].Value.ToString().Trim();
                txtLuong.Text = dtgrid_NhanVien.Rows[row].Cells[7].Value.ToString().Trim();
                txtEmail.Text = dtgrid_NhanVien.Rows[row].Cells[8].Value.ToString().Trim();
                _pathOld = dtgrid_NhanVien.Rows[row].Cells[6].Value.ToString();
                URL.Text = _pathOld;
                pbAnhNV.Image = GetHinhAnhTuPoster(_pathOld);

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Quản lý sản phẩm");
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            //_ind = data.IndexNhanViens.SingleOrDefault<IndexNhanVien>();
            txtMaNv.Enabled = false;
            try
            {
                _nhanvien.MaNV = txtMaNv.Text;
                _nhanvien.TenNV = txtTenNV.Text;
                _nhanvien.NgaySinh = dtNgaySinh.Value;
                _nhanvien.DiaChi = txtDiaChi.Text;
                _nhanvien.SDT = (int)Convert.ToInt32(txtSDT.Text);
                _nhanvien.CMND = (int)Convert.ToInt32(txtCMND.Text);
                _nhanvien.Anh = URL.Text.ToString();
                _nhanvien.Luong = (float)Convert.ToDouble(txtLuong.Text);
                _nhanvien.Email = txtEmail.Text;
                data.NHANVIENs.InsertOnSubmit(_nhanvien);
                //_ind.Id = _index + 1;
                data.SubmitChanges();
                showDataOnGridView();
                System.Windows.Forms.MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Quản lý nhân viên");
            }
        }

        private void btXoa_Click(object sender, EventArgs e) 
        {
            try
            {
                _nhanvien = data.NHANVIENs.Where(nv => nv.MaNV == txtMaNv.Text).SingleOrDefault<NHANVIEN>();
                if (_nhanvien != null)
                {
                    data.NHANVIENs.DeleteOnSubmit(_nhanvien);
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
                System.Windows.Forms.MessageBox.Show(ex.Message, "Quản lý nhân viên");
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try{
              
                _nhanvien = data.NHANVIENs.Where(nv => nv.MaNV == txtMaNv.Text).SingleOrDefault<NHANVIEN>();
                if (_nhanvien != null)
                {
                    _nhanvien.MaNV = txtMaNv.Text;
                    _nhanvien.TenNV = txtTenNV.Text;
                    _nhanvien.NgaySinh = dtNgaySinh.Value;
                    _nhanvien.DiaChi = txtDiaChi.Text;
                    _nhanvien.SDT = (int)Convert.ToInt32(txtSDT.Text);
                    _nhanvien.CMND = (int)Convert.ToInt32(txtCMND.Text);
                    _nhanvien.Anh = URL.Text.ToString(); ;
                    _nhanvien.Luong = (float)Convert.ToDouble(txtLuong.Text);
                    _nhanvien.Email = txtEmail.Text;
                   
                    data.SubmitChanges();
                 
                    System.Windows.Forms.MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Quản lý nhân viên");
            }
            showDataOnGridView();
          
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            _listNhanVien = (from _nhanvien in data.NHANVIENs
                       where (_nhanvien.MaNV.Contains(txtTimKiem.Text) || _nhanvien.TenNV.Contains(txtTimKiem.Text))
                       select _nhanvien).ToList();

            showDataOnGridView();
        }

        private void btnCSDL_Click(object sender, EventArgs e)
        {
            showDataOnGridView();
        }

        private void btnAnhNV_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";
            string ImagePath;
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                ImagePath = dlg.FileName;
                var uri = new Uri(ImagePath);
                stream = new FileStream("../Debug/Image/" + _nhanvien.MaNV + ".png", FileMode.Create);
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Interlace = PngInterlaceOption.On;
                encoder.Frames.Add(BitmapFrame.Create(uri));
                encoder.Save(stream);
                stream.Flush();
                stream.Close();
                ImagePath = stream.Name;
                pbAnhNV.Image = System.Drawing.Image.FromFile(dlg.FileName);
                URL.Text = txtMaNv.Text + ".png";
            }
        }
   
        private System.Drawing.Image GetHinhAnhTuPoster(string _Poster)
        {
            BitmapImage bImg = new BitmapImage();

            Stream bm_Stream = new FileStream("../Debug/Image/" + _Poster, FileMode.Open);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            MemoryStream memoryStream = new MemoryStream();
            encoder.Frames.Add(BitmapFrame.Create(bm_Stream));
            encoder.Interlace = PngInterlaceOption.On;
            encoder.Save(memoryStream);
            System.Drawing.Image img = System.Drawing.Image.FromStream(memoryStream);
            bm_Stream.Close();
            return img;
        }

  
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Bạn muốn thoát!", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }
   }
}
    
