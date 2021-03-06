﻿namespace Main.GUI
{
   public partial class FormNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNhanVien));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.URL = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnAnhNV = new DevComponents.DotNetBar.ButtonX();
            this.pbAnhNV = new System.Windows.Forms.PictureBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btntimkiem = new DevComponents.DotNetBar.ButtonX();
            this.VNĐ = new System.Windows.Forms.Label();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.dtgrid_NhanVien = new System.Windows.Forms.DataGridView();
            this.btSave = new DevComponents.DotNetBar.ButtonX();
            this.btSua = new DevComponents.DotNetBar.ButtonX();
            this.btXoa = new DevComponents.DotNetBar.ButtonX();
            this.btThem = new DevComponents.DotNetBar.ButtonX();
            this.dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtLuong = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.txtMaNv = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.openFD = new System.Windows.Forms.OpenFileDialog();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnhNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_NhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnThoat);
            this.panelEx1.Controls.Add(this.URL);
            this.panelEx1.Controls.Add(this.btnAnhNV);
            this.panelEx1.Controls.Add(this.pbAnhNV);
            this.panelEx1.Controls.Add(this.txtTimKiem);
            this.panelEx1.Controls.Add(this.btntimkiem);
            this.panelEx1.Controls.Add(this.VNĐ);
            this.panelEx1.Controls.Add(this.txtCMND);
            this.panelEx1.Controls.Add(this.txtSDT);
            this.panelEx1.Controls.Add(this.dtgrid_NhanVien);
            this.panelEx1.Controls.Add(this.btSave);
            this.panelEx1.Controls.Add(this.btSua);
            this.panelEx1.Controls.Add(this.btXoa);
            this.panelEx1.Controls.Add(this.btThem);
            this.panelEx1.Controls.Add(this.dtNgaySinh);
            this.panelEx1.Controls.Add(this.txtEmail);
            this.panelEx1.Controls.Add(this.txtLuong);
            this.panelEx1.Controls.Add(this.txtDiaChi);
            this.panelEx1.Controls.Add(this.txtTenNV);
            this.panelEx1.Controls.Add(this.txtMaNv);
            this.panelEx1.Controls.Add(this.label9);
            this.panelEx1.Controls.Add(this.label8);
            this.panelEx1.Controls.Add(this.label7);
            this.panelEx1.Controls.Add(this.label5);
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.label3);
            this.panelEx1.Controls.Add(this.label2);
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.Controls.Add(this.reflectionLabel1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(898, 506);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnThoat.Location = new System.Drawing.Point(804, 471);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 38;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // URL
            // 
            this.URL.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            // 
            // 
            // 
            this.URL.Border.Class = "TextBoxBorder";
            this.URL.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.URL.ButtonCustom.Tooltip = "";
            this.URL.ButtonCustom2.Tooltip = "";
            this.URL.ForeColor = System.Drawing.SystemColors.Window;
            this.URL.Location = new System.Drawing.Point(711, 119);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(168, 26);
            this.URL.TabIndex = 37;
            this.URL.Visible = false;
            // 
            // btnAnhNV
            // 
            this.btnAnhNV.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAnhNV.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAnhNV.Location = new System.Drawing.Point(605, 122);
            this.btnAnhNV.Name = "btnAnhNV";
            this.btnAnhNV.Size = new System.Drawing.Size(75, 23);
            this.btnAnhNV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAnhNV.TabIndex = 36;
            this.btnAnhNV.Text = "Chọn ảnh";
            this.btnAnhNV.Click += new System.EventHandler(this.btnAnhNV_Click);
            // 
            // pbAnhNV
            // 
            this.pbAnhNV.Location = new System.Drawing.Point(711, 53);
            this.pbAnhNV.Name = "pbAnhNV";
            this.pbAnhNV.Size = new System.Drawing.Size(168, 98);
            this.pbAnhNV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAnhNV.TabIndex = 35;
            this.pbAnhNV.TabStop = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(35, 290);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(159, 26);
            this.txtTimKiem.TabIndex = 33;
            // 
            // btntimkiem
            // 
            this.btntimkiem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btntimkiem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btntimkiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btntimkiem.Location = new System.Drawing.Point(225, 293);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(75, 23);
            this.btntimkiem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btntimkiem.TabIndex = 32;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // VNĐ
            // 
            this.VNĐ.AutoSize = true;
            this.VNĐ.Location = new System.Drawing.Point(826, 177);
            this.VNĐ.Name = "VNĐ";
            this.VNĐ.Size = new System.Drawing.Size(44, 19);
            this.VNĐ.TabIndex = 31;
            this.VNĐ.Text = "VNĐ";
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(430, 216);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(100, 26);
            this.txtCMND.TabIndex = 30;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(430, 170);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(100, 26);
            this.txtSDT.TabIndex = 29;
            // 
            // dtgrid_NhanVien
            // 
            this.dtgrid_NhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrid_NhanVien.Location = new System.Drawing.Point(35, 322);
            this.dtgrid_NhanVien.Name = "dtgrid_NhanVien";
            this.dtgrid_NhanVien.Size = new System.Drawing.Size(945, 133);
            this.dtgrid_NhanVien.TabIndex = 28;
            this.dtgrid_NhanVien.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrid_NhanVien_RowEnter);
            // 
            // btSave
            // 
            this.btSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btSave.Location = new System.Drawing.Point(442, 471);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btSave.TabIndex = 27;
            this.btSave.Text = "Thêm";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btSua
            // 
            this.btSua.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.btSua.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btSua.Location = new System.Drawing.Point(696, 471);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(75, 23);
            this.btSua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btSua.TabIndex = 25;
            this.btSua.Text = "Sửa";
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btXoa
            // 
            this.btXoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btXoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btXoa.Location = new System.Drawing.Point(579, 471);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(75, 23);
            this.btXoa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btXoa.TabIndex = 24;
            this.btXoa.Text = "Xóa";
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btThem
            // 
            this.btThem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btThem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btThem.Location = new System.Drawing.Point(325, 471);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(75, 23);
            this.btThem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btThem.TabIndex = 23;
            this.btThem.Text = "Tạo mới";
            this.btThem.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // dtNgaySinh
            // 
            this.dtNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgaySinh.Location = new System.Drawing.Point(128, 217);
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(111, 26);
            this.dtNgaySinh.TabIndex = 22;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(711, 220);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(159, 26);
            this.txtEmail.TabIndex = 19;
            // 
            // txtLuong
            // 
            this.txtLuong.Location = new System.Drawing.Point(711, 173);
            this.txtLuong.Name = "txtLuong";
            this.txtLuong.Size = new System.Drawing.Size(100, 26);
            this.txtLuong.TabIndex = 18;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(371, 122);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(159, 26);
            this.txtDiaChi.TabIndex = 14;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(128, 173);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(111, 26);
            this.txtTenNV.TabIndex = 13;
            // 
            // txtMaNv
            // 
            this.txtMaNv.Location = new System.Drawing.Point(128, 125);
            this.txtMaNv.Name = "txtMaNv";
            this.txtMaNv.ReadOnly = true;
            this.txtMaNv.Size = new System.Drawing.Size(111, 26);
            this.txtMaNv.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(601, 219);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 19);
            this.label9.TabIndex = 10;
            this.label9.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(601, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 19);
            this.label8.TabIndex = 9;
            this.label8.Text = "Lương";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(309, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "CMND";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(309, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Số điện thoại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày sinh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên nhân viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(14, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã nhân viên";
            // 
            // reflectionLabel1
            // 
            // 
            // 
            // 
            this.reflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionLabel1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.reflectionLabel1.Location = new System.Drawing.Point(348, 22);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.Size = new System.Drawing.Size(142, 70);
            this.reflectionLabel1.TabIndex = 1;
            this.reflectionLabel1.Text = "<b><font size=\"+6\"><i></i><font color=\"#B02B2C\">Nhân Viên</font></font></b>";
            // 
            // openFD
            // 
            this.openFD.FileName = "openFD";
            // 
            // FormNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 506);
            this.Controls.Add(this.panelEx1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormNhanVien";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Quản lý hồ sơ";
            this.Load += new System.EventHandler(this.FormNhanVien_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnhNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_NhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.DataGridView dtgrid_NhanVien;
        private DevComponents.DotNetBar.ButtonX btSave;
        private DevComponents.DotNetBar.ButtonX btSua;
        private DevComponents.DotNetBar.ButtonX btXoa;
        private DevComponents.DotNetBar.ButtonX btThem;
        private System.Windows.Forms.DateTimePicker dtNgaySinh;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtLuong;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.TextBox txtMaNv;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label VNĐ;
        private System.Windows.Forms.TextBox txtTimKiem;
        private DevComponents.DotNetBar.ButtonX btntimkiem;
        private DevComponents.DotNetBar.ButtonX btnAnhNV;
        private System.Windows.Forms.PictureBox pbAnhNV;
        private System.Windows.Forms.OpenFileDialog openFD;
        private DevComponents.DotNetBar.Controls.TextBoxX URL;
        private DevComponents.DotNetBar.ButtonX btnThoat;
    }
}