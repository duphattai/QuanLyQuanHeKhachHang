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
    public partial class FormBaoCaoDoanhThuThang : Form
    {
        private DevComponents.DotNetBar.TabControl _tabControl;
        private QLKhachHangDataContext data = new QLKhachHangDataContext(Connection.getConnectionString());

        private List<HOPDONG> _listHopDong;
        private List<LICHHEN> _listLichHen;
        private List<HOPDONG> _listDoanhThu;
        private List<NHANVIEN> _listNhanVien;
        private List<KHACHHANG> _listKhachHang;
        public FormBaoCaoDoanhThuThang(DevComponents.DotNetBar.TabControl tabControl)
        {
            InitializeComponent();
            _tabControl = tabControl;
        }


        private void showDataOnGridViewPageHopDong()
        {
            dtgrid_HopDong.Rows.Clear();
            dtgrid_HopDong.RowCount = _listHopDong.Count;

            for (int i = 0; i < _listHopDong.Count; i++)
            {
                dtgrid_HopDong.Rows[i].Cells["MaKHTabPageHopDong"].Value = _listHopDong[i].MaKH;
                dtgrid_HopDong.Rows[i].Cells["MaNVTabPageHopDong"].Value = _listHopDong[i].MaNV;
                dtgrid_HopDong.Rows[i].Cells["NgayBD"].Value = _listHopDong[i].NgayBD;
                dtgrid_HopDong.Rows[i].Cells["NgayKT"].Value = _listHopDong[i].NgayKT;
                dtgrid_HopDong.Rows[i].Cells["NgayKy"].Value = _listHopDong[i].NgayKy;
                dtgrid_HopDong.Rows[i].Cells["TenHD"].Value = _listHopDong[i].TenHD;
                dtgrid_HopDong.Rows[i].Cells["TinhTrang"].Value = _listHopDong[i].TinhTrang;

                foreach (NHANVIEN nv in _listNhanVien)
                {
                    if (nv.MaNV.Equals(_listHopDong[i].MaNV))
                    {
                        dtgrid_HopDong.Rows[i].Cells["TenNVTabPageHopDong"].Value = nv.TenNV;
                        break;
                    }
                }

                foreach (KHACHHANG kh in _listKhachHang)
                {
                    if (kh.MaKH.Equals(_listHopDong[i].MaKH))
                    {
                        dtgrid_HopDong.Rows[i].Cells["TenKHTabPageHopDong"].Value = kh.TenKH;
                        break;
                    }
                }
            }
        }
        private void showDataOnGridViewPageLichHen()
        {
            dtgrid_LichHen.Rows.Clear();
            dtgrid_LichHen.RowCount = _listLichHen.Count;


            for (int i = 0; i < _listLichHen.Count; i++)
            {
                dtgrid_LichHen.Rows[i].Cells["MaLH"].Value = _listLichHen[i].Ma_LH;
                dtgrid_LichHen.Rows[i].Cells["MaKHTabPageLichHen"].Value = _listLichHen[i].MaKH;
                dtgrid_LichHen.Rows[i].Cells["MaNVTabPageLichHen"].Value = _listLichHen[i].MaNV;
                dtgrid_LichHen.Rows[i].Cells["NgayGap"].Value = _listLichHen[i].NgayGap;
                dtgrid_LichHen.Rows[i].Cells["NgayHen"].Value = _listLichHen[i].NgayHen;
                dtgrid_LichHen.Rows[i].Cells["NoiDung_LH"].Value = _listLichHen[i].NoiDung_LH;

                foreach (NHANVIEN nv in _listNhanVien)
                {
                    if (nv.MaNV.Equals(_listLichHen[i].MaNV))
                    {
                        dtgrid_LichHen.Rows[i].Cells["TenNVTabPageLichHen"].Value = nv.TenNV;
                        break;
                    }
                }

                foreach (KHACHHANG kh in _listKhachHang)
                {
                    if (kh.MaKH.Equals(_listLichHen[i].MaKH))
                    {
                        dtgrid_LichHen.Rows[i].Cells["TenKHTabPageLichHen"].Value = kh.TenKH;
                        break;
                    }
                }
            }
        }


        private float tinhTienHopDong(string MaHD)
        {
            float tien = 0.0f;
            List<CTHD> list = (from cthd in data.CTHDs
                               where (cthd.MaHD == MaHD)
                               select cthd).ToList<CTHD>();

            foreach(CTHD cthd in list)
            {
                tien += (float)cthd.ThanhTien;
            }
            return tien;
        }
        private void showDataOnGridViewPageDoanhThu()
        {
            dtgrid_DoanhThu.Rows.Clear();
            dtgrid_DoanhThu.RowCount = _listDoanhThu.Count;

            for (int i = 0; i < _listDoanhThu.Count; i++)
            {
                dtgrid_DoanhThu.Rows[i].Cells["MaKHTabPageDoanhThu"].Value = _listDoanhThu[i].MaKH;
                dtgrid_DoanhThu.Rows[i].Cells["MaNVTabPageDoanhThu"].Value = _listDoanhThu[i].MaNV;
                dtgrid_DoanhThu.Rows[i].Cells["TenHDTabPageDoanhThu"].Value = _listDoanhThu[i].TenHD;
                dtgrid_DoanhThu.Rows[i].Cells["GiaTien"].Value = tinhTienHopDong(_listDoanhThu[i].MaHD);

                foreach (NHANVIEN nv in _listNhanVien)
                {
                    if (nv.MaNV.Equals(_listDoanhThu[i].MaNV))
                    {
                        dtgrid_DoanhThu.Rows[i].Cells["TenNVTabPageDoanhThu"].Value = nv.TenNV;
                        break;
                    }
                }

                foreach (KHACHHANG kh in _listKhachHang)
                {
                    if (kh.MaKH.Equals(_listDoanhThu[i].MaKH))
                    {
                        dtgrid_DoanhThu.Rows[i].Cells["TenKHTabPageDoanhThu"].Value = kh.TenKH;
                        break;
                    }
                }
            }
        } // show data

        private void btnLapBaoCao_Click(object sender, EventArgs e)
        {
            if(xtraTabControl1.SelectedTabPage == xtraTabControl1.TabPages[0]) // hợp đồng
            {
                _listHopDong = (from hopdong in data.HOPDONGs
                                where (hopdong.NgayKy.Value >= dTimeTuNgay.Value && hopdong.NgayKy.Value <= dTimeDenNgay.Value)
                                select hopdong).ToList<HOPDONG>();

                showDataOnGridViewPageHopDong();
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabControl1.TabPages[1]) // lịch hẹn
            {
                _listLichHen = (from lichhen in data.LICHHENs
                                where (lichhen.NgayGap.Value >= dTimeTuNgay.Value && lichhen.NgayGap.Value <= dTimeDenNgay.Value)
                                select lichhen).ToList<LICHHEN>();

                showDataOnGridViewPageLichHen();
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabControl1.TabPages[2]) // doanh thu
            {
                // code thu chi here
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

        private void FormBaoCaoDoanhThuThang_Load(object sender, EventArgs e)
        {
            _listNhanVien = data.NHANVIENs.ToList();
            _listKhachHang = data.KHACHHANGs.ToList();
        }
    }
}
