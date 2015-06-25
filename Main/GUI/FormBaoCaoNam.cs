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
    public partial class FormBaoCaoNam : Form
    {
        private DevComponents.DotNetBar.TabControl _tabControl;
        private QLKhachHangDataContext data = new QLKhachHangDataContext(Connection.getConnectionString());

        private List<String> _listHopDong = new List<string>();
        private List<String> _listLichHen;
        private List<String> _listDoanhThu;
        public FormBaoCaoNam(DevComponents.DotNetBar.TabControl tabControl)
        {
            InitializeComponent();
            _tabControl = tabControl;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát!", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
                _tabControl.Tabs.Remove(_tabControl.SelectedTab);
            }
        }

        private void btnLapBaoCao_Click(object sender, EventArgs e)
        {
            int minMonth = dTimeTuNgay.Value.Month;
            int minYear = dTimeTuNgay.Value.Year;

            int totalsMonth = 12 * (dTimeDenNgay.Value.Year - dTimeTuNgay.Value.Year) + (dTimeDenNgay.Value.Month - dTimeTuNgay.Value.Month);
            if (totalsMonth < 0)
            {
                MessageBox.Show("Lỗi chọn ngày!(ngày kết thúc > ngày bắt đầu)", "Thông báo");
                return;
            }

            if (xtraTabControl1.SelectedTabPage == xtraTabControl1.TabPages[0]) // hợp đồng
            {
                dtgrid_HopDong.Rows.Clear();

                List<HOPDONG> listHopDong = (from hopdong in data.HOPDONGs
                                where (hopdong.NgayKy.Value >= dTimeTuNgay.Value && hopdong.NgayKy.Value <= dTimeDenNgay.Value)
                                select hopdong).ToList<HOPDONG>();

                
                foreach(HOPDONG hd in listHopDong)
                {
                    bool trung = false;
                    for(int i = 0; i < dtgrid_HopDong.Rows.Count; i++)
                    {
                        if (Convert.ToInt16(dtgrid_HopDong.Rows[i].Cells["ThangTabPageHopDong"].Value) == hd.NgayKy.Value.Month
                            && Convert.ToInt16(dtgrid_HopDong.Rows[i].Cells["NamTabPageHopDong"].Value) == hd.NgayKy.Value.Year)
                        {
                            trung = true;
                            int temp = Convert.ToInt16(dtgrid_HopDong.Rows[i].Cells["SoLuongHD"].Value) + 1;
                            dtgrid_HopDong.Rows[i].Cells["SoLuongHD"].Value = temp;
                            break;
                        }
                    }

                    if(!trung)
                    {
                        dtgrid_HopDong.Rows.Add(new object[] {"", hd.NgayKy.Value.Month, hd.NgayKy.Value.Year, 1});
                    }
                }
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabControl1.TabPages[1]) // lịch hẹn
            {
                List<LICHHEN> listLichHen = (from lichhen in data.LICHHENs
                                             where (lichhen.NgayGap.Value >= dTimeTuNgay.Value && lichhen.NgayGap.Value <= dTimeDenNgay.Value)
                                             select lichhen).ToList<LICHHEN>();

                foreach (LICHHEN lh in listLichHen)
                {
                    bool trung = false;
                    for (int i = 0; i < dtgrid_LichHen.Rows.Count; i++)
                    {
                        if (Convert.ToInt16(dtgrid_LichHen.Rows[i].Cells["ThangTabPageLichHen"].Value) == lh.NgayGap.Value.Month
                            && Convert.ToInt16(dtgrid_LichHen.Rows[i].Cells["NamTabPageLichHen"].Value) == lh.NgayGap.Value.Year)
                        {
                            trung = true;
                            int temp = Convert.ToInt16(dtgrid_LichHen.Rows[i].Cells["SoLuongLH"].Value) + 1;
                            dtgrid_LichHen.Rows[i].Cells["SoLuongLH"].Value = temp;
                            break;
                        }
                    }

                    if (!trung)
                    {
                        dtgrid_LichHen.Rows.Add(new object[] {"", lh.NgayGap.Value.Month, lh.NgayGap.Value.Year, 1 });
                    }
                }

            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabControl1.TabPages[2]) // doanh thu
            {
                // code thu chi here
            }
        }

        private void FormBaoCaoNam_Load(object sender, EventArgs e)
        {

        }
    }
}
