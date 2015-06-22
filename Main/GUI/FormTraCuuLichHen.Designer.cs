namespace Main.GUI
{
    partial class FormTraCuuLichHen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.tabPageKhachHang = new DevExpress.XtraTab.XtraTabPage();
            this.cbbTenKH = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageNhanVien = new DevExpress.XtraTab.XtraTabPage();
            this.cbbTenNV = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageThoiGian = new DevExpress.XtraTab.XtraTabPage();
            this.dTimeDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dTimeTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dt_GridLichHen = new System.Windows.Forms.DataGridView();
            this.Ma_LH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayHen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung_LH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTimKiem = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).BeginInit();
            this.xtraTabControl.SuspendLayout();
            this.tabPageKhachHang.SuspendLayout();
            this.tabPageNhanVien.SuspendLayout();
            this.tabPageThoiGian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_GridLichHen)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.xtraTabControl);
            this.panelEx1.Controls.Add(this.groupControl1);
            this.panelEx1.Controls.Add(this.btnTimKiem);
            this.panelEx1.Controls.Add(this.btnThoat);
            this.panelEx1.Controls.Add(this.reflectionLabel1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(951, 435);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            // 
            // xtraTabControl
            // 
            this.xtraTabControl.Location = new System.Drawing.Point(160, 102);
            this.xtraTabControl.Name = "xtraTabControl";
            this.xtraTabControl.SelectedTabPage = this.tabPageKhachHang;
            this.xtraTabControl.Size = new System.Drawing.Size(402, 136);
            this.xtraTabControl.TabIndex = 51;
            this.xtraTabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageKhachHang,
            this.tabPageNhanVien,
            this.tabPageThoiGian});
            // 
            // tabPageKhachHang
            // 
            this.tabPageKhachHang.Controls.Add(this.cbbTenKH);
            this.tabPageKhachHang.Controls.Add(this.label2);
            this.tabPageKhachHang.Name = "tabPageKhachHang";
            this.tabPageKhachHang.Size = new System.Drawing.Size(396, 108);
            this.tabPageKhachHang.Text = "Tra cứu theo khách hàng";
            // 
            // cbbTenKH
            // 
            this.cbbTenKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTenKH.FormattingEnabled = true;
            this.cbbTenKH.Location = new System.Drawing.Point(151, 23);
            this.cbbTenKH.Name = "cbbTenKH";
            this.cbbTenKH.Size = new System.Drawing.Size(167, 21);
            this.cbbTenKH.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tên khách hàng";
            // 
            // tabPageNhanVien
            // 
            this.tabPageNhanVien.Controls.Add(this.cbbTenNV);
            this.tabPageNhanVien.Controls.Add(this.label1);
            this.tabPageNhanVien.Name = "tabPageNhanVien";
            this.tabPageNhanVien.Size = new System.Drawing.Size(396, 108);
            this.tabPageNhanVien.Text = "Tra cứu theo nhân viên";
            // 
            // cbbTenNV
            // 
            this.cbbTenNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTenNV.FormattingEnabled = true;
            this.cbbTenNV.Location = new System.Drawing.Point(151, 23);
            this.cbbTenNV.Name = "cbbTenNV";
            this.cbbTenNV.Size = new System.Drawing.Size(167, 21);
            this.cbbTenNV.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tên nhân viên";
            // 
            // tabPageThoiGian
            // 
            this.tabPageThoiGian.Controls.Add(this.dTimeDenNgay);
            this.tabPageThoiGian.Controls.Add(this.dTimeTuNgay);
            this.tabPageThoiGian.Controls.Add(this.label4);
            this.tabPageThoiGian.Controls.Add(this.label3);
            this.tabPageThoiGian.Name = "tabPageThoiGian";
            this.tabPageThoiGian.Size = new System.Drawing.Size(396, 108);
            this.tabPageThoiGian.Text = "Tra cứu theo thời gian";
            // 
            // dTimeDenNgay
            // 
            this.dTimeDenNgay.Location = new System.Drawing.Point(140, 63);
            this.dTimeDenNgay.Name = "dTimeDenNgay";
            this.dTimeDenNgay.Size = new System.Drawing.Size(172, 20);
            this.dTimeDenNgay.TabIndex = 14;
            // 
            // dTimeTuNgay
            // 
            this.dTimeTuNgay.Location = new System.Drawing.Point(140, 22);
            this.dTimeTuNgay.Name = "dTimeTuNgay";
            this.dTimeTuNgay.Size = new System.Drawing.Size(172, 20);
            this.dTimeTuNgay.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(16, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "Đến ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(16, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Từ ngày";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl1.Controls.Add(this.dt_GridLichHen);
            this.groupControl1.Location = new System.Drawing.Point(36, 262);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(899, 100);
            this.groupControl1.TabIndex = 50;
            this.groupControl1.Text = "Kết quả tìm kiếm";
            // 
            // dt_GridLichHen
            // 
            this.dt_GridLichHen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_GridLichHen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma_LH,
            this.MaNV,
            this.TenNV,
            this.TenKH,
            this.MaKH,
            this.NgayHen,
            this.NgayGap,
            this.NoiDung_LH});
            this.dt_GridLichHen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_GridLichHen.Location = new System.Drawing.Point(2, 21);
            this.dt_GridLichHen.Name = "dt_GridLichHen";
            this.dt_GridLichHen.Size = new System.Drawing.Size(895, 77);
            this.dt_GridLichHen.TabIndex = 11;
            // 
            // Ma_LH
            // 
            this.Ma_LH.HeaderText = "Mã lịch hẹn";
            this.Ma_LH.Name = "Ma_LH";
            // 
            // MaNV
            // 
            this.MaNV.HeaderText = "Mã nhân viên";
            this.MaNV.Name = "MaNV";
            // 
            // TenNV
            // 
            this.TenNV.HeaderText = "Tên nhân viên";
            this.TenNV.Name = "TenNV";
            this.TenNV.ReadOnly = true;
            // 
            // TenKH
            // 
            this.TenKH.HeaderText = "Tên khách hàng";
            this.TenKH.Name = "TenKH";
            this.TenKH.ReadOnly = true;
            // 
            // MaKH
            // 
            this.MaKH.HeaderText = "Mã khách hàng";
            this.MaKH.Name = "MaKH";
            // 
            // NgayHen
            // 
            this.NgayHen.HeaderText = "Ngày hẹn";
            this.NgayHen.Name = "NgayHen";
            // 
            // NgayGap
            // 
            this.NgayGap.HeaderText = "Ngày gặp";
            this.NgayGap.Name = "NgayGap";
            // 
            // NoiDung_LH
            // 
            this.NoiDung_LH.HeaderText = "Nội dung";
            this.NoiDung_LH.Name = "NoiDung_LH";
            this.NoiDung_LH.Width = 150;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTimKiem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.Location = new System.Drawing.Point(600, 132);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTimKiem.TabIndex = 49;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnThoat.Location = new System.Drawing.Point(858, 400);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 48;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // reflectionLabel1
            // 
            // 
            // 
            // 
            this.reflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionLabel1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.reflectionLabel1.Location = new System.Drawing.Point(294, 33);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.Size = new System.Drawing.Size(295, 70);
            this.reflectionLabel1.TabIndex = 4;
            this.reflectionLabel1.Text = "<b><font size=\"+6\"><i></i><font color=\"#B02B2C\">Tra Cứu Lịch Hẹn</font></font></b" +
    ">";
            // 
            // FormTraCuuLichHen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 435);
            this.Controls.Add(this.panelEx1);
            this.Name = "FormTraCuuLichHen";
            this.Text = "FormTraCuuKhachHang";
            this.Load += new System.EventHandler(this.FormTraCuuLichHen_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).EndInit();
            this.xtraTabControl.ResumeLayout(false);
            this.tabPageKhachHang.ResumeLayout(false);
            this.tabPageKhachHang.PerformLayout();
            this.tabPageNhanVien.ResumeLayout(false);
            this.tabPageNhanVien.PerformLayout();
            this.tabPageThoiGian.ResumeLayout(false);
            this.tabPageThoiGian.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_GridLichHen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.DataGridView dt_GridLichHen;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
        private DevComponents.DotNetBar.ButtonX btnTimKiem;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl;
        private DevExpress.XtraTab.XtraTabPage tabPageKhachHang;
        private DevExpress.XtraTab.XtraTabPage tabPageNhanVien;
        private System.Windows.Forms.ComboBox cbbTenNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbTenKH;
        private DevExpress.XtraTab.XtraTabPage tabPageThoiGian;
        private System.Windows.Forms.DateTimePicker dTimeDenNgay;
        private System.Windows.Forms.DateTimePicker dTimeTuNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_LH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayHen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGap;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung_LH;
    }
}