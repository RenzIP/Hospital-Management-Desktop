using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
using Hospital_Management.Views.Controls;

namespace Hospital_Management.Views
{
    public partial class HomeForm : Form
    {
        private bool isDarkMode = false;
        private Timer clockTimer;
        private string currentMenuSelected = "Home";
        private Panel pnlMainContent;
        private UserControl currentControl;

        // Event for logout
        public event Action LogoutRequested;

        public HomeForm()
        {
            InitializeComponent();
            SetupFullScreenMode();
            SetupMainContentPanel();
            SetupTimer();
            HighlightSelectedMenu("Home");
            LoadHomeContent();
            UpdateMenuLabels();
        }

        private void SetupFullScreenMode()
        {
            // Enable resizing and maximize
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new Size(1000, 650);
            this.WindowState = FormWindowState.Maximized;
        }

        private void UpdateMenuLabels()
        {
            // Update Exit to Logout
            lblMenuExit.Text = "Logout";
            lblIconExit.Text = "🚪";
        }

        private void SetupMainContentPanel()
        {
            // Create main content panel that will host UserControls
            pnlMainContent = new Panel();
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.BackColor = Color.FromArgb(75, 145, 160);
            pnlMainContent.Padding = new Padding(0);
            
            // Add to content panel
            pnlContent.Controls.Add(pnlMainContent);
            pnlMainContent.BringToFront();
            
            // Keep status bar and dark mode button on top
            pnlStatusBar.BringToFront();
            btnDarkMode.BringToFront();
        }

        private void LoadContent(UserControl control)
        {
            // Dispose previous control
            if (currentControl != null)
            {
                pnlMainContent.Controls.Remove(currentControl);
                currentControl.Dispose();
            }

            // Add new control
            currentControl = control;
            currentControl.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Clear();
            pnlMainContent.Controls.Add(currentControl);
            currentControl.BringToFront();
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
            // Update time display
            lblCurrentShiftValue.Text = DateTime.Now.ToString("HH:mm:ss") + " - Dr. Sarah Jenkins";
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            // Center the form on screen if not maximized
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.CenterToScreen();
            }
        }

        private void HomeForm_Resize(object sender, EventArgs e)
        {
            // Reposition status bar on resize
            RepositionStatusBar();
        }

        private void RepositionStatusBar()
        {
            if (pnlStatusBar != null && pnlContent != null)
            {
                int x = (pnlContent.Width - pnlStatusBar.Width) / 2;
                int y = pnlContent.Height - pnlStatusBar.Height - 20;
                pnlStatusBar.Location = new Point(Math.Max(10, x), Math.Max(10, y));
                
                // Reposition dark mode button
                if (btnDarkMode != null)
                {
                    btnDarkMode.Location = new Point(pnlContent.Width - btnDarkMode.Width - 20, y + 5);
                }
            }
        }

        private void HighlightSelectedMenu(string menuName)
        {
            // Reset all menu items to default color
            Color defaultColor = Color.FromArgb(26, 163, 168);
            Color selectedColor = Color.FromArgb(0, 120, 130);
            
            pnlMenuHome.BackColor = defaultColor;
            pnlMenuStaff.BackColor = defaultColor;
            pnlMenuPatients.BackColor = defaultColor;
            pnlMenuLaboratory.BackColor = defaultColor;
            pnlMenuCapital.BackColor = defaultColor;
            pnlMenuUnits.BackColor = defaultColor;

            // Highlight selected
            switch (menuName)
            {
                case "Home":
                    pnlMenuHome.BackColor = selectedColor;
                    break;
                case "Staff":
                    pnlMenuStaff.BackColor = selectedColor;
                    break;
                case "Patients":
                    pnlMenuPatients.BackColor = selectedColor;
                    break;
                case "Laboratory":
                    pnlMenuLaboratory.BackColor = selectedColor;
                    break;
                case "Capital":
                    pnlMenuCapital.BackColor = selectedColor;
                    break;
                case "Units":
                    pnlMenuUnits.BackColor = selectedColor;
                    break;
            }

            currentMenuSelected = menuName;
        }

        // Menu click handlers - load UserControls into embedded panel
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
            // Now acts as Logout
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Raise logout event
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
                btnDarkMode.BackColor = Color.FromArgb(60, 60, 60);
                btnDarkMode.ForeColor = Color.White;
            }
            else
            {
                btnDarkMode.Text = "🌙";
                btnDarkMode.BackColor = Color.White;
                btnDarkMode.ForeColor = Color.Black;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (clockTimer != null)
            {
                clockTimer.Stop();
                clockTimer.Dispose();
            }
            if (currentControl != null)
            {
                currentControl.Dispose();
            }
        }

        // Make menu items clickable through their child labels
        private void lblMenuHome_Click(object sender, EventArgs e) => pnlMenuHome_Click(sender, e);
        private void lblMenuStaff_Click(object sender, EventArgs e) => pnlMenuStaff_Click(sender, e);
        private void lblMenuPatients_Click(object sender, EventArgs e) => pnlMenuPatients_Click(sender, e);
        private void lblMenuLaboratory_Click(object sender, EventArgs e) => pnlMenuLaboratory_Click(sender, e);
        private void lblMenuCapital_Click(object sender, EventArgs e) => pnlMenuCapital_Click(sender, e);
        private void lblMenuUnits_Click(object sender, EventArgs e) => pnlMenuUnits_Click(sender, e);
        private void lblMenuExit_Click(object sender, EventArgs e) => pnlMenuExit_Click(sender, e);

        // Keep these for backwards compatibility
        private void pnlWelcome_Paint(object sender, PaintEventArgs e) { }
        private void pnlStatusBar_Paint(object sender, PaintEventArgs e) { }
        private void CenterStatusBar() { }
    }
}
