namespace Hospital_Management.Views
{
    partial class AddStaffForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();

            // Row 1: Name, CNIC, Phone No, Date of Birth
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCnic = new System.Windows.Forms.Label();
            this.txtCnic = new System.Windows.Forms.TextBox();
            this.lblPhoneNo = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();

            // Row 2: Email, Password, Qualification, Department
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblQualification = new System.Windows.Forms.Label();
            this.cmbQualification = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();

            // Row 3: Gender, Working Hours, Salary
            this.lblGender = new System.Windows.Forms.Label();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.lblWorkingHours = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.cmbFromTime = new System.Windows.Forms.ComboBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.cmbToTime = new System.Windows.Forms.ComboBox();
            this.lblSalary = new System.Windows.Forms.Label();
            this.numSalary = new System.Windows.Forms.NumericUpDown();

            // Row 4: Address
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();

            // Buttons
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalary)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(600, 45);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(600, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add Doctor Information";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlContent.Controls.Add(this.lblName);
            this.pnlContent.Controls.Add(this.txtName);
            this.pnlContent.Controls.Add(this.lblCnic);
            this.pnlContent.Controls.Add(this.txtCnic);
            this.pnlContent.Controls.Add(this.lblPhoneNo);
            this.pnlContent.Controls.Add(this.txtPhoneNo);
            this.pnlContent.Controls.Add(this.lblDateOfBirth);
            this.pnlContent.Controls.Add(this.dtpDateOfBirth);
            this.pnlContent.Controls.Add(this.lblEmail);
            this.pnlContent.Controls.Add(this.txtEmail);
            this.pnlContent.Controls.Add(this.lblPassword);
            this.pnlContent.Controls.Add(this.txtPassword);
            this.pnlContent.Controls.Add(this.lblQualification);
            this.pnlContent.Controls.Add(this.cmbQualification);
            this.pnlContent.Controls.Add(this.lblDepartment);
            this.pnlContent.Controls.Add(this.cmbDepartment);
            this.pnlContent.Controls.Add(this.lblGender);
            this.pnlContent.Controls.Add(this.rbMale);
            this.pnlContent.Controls.Add(this.rbFemale);
            this.pnlContent.Controls.Add(this.lblWorkingHours);
            this.pnlContent.Controls.Add(this.lblFrom);
            this.pnlContent.Controls.Add(this.cmbFromTime);
            this.pnlContent.Controls.Add(this.lblTo);
            this.pnlContent.Controls.Add(this.cmbToTime);
            this.pnlContent.Controls.Add(this.lblSalary);
            this.pnlContent.Controls.Add(this.numSalary);
            this.pnlContent.Controls.Add(this.lblAddress);
            this.pnlContent.Controls.Add(this.txtAddress);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 45);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlContent.Size = new System.Drawing.Size(600, 310);
            this.pnlContent.TabIndex = 1;

            // Row 1 Labels and Controls
            int row1Y = 10;
            int row2Y = 70;
            int row3Y = 130;
            int row4Y = 190;

            // Name
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(20, row1Y);
            this.lblName.Text = "Name:";

            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.Location = new System.Drawing.Point(20, row1Y + 20);
            this.txtName.Size = new System.Drawing.Size(120, 23);

            // CNIC
            this.lblCnic.AutoSize = true;
            this.lblCnic.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCnic.ForeColor = System.Drawing.Color.White;
            this.lblCnic.Location = new System.Drawing.Point(155, row1Y);
            this.lblCnic.Text = "CNIC:";

            this.txtCnic.BackColor = System.Drawing.Color.White;
            this.txtCnic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCnic.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCnic.Location = new System.Drawing.Point(155, row1Y + 20);
            this.txtCnic.Size = new System.Drawing.Size(120, 23);

            // Phone No
            this.lblPhoneNo.AutoSize = true;
            this.lblPhoneNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhoneNo.ForeColor = System.Drawing.Color.White;
            this.lblPhoneNo.Location = new System.Drawing.Point(290, row1Y);
            this.lblPhoneNo.Text = "Phone No.:";

            this.txtPhoneNo.BackColor = System.Drawing.Color.White;
            this.txtPhoneNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhoneNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhoneNo.Location = new System.Drawing.Point(290, row1Y + 20);
            this.txtPhoneNo.Size = new System.Drawing.Size(120, 23);

            // Date of Birth
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDateOfBirth.ForeColor = System.Drawing.Color.White;
            this.lblDateOfBirth.Location = new System.Drawing.Point(425, row1Y);
            this.lblDateOfBirth.Text = "Date of Birth:";

            this.dtpDateOfBirth.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(425, row1Y + 20);
            this.dtpDateOfBirth.Size = new System.Drawing.Size(150, 23);

            // Row 2: Email, Password, Qualification, Department
            // Email
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(20, row2Y);
            this.lblEmail.Text = "Email:";

            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.Location = new System.Drawing.Point(20, row2Y + 20);
            this.txtEmail.Size = new System.Drawing.Size(120, 23);

            // Password
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(155, row2Y);
            this.lblPassword.Text = "Password:";

            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.Location = new System.Drawing.Point(155, row2Y + 20);
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(120, 23);

            // Qualification
            this.lblQualification.AutoSize = true;
            this.lblQualification.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQualification.ForeColor = System.Drawing.Color.White;
            this.lblQualification.Location = new System.Drawing.Point(290, row2Y);
            this.lblQualification.Text = "Qualification:";

            this.cmbQualification.BackColor = System.Drawing.Color.White;
            this.cmbQualification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQualification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbQualification.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbQualification.FormattingEnabled = true;
            this.cmbQualification.Location = new System.Drawing.Point(290, row2Y + 20);
            this.cmbQualification.Size = new System.Drawing.Size(120, 23);

            // Department
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDepartment.ForeColor = System.Drawing.Color.White;
            this.lblDepartment.Location = new System.Drawing.Point(425, row2Y);
            this.lblDepartment.Text = "Department:";

            this.cmbDepartment.BackColor = System.Drawing.Color.White;
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDepartment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(425, row2Y + 20);
            this.cmbDepartment.Size = new System.Drawing.Size(150, 23);

            // Row 3: Gender, Working Hours, Salary
            // Gender
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGender.ForeColor = System.Drawing.Color.White;
            this.lblGender.Location = new System.Drawing.Point(20, row3Y);
            this.lblGender.Text = "Gender:";

            this.rbMale.AutoSize = true;
            this.rbMale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbMale.ForeColor = System.Drawing.Color.White;
            this.rbMale.Location = new System.Drawing.Point(20, row3Y + 20);
            this.rbMale.Text = "Male";

            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbFemale.ForeColor = System.Drawing.Color.White;
            this.rbFemale.Location = new System.Drawing.Point(80, row3Y + 20);
            this.rbFemale.Text = "Female";

            // Working Hours
            this.lblWorkingHours.AutoSize = true;
            this.lblWorkingHours.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblWorkingHours.ForeColor = System.Drawing.Color.White;
            this.lblWorkingHours.Location = new System.Drawing.Point(155, row3Y);
            this.lblWorkingHours.Text = "Working Hours:";

            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFrom.ForeColor = System.Drawing.Color.White;
            this.lblFrom.Location = new System.Drawing.Point(155, row3Y + 23);
            this.lblFrom.Text = "From";

            this.cmbFromTime.BackColor = System.Drawing.Color.White;
            this.cmbFromTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFromTime.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cmbFromTime.FormattingEnabled = true;
            this.cmbFromTime.Location = new System.Drawing.Point(195, row3Y + 20);
            this.cmbFromTime.Size = new System.Drawing.Size(90, 21);

            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTo.ForeColor = System.Drawing.Color.White;
            this.lblTo.Location = new System.Drawing.Point(290, row3Y + 23);
            this.lblTo.Text = "to";

            this.cmbToTime.BackColor = System.Drawing.Color.White;
            this.cmbToTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbToTime.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cmbToTime.FormattingEnabled = true;
            this.cmbToTime.Location = new System.Drawing.Point(310, row3Y + 20);
            this.cmbToTime.Size = new System.Drawing.Size(90, 21);

            // Salary
            this.lblSalary.AutoSize = true;
            this.lblSalary.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSalary.ForeColor = System.Drawing.Color.White;
            this.lblSalary.Location = new System.Drawing.Point(425, row3Y);
            this.lblSalary.Text = "Salary:";

            this.numSalary.BackColor = System.Drawing.Color.White;
            this.numSalary.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numSalary.Location = new System.Drawing.Point(425, row3Y + 20);
            this.numSalary.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numSalary.Size = new System.Drawing.Size(120, 23);
            this.numSalary.ThousandsSeparator = true;

            // Row 4: Address
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddress.ForeColor = System.Drawing.Color.White;
            this.lblAddress.Location = new System.Drawing.Point(20, row4Y);
            this.lblAddress.Text = "Address:";

            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddress.Location = new System.Drawing.Point(20, row4Y + 20);
            this.txtAddress.Multiline = true;
            this.txtAddress.Size = new System.Drawing.Size(555, 60);

            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnClear);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 355);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(600, 50);
            this.pnlButtons.TabIndex = 2;

            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(80, 80, 85);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(350, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 32);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(80, 80, 85);
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(430, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 32);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(510, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 32);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // AddStaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.ClientSize = new System.Drawing.Size(600, 405);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddStaffForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Doctor - Hospital Management System";

            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numSalary)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContent;

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCnic;
        private System.Windows.Forms.TextBox txtCnic;
        private System.Windows.Forms.Label lblPhoneNo;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;

        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblQualification;
        private System.Windows.Forms.ComboBox cmbQualification;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;

        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.Label lblWorkingHours;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.ComboBox cmbFromTime;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.ComboBox cmbToTime;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.NumericUpDown numSalary;

        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
    }
}
