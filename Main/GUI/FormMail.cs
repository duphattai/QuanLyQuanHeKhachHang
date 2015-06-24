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
using System.Net.Mail;
namespace Main.GUI
{
    public partial class FormMail : Form
    {
        private DevComponents.DotNetBar.TabControl _tabControl;
        private QLKhachHangDataContext data = new QLKhachHangDataContext(Connection.getConnectionString());
        private List<KHACHHANG> _listKhachHang;
        private List<NHANVIEN> _listNhanVien;
        private List<NHOM_KH> _listNhomKH;
        private List<GUI_MAIL> _listGuiMail;
        public FormMail(DevComponents.DotNetBar.TabControl tabControl)
        {
            InitializeComponent();
            _tabControl = tabControl;
            txtMK.UseSystemPasswordChar = true;
        }


        private void FormMail_Load(object sender, EventArgs e)
        {
            _listNhanVien = data.NHANVIENs.ToList();
            _listKhachHang = data.KHACHHANGs.ToList();
            _listNhomKH = data.NHOM_KHs.ToList();
            _listGuiMail = data.GUI_MAILs.ToList();

            cbbTenNV.DataSource = _listNhanVien;
            cbbTenNV.DisplayMember = "TenNV";

            txtMaGM.Text = GenrMaGM();
            showDataOnGridViewTabPageKhachHang();
        }

        public string GenrMaGM()
        {
            string _maGM = "";
            data.GetTopGuiMail(ref _maGM);
            Basic bs = new Basic(_maGM);
            return bs.GenerMaGuiMail(_maGM);
        }

        private void showDataOnGridViewTabPageKhachHang()
        {
            dt_GridKhachHang.Rows.Clear();
            dt_GridKhachHang.RowCount = _listKhachHang.Count;

            for(int i = 0; i < _listKhachHang.Count; i++)
            {
                dt_GridKhachHang.Rows[i].Cells["MaKHPageKH"].Value = _listKhachHang[i].MaKH;
                dt_GridKhachHang.Rows[i].Cells["MaNhomKH"].Value = _listKhachHang[i].MaNhomKH;
                dt_GridKhachHang.Rows[i].Cells["NgaySinh"].Value = _listKhachHang[i].NgaySinh;
                dt_GridKhachHang.Rows[i].Cells["SoDienThoai"].Value = _listKhachHang[i].SoDienThoai;
                dt_GridKhachHang.Rows[i].Cells["Email"].Value = _listKhachHang[i].Email;
                dt_GridKhachHang.Rows[i].Cells["DiaChiKH"].Value = _listKhachHang[i].DiaChiKH;
                dt_GridKhachHang.Rows[i].Cells["CMND"].Value = _listKhachHang[i].CMND;
                dt_GridKhachHang.Rows[i].Cells["TenKHPageKH"].Value = _listKhachHang[i].TenKH;

                foreach(NHOM_KH kh in _listNhomKH)
                {
                    if(kh.MaNhomKH.Equals(_listKhachHang[i].MaNhomKH))
                    {
                        dt_GridKhachHang.Rows[i].Cells["TenNhomKH"].Value = kh.TenNhomKH;
                        break;
                    }
                }
            }
        }

        private void showDataOnGridViewTabPageLichSuGuiMail()
        {
            dt_GridLichSuGuiMail.Rows.Clear();
            if (_listGuiMail.Count == 0)
                dt_GridLichSuGuiMail.RowCount = 1;
            else
                dt_GridLichSuGuiMail.RowCount = _listGuiMail.Count;

            for(int i = 0; i < _listGuiMail.Count; i++)
            {
                dt_GridLichSuGuiMail.Rows[i].Cells["Ma_GM"].Value = _listGuiMail[i].Ma_GM;
                dt_GridLichSuGuiMail.Rows[i].Cells["MaKH"].Value = _listGuiMail[i].MaKH;
                dt_GridLichSuGuiMail.Rows[i].Cells["MaNV"].Value = _listGuiMail[i].MaNV;
                dt_GridLichSuGuiMail.Rows[i].Cells["NoiDungGM"].Value = _listGuiMail[i].NoiDungGM;
                dt_GridLichSuGuiMail.Rows[i].Cells["TG_Gui"].Value = _listGuiMail[i].TG_Gui;

                foreach(KHACHHANG kh in _listKhachHang)
                {
                    if(kh.MaKH.Equals(_listGuiMail[i].MaKH))
                    {
                        dt_GridLichSuGuiMail.Rows[i].Cells["TenKHPageGM"].Value = kh.TenKH;
                        break;
                    }
                }

                foreach (NHANVIEN nv in _listNhanVien)
                {
                    if (nv.MaNV.Equals(_listGuiMail[i].MaNV))
                    {
                        dt_GridLichSuGuiMail.Rows[i].Cells["TenNV"].Value = nv.TenNV;
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
                _tabControl.Tabs.Remove(_tabControl.SelectedTab);
            }
        }


        private void guiMail(List<KHACHHANG> toAddress)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(txtEmail.Text);
                for (int i = 0; i < toAddress.Count; i++)
                {
                    mail.To.Add(toAddress[i].Email);
                }
                mail.Subject = txtTieuDe.Text;
                mail.Body = txtNoiDung.Text;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(txtEmail.Text, txtMK.Text);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);


                for (int i = 0; i < toAddress.Count; i++)
                {
                    GUI_MAIL guimail = new GUI_MAIL();
                    guimail.Ma_GM = GenrMaGM();
                    guimail.MaKH = toAddress[i].MaKH;
                    guimail.MaNV = _listNhanVien[cbbTenNV.SelectedIndex].MaNV;
                    guimail.NoiDungGM = txtNoiDung.Text;
                    guimail.TG_Gui = dTime.Value;

                    data.GUI_MAILs.InsertOnSubmit(guimail);
                    data.SubmitChanges();
                }   
                MessageBox.Show("Gửi thành công");            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnGuiMail_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTieuDe.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề!", "Thông báo");
                return;
            }
            if(string.IsNullOrEmpty(txtMK.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo");
                return;
            }
            if (string.IsNullOrEmpty(txtNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung!", "Thông báo");
                return;
            }

            List<KHACHHANG> listDSKHGuiMail = new List<KHACHHANG>();
            for(int i = 0; i < dt_GridKhachHang.Rows.Count; i++)
            {
                if(Convert.ToBoolean(dt_GridKhachHang.Rows[i].Cells["Chon"].Value) == true)
                {
                    listDSKHGuiMail.Add(_listKhachHang[i]);
                }
            }

            if(listDSKHGuiMail.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng nhận email!", "Thông báo");
                return;
            }

            guiMail(listDSKHGuiMail);
        }

        private void cbbTenNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbTenNV.SelectedIndex >= 0)
            {
                txtEmail.Text = _listNhanVien[cbbTenNV.SelectedIndex].Email;
            }
        }

        private void xtraTabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabControl1.TabPages[0]) // khách hàng
            {
                showDataOnGridViewTabPageKhachHang();
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabControl1.TabPages[1]) // lich su gui mail
            {
                _listGuiMail = data.GUI_MAILs.ToList();
                showDataOnGridViewTabPageLichSuGuiMail();
            }
        }
    }
}
