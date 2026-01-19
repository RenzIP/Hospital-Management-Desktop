using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Hospital_Management.Views.Controls
{
    public partial class HomeControl : UserControl
    {
        private Panel pnlCenterContainer;

        public HomeControl()
        {
            InitializeComponent();
            this.Resize += HomeControl_Resize;
        }

        private void HomeControl_Resize(object sender, EventArgs e)
        {
            CenterContent();
        }

        private void CenterContent()
        {
            if (pnlCenterContainer != null)
            {
                int x = (this.Width - pnlCenterContainer.Width) / 2;
                int y = (this.Height - pnlCenterContainer.Height) / 2 - 30;
                pnlCenterContainer.Location = new Point(Math.Max(20, x), Math.Max(20, y));
            }
        }

        private void InitializeComponent()
        {
            this.pnlCenterContainer = new Panel();
            this.pnlWelcome = new Panel();
            this.lblWelcomeTitle = new Label();
            this.lblWelcomeSubtitle = new Label();
            this.lblDescription = new Label();
            this.pnlStats = new Panel();
            this.pnlStaff = new Panel();
            this.lblStaffCount = new Label();
            this.lblStaffLabel = new Label();
            this.pnlPatients = new Panel();
            this.lblPatientsCount = new Label();
            this.lblPatientsLabel = new Label();
            this.pnlLabs = new Panel();
            this.lblLabsCount = new Label();
            this.lblLabsLabel = new Label();
            this.pnlUnits = new Panel();
            this.lblUnitsCount = new Label();
            this.lblUnitsLabel = new Label();

            this.SuspendLayout();

            // HomeControl
            this.BackColor = Color.FromArgb(75, 145, 160);
            this.Dock = DockStyle.Fill;

            // pnlCenterContainer - holds all centered content
            this.pnlCenterContainer.BackColor = Color.Transparent;
            this.pnlCenterContainer.Size = new Size(700, 400);
            this.pnlCenterContainer.Location = new Point(100, 80);

            // pnlWelcome
            this.pnlWelcome.BackColor = Color.White;
            this.pnlWelcome.Location = new Point(170, 0);
            this.pnlWelcome.Size = new Size(360, 130);
            this.pnlWelcome.Paint += PnlWelcome_Paint;

            // lblWelcomeTitle
            this.lblWelcomeTitle.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold);
            this.lblWelcomeTitle.ForeColor = Color.FromArgb(26, 163, 168);
            this.lblWelcomeTitle.Location = new Point(0, 20);
            this.lblWelcomeTitle.Size = new Size(360, 45);
            this.lblWelcomeTitle.Text = "Welcome to HMS";
            this.lblWelcomeTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblWelcomeSubtitle
            this.lblWelcomeSubtitle.Font = new Font("Segoe UI", 12F);
            this.lblWelcomeSubtitle.ForeColor = Color.FromArgb(100, 100, 100);
            this.lblWelcomeSubtitle.Location = new Point(0, 70);
            this.lblWelcomeSubtitle.Size = new Size(360, 25);
            this.lblWelcomeSubtitle.Text = "Hospital Management System";
            this.lblWelcomeSubtitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblDescription
            this.lblDescription.Font = new Font("Segoe UI", 11F);
            this.lblDescription.ForeColor = Color.White;
            this.lblDescription.Location = new Point(0, 150);
            this.lblDescription.Size = new Size(700, 50);
            this.lblDescription.Text = "Manage your hospital efficiently with our comprehensive system.\nSelect a module from the sidebar to get started.";
            this.lblDescription.TextAlign = ContentAlignment.MiddleCenter;

            // pnlStats
            this.pnlStats.BackColor = Color.Transparent;
            this.pnlStats.Location = new Point(0, 220);
            this.pnlStats.Size = new Size(700, 160);

            // Create stat cards with better spacing
            int cardWidth = 155;
            int cardHeight = 140;
            int spacing = 20;
            int totalWidth = (cardWidth * 4) + (spacing * 3);
            int startX = (700 - totalWidth) / 2;

            CreateStatCard(pnlStaff, lblStaffCount, lblStaffLabel, "125", "Staff Members", startX, Color.FromArgb(0, 122, 204), cardWidth, cardHeight);
            CreateStatCard(pnlPatients, lblPatientsCount, lblPatientsLabel, "1,458", "Patients", startX + cardWidth + spacing, Color.FromArgb(40, 167, 69), cardWidth, cardHeight);
            CreateStatCard(pnlLabs, lblLabsCount, lblLabsLabel, "89", "Lab Tests", startX + (cardWidth + spacing) * 2, Color.FromArgb(255, 193, 7), cardWidth, cardHeight);
            CreateStatCard(pnlUnits, lblUnitsCount, lblUnitsLabel, "24", "Units", startX + (cardWidth + spacing) * 3, Color.FromArgb(220, 53, 69), cardWidth, cardHeight);

            this.pnlStats.Controls.AddRange(new Control[] { pnlStaff, pnlPatients, pnlLabs, pnlUnits });
            this.pnlWelcome.Controls.AddRange(new Control[] { lblWelcomeTitle, lblWelcomeSubtitle });
            this.pnlCenterContainer.Controls.AddRange(new Control[] { pnlWelcome, lblDescription, pnlStats });
            this.Controls.Add(pnlCenterContainer);

            this.ResumeLayout(false);
        }

        private void CreateStatCard(Panel pnl, Label lblCount, Label lblLabel, string count, string label, int xOffset, Color bgColor, int width, int height)
        {
            pnl.BackColor = bgColor;
            pnl.Location = new Point(xOffset, 0);
            pnl.Size = new Size(width, height);
            pnl.Paint += StatCard_Paint;
            pnl.Cursor = Cursors.Hand;

            lblCount.Font = new Font("Segoe UI Semibold", 32F, FontStyle.Bold);
            lblCount.ForeColor = Color.White;
            lblCount.Location = new Point(0, 30);
            lblCount.Size = new Size(width, 50);
            lblCount.Text = count;
            lblCount.TextAlign = ContentAlignment.MiddleCenter;

            lblLabel.Font = new Font("Segoe UI", 11F);
            lblLabel.ForeColor = Color.FromArgb(230, 230, 230);
            lblLabel.Location = new Point(0, 85);
            lblLabel.Size = new Size(width, 25);
            lblLabel.Text = label;
            lblLabel.TextAlign = ContentAlignment.MiddleCenter;

            pnl.Controls.AddRange(new Control[] { lblCount, lblLabel });
        }

        private void PnlWelcome_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int radius = 15;
            DrawRoundedPanel(panel, e, radius);
        }

        private void StatCard_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int radius = 12;
            DrawRoundedPanel(panel, e, radius);
        }

        private void DrawRoundedPanel(Panel panel, PaintEventArgs e, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddArc(panel.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddArc(panel.Width - radius * 2, panel.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(0, panel.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CenterContent();
        }

        private Panel pnlWelcome;
        private Label lblWelcomeTitle;
        private Label lblWelcomeSubtitle;
        private Label lblDescription;
        private Panel pnlStats;
        private Panel pnlStaff;
        private Label lblStaffCount;
        private Label lblStaffLabel;
        private Panel pnlPatients;
        private Label lblPatientsCount;
        private Label lblPatientsLabel;
        private Panel pnlLabs;
        private Label lblLabsCount;
        private Label lblLabsLabel;
        private Panel pnlUnits;
        private Label lblUnitsCount;
        private Label lblUnitsLabel;
    }
}
