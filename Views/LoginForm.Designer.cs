namespace Hospital_Management.Views
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblLockIcon = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblEmployeeId = new System.Windows.Forms.Label();
            this.txtEmployeeId = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnTogglePassword = new System.Windows.Forms.Button();
            this.chkTrustedDevice = new System.Windows.Forms.CheckBox();
            this.lblForgotPassword = new System.Windows.Forms.LinkLabel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblAuthorized = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.lblLockIcon);
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.lblSubtitle);
            this.pnlCard.Controls.Add(this.lblEmployeeId);
            this.pnlCard.Controls.Add(this.txtEmployeeId);
            this.pnlCard.Controls.Add(this.lblDepartment);
            this.pnlCard.Controls.Add(this.cmbDepartment);
            this.pnlCard.Controls.Add(this.lblPassword);
            this.pnlCard.Controls.Add(this.txtPassword);
            this.pnlCard.Controls.Add(this.btnTogglePassword);
            this.pnlCard.Controls.Add(this.chkTrustedDevice);
            this.pnlCard.Controls.Add(this.lblForgotPassword);
            this.pnlCard.Controls.Add(this.btnLogin);
            this.pnlCard.Controls.Add(this.lblAuthorized);
            this.pnlCard.Location = new System.Drawing.Point(200, 80);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(400, 440);
            this.pnlCard.TabIndex = 0;
            this.pnlCard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCard_Paint);
            // 
            // lblLockIcon
            // 
            this.lblLockIcon.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblLockIcon.ForeColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.lblLockIcon.Location = new System.Drawing.Point(0, 20);
            this.lblLockIcon.Name = "lblLockIcon";
            this.lblLockIcon.Size = new System.Drawing.Size(400, 40);
            this.lblLockIcon.TabIndex = 0;
            this.lblLockIcon.Text = "🔒";
            this.lblLockIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblTitle.Location = new System.Drawing.Point(0, 65);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 35);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Staff Portal Login";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.lblSubtitle.Location = new System.Drawing.Point(0, 100);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(400, 20);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Please enter your credentials for secure access";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmployeeId
            // 
            this.lblEmployeeId.AutoSize = true;
            this.lblEmployeeId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmployeeId.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblEmployeeId.Location = new System.Drawing.Point(40, 135);
            this.lblEmployeeId.Name = "lblEmployeeId";
            this.lblEmployeeId.Size = new System.Drawing.Size(110, 15);
            this.lblEmployeeId.TabIndex = 3;
            this.lblEmployeeId.Text = "Employee ID / Email";
            // 
            // txtEmployeeId
            // 
            this.txtEmployeeId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmployeeId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmployeeId.ForeColor = System.Drawing.Color.Gray;
            this.txtEmployeeId.Location = new System.Drawing.Point(40, 155);
            this.txtEmployeeId.Name = "txtEmployeeId";
            this.txtEmployeeId.Size = new System.Drawing.Size(320, 25);
            this.txtEmployeeId.TabIndex = 4;
            this.txtEmployeeId.Text = "ID-12345 or email@hospital.org";
            this.txtEmployeeId.Enter += new System.EventHandler(this.txtEmployeeId_Enter);
            this.txtEmployeeId.Leave += new System.EventHandler(this.txtEmployeeId_Leave);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDepartment.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblDepartment.Location = new System.Drawing.Point(40, 195);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(105, 15);
            this.lblDepartment.TabIndex = 5;
            this.lblDepartment.Text = "Department Access";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDepartment.ForeColor = System.Drawing.Color.Gray;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Items.AddRange(new object[] {
                "Select Department",
                "Administration",
                "Emergency",
                "ICU",
                "Laboratory",
                "Pharmacy",
                "Radiology",
                "Surgery"});
            this.cmbDepartment.Location = new System.Drawing.Point(40, 215);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(320, 25);
            this.cmbDepartment.TabIndex = 6;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblPassword.Location = new System.Drawing.Point(40, 255);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(97, 15);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Security Password";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(40, 275);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(285, 25);
            this.txtPassword.TabIndex = 8;
            // 
            // btnTogglePassword
            // 
            this.btnTogglePassword.BackColor = System.Drawing.Color.White;
            this.btnTogglePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTogglePassword.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnTogglePassword.FlatAppearance.BorderSize = 1;
            this.btnTogglePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTogglePassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTogglePassword.ForeColor = System.Drawing.Color.Gray;
            this.btnTogglePassword.Location = new System.Drawing.Point(325, 275);
            this.btnTogglePassword.Name = "btnTogglePassword";
            this.btnTogglePassword.Size = new System.Drawing.Size(35, 25);
            this.btnTogglePassword.TabIndex = 9;
            this.btnTogglePassword.Text = "Show";
            this.btnTogglePassword.UseVisualStyleBackColor = false;
            this.btnTogglePassword.Click += new System.EventHandler(this.btnTogglePassword_Click);
            // 
            // chkTrustedDevice
            // 
            this.chkTrustedDevice.AutoSize = true;
            this.chkTrustedDevice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkTrustedDevice.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.chkTrustedDevice.Location = new System.Drawing.Point(40, 315);
            this.chkTrustedDevice.Name = "chkTrustedDevice";
            this.chkTrustedDevice.Size = new System.Drawing.Size(102, 19);
            this.chkTrustedDevice.TabIndex = 10;
            this.chkTrustedDevice.Text = "Trusted device";
            this.chkTrustedDevice.UseVisualStyleBackColor = true;
            // 
            // lblForgotPassword
            // 
            this.lblForgotPassword.AutoSize = true;
            this.lblForgotPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblForgotPassword.LinkColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.lblForgotPassword.Location = new System.Drawing.Point(260, 316);
            this.lblForgotPassword.Name = "lblForgotPassword";
            this.lblForgotPassword.Size = new System.Drawing.Size(100, 15);
            this.lblForgotPassword.TabIndex = 11;
            this.lblForgotPassword.TabStop = true;
            this.lblForgotPassword.Text = "Forgot Password?";
            this.lblForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblForgotPassword_LinkClicked);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(40, 350);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(320, 40);
            this.btnLogin.TabIndex = 12;
            this.btnLogin.Text = "Authenticate && Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblAuthorized
            // 
            this.lblAuthorized.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblAuthorized.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.lblAuthorized.Location = new System.Drawing.Point(0, 400);
            this.lblAuthorized.Name = "lblAuthorized";
            this.lblAuthorized.Size = new System.Drawing.Size(400, 20);
            this.lblAuthorized.TabIndex = 13;
            this.lblAuthorized.Text = "AUTHORIZED PERSONNEL ONLY";
            this.lblAuthorized.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCopyright.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblCopyright.Location = new System.Drawing.Point(0, 580);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(800, 20);
            this.lblCopyright.TabIndex = 1;
            this.lblCopyright.Text = "© 2026 HOSPITAL MANAGEMENT SYSTEM";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(200, 210, 200);
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.lblCopyright);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital Management - Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblLockIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblEmployeeId;
        private System.Windows.Forms.TextBox txtEmployeeId;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnTogglePassword;
        private System.Windows.Forms.CheckBox chkTrustedDevice;
        private System.Windows.Forms.LinkLabel lblForgotPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblAuthorized;
        private System.Windows.Forms.Label lblCopyright;
    }
}
