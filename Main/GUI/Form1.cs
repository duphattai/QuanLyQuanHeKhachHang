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
            if (checkTab("Phân Quyền") == false)
            {
                FormNguoiDung form = new FormNguoiDung(tabControl);
                AddTabControl(form, "Phân Quyền");
            }
        }

        private void btnGiaoDich_Click(object sender, EventArgs e)
        {
            if (checkTab("Giao Dịch") == false)
            {
                FormGiaoDich form = new FormGiaoDich(tabControl);
                AddTabControl(form, "Giao Dịch");
            }
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            if (checkTab("Hóa Đơn") == false)
            {
                FormHoaDon form = new FormHoaDon(tabControl);
                AddTabControl(form, "Hóa Đơn");
            }
        }

        private void btnGuiMail_Click(object sender, EventArgs e)
        {
            if (checkTab("Email") == false)
            {
                FormMail form = new FormMail();
                AddTabControl(form, "Email");
            }
        }

        private void btnLapLichHen_Click(object sender, EventArgs e)
        {
            if (checkTab("Lịch Hẹn") == false)
            {
                FormLichHen form = new FormLichHen(tabControl);
                AddTabControl(form, "Lịch Hẹn");
            }
        }

        private void btnNhapSanPham_Click(object sender, EventArgs e)
        {
            if (checkTab("Sản Phẩm") == false)
            {
                FormSanPham form = new FormSanPham(tabControl);
                AddTabControl(form, "Sản Phẩm");
            }
        }

        private void btnHoTro_Click(object sender, EventArgs e)
        {
            if (checkTab("Hỗ Trợ") == false)
            {
                FormHoTro form = new FormHoTro(tabControl);
                AddTabControl(form, "Hỗ Trợ");
            }
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            //if (checkTab("Khách Hàng") == false)
            //{
            //    FormNhapKhachHang form = new FormNhapKhachHang(tabControl);
            //    AddTabControl(form, "Khách Hàng");
            //}
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            //FormSanPham sp = new FormSanPham(tabControl);
            //sp.ShowDialog();
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            if (checkTab("Hợp Đồng") == false)
            {
                FormHopDong form = new FormHopDong(tabControl);
                AddTabControl(form, "Hợp Đồng");
            }
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            if (checkTab("Nhân Viên") == false)
            {
                FormNhanVien form = new FormNhanVien(tabControl);
                AddTabControl(form, "Nhân Viên");
            }
        }

        private void btnThuChi_Click(object sender, EventArgs e)
        {
            if (checkTab("Thu Chi") == false)
            {
                FormThuChi form = new FormThuChi(tabControl);
                AddTabControl(form, "Thu Chi");
            }
        }

        private void btnNguoiDung_Click(object sender, EventArgs e)
        {
            if (checkTab("Người Dùng") == false)
            {
                FormNguoiDung form = new FormNguoiDung(tabControl);
                AddTabControl(form, "Người Dùng");
            }
        }

        private void btnGioiThieu_Click(object sender, EventArgs e)
        {
            if (checkTab("Giới Thiệu") == false)
            {
                FormGioiThieu form = new FormGioiThieu(tabControl);
                AddTabControl(form, "Giới Thiệu");
            }
        }


        private void tabControl_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            tabControl.Tabs.Remove(tabControl.SelectedTab);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát!", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
                tabControl.Tabs.Clear();
            }
        }


        private void setDefaulAuthority()
        {
            buttonItemGioiThieu.Enabled = true;
            
            buttonItemPhanQuyen.Enabled = false;
            buttonItemThayDoiMatKhau.Enabled = false;
            buttonItemDangNhap.Enabled = true;
            
            buttonItemTraCuuKH.Enabled = false;
            buttonItemTraCuuLH.Enabled = false;
            buttonItemTraCuuSP.Enabled = false;

            buttonItemKhachHang.Enabled = false;
            buttonItemGiaoDich.Enabled = false;
            buttonItemGuiMail.Enabled = false;
            buttonItemHoTro.Enabled = false;
            buttonItemHoaDon.Enabled = false;
            buttonItemHopDong.Enabled = false;
            buttonItemLapLichHen.Enabled = false;
            buttonItemNhanVien.Enabled = false;
            buttonItemNhapSanPham.Enabled = false;
            buttonItemThuChi.Enabled = false;   
        }


        private void phanQuyen(string quyen)
        {
            switch (quyen)
            {
                case "":
                    break;
                case "ND0001": // bán hàng
                    buttonItemHoaDon.Enabled = true;
                    buttonItemLapLichHen.Enabled = true;
                    buttonItemNhapSanPham.Enabled = true;
                    buttonItemKhachHang.Enabled = true;
                    buttonItemTraCuuKH.Enabled = true;
                    buttonItemTraCuuSP.Enabled = true;
                    buttonItemThayDoiMatKhau.Enabled = true;
                    break;
                case "ND0002": // marketing
                    buttonItemGuiMail.Enabled = true;
                    buttonItemThayDoiMatKhau.Enabled = true;
                    break;
                case "ND0003": // quản lý
                    buttonItemGiaoDich.Enabled = true;
                    buttonItemHopDong.Enabled = true;
                    buttonItemThuChi.Enabled = true;
                    buttonItemNhanVien.Enabled = true;
                    buttonItemTraCuuLH.Enabled = true;
                    buttonItemTraCuuKH.Enabled = true;
                    buttonItemTraCuuSP.Enabled = true;
                    buttonItemThayDoiMatKhau.Enabled = true;
                    break;
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            FormDangNhap form = new FormDangNhap();
            form.ShowDialog();

            setDefaulAuthority();
            phanQuyen(form._quyen);
        }

        private void buttonItemKhachHang_Click(object sender, EventArgs e)
        {
            if (checkTab("Khách Hàng") == false)
            {
                FormNhapKhachHang form = new FormNhapKhachHang(tabControl);
                AddTabControl(form, "Khách Hàng");
            }
        }

        private void buttonItemThayDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (checkTab("Thay Đổi Mật Khẩu") == false)
            {
                FormThayDoiMatKhau form = new FormThayDoiMatKhau(tabControl);
                AddTabControl(form, "Thay Đổi Mật Khẩu");
            }
        }

        private void MAIN_Load(object sender, EventArgs e)
        {
            if (BUS.Connection.getConnectionString() == null)
                this.Close();

            setDefaulAuthority();
            FormDangNhap form = new FormDangNhap();
            form.ShowDialog();
            
            phanQuyen(form._quyen);
        }

        private void buttonItemTraCuuKH_Click(object sender, EventArgs e)
        {
            if (checkTab("Tra Cứu Khách Hàng") == false)
            {
                FormTraCuuThongTinKhachHang form = new FormTraCuuThongTinKhachHang(tabControl);
                AddTabControl(form, "Tra Cứu Khách Hàng");
            }
        }

        private void buttonItemTraCuuLH_Click(object sender, EventArgs e)
        {
            if (checkTab("Tra Cứu Lịch Hẹn") == false)
            {
                FormTraCuuLichHen form = new FormTraCuuLichHen(tabControl);
                AddTabControl(form, "Tra Cứu Lịch Hẹn");
            }
        }
    }
}
