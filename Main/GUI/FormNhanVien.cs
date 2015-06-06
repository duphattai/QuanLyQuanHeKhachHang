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

namespace Main.GUI
{

    public partial class FormNhanVien : Form
    {

        QLKhachHangDataContext data = new QLKhachHangDataContext();
        NHANVIEN _nhanvien = new NHANVIEN();
        IndexNhanVien _ind = new IndexNhanVien();
        FileStream stream;
        String _pathOld;
        int _index;
       
       
        public  FormNhanVien()
        {
            InitializeComponent();
            
            dtNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.StartPosition = FormStartPosition.CenterScreen;
            dtgrid_NhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.Width = dtgrid_NhanVien.Width;
            pbAnhNV.SizeMode = PictureBoxSizeMode.StretchImage;
           //_index = id();
          
            

        }

        //int _id;
        //public int id()
        //{
            
        //   // data.getIndex(ref _id);

        //}
        public void Refresh()
        {
           
            var list = from load in data.NHANVIENs
                       select load;
            dtgrid_NhanVien.DataSource = list;
            dtgrid_NhanVien.Columns["MANV"].HeaderText = "Mã nhân viên";
            dtgrid_NhanVien.Columns["TENNV"].HeaderText = "Tên nhân viên";
            dtgrid_NhanVien.Columns["NGAYSINH"].HeaderText = "Ngày sinh";
            dtgrid_NhanVien.Columns["DIACHI"].HeaderText = "Địa chỉ";
            dtgrid_NhanVien.Columns["SDT"].HeaderText = "Số điện thoại";
            dtgrid_NhanVien.Columns["CMND"].HeaderText = "Chứng minh nhân dân";
            dtgrid_NhanVien.Columns["ANH"].HeaderText = "Ảnh đại diện";
            dtgrid_NhanVien.Columns["LUONG"].HeaderText = "Lương";
            dtgrid_NhanVien.Columns["EMAIL"].HeaderText = "Email";
         
        }
        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            Refresh();

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
        }
        string _manv;
        public string GenerMaNV()
        {
            
            data.GetTopMaNV(ref _manv);
            Basic bc = new Basic();
            return bc.GenerMa(_manv);
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
            txtMaNv.Enabled = false;
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
                
                _nhanvien.MANV = txtMaNv.Text;
                _nhanvien.TENNV = txtTenNV.Text;
                _nhanvien.NGAYSINH = dtNgaySinh.Text;
                _nhanvien.DIACHI = txtDiaChi.Text;
                _nhanvien.SDT = (int)Convert.ToInt32(txtSDT.Text);
                _nhanvien.CMND = (int)Convert.ToInt32(txtCMND.Text);
                _nhanvien.ANH = URL.Text.ToString();
                _nhanvien.LUONG = (float)Convert.ToDouble(txtLuong.Text);
                _nhanvien.EMAIL = txtEmail.Text;
                data.NHANVIENs.InsertOnSubmit(_nhanvien);
                _ind.Id = _index + 1;
                data.SubmitChanges();
                Refresh();
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
                _nhanvien = data.NHANVIENs.Where(nv => nv.MANV == txtMaNv.Text).SingleOrDefault<NHANVIEN>();
                if (_nhanvien != null)
                {
                    data.NHANVIENs.DeleteOnSubmit(_nhanvien);
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
                System.Windows.Forms.MessageBox.Show(ex.Message, "Quản lý nhân viên");
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            txtMaNv.Enabled = false;
            try{
              
                _nhanvien = data.NHANVIENs.Where(nv => nv.MANV == txtMaNv.Text).SingleOrDefault<NHANVIEN>();
                if (_nhanvien != null)
                {
                    _nhanvien.MANV = txtMaNv.Text;
                    _nhanvien.TENNV = txtTenNV.Text;
                    _nhanvien.NGAYSINH = dtNgaySinh.Text;
                    _nhanvien.DIACHI = txtDiaChi.Text;
                    _nhanvien.SDT = (int)Convert.ToInt32(txtSDT.Text);
                    _nhanvien.CMND = (int)Convert.ToInt32(txtCMND.Text);
                    _nhanvien.ANH = URL.Text.ToString(); ;
                    _nhanvien.LUONG = (float)Convert.ToDouble(txtLuong.Text);
                    _nhanvien.EMAIL = txtEmail.Text;
                   
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
            Refresh();
          
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            var list = from _nhanvien in data.NHANVIENs
                       where (_nhanvien.MANV.Contains(txtTimKiem.Text) || _nhanvien.TENNV.Contains(txtTimKiem.Text))
                       select _nhanvien;
            dtgrid_NhanVien.DataSource = list;
        }

        private void btnCSDL_Click(object sender, EventArgs e)
        {
            Refresh();
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
                    stream = new FileStream("../Debug/Image/" + (_index + 1) + ".png", FileMode.Create);
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Interlace = PngInterlaceOption.On;
                    encoder.Frames.Add(BitmapFrame.Create(uri));
                    encoder.Save(stream);
                    stream.Flush();
                    stream.Close();
                    ImagePath = stream.Name;
                    pbAnhNV.Image = System.Drawing.Image.FromFile(dlg.FileName);
                    URL.Text = (_index + 1).ToString() + ".png";

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




   }

            
}
    
