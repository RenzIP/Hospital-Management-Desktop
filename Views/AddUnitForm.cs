using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Hospital_Management.Helpers;

namespace Hospital_Management.Views
{
    public partial class AddUnitForm : Form
    {
        private string unitIdToEdit = null;
        private bool isEditMode = false;

        public AddUnitForm()
        {
            InitializeComponent();
            SetupForm();
        }

        public AddUnitForm(string unitId)
        {
            InitializeComponent();
            SetupForm();
            unitIdToEdit = unitId;
            isEditMode = true;
            lblTitle.Text = "Update Unit Information";
            btnSave.Text = "Update";
            LoadUnitData(unitId);
        }

        private void SetupForm()
        {
            // Setup type dropdown
            cmbType.Items.AddRange(new object[] {
                "Select Type",
                "ICU",
                "General",
                "Emergency",
                "Pediatric",
                "Maternity",
                "Surgery",
                "Outpatient",
                "Laboratory",
                "Radiology",
                "Pharmacy"
            });
            cmbType.SelectedIndex = 0;

            // Setup floor dropdown
            cmbFloor.Items.AddRange(new object[] {
                "Select Floor",
                "Basement",
                "Ground Floor",
                "1st Floor",
                "2nd Floor",
                "3rd Floor",
                "4th Floor",
                "5th Floor"
            });
            cmbFloor.SelectedIndex = 0;

            // Setup status dropdown
            cmbStatus.Items.AddRange(new object[] {
                "active",
                "inactive",
                "maintenance"
            });
            cmbStatus.SelectedIndex = 0;
        }

        private void LoadUnitData(string unitId)
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM units WHERE unit_id = @unitId";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@unitId", unitId);
                    
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtUnitName.Text = reader["unit_name"].ToString();
                            cmbType.Text = reader["unit_type"].ToString();
                            cmbFloor.Text = reader["floor"].ToString();
                            numCapacity.Value = Convert.ToDecimal(reader["capacity"]);
                            cmbStatus.Text = reader["status"].ToString();
                            txtDescription.Text = reader["description"]?.ToString() ?? "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Demo mode
                txtUnitName.Text = "ICU Ward A";
                cmbType.SelectedIndex = 1;
                cmbFloor.SelectedIndex = 3;
                numCapacity.Value = 10;
                txtDescription.Text = "Sample unit description";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtUnitName.Text))
            {
                MessageBox.Show("Please enter the unit name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnitName.Focus();
                return;
            }

            if (cmbType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a unit type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbFloor.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a floor.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numCapacity.Value <= 0)
            {
                MessageBox.Show("Please enter a valid capacity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCapacity.Focus();
                return;
            }

            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query;
                    MySqlCommand cmd;

                    if (isEditMode)
                    {
                        query = @"UPDATE units SET unit_name = @unitName, unit_type = @unitType, 
                                  floor_number = @floor, capacity = @capacity, is_active = @active 
                                  WHERE unit_id = @unitId";
                        cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@unitId", unitIdToEdit);
                    }
                    else
                    {
                        string newUnitId = GenerateUnitId(connection);
                        query = @"INSERT INTO units (unit_id, unit_name, unit_type, floor_number, capacity, is_active) 
                                  VALUES (@unitId, @unitName, @unitType, @floor, @capacity, @active)";
                        cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@unitId", newUnitId);
                    }

                    cmd.Parameters.AddWithValue("@unitName", txtUnitName.Text.Trim());
                    cmd.Parameters.AddWithValue("@unitType", cmbType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@floor", cmbFloor.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@capacity", (int)numCapacity.Value);
                    cmd.Parameters.AddWithValue("@active", cmbStatus.SelectedItem.ToString() == "active" ? 1 : 0);

                    cmd.ExecuteNonQuery();

                    string message = isEditMode ? "Unit information updated successfully!" : "Unit added successfully!";
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUnitName.Clear();
            cmbType.SelectedIndex = 0;
            cmbFloor.SelectedIndex = 0;
            numCapacity.Value = 0;
            cmbStatus.SelectedIndex = 0;
            txtDescription.Clear();
            txtUnitName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GenerateUnitId(MySqlConnection connection)
        {
            try
            {
                string query = "SELECT MAX(CAST(SUBSTRING(unit_id, 6) AS UNSIGNED)) FROM units WHERE unit_id LIKE 'UNIT-%'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                object result = cmd.ExecuteScalar();
                int nextNum = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) + 1 : 1;
                return $"UNIT-{nextNum:000}";
            }
            catch { return $"UNIT-{DateTime.Now:yyyyMMddHHmmss}"; }
        }
    }
}
