namespace Hospital_Management.Views
{
    partial class CapitalForm
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
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblTotalIncome = new System.Windows.Forms.Label();
            this.lblTotalExpense = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.cmbTypeFilter = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvCapital = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnAddTransaction = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapital)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 50);
            this.pnlHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Capital / Financial Management";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pnlSummary
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(60, 60, 65);
            this.pnlSummary.Controls.Add(this.lblTotalIncome);
            this.pnlSummary.Controls.Add(this.lblTotalExpense);
            this.pnlSummary.Controls.Add(this.lblBalance);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Location = new System.Drawing.Point(0, 50);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(900, 40);
            this.pnlSummary.TabIndex = 1;

            // lblTotalIncome
            this.lblTotalIncome.AutoSize = true;
            this.lblTotalIncome.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalIncome.ForeColor = System.Drawing.Color.LightGreen;
            this.lblTotalIncome.Location = new System.Drawing.Point(20, 10);
            this.lblTotalIncome.Name = "lblTotalIncome";
            this.lblTotalIncome.Text = "Total Income: Rp 0";

            // lblTotalExpense
            this.lblTotalExpense.AutoSize = true;
            this.lblTotalExpense.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalExpense.ForeColor = System.Drawing.Color.Salmon;
            this.lblTotalExpense.Location = new System.Drawing.Point(280, 10);
            this.lblTotalExpense.Name = "lblTotalExpense";
            this.lblTotalExpense.Text = "Total Expense: Rp 0";

            // lblBalance
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblBalance.ForeColor = System.Drawing.Color.White;
            this.lblBalance.Location = new System.Drawing.Point(540, 10);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Text = "Balance: Rp 0";

            // pnlSearch
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlSearch.Controls.Add(this.cmbTypeFilter);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 90);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(900, 40);
            this.pnlSearch.TabIndex = 2;

            // cmbTypeFilter
            this.cmbTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTypeFilter.Location = new System.Drawing.Point(15, 7);
            this.cmbTypeFilter.Name = "cmbTypeFilter";
            this.cmbTypeFilter.Size = new System.Drawing.Size(150, 25);
            this.cmbTypeFilter.Items.AddRange(new object[] { "All Types", "income", "expense" });
            this.cmbTypeFilter.SelectedIndex = 0;
            this.cmbTypeFilter.SelectedIndexChanged += new System.EventHandler(this.cmbTypeFilter_SelectedIndexChanged);

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(650, 10);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Text = "Search:";

            // txtSearch
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(710, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(175, 25);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // dgvCapital
            this.dgvCapital.AllowUserToAddRows = false;
            this.dgvCapital.AllowUserToDeleteRows = false;
            this.dgvCapital.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCapital.BackgroundColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.dgvCapital.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCapital.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCapital.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCapital.ColumnHeadersDefaultCellStyle = GetHeaderStyle();
            this.dgvCapital.ColumnHeadersHeight = 35;
            this.dgvCapital.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCapital.DefaultCellStyle = GetCellStyle();
            this.dgvCapital.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCapital.EnableHeadersVisualStyles = false;
            this.dgvCapital.GridColor = System.Drawing.Color.FromArgb(60, 60, 65);
            this.dgvCapital.Location = new System.Drawing.Point(0, 130);
            this.dgvCapital.MultiSelect = false;
            this.dgvCapital.Name = "dgvCapital";
            this.dgvCapital.ReadOnly = true;
            this.dgvCapital.RowHeadersVisible = false;
            this.dgvCapital.RowTemplate.Height = 35;
            this.dgvCapital.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCapital.Size = new System.Drawing.Size(900, 320);
            this.dgvCapital.TabIndex = 3;
            this.dgvCapital.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCapital_CellClick);

            // pnlFooter
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlFooter.Controls.Add(this.btnAddTransaction);
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 450);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(900, 50);
            this.pnlFooter.TabIndex = 4;

            // btnAddTransaction
            this.btnAddTransaction.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnAddTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddTransaction.FlatAppearance.BorderSize = 0;
            this.btnAddTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTransaction.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddTransaction.ForeColor = System.Drawing.Color.White;
            this.btnAddTransaction.Location = new System.Drawing.Point(745, 10);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(140, 32);
            this.btnAddTransaction.TabIndex = 0;
            this.btnAddTransaction.Text = "Add Transaction";
            this.btnAddTransaction.UseVisualStyleBackColor = false;
            this.btnAddTransaction.Click += new System.EventHandler(this.btnAddTransaction_Click);

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

            // CapitalForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.dgvCapital);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CapitalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Capital - Hospital Management System";
            this.Load += new System.EventHandler(this.CapitalForm_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapital)).EndInit();
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
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblTotalIncome;
        private System.Windows.Forms.Label lblTotalExpense;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbTypeFilter;
        private System.Windows.Forms.DataGridView dgvCapital;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnAddTransaction;
        private System.Windows.Forms.Button btnClose;
    }
}
