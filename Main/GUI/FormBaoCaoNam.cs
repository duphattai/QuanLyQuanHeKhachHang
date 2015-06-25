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

        }

        private void FormBaoCaoNam_Load(object sender, EventArgs e)
        {

        }
    }
}
