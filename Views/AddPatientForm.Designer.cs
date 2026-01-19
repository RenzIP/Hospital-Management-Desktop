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

            // Form fields
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

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(500, 50);
            this.pnlHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Add New Patient";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pnlContent
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 50);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(500, 450);
            this.pnlContent.TabIndex = 1;

            int y = 10;
            int labelWidth = 130;
            int fieldWidth = 320;
            int rowHeight = 35;

            // Name
            SetupLabel(lblName, "Name:", 20, y, labelWidth);
            SetupTextBox(txtName, 155, y, fieldWidth);
            y += rowHeight;

            // CNIC
            SetupLabel(lblCnic, "CNIC:", 20, y, labelWidth);
            SetupTextBox(txtCnic, 155, y, fieldWidth);
            y += rowHeight;

            // Phone
            SetupLabel(lblPhoneNo, "Phone No:", 20, y, labelWidth);
            SetupTextBox(txtPhoneNo, 155, y, fieldWidth);
            y += rowHeight;

            // DOB
            SetupLabel(lblDob, "Date of Birth:", 20, y, labelWidth);
            this.dtpDateOfBirth.Location = new System.Drawing.Point(155, y);
            this.dtpDateOfBirth.Size = new System.Drawing.Size(fieldWidth, 25);
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 10F);
            y += rowHeight;

            // Email
            SetupLabel(lblEmail, "Email:", 20, y, labelWidth);
            SetupTextBox(txtEmail, 155, y, fieldWidth);
            y += rowHeight;

            // Gender
            SetupLabel(lblGender, "Gender:", 20, y, labelWidth);
            this.rbMale.AutoSize = true;
            this.rbMale.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbMale.ForeColor = System.Drawing.Color.White;
            this.rbMale.Location = new System.Drawing.Point(155, y);
            this.rbMale.Name = "rbMale";
            this.rbMale.Text = "Male";
            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbFemale.ForeColor = System.Drawing.Color.White;
            this.rbFemale.Location = new System.Drawing.Point(230, y);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Text = "Female";
            y += rowHeight;

            // Blood Group
            SetupLabel(lblBloodGroup, "Blood Group:", 20, y, labelWidth);
            this.cmbBloodGroup.Location = new System.Drawing.Point(155, y);
            this.cmbBloodGroup.Size = new System.Drawing.Size(150, 25);
            this.cmbBloodGroup.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbBloodGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            y += rowHeight;

            // Address
            SetupLabel(lblAddress, "Address:", 20, y, labelWidth);
            SetupTextBox(txtAddress, 155, y, fieldWidth);
            y += rowHeight;

            // Emergency Contact
            SetupLabel(lblEmergencyContact, "Emergency Phone:", 20, y, labelWidth);
            SetupTextBox(txtEmergencyContact, 155, y, fieldWidth);
            y += rowHeight;

            // Emergency Name
            SetupLabel(lblEmergencyName, "Emergency Name:", 20, y, labelWidth);
            SetupTextBox(txtEmergencyName, 155, y, fieldWidth);
            y += rowHeight;

            // Medical History
            SetupLabel(lblMedicalHistory, "Medical History:", 20, y, labelWidth);
            this.txtMedicalHistory.Location = new System.Drawing.Point(155, y);
            this.txtMedicalHistory.Size = new System.Drawing.Size(fieldWidth, 50);
            this.txtMedicalHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMedicalHistory.Multiline = true;
            y += 55;

            // Allergies
            SetupLabel(lblAllergies, "Allergies:", 20, y, labelWidth);
            this.txtAllergies.Location = new System.Drawing.Point(155, y);
            this.txtAllergies.Size = new System.Drawing.Size(fieldWidth, 50);
            this.txtAllergies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAllergies.Multiline = true;

            // Add controls to pnlContent
            this.pnlContent.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblName, txtName, lblCnic, txtCnic, lblPhoneNo, txtPhoneNo,
                lblDob, dtpDateOfBirth, lblEmail, txtEmail, lblGender, rbMale, rbFemale,
                lblBloodGroup, cmbBloodGroup, lblAddress, txtAddress,
                lblEmergencyContact, txtEmergencyContact, lblEmergencyName, txtEmergencyName,
                lblMedicalHistory, txtMedicalHistory, lblAllergies, txtAllergies
            });

            // pnlFooter
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Controls.Add(this.btnClear);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 500);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(500, 50);
            this.pnlFooter.TabIndex = 2;

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(395, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 32);
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnClear
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(80, 80, 85);
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(295, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 32);
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(80, 80, 85);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(15, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 32);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // AddPatientForm
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

        private void SetupLabel(System.Windows.Forms.Label lbl, string text, int x, int y, int width)
        {
            lbl.AutoSize = false;
            lbl.Text = text;
            lbl.Location = new System.Drawing.Point(x, y + 3);
            lbl.Size = new System.Drawing.Size(width, 20);
            lbl.Font = new System.Drawing.Font("Segoe UI", 10F);
            lbl.ForeColor = System.Drawing.Color.White;
        }

        private void SetupTextBox(System.Windows.Forms.TextBox txt, int x, int y, int width)
        {
            txt.Location = new System.Drawing.Point(x, y);
            txt.Size = new System.Drawing.Size(width, 25);
            txt.Font = new System.Drawing.Font("Segoe UI", 10F);
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
