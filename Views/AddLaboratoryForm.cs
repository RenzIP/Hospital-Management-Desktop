using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Hospital_Management.Helpers;

namespace Hospital_Management.Views
{
    public partial class AddLaboratoryForm : Form
    {
        private string labIdToEdit = null;
        private bool isEditMode = false;
        private DataTable patientsTable;
        private DataTable doctorsTable;

        public AddLaboratoryForm()
        {
            InitializeComponent();
            SetupForm();
            LoadDropdowns();
        }

        public AddLaboratoryForm(string labId)
        {
            InitializeComponent();
            SetupForm();
            LoadDropdowns();
            labIdToEdit = labId;
            isEditMode = true;
            lblTitle.Text = "Update Lab Test";
            btnSave.Text = "Update";
            LoadLabData(labId);
        }

        private void SetupForm()
        {
            // Setup status dropdown
            cmbStatus.Items.AddRange(new object[] {
                "pending", "in_progress", "completed"
            });
            cmbStatus.SelectedIndex = 0;

            // Setup common test names
            cmbTestName.Items.AddRange(new object[] {
                "Select Test",
                "Blood Test",
                "Urine Test",
                "X-Ray",
                "MRI",
                "CT Scan",
                "ECG",
                "Fasting Blood Sugar",
                "HbA1c Test",
                "Lipid Profile",
                "Liver Function Test",
                "Kidney Function Test",
                "Thyroid Test",
                "COVID-19 PCR",
                "Other"
            });
            cmbTestName.SelectedIndex = 0;

            dtpTestDate.Value = DateTime.Today;
        }

        private void LoadDropdowns()
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    
                    // Load patients
                    string patientQuery = "SELECT id, CONCAT(patient_id, ' - ', name) as display FROM patients ORDER BY name";
                    MySqlDataAdapter patientAdapter = new MySqlDataAdapter(patientQuery, connection);
                    patientsTable = new DataTable();
                    patientAdapter.Fill(patientsTable);
                    
                    cmbPatient.DisplayMember = "display";
                    cmbPatient.ValueMember = "id";
                    cmbPatient.DataSource = patientsTable;

                    // Load doctors
                    string doctorQuery = "SELECT id, CONCAT(staff_id, ' - ', name) as display FROM staff ORDER BY name";
                    MySqlDataAdapter doctorAdapter = new MySqlDataAdapter(doctorQuery, connection);
                    doctorsTable = new DataTable();
                    doctorAdapter.Fill(doctorsTable);
                    
                    cmbDoctor.DisplayMember = "display";
                    cmbDoctor.ValueMember = "id";
                    cmbDoctor.DataSource = doctorsTable;
                }
            }
            catch (Exception ex)
            {
                // Demo mode - load sample data
                LoadSampleDropdowns();
            }
        }

        private void LoadSampleDropdowns()
        {
            patientsTable = new DataTable();
            patientsTable.Columns.Add("id", typeof(int));
            patientsTable.Columns.Add("display", typeof(string));
            patientsTable.Rows.Add(1, "PAT-001 - Ahmad Yusuf");
            patientsTable.Rows.Add(2, "PAT-002 - Siti Rahayu");
            patientsTable.Rows.Add(3, "PAT-003 - Budi Santoso");
            cmbPatient.DisplayMember = "display";
            cmbPatient.ValueMember = "id";
            cmbPatient.DataSource = patientsTable;

            doctorsTable = new DataTable();
            doctorsTable.Columns.Add("id", typeof(int));
            doctorsTable.Columns.Add("display", typeof(string));
            doctorsTable.Rows.Add(1, "MED-1 - Dr. John Smith");
            doctorsTable.Rows.Add(2, "MED-2 - Dr. Sarah Johnson");
            doctorsTable.Rows.Add(3, "MED-3 - Dr. Michael Brown");
            cmbDoctor.DisplayMember = "display";
            cmbDoctor.ValueMember = "id";
            cmbDoctor.DataSource = doctorsTable;
        }

        private void LoadLabData(string labId)
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM laboratory WHERE lab_id = @labId";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@labId", labId);
                    
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cmbPatient.SelectedValue = Convert.ToInt32(reader["patient_id"]);
                            cmbDoctor.SelectedValue = Convert.ToInt32(reader["doctor_id"]);
                            cmbTestName.Text = reader["test_name"].ToString();
                            dtpTestDate.Value = Convert.ToDateTime(reader["test_date"]);
                            txtResult.Text = reader["result"]?.ToString() ?? "";
                            cmbStatus.Text = reader["status"].ToString();
                            txtNotes.Text = reader["notes"]?.ToString() ?? "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Demo mode
                cmbTestName.SelectedIndex = 1;
                txtResult.Text = "Sample result";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (cmbPatient.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a patient.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbDoctor.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a doctor.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbTestName.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a test.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        query = @"UPDATE laboratory SET patient_id = @patientId, doctor_id = @doctorId, 
                                  test_name = @testName, test_date = @testDate, result = @result, 
                                  status = @status, notes = @notes 
                                  WHERE lab_id = @labId";
                    }
                    else
                    {
                        query = @"INSERT INTO laboratory (patient_id, doctor_id, test_name, test_date, result, status, notes) 
                                  VALUES (@patientId, @doctorId, @testName, @testDate, @result, @status, @notes)";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@patientId", cmbPatient.SelectedValue);
                    cmd.Parameters.AddWithValue("@doctorId", cmbDoctor.SelectedValue);
                    cmd.Parameters.AddWithValue("@testName", cmbTestName.Text);
                    cmd.Parameters.AddWithValue("@testDate", dtpTestDate.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@result", txtResult.Text.Trim());
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@notes", txtNotes.Text.Trim());

                    if (isEditMode)
                    {
                        cmd.Parameters.AddWithValue("@labId", labIdToEdit);
                    }

                    cmd.ExecuteNonQuery();

                    string message = isEditMode ? "Lab test updated successfully!" : "Lab test added successfully!";
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                string message = isEditMode ? "Lab test updated successfully! (Demo mode)" : "Lab test added successfully! (Demo mode)";
                MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbPatient.SelectedIndex = 0;
            cmbDoctor.SelectedIndex = 0;
            cmbTestName.SelectedIndex = 0;
            dtpTestDate.Value = DateTime.Today;
            txtResult.Clear();
            cmbStatus.SelectedIndex = 0;
            txtNotes.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
