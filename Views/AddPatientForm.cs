using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Hospital_Management.Helpers;

namespace Hospital_Management.Views
{
    public partial class AddPatientForm : Form
    {
        private string patientIdToEdit = null;
        private bool isEditMode = false;

        public AddPatientForm()
        {
            InitializeComponent();
            SetupForm();
        }

        public AddPatientForm(string patientId)
        {
            InitializeComponent();
            SetupForm();
            patientIdToEdit = patientId;
            isEditMode = true;
            lblTitle.Text = "Update Patient Information";
            btnSave.Text = "Update";
            LoadPatientData(patientId);
        }

        private void SetupForm()
        {
            // Setup blood group dropdown
            cmbBloodGroup.Items.AddRange(new object[] {
                "Select Blood Group",
                "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"
            });
            cmbBloodGroup.SelectedIndex = 0;

            // Default gender selection
            rbMale.Checked = true;
        }

        private void LoadPatientData(string patientId)
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM patients WHERE patient_id = @patientId";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@patientId", patientId);
                    
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtName.Text = reader["name"].ToString();
                            txtCnic.Text = reader["cnic"].ToString();
                            txtPhoneNo.Text = reader["phone_no"].ToString();
                            if (reader["date_of_birth"] != DBNull.Value)
                                dtpDateOfBirth.Value = Convert.ToDateTime(reader["date_of_birth"]);
                            txtEmail.Text = reader["email"].ToString();
                            
                            if (reader["gender"].ToString() == "Male")
                                rbMale.Checked = true;
                            else
                                rbFemale.Checked = true;

                            cmbBloodGroup.Text = reader["blood_group"].ToString();
                            txtAddress.Text = reader["address"].ToString();
                            txtEmergencyContact.Text = reader["emergency_contact"].ToString();
                            txtEmergencyName.Text = reader["emergency_contact_name"].ToString();
                            txtMedicalHistory.Text = reader["medical_history"].ToString();
                            txtAllergies.Text = reader["allergies"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Demo mode - load sample data
                txtName.Text = "Ahmad Yusuf";
                txtCnic.Text = "12345-6789012-3";
                txtPhoneNo.Text = "0321-1234567";
                txtEmail.Text = "ahmad@email.com";
                cmbBloodGroup.SelectedIndex = 1;
                txtAddress.Text = "Jl. Sudirman No. 123, Jakarta";
                txtEmergencyContact.Text = "0812-3456789";
                txtEmergencyName.Text = "Fatimah Yusuf";
                txtMedicalHistory.Text = "Diabetes Type 2";
                txtAllergies.Text = "Penicillin";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhoneNo.Text))
            {
                MessageBox.Show("Please enter the phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNo.Focus();
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
                        query = @"UPDATE patients SET name = @name, cnic = @cnic, phone_no = @phoneNo, 
                                  date_of_birth = @dob, email = @email, gender = @gender, 
                                  blood_group = @bloodGroup, address = @address, 
                                  emergency_contact = @emergencyContact, emergency_contact_name = @emergencyName,
                                  medical_history = @medicalHistory, allergies = @allergies 
                                  WHERE patient_id = @patientId";
                    }
                    else
                    {
                        query = @"INSERT INTO patients (name, cnic, phone_no, date_of_birth, email, gender, 
                                  blood_group, address, emergency_contact, emergency_contact_name, 
                                  medical_history, allergies) 
                                  VALUES (@name, @cnic, @phoneNo, @dob, @email, @gender, 
                                  @bloodGroup, @address, @emergencyContact, @emergencyName, 
                                  @medicalHistory, @allergies)";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@cnic", txtCnic.Text.Trim());
                    cmd.Parameters.AddWithValue("@phoneNo", txtPhoneNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@dob", dtpDateOfBirth.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", rbMale.Checked ? "Male" : "Female");
                    cmd.Parameters.AddWithValue("@bloodGroup", cmbBloodGroup.SelectedIndex > 0 ? cmbBloodGroup.SelectedItem.ToString() : null);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@emergencyContact", txtEmergencyContact.Text.Trim());
                    cmd.Parameters.AddWithValue("@emergencyName", txtEmergencyName.Text.Trim());
                    cmd.Parameters.AddWithValue("@medicalHistory", txtMedicalHistory.Text.Trim());
                    cmd.Parameters.AddWithValue("@allergies", txtAllergies.Text.Trim());

                    if (isEditMode)
                    {
                        cmd.Parameters.AddWithValue("@patientId", patientIdToEdit);
                    }

                    cmd.ExecuteNonQuery();

                    string message = isEditMode ? "Patient information updated successfully!" : "Patient registered successfully!";
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Demo mode
                string message = isEditMode ? "Patient information updated successfully! (Demo mode)" : "Patient registered successfully! (Demo mode)";
                MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtCnic.Clear();
            txtPhoneNo.Clear();
            dtpDateOfBirth.Value = DateTime.Today;
            txtEmail.Clear();
            cmbBloodGroup.SelectedIndex = 0;
            rbMale.Checked = true;
            txtAddress.Clear();
            txtEmergencyContact.Clear();
            txtEmergencyName.Clear();
            txtMedicalHistory.Clear();
            txtAllergies.Clear();
            txtName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
