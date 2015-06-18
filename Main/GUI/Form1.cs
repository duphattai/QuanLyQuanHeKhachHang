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
using DevComponents.DotNetBar;

namespace Main
{
    public partial class MAIN : DevComponents.DotNetBar.Office2007RibbonForm
    {

        public static DevComponents.DotNetBar.TabControl m_Tab;
        public MAIN()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }


        public void AddTabControl(Form form, string nameTab)
        {
            TabItem tab = tabControl.CreateTab(nameTab);
            form.Dock = DockStyle.Fill;
            form.AutoScroll = true;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            tab.AttachedControl.Controls.Add(form);
            form.Show();
            tabControl.SelectedTabIndex = tabControl.Tabs.Count - 1;
            m_Tab = tabControl;
        }

        private bool checkTab(string name)
        {
            for (int i = 0; i < tabControl.Tabs.Count; i++)
            {
                if (tabControl.Tabs[i].Text == name)
                {
                    tabControl.SelectedTabIndex = i;
                    return true;
                }
            }
            return false;
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            if (checkTab("Nhân Viên") == false)
            {
                FormNhanVien form = new FormNhanVien();
                AddTabControl(form, "Nhân Viên");
            }
        }

        private void buttonItemGiaoDich_Click(object sender, EventArgs e)
        {
            if (checkTab("Giao Dịch") == false)
            {
                FormGiaoDich form = new FormGiaoDich();
                AddTabControl(form, "Giao Dịch");
            }
        }

        private void buttonItemHoaDon_Click(object sender, EventArgs e)
        {
            if (checkTab("Hóa Đơn") == false)
            {
                FormHoaDon form = new FormHoaDon();
                AddTabControl(form, "Hóa Đơn");
            }
        }

        private void buttonItemGuiMail_Click(object sender, EventArgs e)
        {
            if (checkTab("Email") == false)
            {
                FormMail form = new FormMail();
                AddTabControl(form, "Email");
            }
        }

        private void buttonItemLapLichHen_Click(object sender, EventArgs e)
        {
            if (checkTab("Lịch Hẹn") == false)
            {
                FormLichHen form = new FormLichHen();
                AddTabControl(form, "Lịch Hẹn");
            }
        }

        private void buttonItemNhapSanPham_Click(object sender, EventArgs e)
        {
            if (checkTab("Sản Phẩm") == false)
            {
                FormSanPham form = new FormSanPham();
                AddTabControl(form, "Sản Phẩm");
            }
        }

        private void buttonItemHoTro_Click(object sender, EventArgs e)
        {
            if (checkTab("Hỗ Trợ") == false)
            {
                FormHoTro form = new FormHoTro();
                AddTabControl(form, "Hỗ Trợ");
            }
        }

        private void buttonItemKhachHang_Click(object sender, EventArgs e)
        {
            if (checkTab("Khách Hàng") == false)
            {
                FormNhapKhachHang form = new FormNhapKhachHang();
                AddTabControl(form, "Khách Hàng");
            }
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            FormSanPham sp = new FormSanPham();
            sp.ShowDialog();
        }

        private void buttonItemHopDong_Click(object sender, EventArgs e)
        {
            if (checkTab("Hợp Đồng") == false)
            {
                FormHopDong form = new FormHopDong();
                AddTabControl(form, "Hợp Đồng");
            }
        }

        private void buttonItemNhanVien_Click(object sender, EventArgs e)
        {
            if (checkTab("Nhân Viên") == false)
            {
                FormNhanVien form = new FormNhanVien();
                AddTabControl(form, "Nhân Viên");
            }
        }

        private void buttonItemThuChi_Click(object sender, EventArgs e)
        {
            if (checkTab("Thu Chi") == false)
            {
                FormThuChi form = new FormThuChi();
                AddTabControl(form, "Thu Chi");
            }
        }

        private void buttonItemNguoiDung_Click(object sender, EventArgs e)
        {
            if (checkTab("Người Dùng") == false)
            {
                FormNguoiDung form = new FormNguoiDung();
                AddTabControl(form, "Người Dùng");
            }
        }

        private void buttonItemGioiThieu_Click(object sender, EventArgs e)
        {
            if (checkTab("Giới Thiệu") == false)
            {
                FormGioiThieu form = new FormGioiThieu();
                AddTabControl(form, "Giới Thiệu");
            }
        }


        private void tabControl_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            tabControl.Tabs.Remove(tabControl.SelectedTab);
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
