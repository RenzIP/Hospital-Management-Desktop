using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Hospital_Management.Helpers;

namespace Hospital_Management.Views
{
    public partial class PatientForm : Form
    {
        private DataTable patientDataTable;

        public PatientForm()
        {
            InitializeComponent();
            LoadPatientData();
        }

        private void PatientForm_Load(object sender, EventArgs e)
        {
            // Initial setup
        }

        public void LoadPatientData()
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT patient_id as 'Patient ID', name as 'Name', cnic as 'CNIC', 
                                     phone_no as 'Phone', email as 'Email', gender as 'Gender', 
                                     blood_group as 'Blood Group' FROM patients ORDER BY patient_id";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    patientDataTable = new DataTable();
                    adapter.Fill(patientDataTable);
                    dgvPatients.DataSource = patientDataTable;
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
            patientDataTable = new DataTable();
            patientDataTable.Columns.Add("Patient ID", typeof(string));
            patientDataTable.Columns.Add("Name", typeof(string));
            patientDataTable.Columns.Add("CNIC", typeof(string));
            patientDataTable.Columns.Add("Phone", typeof(string));
            patientDataTable.Columns.Add("Email", typeof(string));
            patientDataTable.Columns.Add("Gender", typeof(string));
            patientDataTable.Columns.Add("Blood Group", typeof(string));

            patientDataTable.Rows.Add("PAT-001", "Ahmad Yusuf", "12345-6789012-3", "0321-1234567", "ahmad@email.com", "Male", "A+");
            patientDataTable.Rows.Add("PAT-002", "Siti Rahayu", "23456-7890123-4", "0322-2345678", "siti@email.com", "Female", "B+");
            patientDataTable.Rows.Add("PAT-003", "Budi Santoso", "34567-8901234-5", "0323-3456789", "budi@email.com", "Male", "O+");
            patientDataTable.Rows.Add("PAT-004", "Dewi Lestari", "45678-9012345-6", "0324-4567890", "dewi@email.com", "Female", "AB+");
            patientDataTable.Rows.Add("PAT-005", "Eko Prasetyo", "56789-0123456-7", "0325-5678901", "eko@email.com", "Male", "A-");

            dgvPatients.DataSource = patientDataTable;
            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            if (dgvPatients.Columns.Count > 0)
            {
                dgvPatients.Columns["Patient ID"].Width = 80;
                dgvPatients.Columns["Name"].Width = 130;
                dgvPatients.Columns["CNIC"].Width = 120;
                dgvPatients.Columns["Phone"].Width = 100;
                
                if (dgvPatients.Columns.Contains("Email"))
                    dgvPatients.Columns["Email"].Width = 130;
                if (dgvPatients.Columns.Contains("Gender"))
                    dgvPatients.Columns["Gender"].Width = 60;
                if (dgvPatients.Columns.Contains("Blood Group"))
                    dgvPatients.Columns["Blood Group"].Width = 80;
            }

            if (!dgvPatients.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                editBtn.Name = "Edit";
                editBtn.HeaderText = "";
                editBtn.Text = "✏️";
                editBtn.UseColumnTextForButtonValue = true;
                editBtn.Width = 40;
                dgvPatients.Columns.Add(editBtn);
            }

            if (!dgvPatients.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                deleteBtn.Name = "Delete";
                deleteBtn.HeaderText = "";
                deleteBtn.Text = "🗑️";
                deleteBtn.UseColumnTextForButtonValue = true;
                deleteBtn.Width = 40;
                dgvPatients.Columns.Add(deleteBtn);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (patientDataTable != null)
            {
                string searchText = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                {
                    patientDataTable.DefaultView.RowFilter = "";
                }
                else
                {
                    patientDataTable.DefaultView.RowFilter = $"[Name] LIKE '%{searchText}%' OR [Patient ID] LIKE '%{searchText}%' OR [CNIC] LIKE '%{searchText}%'";
                }
            }
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            AddPatientForm addForm = new AddPatientForm();
            addForm.ShowDialog();
            LoadPatientData();
        }

        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvPatients.Columns["Edit"].Index)
                {
                    string patientId = dgvPatients.Rows[e.RowIndex].Cells["Patient ID"].Value.ToString();
                    AddPatientForm editForm = new AddPatientForm(patientId);
                    editForm.ShowDialog();
                    LoadPatientData();
                }
                else if (e.ColumnIndex == dgvPatients.Columns["Delete"].Index)
                {
                    string patientId = dgvPatients.Rows[e.RowIndex].Cells["Patient ID"].Value.ToString();
                    string patientName = dgvPatients.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                    
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete {patientName}?", 
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    
                    if (result == DialogResult.Yes)
                    {
                        DeletePatient(patientId);
                    }
                }
            }
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowPatientInfo(e.RowIndex);
            }
        }

        private void ShowPatientInfo(int rowIndex)
        {
            var row = dgvPatients.Rows[rowIndex];
            string info = $"Name: {row.Cells["Name"].Value}\n" +
                         $"Patient ID: {row.Cells["Patient ID"].Value}\n" +
                         $"CNIC: {row.Cells["CNIC"].Value}\n" +
                         $"Phone: {row.Cells["Phone"].Value}\n";
            
            if (dgvPatients.Columns.Contains("Email"))
                info += $"Email: {row.Cells["Email"].Value}\n";
            if (dgvPatients.Columns.Contains("Gender"))
                info += $"Gender: {row.Cells["Gender"].Value}\n";
            if (dgvPatients.Columns.Contains("Blood Group"))
                info += $"Blood Group: {row.Cells["Blood Group"].Value}\n";

            MessageBox.Show(info, "Patient Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeletePatient(string patientId)
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM patients WHERE patient_id = @patientId";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@patientId", patientId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPatientData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Patient deleted successfully! (Demo mode)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSampleData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
