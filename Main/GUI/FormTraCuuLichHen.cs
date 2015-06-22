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
    public partial class FormTraCuuLichHen : Form
    {
        private DevComponents.DotNetBar.TabControl _tabControl;
        private QLKhachHangDataContext data = new QLKhachHangDataContext(Connection.getConnectionString());
        private List<KHACHHANG> _listKhachHang;
        private List<NHANVIEN> _listNhanVien;
        private List<LICHHEN> _listLichHen;
        public FormTraCuuLichHen(DevComponents.DotNetBar.TabControl tabControl)
        {
            InitializeComponent();
            _tabControl = tabControl;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (xtraTabControl.SelectedTabPage == xtraTabControl.TabPages[0]) // khách hàng
            {
                if (cbbTenKH.SelectedIndex < 0) return;

                _listLichHen = (from lichhen in data.LICHHENs
                                where (lichhen.MaKH.Contains(_listKhachHang[cbbTenKH.SelectedIndex].MaKH))
                                select lichhen).ToList<LICHHEN>();

                showDataOnGridView();
            }
            else if (xtraTabControl.SelectedTabPage == xtraTabControl.TabPages[1]) // nhân viên
            {
                if (cbbTenNV.SelectedIndex < 0) return;

                _listLichHen = (from lichhen in data.LICHHENs
                                where (lichhen.MaNV.Contains(_listNhanVien[cbbTenNV.SelectedIndex].MaNV))
                                select lichhen).ToList<LICHHEN>();

                showDataOnGridView();
            }
            else if (xtraTabControl.SelectedTabPage == xtraTabControl.TabPages[2]) // thời gian
            {
                _listLichHen = (from lichhen in data.LICHHENs
                                where (lichhen.NgayGap.Value <= dTimeDenNgay.Value && lichhen.NgayGap.Value >= dTimeTuNgay.Value)
                                select lichhen).ToList<LICHHEN>();

                showDataOnGridView();
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

        private void FormTraCuuLichHen_Load(object sender, EventArgs e)
        {
            _listKhachHang = data.KHACHHANGs.ToList();
            _listNhanVien = data.NHANVIENs.ToList();

            cbbTenKH.DataSource = _listKhachHang;
            cbbTenKH.DisplayMember = "TenKH";

            cbbTenNV.DataSource = _listNhanVien;
            cbbTenNV.DisplayMember = "TenNV";

            _listLichHen = data.LICHHENs.ToList();
            showDataOnGridView();
        }

        private void showDataOnGridView()
        {
            dt_GridLichHen.Rows.Clear();
            if (_listLichHen.Count == 0)
                dt_GridLichHen.RowCount = 1;
            else
                dt_GridLichHen.RowCount = _listLichHen.Count();

            for(int i = 0; i < _listLichHen.Count; i++)
            {
                dt_GridLichHen.Rows[i].Cells["Ma_LH"].Value = _listLichHen[i].Ma_LH;
                dt_GridLichHen.Rows[i].Cells["MaKH"].Value = _listLichHen[i].MaKH;
                dt_GridLichHen.Rows[i].Cells["MaNV"].Value = _listLichHen[i].MaNV;
                dt_GridLichHen.Rows[i].Cells["NoiDung_LH"].Value = _listLichHen[i].NoiDung_LH;
                dt_GridLichHen.Rows[i].Cells["NgayGap"].Value = _listLichHen[i].NgayGap;
                dt_GridLichHen.Rows[i].Cells["NgayHen"].Value = _listLichHen[i].NgayHen;

                foreach(NHANVIEN nv in _listNhanVien)
                {
                    if(nv.MaNV.Equals(_listLichHen[i].MaNV))
                    {
                        dt_GridLichHen.Rows[i].Cells["TenNV"].Value = nv.TenNV;
                        break;
                    }
                }

                foreach(KHACHHANG kh in _listKhachHang)
                {
                    if(kh.MaKH.Equals(_listLichHen[i].MaKH))
                    {
                        dt_GridLichHen.Rows[i].Cells["TenKH"].Value = kh.TenKH;
                        break;
                    }
                }
            }
        }
    }
}
