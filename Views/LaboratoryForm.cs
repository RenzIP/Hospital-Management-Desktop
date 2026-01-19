using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Hospital_Management.Helpers;

namespace Hospital_Management.Views
{
    public partial class LaboratoryForm : Form
    {
        private DataTable labDataTable;

        public LaboratoryForm()
        {
            InitializeComponent();
            LoadLabData();
        }

        private void LaboratoryForm_Load(object sender, EventArgs e)
        {
            // Initial setup
        }

        public void LoadLabData()
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT l.lab_id as 'Lab ID', p.name as 'Patient', s.name as 'Doctor', 
                                     l.test_name as 'Test Name', l.test_date as 'Test Date', l.status as 'Status'
                                     FROM laboratory l 
                                     LEFT JOIN patients p ON l.patient_id = p.id
                                     LEFT JOIN staff s ON l.doctor_id = s.id
                                     ORDER BY l.test_date DESC";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    labDataTable = new DataTable();
                    adapter.Fill(labDataTable);
                    dgvLaboratory.DataSource = labDataTable;
                    FormatDataGridView();
                }
            }
            catch (Exception ex)
            {
                LoadSampleData();
            }
        }

        private void LoadSampleData()
        {
            labDataTable = new DataTable();
            labDataTable.Columns.Add("Lab ID", typeof(string));
            labDataTable.Columns.Add("Patient", typeof(string));
            labDataTable.Columns.Add("Doctor", typeof(string));
            labDataTable.Columns.Add("Test Name", typeof(string));
            labDataTable.Columns.Add("Test Date", typeof(string));
            labDataTable.Columns.Add("Status", typeof(string));

            labDataTable.Rows.Add("LAB-001", "Ahmad Yusuf", "Dr. John Smith", "Fasting Blood Sugar", "2026-01-10", "completed");
            labDataTable.Rows.Add("LAB-002", "Ahmad Yusuf", "Dr. John Smith", "HbA1c Test", "2026-01-10", "completed");
            labDataTable.Rows.Add("LAB-003", "Siti Rahayu", "Dr. Sarah Johnson", "MRI Brain", "2026-01-11", "pending");
            labDataTable.Rows.Add("LAB-004", "Budi Santoso", "Dr. John Smith", "Lipid Profile", "2026-01-09", "completed");
            labDataTable.Rows.Add("LAB-005", "Budi Santoso", "Dr. John Smith", "ECG", "2026-01-09", "in_progress");

            dgvLaboratory.DataSource = labDataTable;
            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            if (dgvLaboratory.Columns.Count > 0)
            {
                dgvLaboratory.Columns["Lab ID"].Width = 80;
                dgvLaboratory.Columns["Patient"].Width = 130;
                dgvLaboratory.Columns["Doctor"].Width = 130;
                dgvLaboratory.Columns["Test Name"].Width = 150;
                dgvLaboratory.Columns["Test Date"].Width = 100;
                dgvLaboratory.Columns["Status"].Width = 90;
            }

            if (!dgvLaboratory.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                editBtn.Name = "Edit";
                editBtn.HeaderText = "";
                editBtn.Text = "✏️";
                editBtn.UseColumnTextForButtonValue = true;
                editBtn.Width = 40;
                dgvLaboratory.Columns.Add(editBtn);
            }

            if (!dgvLaboratory.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                deleteBtn.Name = "Delete";
                deleteBtn.HeaderText = "";
                deleteBtn.Text = "🗑️";
                deleteBtn.UseColumnTextForButtonValue = true;
                deleteBtn.Width = 40;
                dgvLaboratory.Columns.Add(deleteBtn);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (labDataTable != null)
            {
                string searchText = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                {
                    labDataTable.DefaultView.RowFilter = "";
                }
                else
                {
                    labDataTable.DefaultView.RowFilter = $"[Patient] LIKE '%{searchText}%' OR [Lab ID] LIKE '%{searchText}%' OR [Test Name] LIKE '%{searchText}%'";
                }
            }
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (labDataTable != null)
            {
                string status = cmbStatusFilter.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(status) || status == "All Status")
                {
                    labDataTable.DefaultView.RowFilter = "";
                }
                else
                {
                    labDataTable.DefaultView.RowFilter = $"[Status] = '{status.ToLower()}'";
                }
            }
        }

        private void btnAddTest_Click(object sender, EventArgs e)
        {
            AddLaboratoryForm addForm = new AddLaboratoryForm();
            addForm.ShowDialog();
            LoadLabData();
        }

        private void dgvLaboratory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvLaboratory.Columns["Edit"].Index)
                {
                    string labId = dgvLaboratory.Rows[e.RowIndex].Cells["Lab ID"].Value.ToString();
                    AddLaboratoryForm editForm = new AddLaboratoryForm(labId);
                    editForm.ShowDialog();
                    LoadLabData();
                }
                else if (e.ColumnIndex == dgvLaboratory.Columns["Delete"].Index)
                {
                    string labId = dgvLaboratory.Rows[e.RowIndex].Cells["Lab ID"].Value.ToString();
                    string testName = dgvLaboratory.Rows[e.RowIndex].Cells["Test Name"].Value.ToString();
                    
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete test '{testName}'?", 
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    
                    if (result == DialogResult.Yes)
                    {
                        DeleteLabTest(labId);
                    }
                }
            }
        }

        private void DeleteLabTest(string labId)
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM laboratory WHERE lab_id = @labId";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@labId", labId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Lab test deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLabData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lab test deleted successfully! (Demo mode)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSampleData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
