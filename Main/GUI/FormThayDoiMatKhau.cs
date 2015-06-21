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
    public partial class FormThayDoiMatKhau : Form
    {
        private QLKhachHangDataContext data = new QLKhachHangDataContext(Connection.getConnectionString());
        private DevComponents.DotNetBar.TabControl _tabControl;
        public FormThayDoiMatKhau(DevComponents.DotNetBar.TabControl tabControl)
        {
            InitializeComponent();
            _tabControl = tabControl;
            txtMKMoi1.UseSystemPasswordChar = true;
            txtMKMoi2.UseSystemPasswordChar = true;
            txtMKHienTai.UseSystemPasswordChar = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát!", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
                _tabControl.Tabs.Remove(_tabControl.SelectedTab);
            }
        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thay đổi mật khẩu?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                NGUOIDUNG tk = data.NGUOIDUNGs.Where(nguoidung => nguoidung.Ten_ND == FormDangNhap._tenTK && nguoidung.MatKhau == txtMKHienTai.Text).SingleOrDefault<NGUOIDUNG>();
                if(tk != null)
                {
                    if(!txtMKMoi1.Text.Equals(txtMKMoi2.Text))
                    {
                        MessageBox.Show("Mật khẩu nhập lần 1 và lần 2 không trùng nhau!", "Thông báo");
                        return;
                    }

                    tk.MatKhau = txtMKMoi2.Text;
                    data.SubmitChanges();

                    MessageBox.Show("Thay đổi mật khẩu thành công!", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Mật khẩu hiện tại không đúng!", "Thông báo");
                }
            }
        }

        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxShowPass.Checked == true)
            {
                txtMKMoi1.UseSystemPasswordChar = false;
                txtMKMoi2.UseSystemPasswordChar = false;
                txtMKHienTai.UseSystemPasswordChar = false;
            }
            else
            {
                txtMKMoi1.UseSystemPasswordChar = true;
                txtMKMoi2.UseSystemPasswordChar = true;
                txtMKHienTai.UseSystemPasswordChar = true;
            }
        }
    }
}
