using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Hospital_Management.Helpers;

namespace Hospital_Management.Views
{
    public partial class RegisterUserForm : Form
    {
        public RegisterUserForm()
        {
            InitializeComponent();
        }

        private void RegisterUserForm_Load(object sender, EventArgs e)
        {
            CenterCard();
            LoadRoles();
            LoadDepartments();
        }

        private void CenterCard()
        {
            pnlCard.Location = new Point(
                (this.ClientSize.Width - pnlCard.Width) / 2,
                (this.ClientSize.Height - pnlCard.Height) / 2
            );
        }

        private void LoadRoles()
        {
            cboRole.Items.Clear();
            // Only non-critical roles available for self-registration
            // Admin and Doctor roles must be assigned by system administrator
            cboRole.Items.Add("staff");
            cboRole.Items.Add("nurse");
            cboRole.Items.Add("receptionist");
            cboRole.Items.Add("lab_technician");
            cboRole.SelectedIndex = 0; // Default to staff
        }

        private void LoadDepartments()
        {
            cboDepartment.Items.Clear();
            cboDepartment.Items.Add("General");
            cboDepartment.Items.Add("Cardiology");
            cboDepartment.Items.Add("Neurology");
            cboDepartment.Items.Add("Orthopedics");
            cboDepartment.Items.Add("Pediatrics");
            cboDepartment.Items.Add("Emergency");
            cboDepartment.Items.Add("Laboratory");
            cboDepartment.Items.Add("Radiology");
            cboDepartment.Items.Add("Pharmacy");
            cboDepartment.Items.Add("Administration");
            cboDepartment.SelectedIndex = 0;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter an email.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter a password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                var dbHelper = DatabaseHelper.Instance;
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();

                    // Check if username or email already exists
                    using (var checkCmd = conn.CreateCommand())
                    {
                        checkCmd.CommandText = "SELECT COUNT(*) FROM users WHERE username = @username OR email = @email";
                        var usernameParam = checkCmd.CreateParameter();
                        usernameParam.ParameterName = "@username";
                        usernameParam.Value = txtUsername.Text.Trim();
                        checkCmd.Parameters.Add(usernameParam);

                        var emailParam = checkCmd.CreateParameter();
                        emailParam.ParameterName = "@email";
                        emailParam.Value = txtEmail.Text.Trim();
                        checkCmd.Parameters.Add(emailParam);

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Username or email already exists.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insert new user
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"INSERT INTO users (username, email, password, role, department, is_active, created_at, updated_at) 
                                            VALUES (@username, @email, @password, @role, @department, 1, NOW(), NOW())";

                        var usernameParam = cmd.CreateParameter();
                        usernameParam.ParameterName = "@username";
                        usernameParam.Value = txtUsername.Text.Trim();
                        cmd.Parameters.Add(usernameParam);

                        var emailParam = cmd.CreateParameter();
                        emailParam.ParameterName = "@email";
                        emailParam.Value = txtEmail.Text.Trim();
                        cmd.Parameters.Add(emailParam);

                        var passwordParam = cmd.CreateParameter();
                        passwordParam.ParameterName = "@password";
                        passwordParam.Value = txtPassword.Text; // In production, use BCrypt or similar
                        cmd.Parameters.Add(passwordParam);

                        var roleParam = cmd.CreateParameter();
                        roleParam.ParameterName = "@role";
                        roleParam.Value = cboRole.SelectedItem.ToString();
                        cmd.Parameters.Add(roleParam);

                        var deptParam = cmd.CreateParameter();
                        deptParam.ParameterName = "@department";
                        deptParam.Value = cboDepartment.SelectedItem.ToString();
                        cmd.Parameters.Add(deptParam);

                        cmd.ExecuteNonQuery();
                    }

                    // Also insert into staff table for sync
                    using (var staffCmd = conn.CreateCommand())
                    {
                        // Generate staff_id
                        string staffId = GenerateStaffId(conn);
                        
                        staffCmd.CommandText = @"INSERT INTO staff (staff_id, name, email, password, department) 
                                                VALUES (@staffId, @name, @email, @password, @department)";

                        var staffIdParam = staffCmd.CreateParameter();
                        staffIdParam.ParameterName = "@staffId";
                        staffIdParam.Value = staffId;
                        staffCmd.Parameters.Add(staffIdParam);

                        var nameParam = staffCmd.CreateParameter();
                        nameParam.ParameterName = "@name";
                        nameParam.Value = txtUsername.Text.Trim(); // Use username as name
                        staffCmd.Parameters.Add(nameParam);

                        var emailParam = staffCmd.CreateParameter();
                        emailParam.ParameterName = "@email";
                        emailParam.Value = txtEmail.Text.Trim();
                        staffCmd.Parameters.Add(emailParam);

                        var passwordParam = staffCmd.CreateParameter();
                        passwordParam.ParameterName = "@password";
                        passwordParam.Value = txtPassword.Text;
                        staffCmd.Parameters.Add(passwordParam);

                        var deptParam = staffCmd.CreateParameter();
                        deptParam.ParameterName = "@department";
                        deptParam.Value = cboDepartment.SelectedItem.ToString();
                        staffCmd.Parameters.Add(deptParam);

                        staffCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("User registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private string GenerateStaffId(System.Data.IDbConnection conn)
        {
            try
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT MAX(CAST(SUBSTRING(staff_id, 5) AS UNSIGNED)) FROM staff WHERE staff_id LIKE 'MED-%'";
                    object result = cmd.ExecuteScalar();
                    int nextNum = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) + 1 : 1;
                    return $"MED-{nextNum}";
                }
            }
            catch { return $"MED-{DateTime.Now:yyyyMMddHHmmss}"; }
        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int radius = 15;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddArc(panel.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddArc(panel.Width - radius * 2, panel.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(0, panel.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);
        }
    }
}
