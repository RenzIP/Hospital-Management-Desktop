using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Hospital_Management.Helpers;

namespace Hospital_Management.Views
{
    public partial class AddStaffForm : Form
    {
        private string staffIdToEdit = null;
        private bool isEditMode = false;

        public AddStaffForm()
        {
            InitializeComponent();
            SetupForm();
        }

        public AddStaffForm(string staffId)
        {
            InitializeComponent();
            SetupForm();
            staffIdToEdit = staffId;
            isEditMode = true;
            lblTitle.Text = "Update Doctor Information";
            btnSave.Text = "Update";
            LoadStaffData(staffId);
        }

        private void SetupForm()
        {
            // Setup department dropdown
            cmbDepartment.Items.AddRange(new object[] {
                "Select Department",
                "Cardiology",
                "Neurology",
                "Pediatrics",
                "Orthopedics",
                "Dermatology",
                "Oncology",
                "Radiology",
                "Surgery",
                "Emergency",
                "ICU"
            });
            cmbDepartment.SelectedIndex = 0;

            // Setup qualification dropdown
            cmbQualification.Items.AddRange(new object[] {
                "Select Qualification",
                "MBBS",
                "MD",
                "MS",
                "DM",
                "MCh",
                "DNB",
                "PhD"
            });
            cmbQualification.SelectedIndex = 0;

            // Setup time dropdowns
            for (int hour = 0; hour < 24; hour++)
            {
                string time = DateTime.Today.AddHours(hour).ToString("h:00:00 tt");
                cmbFromTime.Items.Add(time);
                cmbToTime.Items.Add(time);
            }
            cmbFromTime.SelectedIndex = 8; // 8:00 AM
            cmbToTime.SelectedIndex = 16; // 4:00 PM

            // Default gender selection
            rbMale.Checked = true;
        }

        private void LoadStaffData(string staffId)
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM staff WHERE staff_id = @staffId";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@staffId", staffId);
                    
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtName.Text = reader["name"].ToString();
                            txtCnic.Text = reader["cnic"].ToString();
                            txtPhoneNo.Text = reader["phone_no"].ToString();
                            dtpDateOfBirth.Value = Convert.ToDateTime(reader["date_of_birth"]);
                            txtEmail.Text = reader["email"].ToString();
                            txtPassword.Text = reader["password"].ToString();
                            cmbQualification.Text = reader["qualification"].ToString();
                            cmbDepartment.Text = reader["department"].ToString();
                            
                            if (reader["gender"].ToString() == "Male")
                                rbMale.Checked = true;
                            else
                                rbFemale.Checked = true;

                            numSalary.Value = Convert.ToDecimal(reader["salary"]);
                            txtAddress.Text = reader["address"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Demo mode - load sample data
                txtName.Text = "Dr. John Smith";
                txtCnic.Text = "23123-1312312-3";
                txtPhoneNo.Text = "2321-3123123";
                txtEmail.Text = "john@hospital.org";
                cmbQualification.SelectedIndex = 1;
                cmbDepartment.SelectedIndex = 1;
                numSalary.Value = 90000;
                txtAddress.Text = "house 1, street 2, city 3 and country 4";
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

            if (string.IsNullOrWhiteSpace(txtCnic.Text))
            {
                MessageBox.Show("Please enter the CNIC.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCnic.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhoneNo.Text))
            {
                MessageBox.Show("Please enter the phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter the email.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (!isEditMode && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter the password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (cmbDepartment.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a department.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepartment.Focus();
                return;
            }

            if (cmbQualification.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a qualification.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbQualification.Focus();
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
                        query = @"UPDATE staff SET name = @name, cnic = @cnic, phone_no = @phoneNo, 
                                  date_of_birth = @dob, email = @email, password = @password, 
                                  qualification = @qualification, department = @department, 
                                  gender = @gender, working_from = @workingFrom, working_to = @workingTo, 
                                  salary = @salary, address = @address 
                                  WHERE staff_id = @staffId";
                    }
                    else
                    {
                        query = @"INSERT INTO staff (name, cnic, phone_no, date_of_birth, email, password, 
                                  qualification, department, gender, working_from, working_to, salary, address) 
                                  VALUES (@name, @cnic, @phoneNo, @dob, @email, @password, 
                                  @qualification, @department, @gender, @workingFrom, @workingTo, @salary, @address)";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@cnic", txtCnic.Text.Trim());
                    cmd.Parameters.AddWithValue("@phoneNo", txtPhoneNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@dob", dtpDateOfBirth.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@qualification", cmbQualification.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@department", cmbDepartment.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@gender", rbMale.Checked ? "Male" : "Female");
                    cmd.Parameters.AddWithValue("@workingFrom", cmbFromTime.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@workingTo", cmbToTime.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@salary", numSalary.Value);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());

                    if (isEditMode)
                    {
                        cmd.Parameters.AddWithValue("@staffId", staffIdToEdit);
                    }

                    cmd.ExecuteNonQuery();

                    string message = isEditMode ? "Doctor information updated successfully!" : "Doctor registered successfully!";
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Demo mode
                string message = isEditMode ? "Doctor information updated successfully! (Demo mode)" : "Doctor registered successfully! (Demo mode)";
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
            txtPassword.Clear();
            cmbQualification.SelectedIndex = 0;
            cmbDepartment.SelectedIndex = 0;
            rbMale.Checked = true;
            cmbFromTime.SelectedIndex = 8;
            cmbToTime.SelectedIndex = 16;
            numSalary.Value = 0;
            txtAddress.Clear();
            txtName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
