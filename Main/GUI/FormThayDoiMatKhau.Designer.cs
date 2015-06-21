namespace Main.GUI
{
    partial class FormThayDoiMatKhau
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
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.btnThayDoi = new DevComponents.DotNetBar.ButtonX();
            this.txtMKMoi1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMKHienTai = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.txtMKMoi2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxShowPass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnThoat.Location = new System.Drawing.Point(341, 259);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(87, 23);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 25;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThayDoi
            // 
            this.btnThayDoi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThayDoi.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThayDoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnThayDoi.Location = new System.Drawing.Point(133, 259);
            this.btnThayDoi.Name = "btnThayDoi";
            this.btnThayDoi.Size = new System.Drawing.Size(96, 23);
            this.btnThayDoi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThayDoi.TabIndex = 24;
            this.btnThayDoi.Text = "Thay đổi";
            this.btnThayDoi.Click += new System.EventHandler(this.btnThayDoi_Click);
            // 
            // txtMKMoi1
            // 
            this.txtMKMoi1.Location = new System.Drawing.Point(337, 149);
            this.txtMKMoi1.Name = "txtMKMoi1";
            this.txtMKMoi1.Size = new System.Drawing.Size(129, 20);
            this.txtMKMoi1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(101, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "Nhập mật khẩu mới";
            // 
            // txtMKHienTai
            // 
            this.txtMKHienTai.Location = new System.Drawing.Point(337, 113);
            this.txtMKHienTai.Name = "txtMKHienTai";
            this.txtMKHienTai.Size = new System.Drawing.Size(129, 20);
            this.txtMKHienTai.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(101, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 19);
            this.label3.TabIndex = 20;
            this.label3.Text = "Mật khẩu hiện tại";
            // 
            // reflectionLabel1
            // 
            // 
            // 
            // 
            this.reflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionLabel1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.reflectionLabel1.Location = new System.Drawing.Point(169, 12);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.Size = new System.Drawing.Size(259, 70);
            this.reflectionLabel1.TabIndex = 19;
            this.reflectionLabel1.Text = "<b><font size=\"+6\"><i></i><font color=\"#B02B2C\">Thay đổi mật khẩu</font></font></" +
    "b>";
            // 
            // txtMKMoi2
            // 
            this.txtMKMoi2.Location = new System.Drawing.Point(337, 185);
            this.txtMKMoi2.Name = "txtMKMoi2";
            this.txtMKMoi2.Size = new System.Drawing.Size(129, 20);
            this.txtMKMoi2.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(101, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 19);
            this.label2.TabIndex = 26;
            this.label2.Text = "Nhập mật khẩu mới lần nữa";
            // 
            // checkBoxShowPass
            // 
            this.checkBoxShowPass.AutoSize = true;
            this.checkBoxShowPass.Location = new System.Drawing.Point(337, 224);
            this.checkBoxShowPass.Name = "checkBoxShowPass";
            this.checkBoxShowPass.Size = new System.Drawing.Size(109, 17);
            this.checkBoxShowPass.TabIndex = 28;
            this.checkBoxShowPass.Text = "Hiển thị mật khẩu";
            this.checkBoxShowPass.UseVisualStyleBackColor = true;
            this.checkBoxShowPass.CheckedChanged += new System.EventHandler(this.checkBoxShowPass_CheckedChanged);
            // 
            // FormThayDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 300);
            this.Controls.Add(this.checkBoxShowPass);
            this.Controls.Add(this.txtMKMoi2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThayDoi);
            this.Controls.Add(this.txtMKMoi1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMKHienTai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reflectionLabel1);
            this.Name = "FormThayDoiMatKhau";
            this.Text = "FormThayDoiMatKhau";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.ButtonX btnThayDoi;
        private System.Windows.Forms.TextBox txtMKMoi1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMKHienTai;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
        private System.Windows.Forms.TextBox txtMKMoi2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxShowPass;
    }
}