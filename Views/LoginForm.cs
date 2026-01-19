using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Hospital_Management.Controllers;

namespace Hospital_Management.Views
{
    public partial class LoginForm : Form
    {
        private string employeePlaceholder = "Enter username or email";

        public LoginForm()
        {
            InitializeComponent();
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
            string username = txtEmployeeId.Text == employeePlaceholder ? "" : txtEmployeeId.Text;
            string password = txtPassword.Text;

            // Validation
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter your Username or Email.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeId.Focus();
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
            var controller = new LoginController();
            bool isLoginSuccess = controller.PerformLogin(username, password);

            if (isLoginSuccess)
            {
                // Role and department are now fetched from database via CurrentUser
                string role = CurrentUser.Role ?? "User";
                string department = CurrentUser.Department ?? "";
                string welcomeMessage = $"Welcome, {CurrentUser.Username}!\nRole: {role}";
                
                if (!string.IsNullOrEmpty(department))
                {
                    welcomeMessage += $"\nDepartment: {department}";
                }

                MessageBox.Show(welcomeMessage, "Login Successful", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                HomeForm mainForm = new HomeForm();
                bool isLoggingOut = false;
                
                mainForm.LogoutRequested += () => {
                    isLoggingOut = true;
                    this.Show();
                    txtPassword.Clear();
                };
                
                mainForm.FormClosed += (s, args) => {
                    if (!isLoggingOut)
                    {
                        this.Close(); // Only close app if user clicked X, not logout
                    }
                };
                
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password. Please try again.", "Authentication Failed", 
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

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0'; // Show password
                btnTogglePassword.Text = "Hide";
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Hide password
                btnTogglePassword.Text = "Show";
            }
        }
    }
}
