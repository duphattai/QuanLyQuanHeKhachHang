namespace Main.GUI
{
    partial class FormGiaoDich
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGiaoDich));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.cbtMHD = new DevComponents.DotNetBar.Controls.ComboTree();
            this.dtgrid_GiaoDich = new System.Windows.Forms.DataGridView();
            this.dtNGD = new System.Windows.Forms.DateTimePicker();
            this.btntimkiem = new DevComponents.DotNetBar.ButtonX();
            this.btnLuu = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.btnSua = new DevComponents.DotNetBar.ButtonX();
            this.btnXoa = new DevComponents.DotNetBar.ButtonX();
            this.btnThem = new DevComponents.DotNetBar.ButtonX();
            this.txtDDGD = new System.Windows.Forms.TextBox();
            this.txtTGD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.txtMGD = new System.Windows.Forms.TextBox();
            this.cbtTimKiem = new DevComponents.DotNetBar.Controls.ComboTree();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_GiaoDich)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.cbtTimKiem);
            this.panelEx1.Controls.Add(this.txtMGD);
            this.panelEx1.Controls.Add(this.cbtMHD);
            this.panelEx1.Controls.Add(this.dtgrid_GiaoDich);
            this.panelEx1.Controls.Add(this.dtNGD);
            this.panelEx1.Controls.Add(this.btntimkiem);
            this.panelEx1.Controls.Add(this.btnLuu);
            this.panelEx1.Controls.Add(this.btnThoat);
            this.panelEx1.Controls.Add(this.btnSua);
            this.panelEx1.Controls.Add(this.btnXoa);
            this.panelEx1.Controls.Add(this.btnThem);
            this.panelEx1.Controls.Add(this.txtDDGD);
            this.panelEx1.Controls.Add(this.txtTGD);
            this.panelEx1.Controls.Add(this.label5);
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.label3);
            this.panelEx1.Controls.Add(this.label2);
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.Controls.Add(this.reflectionLabel1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(865, 487);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // cbtMHD
            // 
            this.cbtMHD.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cbtMHD.BackgroundStyle.Class = "TextBoxBorder";
            this.cbtMHD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbtMHD.ButtonClear.Tooltip = "";
            this.cbtMHD.ButtonCustom.Tooltip = "";
            this.cbtMHD.ButtonCustom2.Tooltip = "";
            this.cbtMHD.ButtonDropDown.Tooltip = "";
            this.cbtMHD.ButtonDropDown.Visible = true;
            this.cbtMHD.Location = new System.Drawing.Point(309, 143);
            this.cbtMHD.Name = "cbtMHD";
            this.cbtMHD.Size = new System.Drawing.Size(100, 23);
            this.cbtMHD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbtMHD.TabIndex = 37;
            // 
            // dtgrid_GiaoDich
            // 
            this.dtgrid_GiaoDich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrid_GiaoDich.Location = new System.Drawing.Point(76, 295);
            this.dtgrid_GiaoDich.Name = "dtgrid_GiaoDich";
            this.dtgrid_GiaoDich.Size = new System.Drawing.Size(777, 128);
            this.dtgrid_GiaoDich.TabIndex = 36;
            this.dtgrid_GiaoDich.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrid_GiaoDich_RowEnter);
            // 
            // dtNGD
            // 
            this.dtNGD.CustomFormat = "dd/MM/yyyy";
            this.dtNGD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNGD.Location = new System.Drawing.Point(577, 100);
            this.dtNGD.Name = "dtNGD";
            this.dtNGD.Size = new System.Drawing.Size(146, 20);
            this.dtNGD.TabIndex = 35;
            // 
            // btntimkiem
            // 
            this.btntimkiem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btntimkiem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btntimkiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btntimkiem.Location = new System.Drawing.Point(233, 259);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(75, 23);
            this.btntimkiem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btntimkiem.TabIndex = 33;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Location = new System.Drawing.Point(325, 443);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLuu.TabIndex = 19;
            this.btnLuu.Text = "Thêm";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnThoat.Location = new System.Drawing.Point(772, 441);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 18;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSua
            // 
            this.btnSua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSua.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnSua.Location = new System.Drawing.Point(622, 441);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSua.TabIndex = 17;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnXoa.Location = new System.Drawing.Point(470, 443);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnThem.Location = new System.Drawing.Point(188, 444);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThem.TabIndex = 15;
            this.btnThem.Text = "Tạo mới";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtDDGD
            // 
            this.txtDDGD.Location = new System.Drawing.Point(577, 148);
            this.txtDDGD.Name = "txtDDGD";
            this.txtDDGD.Size = new System.Drawing.Size(146, 20);
            this.txtDDGD.TabIndex = 14;
            // 
            // txtTGD
            // 
            this.txtTGD.Location = new System.Drawing.Point(309, 197);
            this.txtTGD.Name = "txtTGD";
            this.txtTGD.Size = new System.Drawing.Size(100, 20);
            this.txtTGD.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(463, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Địa điểm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(463, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ngày giao dịch";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(204, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tên giao dịch";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(205, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên hợp đồng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(206, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mã giao dịch";
            // 
            // reflectionLabel1
            // 
            // 
            // 
            // 
            this.reflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionLabel1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.reflectionLabel1.Location = new System.Drawing.Point(335, 12);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.Size = new System.Drawing.Size(287, 70);
            this.reflectionLabel1.TabIndex = 4;
            this.reflectionLabel1.Text = "<b><font size=\"+6\"><i></i><font color=\"#B02B2C\">Thông Tin Giao Dịch</font></font>" +
    "</b>";
            // 
            // txtMGD
            // 
            this.txtMGD.Location = new System.Drawing.Point(309, 100);
            this.txtMGD.Name = "txtMGD";
            this.txtMGD.ReadOnly = true;
            this.txtMGD.Size = new System.Drawing.Size(100, 20);
            this.txtMGD.TabIndex = 38;
            // 
            // cbtTimKiem
            // 
            this.cbtTimKiem.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cbtTimKiem.BackgroundStyle.Class = "TextBoxBorder";
            this.cbtTimKiem.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbtTimKiem.ButtonClear.Tooltip = "";
            this.cbtTimKiem.ButtonCustom.Tooltip = "";
            this.cbtTimKiem.ButtonCustom2.Tooltip = "";
            this.cbtTimKiem.ButtonDropDown.Tooltip = "";
            this.cbtTimKiem.ButtonDropDown.Visible = true;
            this.cbtTimKiem.Location = new System.Drawing.Point(76, 259);
            this.cbtTimKiem.Name = "cbtTimKiem";
            this.cbtTimKiem.Size = new System.Drawing.Size(132, 23);
            this.cbtTimKiem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbtTimKiem.TabIndex = 39;
            // 
            // FormGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 487);
            this.Controls.Add(this.panelEx1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGiaoDich";
            this.Text = "Quản Lý Giao Dịch";
            this.Load += new System.EventHandler(this.FormGiaoDich_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_GiaoDich)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDDGD;
        private System.Windows.Forms.TextBox txtTGD;
        private DevComponents.DotNetBar.ButtonX btnLuu;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.ButtonX btnSua;
        private DevComponents.DotNetBar.ButtonX btnXoa;
        private DevComponents.DotNetBar.ButtonX btnThem;
        private DevComponents.DotNetBar.ButtonX btntimkiem;
        private System.Windows.Forms.DateTimePicker dtNGD;
        private System.Windows.Forms.DataGridView dtgrid_GiaoDich;
        private DevComponents.DotNetBar.Controls.ComboTree cbtMHD;
        private System.Windows.Forms.BindingSource qUANLYQUANHEKHACHHANGDataSet1BindingSource;
        private System.Windows.Forms.TextBox txtMGD;
        private DevComponents.DotNetBar.Controls.ComboTree cbtTimKiem;
       
    }
}