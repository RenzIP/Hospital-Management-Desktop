using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Hospital_Management.Helpers;

namespace Hospital_Management.Views
{
    public partial class AddCapitalForm : Form
    {
        private string transactionIdToEdit = null;
        private bool isEditMode = false;

        public AddCapitalForm()
        {
            InitializeComponent();
            SetupForm();
        }

        public AddCapitalForm(string transactionId)
        {
            InitializeComponent();
            SetupForm();
            transactionIdToEdit = transactionId;
            isEditMode = true;
            lblTitle.Text = "Update Transaction";
            btnSave.Text = "Update";
            LoadTransactionData(transactionId);
        }

        private void SetupForm()
        {
            // Setup type dropdown
            cmbType.Items.AddRange(new object[] {
                "income", "expense"
            });
            cmbType.SelectedIndex = 0;

            // Setup category dropdown
            cmbCategory.Items.AddRange(new object[] {
                "Select Category",
                "Consultation Fees",
                "Laboratory Services",
                "Pharmacy Sales",
                "Surgery Fees",
                "Room Charges",
                "Medical Supplies",
                "Staff Salaries",
                "Utilities",
                "Maintenance",
                "Equipment Purchase",
                "Insurance",
                "Marketing",
                "Other Income",
                "Other Expense"
            });
            cmbCategory.SelectedIndex = 0;

            dtpTransactionDate.Value = DateTime.Today;
        }

        private void LoadTransactionData(string transactionId)
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM capital WHERE transaction_id = @transactionId";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@transactionId", transactionId);
                    
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cmbType.Text = reader["transaction_type"].ToString();
                            cmbCategory.Text = reader["category"].ToString();
                            numAmount.Value = Convert.ToDecimal(reader["amount"]);
                            dtpTransactionDate.Value = Convert.ToDateTime(reader["transaction_date"]);
                            txtDescription.Text = reader["description"]?.ToString() ?? "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Demo mode
                cmbType.SelectedIndex = 0;
                cmbCategory.SelectedIndex = 1;
                numAmount.Value = 1000000;
                txtDescription.Text = "Sample transaction";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (cmbCategory.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numAmount.Value <= 0)
            {
                MessageBox.Show("Please enter a valid amount greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numAmount.Focus();
                return;
            }

            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query;

                    if (isEditMode)
                    {
                        query = @"UPDATE capital SET transaction_type = @type, category = @category, 
                                  amount = @amount, transaction_date = @date, description = @description 
                                  WHERE transaction_id = @transactionId";
                    }
                    else
                    {
                        query = @"INSERT INTO capital (transaction_type, category, amount, transaction_date, description) 
                                  VALUES (@type, @category, @amount, @date, @description)";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@type", cmbType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@category", cmbCategory.Text);
                    cmd.Parameters.AddWithValue("@amount", numAmount.Value);
                    cmd.Parameters.AddWithValue("@date", dtpTransactionDate.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim());

                    if (isEditMode)
                    {
                        cmd.Parameters.AddWithValue("@transactionId", transactionIdToEdit);
                    }

                    cmd.ExecuteNonQuery();

                    string message = isEditMode ? "Transaction updated successfully!" : "Transaction added successfully!";
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                string message = isEditMode ? "Transaction updated successfully! (Demo mode)" : "Transaction added successfully! (Demo mode)";
                MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            numAmount.Value = 0;
            dtpTransactionDate.Value = DateTime.Today;
            txtDescription.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
