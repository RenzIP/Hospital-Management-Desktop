namespace Hospital_Management.Views
{
    partial class AddLaboratoryForm
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
            this.lblPatient = new System.Windows.Forms.Label();
            this.cmbPatient = new System.Windows.Forms.ComboBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.lblTestName = new System.Windows.Forms.Label();
            this.cmbTestName = new System.Windows.Forms.ComboBox();
            this.lblTestDate = new System.Windows.Forms.Label();
            this.dtpTestDate = new System.Windows.Forms.DateTimePicker();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
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
            this.pnlHeader.Size = new System.Drawing.Size(450, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(450, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Lab Test";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlContent.Controls.Add(this.lblPatient);
            this.pnlContent.Controls.Add(this.cmbPatient);
            this.pnlContent.Controls.Add(this.lblDoctor);
            this.pnlContent.Controls.Add(this.cmbDoctor);
            this.pnlContent.Controls.Add(this.lblTestName);
            this.pnlContent.Controls.Add(this.cmbTestName);
            this.pnlContent.Controls.Add(this.lblTestDate);
            this.pnlContent.Controls.Add(this.dtpTestDate);
            this.pnlContent.Controls.Add(this.lblStatus);
            this.pnlContent.Controls.Add(this.cmbStatus);
            this.pnlContent.Controls.Add(this.lblResult);
            this.pnlContent.Controls.Add(this.txtResult);
            this.pnlContent.Controls.Add(this.lblNotes);
            this.pnlContent.Controls.Add(this.txtNotes);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 50);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(450, 350);
            this.pnlContent.TabIndex = 1;
            // 
            // lblPatient
            // 
            this.lblPatient.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPatient.ForeColor = System.Drawing.Color.White;
            this.lblPatient.Location = new System.Drawing.Point(20, 13);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(100, 20);
            this.lblPatient.TabIndex = 0;
            this.lblPatient.Text = "Patient:";
            // 
            // cmbPatient
            // 
            this.cmbPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatient.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPatient.FormattingEnabled = true;
            this.cmbPatient.Location = new System.Drawing.Point(130, 10);
            this.cmbPatient.Name = "cmbPatient";
            this.cmbPatient.Size = new System.Drawing.Size(300, 25);
            this.cmbPatient.TabIndex = 1;
            // 
            // lblDoctor
            // 
            this.lblDoctor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDoctor.ForeColor = System.Drawing.Color.White;
            this.lblDoctor.Location = new System.Drawing.Point(20, 53);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(100, 20);
            this.lblDoctor.TabIndex = 2;
            this.lblDoctor.Text = "Doctor:";
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoctor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.Location = new System.Drawing.Point(130, 50);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(300, 25);
            this.cmbDoctor.TabIndex = 3;
            // 
            // lblTestName
            // 
            this.lblTestName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTestName.ForeColor = System.Drawing.Color.White;
            this.lblTestName.Location = new System.Drawing.Point(20, 93);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(100, 20);
            this.lblTestName.TabIndex = 4;
            this.lblTestName.Text = "Test Name:";
            // 
            // cmbTestName
            // 
            this.cmbTestName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTestName.FormattingEnabled = true;
            this.cmbTestName.Location = new System.Drawing.Point(130, 90);
            this.cmbTestName.Name = "cmbTestName";
            this.cmbTestName.Size = new System.Drawing.Size(300, 25);
            this.cmbTestName.TabIndex = 5;
            // 
            // lblTestDate
            // 
            this.lblTestDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTestDate.ForeColor = System.Drawing.Color.White;
            this.lblTestDate.Location = new System.Drawing.Point(20, 133);
            this.lblTestDate.Name = "lblTestDate";
            this.lblTestDate.Size = new System.Drawing.Size(100, 20);
            this.lblTestDate.TabIndex = 6;
            this.lblTestDate.Text = "Test Date:";
            // 
            // dtpTestDate
            // 
            this.dtpTestDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTestDate.Location = new System.Drawing.Point(130, 130);
            this.dtpTestDate.Name = "dtpTestDate";
            this.dtpTestDate.Size = new System.Drawing.Size(300, 25);
            this.dtpTestDate.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(20, 173);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 20);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] { "pending", "in_progress", "completed" });
            this.cmbStatus.Location = new System.Drawing.Point(130, 170);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 25);
            this.cmbStatus.TabIndex = 9;
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblResult.ForeColor = System.Drawing.Color.White;
            this.lblResult.Location = new System.Drawing.Point(20, 213);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(100, 20);
            this.lblResult.TabIndex = 10;
            this.lblResult.Text = "Result:";
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtResult.Location = new System.Drawing.Point(130, 210);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(300, 60);
            this.txtResult.TabIndex = 11;
            // 
            // lblNotes
            // 
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNotes.ForeColor = System.Drawing.Color.White;
            this.lblNotes.Location = new System.Drawing.Point(20, 283);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(100, 20);
            this.lblNotes.TabIndex = 12;
            this.lblNotes.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNotes.Location = new System.Drawing.Point(130, 280);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(300, 60);
            this.txtNotes.TabIndex = 13;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Controls.Add(this.btnClear);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 400);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(450, 50);
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
            this.btnSave.Location = new System.Drawing.Point(345, 10);
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
            this.btnClear.Location = new System.Drawing.Point(245, 10);
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
            // AddLaboratoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddLaboratoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Lab Test - Hospital Management System";
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
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.ComboBox cmbPatient;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Label lblTestName;
        private System.Windows.Forms.ComboBox cmbTestName;
        private System.Windows.Forms.Label lblTestDate;
        private System.Windows.Forms.DateTimePicker dtpTestDate;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
    }
}
