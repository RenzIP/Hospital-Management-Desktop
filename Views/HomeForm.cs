using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;

namespace Hospital_Management.Views
{
    public partial class HomeForm : Form
    {
        private bool isDarkMode = false;
        private Timer clockTimer;
        private string currentMenuSelected = "Home";

        public HomeForm()
        {
            InitializeComponent();
            SetupTimer();
            HighlightSelectedMenu("Home");
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
            // Update time display if needed
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            // Center the form on screen
            this.CenterToScreen();
        }

        private void HomeForm_Resize(object sender, EventArgs e)
        {
            // Handle resize if needed
            CenterStatusBar();
        }

        private void CenterStatusBar()
        {
            if (pnlStatusBar != null)
            {
                int x = pnlContent.Width / 2 - pnlStatusBar.Width / 2 + pnlSidebar.Width;
                int y = pnlContent.Height - pnlStatusBar.Height - 30;
                pnlStatusBar.Location = new Point(x, y);
            }
        }

        // Rounded corners for panels
        private void pnlWelcome_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int radius = 12;
            DrawRoundedPanel(panel, e, radius, Color.White, Color.FromArgb(230, 230, 230));
        }

        private void pnlStatusBar_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int radius = 8;
            DrawRoundedPanel(panel, e, radius, Color.White, Color.FromArgb(220, 220, 220));
        }

        private void DrawRoundedPanel(Panel panel, PaintEventArgs e, int radius, Color bgColor, Color borderColor)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddArc(panel.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddArc(panel.Width - radius * 2, panel.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(0, panel.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(borderColor, 1))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void HighlightSelectedMenu(string menuName)
        {
            // Reset all menu items
            pnlMenuHome.BackColor = Color.FromArgb(26, 163, 168);
            pnlMenuStaff.BackColor = Color.FromArgb(26, 163, 168);
            pnlMenuPatients.BackColor = Color.FromArgb(26, 163, 168);
            pnlMenuLaboratory.BackColor = Color.FromArgb(26, 163, 168);
            pnlMenuCapital.BackColor = Color.FromArgb(26, 163, 168);
            pnlMenuUnits.BackColor = Color.FromArgb(26, 163, 168);

            // Highlight selected
            switch (menuName)
            {
                case "Home":
                    pnlMenuHome.BackColor = Color.FromArgb(0, 133, 138);
                    break;
                case "Staff":
                    pnlMenuStaff.BackColor = Color.FromArgb(0, 133, 138);
                    break;
                case "Patients":
                    pnlMenuPatients.BackColor = Color.FromArgb(0, 133, 138);
                    break;
                case "Laboratory":
                    pnlMenuLaboratory.BackColor = Color.FromArgb(0, 133, 138);
                    break;
                case "Capital":
                    pnlMenuCapital.BackColor = Color.FromArgb(0, 133, 138);
                    break;
                case "Units":
                    pnlMenuUnits.BackColor = Color.FromArgb(0, 133, 138);
                    break;
            }

            currentMenuSelected = menuName;
        }

        // Menu click handlers
        private void pnlMenuHome_Click(object sender, EventArgs e)
        {
            HighlightSelectedMenu("Home");
        }

        private void pnlMenuStaff_Click(object sender, EventArgs e)
        {
            HighlightSelectedMenu("Staff");
            StaffForm staffForm = new StaffForm();
            staffForm.ShowDialog();
        }

        private void pnlMenuPatients_Click(object sender, EventArgs e)
        {
            HighlightSelectedMenu("Patients");
            PatientForm patientForm = new PatientForm();
            patientForm.ShowDialog();
        }

        private void pnlMenuLaboratory_Click(object sender, EventArgs e)
        {
            HighlightSelectedMenu("Laboratory");
            LaboratoryForm laboratoryForm = new LaboratoryForm();
            laboratoryForm.ShowDialog();
        }

        private void pnlMenuCapital_Click(object sender, EventArgs e)
        {
            HighlightSelectedMenu("Capital");
            CapitalForm capitalForm = new CapitalForm();
            capitalForm.ShowDialog();
        }

        private void pnlMenuUnits_Click(object sender, EventArgs e)
        {
            HighlightSelectedMenu("Units");
            UnitForm unitForm = new UnitForm();
            unitForm.ShowDialog();
        }

        private void pnlMenuExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
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
            }
            else
            {
                btnDarkMode.Text = "🌙";
                btnDarkMode.BackColor = Color.White;
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
        }

        // Make menu items clickable through their child labels
        private void lblMenuHome_Click(object sender, EventArgs e) => pnlMenuHome_Click(sender, e);
        private void lblMenuStaff_Click(object sender, EventArgs e) => pnlMenuStaff_Click(sender, e);
        private void lblMenuPatients_Click(object sender, EventArgs e) => pnlMenuPatients_Click(sender, e);
        private void lblMenuLaboratory_Click(object sender, EventArgs e) => pnlMenuLaboratory_Click(sender, e);
        private void lblMenuCapital_Click(object sender, EventArgs e) => pnlMenuCapital_Click(sender, e);
        private void lblMenuUnits_Click(object sender, EventArgs e) => pnlMenuUnits_Click(sender, e);
        private void lblMenuExit_Click(object sender, EventArgs e) => pnlMenuExit_Click(sender, e);
    }
}
