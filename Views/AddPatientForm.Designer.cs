namespace Hospital_Management.Views
{
    partial class AddPatientForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCnic = new System.Windows.Forms.Label();
            this.txtCnic = new System.Windows.Forms.TextBox();
            this.lblPhoneNo = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.lblDob = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.lblBloodGroup = new System.Windows.Forms.Label();
            this.cmbBloodGroup = new System.Windows.Forms.ComboBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblEmergencyContact = new System.Windows.Forms.Label();
            this.txtEmergencyContact = new System.Windows.Forms.TextBox();
            this.lblEmergencyName = new System.Windows.Forms.Label();
            this.txtEmergencyName = new System.Windows.Forms.TextBox();
            this.lblMedicalHistory = new System.Windows.Forms.Label();
            this.txtMedicalHistory = new System.Windows.Forms.TextBox();
            this.lblAllergies = new System.Windows.Forms.Label();
            this.txtAllergies = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(500, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Patient";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlContent.Controls.Add(this.lblName);
            this.pnlContent.Controls.Add(this.txtName);
            this.pnlContent.Controls.Add(this.lblCnic);
            this.pnlContent.Controls.Add(this.txtCnic);
            this.pnlContent.Controls.Add(this.lblPhoneNo);
            this.pnlContent.Controls.Add(this.txtPhoneNo);
            this.pnlContent.Controls.Add(this.lblDob);
            this.pnlContent.Controls.Add(this.dtpDateOfBirth);
            this.pnlContent.Controls.Add(this.lblEmail);
            this.pnlContent.Controls.Add(this.txtEmail);
            this.pnlContent.Controls.Add(this.lblGender);
            this.pnlContent.Controls.Add(this.rbMale);
            this.pnlContent.Controls.Add(this.rbFemale);
            this.pnlContent.Controls.Add(this.lblBloodGroup);
            this.pnlContent.Controls.Add(this.cmbBloodGroup);
            this.pnlContent.Controls.Add(this.lblAddress);
            this.pnlContent.Controls.Add(this.txtAddress);
            this.pnlContent.Controls.Add(this.lblEmergencyContact);
            this.pnlContent.Controls.Add(this.txtEmergencyContact);
            this.pnlContent.Controls.Add(this.lblEmergencyName);
            this.pnlContent.Controls.Add(this.txtEmergencyName);
            this.pnlContent.Controls.Add(this.lblMedicalHistory);
            this.pnlContent.Controls.Add(this.txtMedicalHistory);
            this.pnlContent.Controls.Add(this.lblAllergies);
            this.pnlContent.Controls.Add(this.txtAllergies);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 50);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(500, 450);
            this.pnlContent.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(20, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(130, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.Location = new System.Drawing.Point(155, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(320, 25);
            this.txtName.TabIndex = 1;
            // 
            // lblCnic
            // 
            this.lblCnic.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCnic.ForeColor = System.Drawing.Color.White;
            this.lblCnic.Location = new System.Drawing.Point(20, 48);
            this.lblCnic.Name = "lblCnic";
            this.lblCnic.Size = new System.Drawing.Size(130, 20);
            this.lblCnic.TabIndex = 2;
            this.lblCnic.Text = "CNIC:";
            // 
            // txtCnic
            // 
            this.txtCnic.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCnic.Location = new System.Drawing.Point(155, 45);
            this.txtCnic.Name = "txtCnic";
            this.txtCnic.Size = new System.Drawing.Size(320, 25);
            this.txtCnic.TabIndex = 3;
            // 
            // lblPhoneNo
            // 
            this.lblPhoneNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhoneNo.ForeColor = System.Drawing.Color.White;
            this.lblPhoneNo.Location = new System.Drawing.Point(20, 83);
            this.lblPhoneNo.Name = "lblPhoneNo";
            this.lblPhoneNo.Size = new System.Drawing.Size(130, 20);
            this.lblPhoneNo.TabIndex = 4;
            this.lblPhoneNo.Text = "Phone No:";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhoneNo.Location = new System.Drawing.Point(155, 80);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(320, 25);
            this.txtPhoneNo.TabIndex = 5;
            // 
            // lblDob
            // 
            this.lblDob.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDob.ForeColor = System.Drawing.Color.White;
            this.lblDob.Location = new System.Drawing.Point(20, 118);
            this.lblDob.Name = "lblDob";
            this.lblDob.Size = new System.Drawing.Size(130, 20);
            this.lblDob.TabIndex = 6;
            this.lblDob.Text = "Date of Birth:";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDateOfBirth.Location = new System.Drawing.Point(155, 115);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(320, 25);
            this.dtpDateOfBirth.TabIndex = 7;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(20, 153);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(130, 20);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(155, 150);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(320, 25);
            this.txtEmail.TabIndex = 9;
            // 
            // lblGender
            // 
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGender.ForeColor = System.Drawing.Color.White;
            this.lblGender.Location = new System.Drawing.Point(20, 188);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(130, 20);
            this.lblGender.TabIndex = 10;
            this.lblGender.Text = "Gender:";
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbMale.ForeColor = System.Drawing.Color.White;
            this.rbMale.Location = new System.Drawing.Point(155, 185);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(55, 23);
            this.rbMale.TabIndex = 11;
            this.rbMale.Text = "Male";
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbFemale.ForeColor = System.Drawing.Color.White;
            this.rbFemale.Location = new System.Drawing.Point(230, 185);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(69, 23);
            this.rbFemale.TabIndex = 12;
            this.rbFemale.Text = "Female";
            // 
            // lblBloodGroup
            // 
            this.lblBloodGroup.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBloodGroup.ForeColor = System.Drawing.Color.White;
            this.lblBloodGroup.Location = new System.Drawing.Point(20, 223);
            this.lblBloodGroup.Name = "lblBloodGroup";
            this.lblBloodGroup.Size = new System.Drawing.Size(130, 20);
            this.lblBloodGroup.TabIndex = 13;
            this.lblBloodGroup.Text = "Blood Group:";
            // 
            // cmbBloodGroup
            // 
            this.cmbBloodGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBloodGroup.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbBloodGroup.FormattingEnabled = true;
            this.cmbBloodGroup.Items.AddRange(new object[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" });
            this.cmbBloodGroup.Location = new System.Drawing.Point(155, 220);
            this.cmbBloodGroup.Name = "cmbBloodGroup";
            this.cmbBloodGroup.Size = new System.Drawing.Size(150, 25);
            this.cmbBloodGroup.TabIndex = 14;
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAddress.ForeColor = System.Drawing.Color.White;
            this.lblAddress.Location = new System.Drawing.Point(20, 258);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(130, 20);
            this.lblAddress.TabIndex = 15;
            this.lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Location = new System.Drawing.Point(155, 255);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(320, 25);
            this.txtAddress.TabIndex = 16;
            // 
            // lblEmergencyContact
            // 
            this.lblEmergencyContact.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmergencyContact.ForeColor = System.Drawing.Color.White;
            this.lblEmergencyContact.Location = new System.Drawing.Point(20, 293);
            this.lblEmergencyContact.Name = "lblEmergencyContact";
            this.lblEmergencyContact.Size = new System.Drawing.Size(130, 20);
            this.lblEmergencyContact.TabIndex = 17;
            this.lblEmergencyContact.Text = "Emergency Phone:";
            // 
            // txtEmergencyContact
            // 
            this.txtEmergencyContact.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmergencyContact.Location = new System.Drawing.Point(155, 290);
            this.txtEmergencyContact.Name = "txtEmergencyContact";
            this.txtEmergencyContact.Size = new System.Drawing.Size(320, 25);
            this.txtEmergencyContact.TabIndex = 18;
            // 
            // lblEmergencyName
            // 
            this.lblEmergencyName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmergencyName.ForeColor = System.Drawing.Color.White;
            this.lblEmergencyName.Location = new System.Drawing.Point(20, 328);
            this.lblEmergencyName.Name = "lblEmergencyName";
            this.lblEmergencyName.Size = new System.Drawing.Size(130, 20);
            this.lblEmergencyName.TabIndex = 19;
            this.lblEmergencyName.Text = "Emergency Name:";
            // 
            // txtEmergencyName
            // 
            this.txtEmergencyName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmergencyName.Location = new System.Drawing.Point(155, 325);
            this.txtEmergencyName.Name = "txtEmergencyName";
            this.txtEmergencyName.Size = new System.Drawing.Size(320, 25);
            this.txtEmergencyName.TabIndex = 20;
            // 
            // lblMedicalHistory
            // 
            this.lblMedicalHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMedicalHistory.ForeColor = System.Drawing.Color.White;
            this.lblMedicalHistory.Location = new System.Drawing.Point(20, 363);
            this.lblMedicalHistory.Name = "lblMedicalHistory";
            this.lblMedicalHistory.Size = new System.Drawing.Size(130, 20);
            this.lblMedicalHistory.TabIndex = 21;
            this.lblMedicalHistory.Text = "Medical History:";
            // 
            // txtMedicalHistory
            // 
            this.txtMedicalHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMedicalHistory.Location = new System.Drawing.Point(155, 360);
            this.txtMedicalHistory.Multiline = true;
            this.txtMedicalHistory.Name = "txtMedicalHistory";
            this.txtMedicalHistory.Size = new System.Drawing.Size(320, 50);
            this.txtMedicalHistory.TabIndex = 22;
            // 
            // lblAllergies
            // 
            this.lblAllergies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAllergies.ForeColor = System.Drawing.Color.White;
            this.lblAllergies.Location = new System.Drawing.Point(20, 418);
            this.lblAllergies.Name = "lblAllergies";
            this.lblAllergies.Size = new System.Drawing.Size(130, 20);
            this.lblAllergies.TabIndex = 23;
            this.lblAllergies.Text = "Allergies:";
            // 
            // txtAllergies
            // 
            this.txtAllergies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAllergies.Location = new System.Drawing.Point(155, 415);
            this.txtAllergies.Multiline = true;
            this.txtAllergies.Name = "txtAllergies";
            this.txtAllergies.Size = new System.Drawing.Size(320, 50);
            this.txtAllergies.TabIndex = 24;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Controls.Add(this.btnClear);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 500);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(500, 50);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(395, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(80, 80, 85);
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(295, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 32);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(80, 80, 85);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(15, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddPatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.ClientSize = new System.Drawing.Size(500, 550);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPatientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Patient - Hospital Management System";
            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCnic;
        private System.Windows.Forms.TextBox txtCnic;
        private System.Windows.Forms.Label lblPhoneNo;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.Label lblBloodGroup;
        private System.Windows.Forms.ComboBox cmbBloodGroup;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblEmergencyContact;
        private System.Windows.Forms.TextBox txtEmergencyContact;
        private System.Windows.Forms.Label lblEmergencyName;
        private System.Windows.Forms.TextBox txtEmergencyName;
        private System.Windows.Forms.Label lblMedicalHistory;
        private System.Windows.Forms.TextBox txtMedicalHistory;
        private System.Windows.Forms.Label lblAllergies;
        private System.Windows.Forms.TextBox txtAllergies;
    }
}
