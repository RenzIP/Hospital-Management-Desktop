using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Hospital_Management.Views
{
    public partial class LoginForm : Form
    {
        private string employeePlaceholder = "ID-12345 or email@hospital.org";

        public LoginForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Set department dropdown to first item
            cmbDepartment.SelectedIndex = 0;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Center the card
            CenterCard();
        }

        private void CenterCard()
        {
            pnlCard.Location = new Point(
                (this.ClientSize.Width - pnlCard.Width) / 2,
                (this.ClientSize.Height - pnlCard.Height - 40) / 2
            );
        }

        // Rounded corners for card
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

            // Optional: add shadow effect by drawing border
            using (Pen pen = new Pen(Color.FromArgb(220, 220, 220), 1))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(pen, path);
            }
        }

        // Placeholder functionality for Employee ID
        private void txtEmployeeId_Enter(object sender, EventArgs e)
        {
            if (txtEmployeeId.Text == employeePlaceholder)
            {
                txtEmployeeId.Text = "";
                txtEmployeeId.ForeColor = Color.Black;
            }
        }

        private void txtEmployeeId_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmployeeId.Text))
            {
                txtEmployeeId.Text = employeePlaceholder;
                txtEmployeeId.ForeColor = Color.Gray;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string employeeId = txtEmployeeId.Text == employeePlaceholder ? "" : txtEmployeeId.Text;
            string password = txtPassword.Text;
            string department = cmbDepartment.SelectedItem?.ToString();

            // Validation
            if (string.IsNullOrWhiteSpace(employeeId))
            {
                MessageBox.Show("Please enter your Employee ID or Email.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeId.Focus();
                return;
            }

            if (department == "Select Department" || string.IsNullOrEmpty(department))
            {
                MessageBox.Show("Please select a department.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepartment.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your password.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Use controller for authentication
            var controller = new Controllers.LoginController();
            bool isLoginSuccess = controller.PerformLogin(employeeId, password);

            if (isLoginSuccess)
            {
                MessageBox.Show($"Welcome! You are logged in to {department}.", "Login Successful", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                HomeForm mainForm = new HomeForm();
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Employee ID or Password. Please try again.", "Authentication Failed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void lblForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please contact your system administrator to reset your password.", 
                "Password Recovery", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblCopyright_Click(object sender, EventArgs e)
        {

        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '●')
            {
                txtPassword.PasswordChar = '\0'; // Show password
                btnTogglePassword.Text = "🙈";
            }
            else
            {
                txtPassword.PasswordChar = '●'; // Hide password
                btnTogglePassword.Text = "👁";
            }
        }
    }
}
