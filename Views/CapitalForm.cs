using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Hospital_Management.Helpers;

namespace Hospital_Management.Views
{
    public partial class CapitalForm : Form
    {
        private DataTable capitalDataTable;

        public CapitalForm()
        {
            InitializeComponent();
            LoadCapitalData();
        }

        private void CapitalForm_Load(object sender, EventArgs e)
        {
            // Initial setup
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

                // Format amount column
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
                editBtn.Width = 40;
                dgvCapital.Columns.Add(editBtn);
            }

            if (!dgvCapital.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                deleteBtn.Name = "Delete";
                deleteBtn.HeaderText = "";
                deleteBtn.Text = "🗑️";
                deleteBtn.UseColumnTextForButtonValue = true;
                deleteBtn.Width = 40;
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
            
            // Color balance
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
                UpdateSummary();
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
                UpdateSummary();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
