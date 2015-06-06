using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Main.GUI;

namespace Main
{
    public partial class MAIN : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public MAIN()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            FormNhanVien nv = new FormNhanVien();
            nv.ShowDialog(); ;

        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            FormGiaoDich gd = new FormGiaoDich();
            gd.ShowDialog();
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            FormHoaDon hd = new FormHoaDon();
            hd.ShowDialog();
        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            FormMail mail = new FormMail();
            mail.ShowDialog();
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            FormLichHen lh = new FormLichHen();
            lh.ShowDialog();
        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            FormSanPham sp = new FormSanPham();
            sp.ShowDialog();
        }

        private void buttonItem38_Click(object sender, EventArgs e)
        {
            FormHoTro ht = new FormHoTro();
            ht.ShowDialog();
        }

        private void buttonItem25_Click(object sender, EventArgs e)
        {
            FormNhapKhachHang kh = new FormNhapKhachHang();
            kh.ShowDialog();
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            FormSanPham sp = new FormSanPham();
            sp.ShowDialog();
        }

        private void buttonItem27_Click(object sender, EventArgs e)
        {
            FormHopDong hd = new FormHopDong();
            hd.ShowDialog();
        }

        private void buttonItem28_Click(object sender, EventArgs e)
        {
            FormNhanVien nv = new FormNhanVien();
            nv.ShowDialog(); ;

        }

        private void buttonItem29_Click(object sender, EventArgs e)
        {
            FormThuChi tc = new FormThuChi();
            tc.ShowDialog();
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            FormNguoiDung nd = new FormNguoiDung();

        }

        private void buttonItem35_Click(object sender, EventArgs e)
        {
            FormGioiThieu gt = new FormGioiThieu();
            gt.ShowDialog();
        }
    }
}
