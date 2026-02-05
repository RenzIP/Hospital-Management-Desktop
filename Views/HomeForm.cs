using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
using Hospital_Management.Views.Controls;
using Hospital_Management.Helpers;
using Hospital_Management.Controllers;

namespace Hospital_Management.Views
{
    public partial class HomeForm : Form
    {
        private bool isDarkMode = false;
        private Timer clockTimer;
        private string currentMenuSelected = "Home";
        private Panel pnlMainContent;
        private UserControl currentControl;

        // Theme colors
        private Color sidebarColor = Color.FromArgb(29, 53, 58);
        private Color sidebarLightColor = Color.FromArgb(38, 70, 77);
        private Color accentColor = Color.FromArgb(0, 173, 181);
        private Color contentBgColor = Color.FromArgb(38, 70, 77);

        // Event for logout
        public event Action LogoutRequested;

        public HomeForm()
        {
            InitializeComponent();
            SetupFullScreenMode();
            SetupMainContentPanel();
            SetupTimer();
            ApplyRoleBasedMenuVisibility();
            UpdateUserDisplay();
            HighlightSelectedMenu("Home");
            LoadHomeContent();
        }

        /// <summary>
        /// Show/hide menu items based on current user's role
        /// </summary>
        private void ApplyRoleBasedMenuVisibility()
        {
            // Apply visibility based on role permissions
            pnlMenuHome.Visible = RoleHelper.CanAccessMenu("Home");
            pnlMenuStaff.Visible = RoleHelper.CanAccessMenu("Staff");
            pnlMenuPatients.Visible = RoleHelper.CanAccessMenu("Patients");
            pnlMenuLaboratory.Visible = RoleHelper.CanAccessMenu("Laboratory");
            pnlMenuCapital.Visible = RoleHelper.CanAccessMenu("Capital");
            pnlMenuUnits.Visible = RoleHelper.CanAccessMenu("Units");

            // Reorganize visible menu positions
            RepositionMenuItems();
        }

        /// <summary>
        /// Reposition menu items after hiding some based on role
        /// </summary>
        private void RepositionMenuItems()
        {
            int yPosition = 130; // Starting position after logo
            int menuHeight = 50;

            Panel[] menuItems = { pnlMenuHome, pnlMenuStaff, pnlMenuPatients, 
                                  pnlMenuLaboratory, pnlMenuCapital, pnlMenuUnits };

            foreach (var menu in menuItems)
            {
                if (menu.Visible)
                {
                    menu.Location = new Point(0, yPosition);
                    yPosition += menuHeight;
                }
            }
        }

        /// <summary>
        /// Update display with current user info
        /// </summary>
        private void UpdateUserDisplay()
        {
            string username = CurrentUser.Username ?? "User";
            string role = RoleHelper.GetRoleDisplayName();
            
            // Update welcome title
            lblWelcomeTitle.Text = $"Welcome, {username}!";
            lblWelcomeSubtitle.Text = $"Role: {role}";

            // Update shift display with current user
            lblCurrentShiftValue.Text = $"{DateTime.Now:HH:mm} - {username}";
        }

        private void SetupFullScreenMode()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new Size(1000, 700);
            this.WindowState = FormWindowState.Maximized;
        }

        private void SetupMainContentPanel()
        {
            pnlMainContent = new Panel();
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.BackColor = contentBgColor;
            pnlMainContent.Padding = new Padding(0);
            
            pnlContent.Controls.Add(pnlMainContent);
            pnlMainContent.BringToFront();
            
            pnlStatusBar.BringToFront();
            btnDarkMode.BringToFront();
        }

        private void LoadContent(UserControl control)
        {
            if (currentControl != null)
            {
                pnlMainContent.Controls.Remove(currentControl);
                currentControl.Dispose();
            }

            currentControl = control;
            currentControl.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Clear();
            pnlMainContent.Controls.Add(currentControl);
            currentControl.BringToFront();

            // Hide status bar on non-Home views (UserControls have their own footer)
            bool isHome = control is HomeControl;
            pnlStatusBar.Visible = isHome;
            btnDarkMode.Visible = isHome;
        }

        private void LoadHomeContent()
        {
            LoadContent(new HomeControl());
        }

        private void SetupTimer()
        {
            clockTimer = new Timer();
            clockTimer.Interval = 1000;
            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            lblCurrentShiftValue.Text = DateTime.Now.ToString("HH:mm") + " - Dr. Sarah";
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.CenterToScreen();
            }
        }

        private void HomeForm_Resize(object sender, EventArgs e)
        {
            // Status bar is anchored, will auto-reposition
        }

        private void HighlightSelectedMenu(string menuName)
        {
            // Reset all to default
            pnlMenuHome.BackColor = sidebarColor;
            pnlMenuStaff.BackColor = sidebarColor;
            pnlMenuPatients.BackColor = sidebarColor;
            pnlMenuLaboratory.BackColor = sidebarColor;
            pnlMenuCapital.BackColor = sidebarColor;
            pnlMenuUnits.BackColor = sidebarColor;

            // Highlight selected
            switch (menuName)
            {
                case "Home":
                    pnlMenuHome.BackColor = sidebarLightColor;
                    break;
                case "Staff":
                    pnlMenuStaff.BackColor = sidebarLightColor;
                    break;
                case "Patients":
                    pnlMenuPatients.BackColor = sidebarLightColor;
                    break;
                case "Laboratory":
                    pnlMenuLaboratory.BackColor = sidebarLightColor;
                    break;
                case "Capital":
                    pnlMenuCapital.BackColor = sidebarLightColor;
                    break;
                case "Units":
                    pnlMenuUnits.BackColor = sidebarLightColor;
                    break;
            }

            currentMenuSelected = menuName;
        }

        private void pnlMenuHome_Click(object sender, EventArgs e)
        {
            HighlightSelectedMenu("Home");
            LoadContent(new HomeControl());
        }

        private void pnlMenuStaff_Click(object sender, EventArgs e)
        {
            HighlightSelectedMenu("Staff");
            LoadContent(new StaffControl());
        }

        private void pnlMenuPatients_Click(object sender, EventArgs e)
        {
            HighlightSelectedMenu("Patients");
            LoadContent(new PatientControl());
        }

        private void pnlMenuLaboratory_Click(object sender, EventArgs e)
        {
            HighlightSelectedMenu("Laboratory");
            LoadContent(new LaboratoryControl());
        }

        private void pnlMenuCapital_Click(object sender, EventArgs e)
        {
            HighlightSelectedMenu("Capital");
            LoadContent(new CapitalControl());
        }

        private void pnlMenuUnits_Click(object sender, EventArgs e)
        {
            HighlightSelectedMenu("Units");
            LoadContent(new UnitControl());
        }

        private void pnlMenuExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LogoutRequested?.Invoke();
                this.Close();
            }
        }

        private void btnDarkMode_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            if (isDarkMode)
            {
                btnDarkMode.Text = "☀";
                btnDarkMode.BackColor = Color.FromArgb(30, 55, 60);
            }
            else
            {
                btnDarkMode.Text = "🌙";
                btnDarkMode.BackColor = Color.FromArgb(50, 90, 100);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            clockTimer?.Stop();
            clockTimer?.Dispose();
            currentControl?.Dispose();
        }

        // Label click handlers
        private void lblMenuHome_Click(object sender, EventArgs e) => pnlMenuHome_Click(sender, e);
        private void lblMenuStaff_Click(object sender, EventArgs e) => pnlMenuStaff_Click(sender, e);
        private void lblMenuPatients_Click(object sender, EventArgs e) => pnlMenuPatients_Click(sender, e);
        private void lblMenuLaboratory_Click(object sender, EventArgs e) => pnlMenuLaboratory_Click(sender, e);
        private void lblMenuCapital_Click(object sender, EventArgs e) => pnlMenuCapital_Click(sender, e);
        private void lblMenuUnits_Click(object sender, EventArgs e) => pnlMenuUnits_Click(sender, e);
        private void lblMenuExit_Click(object sender, EventArgs e) => pnlMenuExit_Click(sender, e);

        // Stubs for designer compatibility
        private void pnlWelcome_Paint(object sender, PaintEventArgs e) { }
        private void pnlStatusBar_Paint(object sender, PaintEventArgs e) { }
        private void CenterStatusBar() { }
    }
}
