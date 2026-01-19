namespace Hospital_Management.Views
{
    partial class LaboratoryForm
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
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.dgvLaboratory = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnAddTest = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaboratory)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(850, 50);
            this.pnlHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(850, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Laboratory Tests";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pnlSearch
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlSearch.Controls.Add(this.cmbStatusFilter);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 50);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(850, 40);
            this.pnlSearch.TabIndex = 1;

            // cmbStatusFilter
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatusFilter.Location = new System.Drawing.Point(15, 7);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(150, 25);
            this.cmbStatusFilter.Items.AddRange(new object[] { "All Status", "pending", "in_progress", "completed" });
            this.cmbStatusFilter.SelectedIndex = 0;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cmbStatusFilter_SelectedIndexChanged);

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(600, 10);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(53, 19);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";

            // txtSearch
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(660, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(175, 25);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // dgvLaboratory
            this.dgvLaboratory.AllowUserToAddRows = false;
            this.dgvLaboratory.AllowUserToDeleteRows = false;
            this.dgvLaboratory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLaboratory.BackgroundColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.dgvLaboratory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLaboratory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLaboratory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLaboratory.ColumnHeadersDefaultCellStyle = GetHeaderStyle();
            this.dgvLaboratory.ColumnHeadersHeight = 35;
            this.dgvLaboratory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLaboratory.DefaultCellStyle = GetCellStyle();
            this.dgvLaboratory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLaboratory.EnableHeadersVisualStyles = false;
            this.dgvLaboratory.GridColor = System.Drawing.Color.FromArgb(60, 60, 65);
            this.dgvLaboratory.Location = new System.Drawing.Point(0, 90);
            this.dgvLaboratory.MultiSelect = false;
            this.dgvLaboratory.Name = "dgvLaboratory";
            this.dgvLaboratory.ReadOnly = true;
            this.dgvLaboratory.RowHeadersVisible = false;
            this.dgvLaboratory.RowTemplate.Height = 35;
            this.dgvLaboratory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLaboratory.Size = new System.Drawing.Size(850, 360);
            this.dgvLaboratory.TabIndex = 2;
            this.dgvLaboratory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLaboratory_CellClick);

            // pnlFooter
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlFooter.Controls.Add(this.btnAddTest);
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 450);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(850, 50);
            this.pnlFooter.TabIndex = 3;

            // btnAddTest
            this.btnAddTest.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnAddTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddTest.FlatAppearance.BorderSize = 0;
            this.btnAddTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTest.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddTest.ForeColor = System.Drawing.Color.White;
            this.btnAddTest.Location = new System.Drawing.Point(710, 10);
            this.btnAddTest.Name = "btnAddTest";
            this.btnAddTest.Size = new System.Drawing.Size(125, 32);
            this.btnAddTest.TabIndex = 0;
            this.btnAddTest.Text = "Add Lab Test";
            this.btnAddTest.UseVisualStyleBackColor = false;
            this.btnAddTest.Click += new System.EventHandler(this.btnAddTest_Click);

            // btnClose
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(80, 80, 85);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(15, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // LaboratoryForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.Controls.Add(this.dgvLaboratory);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LaboratoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Laboratory - Hospital Management System";
            this.Load += new System.EventHandler(this.LaboratoryForm_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaboratory)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridViewCellStyle GetHeaderStyle()
        {
            System.Windows.Forms.DataGridViewCellStyle style = new System.Windows.Forms.DataGridViewCellStyle();
            style.BackColor = System.Drawing.Color.FromArgb(60, 60, 65);
            style.ForeColor = System.Drawing.Color.White;
            style.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            style.SelectionBackColor = System.Drawing.Color.FromArgb(60, 60, 65);
            style.SelectionForeColor = System.Drawing.Color.White;
            style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            style.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            return style;
        }

        private System.Windows.Forms.DataGridViewCellStyle GetCellStyle()
        {
            System.Windows.Forms.DataGridViewCellStyle style = new System.Windows.Forms.DataGridViewCellStyle();
            style.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            style.ForeColor = System.Drawing.Color.White;
            style.Font = new System.Drawing.Font("Segoe UI", 9F);
            style.SelectionBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            style.SelectionForeColor = System.Drawing.Color.White;
            style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            style.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            return style;
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.DataGridView dgvLaboratory;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnAddTest;
        private System.Windows.Forms.Button btnClose;
    }
}
