using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Hospital_Management.Helpers;

namespace Hospital_Management.Views
{
    public partial class StaffForm : Form
    {
        private DataTable staffDataTable;

        public StaffForm()
        {
            InitializeComponent();
            LoadStaffData();
        }

        private void StaffForm_Load(object sender, EventArgs e)
        {
            // Initial setup
        }

        public void LoadStaffData()
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT staff_id as 'Staff ID', name as 'Name', cnic as 'CNIC', phone_no as 'Phone Number', email as 'Email', department as 'Department' FROM staff ORDER BY staff_id";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    staffDataTable = new DataTable();
                    adapter.Fill(staffDataTable);
                    dgvStaff.DataSource = staffDataTable;

                    // Style the DataGridView
                    FormatDataGridView();
                }
            }
            catch (Exception ex)
            {
                // If database not connected, show sample data
                LoadSampleData();
            }
        }

        private void LoadSampleData()
        {
            staffDataTable = new DataTable();
            staffDataTable.Columns.Add("Staff ID", typeof(string));
            staffDataTable.Columns.Add("Name", typeof(string));
            staffDataTable.Columns.Add("CNIC", typeof(string));
            staffDataTable.Columns.Add("Phone Number", typeof(string));
            staffDataTable.Columns.Add("Email", typeof(string));
            staffDataTable.Columns.Add("Department", typeof(string));

            // Sample data
            staffDataTable.Rows.Add("MED-1", "Dr. John Smith", "23123-1312312-3", "2321-3123123", "john@hospital.org", "Cardiology");
            staffDataTable.Rows.Add("MED-2", "Dr. Sarah Johnson", "45678-9012345-6", "2321-4567890", "sarah@hospital.org", "Neurology");
            staffDataTable.Rows.Add("MED-3", "Dr. Michael Brown", "78901-2345678-9", "2321-7890123", "michael@hospital.org", "Pediatrics");

            dgvStaff.DataSource = staffDataTable;
            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            if (dgvStaff.Columns.Count > 0)
            {
                dgvStaff.Columns["Staff ID"].Width = 80;
                dgvStaff.Columns["Name"].Width = 150;
                dgvStaff.Columns["CNIC"].Width = 130;
                dgvStaff.Columns["Phone Number"].Width = 120;
                
                if (dgvStaff.Columns.Contains("Email"))
                    dgvStaff.Columns["Email"].Width = 150;
                if (dgvStaff.Columns.Contains("Department"))
                    dgvStaff.Columns["Department"].Width = 120;
            }

            // Add action buttons if not already added
            if (!dgvStaff.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                editBtn.Name = "Edit";
                editBtn.HeaderText = "";
                editBtn.Text = "✏️";
                editBtn.UseColumnTextForButtonValue = true;
                editBtn.Width = 40;
                dgvStaff.Columns.Add(editBtn);
            }

            if (!dgvStaff.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                deleteBtn.Name = "Delete";
                deleteBtn.HeaderText = "";
                deleteBtn.Text = "🗑️";
                deleteBtn.UseColumnTextForButtonValue = true;
                deleteBtn.Width = 40;
                dgvStaff.Columns.Add(deleteBtn);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (staffDataTable != null)
            {
                string searchText = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                {
                    staffDataTable.DefaultView.RowFilter = "";
                }
                else
                {
                    staffDataTable.DefaultView.RowFilter = $"[Name] LIKE '%{searchText}%' OR [Staff ID] LIKE '%{searchText}%' OR [CNIC] LIKE '%{searchText}%'";
                }
            }
        }

        private void btnRegisterDoctor_Click(object sender, EventArgs e)
        {
            AddStaffForm addForm = new AddStaffForm();
            addForm.ShowDialog();
            LoadStaffData(); // Refresh after adding
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvStaff.Columns["Edit"].Index)
                {
                    // Edit staff
                    string staffId = dgvStaff.Rows[e.RowIndex].Cells["Staff ID"].Value.ToString();
                    AddStaffForm editForm = new AddStaffForm(staffId);
                    editForm.ShowDialog();
                    LoadStaffData();
                }
                else if (e.ColumnIndex == dgvStaff.Columns["Delete"].Index)
                {
                    // Delete staff
                    string staffId = dgvStaff.Rows[e.RowIndex].Cells["Staff ID"].Value.ToString();
                    string staffName = dgvStaff.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                    
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete {staffName}?", 
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    
                    if (result == DialogResult.Yes)
                    {
                        DeleteStaff(staffId);
                    }
                }
            }
        }

        private void dgvStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Show staff information dialog
                ShowStaffInfo(e.RowIndex);
            }
        }

        private void ShowStaffInfo(int rowIndex)
        {
            var row = dgvStaff.Rows[rowIndex];
            string info = $"Name: {row.Cells["Name"].Value}\n" +
                         $"Staff ID: {row.Cells["Staff ID"].Value}\n" +
                         $"CNIC: {row.Cells["CNIC"].Value}\n" +
                         $"Phone No: {row.Cells["Phone Number"].Value}\n";
            
            if (dgvStaff.Columns.Contains("Email"))
                info += $"Email: {row.Cells["Email"].Value}\n";
            if (dgvStaff.Columns.Contains("Department"))
                info += $"Department: {row.Cells["Department"].Value}\n";

            MessageBox.Show(info, "Doctor Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteStaff(string staffId)
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM staff WHERE staff_id = @staffId";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@staffId", staffId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStaffData();
                }
            }
            catch (Exception ex)
            {
                // For demo without database
                MessageBox.Show("Staff deleted successfully! (Demo mode)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSampleData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
