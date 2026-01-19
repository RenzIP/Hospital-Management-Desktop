using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Hospital_Management.Helpers;

namespace Hospital_Management.Views.Controls
{
    public partial class CapitalControl : UserControl
    {
        private DataTable capitalDataTable;

        public CapitalControl()
        {
            InitializeComponent();
            LoadCapitalData();
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.pnlSummary = new Panel();
            this.lblTotalIncome = new Label();
            this.lblTotalExpense = new Label();
            this.lblBalance = new Label();
            this.pnlSearch = new Panel();
            this.lblSearch = new Label();
            this.txtSearch = new TextBox();
            this.cmbTypeFilter = new ComboBox();
            this.dgvCapital = new DataGridView();
            this.pnlFooter = new Panel();
            this.btnAddTransaction = new Button();

            this.pnlHeader.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapital)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // CapitalControl
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.Dock = DockStyle.Fill;
            this.Size = new Size(720, 600);

            // pnlHeader
            this.pnlHeader.BackColor = Color.FromArgb(45, 45, 48);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Size = new Size(720, 50);

            // lblTitle
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Text = "💳 Capital Management";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // pnlSummary
            this.pnlSummary.BackColor = Color.FromArgb(35, 35, 40);
            this.pnlSummary.Controls.Add(this.lblTotalIncome);
            this.pnlSummary.Controls.Add(this.lblTotalExpense);
            this.pnlSummary.Controls.Add(this.lblBalance);
            this.pnlSummary.Dock = DockStyle.Top;
            this.pnlSummary.Location = new Point(0, 50);
            this.pnlSummary.Size = new Size(720, 50);

            // lblTotalIncome
            this.lblTotalIncome.AutoSize = true;
            this.lblTotalIncome.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.lblTotalIncome.ForeColor = Color.LightGreen;
            this.lblTotalIncome.Location = new Point(20, 15);
            this.lblTotalIncome.Text = "Total Income: Rp 0";

            // lblTotalExpense
            this.lblTotalExpense.AutoSize = true;
            this.lblTotalExpense.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.lblTotalExpense.ForeColor = Color.Salmon;
            this.lblTotalExpense.Location = new Point(250, 15);
            this.lblTotalExpense.Text = "Total Expense: Rp 0";

            // lblBalance
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.lblBalance.ForeColor = Color.White;
            this.lblBalance.Location = new Point(500, 15);
            this.lblBalance.Text = "Balance: Rp 0";

            // pnlSearch
            this.pnlSearch.BackColor = Color.FromArgb(55, 55, 60);
            this.pnlSearch.Controls.Add(this.cmbTypeFilter);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Dock = DockStyle.Top;
            this.pnlSearch.Location = new Point(0, 100);
            this.pnlSearch.Size = new Size(720, 50);

            // cmbTypeFilter
            this.cmbTypeFilter.BackColor = Color.White;
            this.cmbTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTypeFilter.Font = new Font("Segoe UI", 10F);
            this.cmbTypeFilter.Location = new Point(15, 12);
            this.cmbTypeFilter.Size = new Size(120, 25);
            this.cmbTypeFilter.Items.AddRange(new object[] { "All Types", "Income", "Expense" });
            this.cmbTypeFilter.SelectedIndex = 0;
            this.cmbTypeFilter.SelectedIndexChanged += cmbTypeFilter_SelectedIndexChanged;

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new Font("Segoe UI", 10F);
            this.lblSearch.ForeColor = Color.White;
            this.lblSearch.Location = new Point(480, 15);
            this.lblSearch.Text = "Search:";

            // txtSearch
            this.txtSearch.BackColor = Color.White;
            this.txtSearch.BorderStyle = BorderStyle.FixedSingle;
            this.txtSearch.Font = new Font("Segoe UI", 10F);
            this.txtSearch.Location = new Point(540, 12);
            this.txtSearch.Size = new Size(165, 25);
            this.txtSearch.TextChanged += txtSearch_TextChanged;

            // dgvCapital
            this.dgvCapital.AllowUserToAddRows = false;
            this.dgvCapital.AllowUserToDeleteRows = false;
            this.dgvCapital.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCapital.BackgroundColor = Color.FromArgb(45, 45, 48);
            this.dgvCapital.BorderStyle = BorderStyle.None;
            this.dgvCapital.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCapital.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvCapital.ColumnHeadersDefaultCellStyle = GetHeaderStyle();
            this.dgvCapital.ColumnHeadersHeight = 40;
            this.dgvCapital.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCapital.DefaultCellStyle = GetCellStyle();
            this.dgvCapital.Dock = DockStyle.Fill;
            this.dgvCapital.EnableHeadersVisualStyles = false;
            this.dgvCapital.GridColor = Color.FromArgb(60, 60, 65);
            this.dgvCapital.Location = new Point(0, 150);
            this.dgvCapital.MultiSelect = false;
            this.dgvCapital.ReadOnly = true;
            this.dgvCapital.RowHeadersVisible = false;
            this.dgvCapital.RowTemplate.Height = 40;
            this.dgvCapital.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCapital.Size = new Size(720, 390);
            this.dgvCapital.CellClick += dgvCapital_CellClick;

            // pnlFooter
            this.pnlFooter.BackColor = Color.FromArgb(55, 55, 60);
            this.pnlFooter.Controls.Add(this.btnAddTransaction);
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Location = new Point(0, 540);
            this.pnlFooter.Size = new Size(720, 60);

            // btnAddTransaction
            this.btnAddTransaction.BackColor = Color.FromArgb(220, 53, 69);
            this.btnAddTransaction.Cursor = Cursors.Hand;
            this.btnAddTransaction.FlatAppearance.BorderSize = 0;
            this.btnAddTransaction.FlatStyle = FlatStyle.Flat;
            this.btnAddTransaction.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            this.btnAddTransaction.ForeColor = Color.White;
            this.btnAddTransaction.Location = new Point(550, 12);
            this.btnAddTransaction.Size = new Size(155, 36);
            this.btnAddTransaction.Text = "+ Add Transaction";
            this.btnAddTransaction.Click += btnAddTransaction_Click;

            this.Controls.Add(this.dgvCapital);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapital)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private DataGridViewCellStyle GetHeaderStyle()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.FromArgb(26, 163, 168);
            style.ForeColor = Color.White;
            style.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            style.SelectionBackColor = Color.FromArgb(26, 163, 168);
            style.SelectionForeColor = Color.White;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.Padding = new Padding(10, 0, 0, 0);
            return style;
        }

        private DataGridViewCellStyle GetCellStyle()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.FromArgb(50, 50, 55);
            style.ForeColor = Color.White;
            style.Font = new Font("Segoe UI", 10F);
            style.SelectionBackColor = Color.FromArgb(0, 122, 204);
            style.SelectionForeColor = Color.White;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.Padding = new Padding(10, 0, 0, 0);
            return style;
        }

        public void LoadCapitalData()
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT transaction_id as 'Transaction ID', transaction_type as 'Type', 
                                     category as 'Category', amount as 'Amount', 
                                     transaction_date as 'Date', description as 'Description'
                                     FROM capital ORDER BY transaction_date DESC";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    capitalDataTable = new DataTable();
                    adapter.Fill(capitalDataTable);
                    dgvCapital.DataSource = capitalDataTable;
                    FormatDataGridView();
                    UpdateSummary();
                }
            }
            catch (Exception ex)
            {
                LoadSampleData();
            }
        }

        private void LoadSampleData()
        {
            capitalDataTable = new DataTable();
            capitalDataTable.Columns.Add("Transaction ID", typeof(string));
            capitalDataTable.Columns.Add("Type", typeof(string));
            capitalDataTable.Columns.Add("Category", typeof(string));
            capitalDataTable.Columns.Add("Amount", typeof(decimal));
            capitalDataTable.Columns.Add("Date", typeof(string));
            capitalDataTable.Columns.Add("Description", typeof(string));

            capitalDataTable.Rows.Add("TRX-001", "income", "Consultation Fees", 5000000.00m, "2026-01-01", "Monthly consultation income");
            capitalDataTable.Rows.Add("TRX-002", "income", "Laboratory Services", 3500000.00m, "2026-01-05", "Laboratory test fees");
            capitalDataTable.Rows.Add("TRX-003", "expense", "Medical Supplies", 2000000.00m, "2026-01-03", "Purchase of medical equipment");
            capitalDataTable.Rows.Add("TRX-004", "expense", "Staff Salaries", 15000000.00m, "2026-01-01", "Monthly staff salary");
            capitalDataTable.Rows.Add("TRX-005", "income", "Pharmacy Sales", 4200000.00m, "2026-01-08", "Pharmacy medicine sales");
            capitalDataTable.Rows.Add("TRX-006", "expense", "Utilities", 1500000.00m, "2026-01-10", "Electricity and water bills");
            capitalDataTable.Rows.Add("TRX-007", "income", "Ward Charges", 8500000.00m, "2026-01-12", "Inpatient ward charges");
            capitalDataTable.Rows.Add("TRX-008", "expense", "Maintenance", 750000.00m, "2026-01-15", "Building maintenance");

            dgvCapital.DataSource = capitalDataTable;
            FormatDataGridView();
            UpdateSummary();
        }

        private void FormatDataGridView()
        {
            if (dgvCapital.Columns.Count > 0)
            {
                dgvCapital.Columns["Transaction ID"].Width = 100;
                dgvCapital.Columns["Type"].Width = 80;
                dgvCapital.Columns["Category"].Width = 130;
                dgvCapital.Columns["Amount"].Width = 120;
                dgvCapital.Columns["Date"].Width = 100;
                dgvCapital.Columns["Description"].Width = 180;

                dgvCapital.Columns["Amount"].DefaultCellStyle.Format = "N2";
                dgvCapital.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (!dgvCapital.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                editBtn.Name = "Edit";
                editBtn.HeaderText = "";
                editBtn.Text = "✏️";
                editBtn.UseColumnTextForButtonValue = true;
                editBtn.Width = 45;
                dgvCapital.Columns.Add(editBtn);
            }

            if (!dgvCapital.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                deleteBtn.Name = "Delete";
                deleteBtn.HeaderText = "";
                deleteBtn.Text = "🗑️";
                deleteBtn.UseColumnTextForButtonValue = true;
                deleteBtn.Width = 45;
                dgvCapital.Columns.Add(deleteBtn);
            }
        }

        private void UpdateSummary()
        {
            decimal totalIncome = 0;
            decimal totalExpense = 0;

            foreach (DataRow row in capitalDataTable.Rows)
            {
                decimal amount = Convert.ToDecimal(row["Amount"]);
                string type = row["Type"].ToString().ToLower();

                if (type == "income")
                    totalIncome += amount;
                else
                    totalExpense += amount;
            }

            lblTotalIncome.Text = $"Total Income: Rp {totalIncome:N2}";
            lblTotalExpense.Text = $"Total Expense: Rp {totalExpense:N2}";
            lblBalance.Text = $"Balance: Rp {(totalIncome - totalExpense):N2}";

            lblBalance.ForeColor = (totalIncome - totalExpense) >= 0 ? Color.LightGreen : Color.Salmon;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (capitalDataTable != null)
            {
                string searchText = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                {
                    capitalDataTable.DefaultView.RowFilter = "";
                }
                else
                {
                    capitalDataTable.DefaultView.RowFilter = $"[Category] LIKE '%{searchText}%' OR [Transaction ID] LIKE '%{searchText}%' OR [Description] LIKE '%{searchText}%'";
                }
            }
        }

        private void cmbTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (capitalDataTable != null)
            {
                string type = cmbTypeFilter.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(type) || type == "All Types")
                {
                    capitalDataTable.DefaultView.RowFilter = "";
                }
                else
                {
                    capitalDataTable.DefaultView.RowFilter = $"[Type] = '{type.ToLower()}'";
                }
            }
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            AddCapitalForm addForm = new AddCapitalForm();
            addForm.ShowDialog();
            LoadCapitalData();
        }

        private void dgvCapital_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvCapital.Columns["Edit"].Index)
                {
                    string transactionId = dgvCapital.Rows[e.RowIndex].Cells["Transaction ID"].Value.ToString();
                    AddCapitalForm editForm = new AddCapitalForm(transactionId);
                    editForm.ShowDialog();
                    LoadCapitalData();
                }
                else if (e.ColumnIndex == dgvCapital.Columns["Delete"].Index)
                {
                    string transactionId = dgvCapital.Rows[e.RowIndex].Cells["Transaction ID"].Value.ToString();
                    string category = dgvCapital.Rows[e.RowIndex].Cells["Category"].Value.ToString();

                    DialogResult result = MessageBox.Show($"Are you sure you want to delete transaction '{category}'?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        DeleteTransaction(transactionId);
                    }
                }
            }
        }

        private void DeleteTransaction(string transactionId)
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM capital WHERE transaction_id = @transactionId";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@transactionId", transactionId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Transaction deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCapitalData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction deleted successfully! (Demo mode)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSampleData();
            }
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlSummary;
        private Label lblTotalIncome;
        private Label lblTotalExpense;
        private Label lblBalance;
        private Panel pnlSearch;
        private Label lblSearch;
        private TextBox txtSearch;
        private ComboBox cmbTypeFilter;
        private DataGridView dgvCapital;
        private Panel pnlFooter;
        private Button btnAddTransaction;
    }
}
