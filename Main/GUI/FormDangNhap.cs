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
    public partial class FormDangNhap : Form
    {
        public String _quyen;
        private QLKhachHangDataContext data = new QLKhachHangDataContext(Connection.getConnectionString());
        public static string _tenTK;
        public FormDangNhap()
        {
            InitializeComponent();
            txtMK.PasswordChar = '*';
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            _quyen = "";
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                NGUOIDUNG taiKhoan = data.NGUOIDUNGs.Where(tk => tk.Ten_ND == txtTK.Text && tk.MatKhau == txtMK.Text).SingleOrDefault<NGUOIDUNG>();
                if (taiKhoan != null)
                {
                    _quyen = taiKhoan.MaNhomND;
                    _tenTK = taiKhoan.Ten_ND;
                    this.Close();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
