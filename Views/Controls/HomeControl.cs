using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Hospital_Management.Views.Controls
{
    public partial class HomeControl : UserControl
    {
        // Colors matching HomeForm theme
        private Color bgColor = Color.FromArgb(38, 70, 77);
        private Color accentColor = Color.FromArgb(0, 173, 181);
        private Color cardBg = Color.FromArgb(45, 85, 93);

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
                int y = (this.Height - pnlCenterContainer.Height) / 2 - 50;
                pnlCenterContainer.Location = new Point(Math.Max(20, x), Math.Max(20, y));
            }
        }

        private void InitializeComponent()
        {
            this.pnlCenterContainer = new Panel();
            this.lblWelcomeTitle = new Label();
            this.lblWelcomeSubtitle = new Label();
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
            this.BackColor = bgColor;
            this.Dock = DockStyle.Fill;

            // pnlCenterContainer
            this.pnlCenterContainer = new Panel();
            this.pnlCenterContainer.BackColor = Color.Transparent;
            this.pnlCenterContainer.Size = new Size(800, 350);
            this.pnlCenterContainer.Location = new Point(100, 100);

            // lblWelcomeTitle
            this.lblWelcomeTitle.Font = new Font("Segoe UI Light", 32F);
            this.lblWelcomeTitle.ForeColor = Color.White;
            this.lblWelcomeTitle.Location = new Point(0, 0);
            this.lblWelcomeTitle.Size = new Size(800, 55);
            this.lblWelcomeTitle.Text = "Welcome to HMS";
            this.lblWelcomeTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblWelcomeSubtitle
            this.lblWelcomeSubtitle.Font = new Font("Segoe UI", 14F);
            this.lblWelcomeSubtitle.ForeColor = Color.FromArgb(140, 180, 190);
            this.lblWelcomeSubtitle.Location = new Point(0, 55);
            this.lblWelcomeSubtitle.Size = new Size(800, 30);
            this.lblWelcomeSubtitle.Text = "(Hospital Management System)";
            this.lblWelcomeSubtitle.TextAlign = ContentAlignment.MiddleCenter;

            // pnlStats
            this.pnlStats.BackColor = Color.Transparent;
            this.pnlStats.Location = new Point(0, 120);
            this.pnlStats.Size = new Size(800, 200);

            // Create stat cards
            int cardWidth = 180;
            int cardHeight = 160;
            int spacing = 25;
            int totalWidth = (cardWidth * 4) + (spacing * 3);
            int startX = (800 - totalWidth) / 2;

            CreateStatCard(pnlStaff, lblStaffCount, lblStaffLabel, "125", "Staff Members", startX, 
                Color.FromArgb(0, 122, 204), "👥", cardWidth, cardHeight);
            CreateStatCard(pnlPatients, lblPatientsCount, lblPatientsLabel, "1,458", "Patients", 
                startX + cardWidth + spacing, Color.FromArgb(40, 167, 69), "❤", cardWidth, cardHeight);
            CreateStatCard(pnlLabs, lblLabsCount, lblLabsLabel, "89", "Lab Tests", 
                startX + (cardWidth + spacing) * 2, Color.FromArgb(255, 193, 7), "🔬", cardWidth, cardHeight);
            CreateStatCard(pnlUnits, lblUnitsCount, lblUnitsLabel, "24", "Units", 
                startX + (cardWidth + spacing) * 3, Color.FromArgb(220, 53, 69), "🏥", cardWidth, cardHeight);

            this.pnlStats.Controls.AddRange(new Control[] { pnlStaff, pnlPatients, pnlLabs, pnlUnits });
            this.pnlCenterContainer.Controls.AddRange(new Control[] { lblWelcomeTitle, lblWelcomeSubtitle, pnlStats });
            this.Controls.Add(pnlCenterContainer);

            this.ResumeLayout(false);
        }

        private void CreateStatCard(Panel pnl, Label lblCount, Label lblLabel, string count, string label, 
            int xOffset, Color accentLine, string icon, int width, int height)
        {
            pnl.BackColor = cardBg;
            pnl.Location = new Point(xOffset, 0);
            pnl.Size = new Size(width, height);
            pnl.Cursor = Cursors.Hand;
            pnl.Paint += (s, e) => {
                // Draw accent line at top
                using (Brush brush = new SolidBrush(accentLine))
                {
                    e.Graphics.FillRectangle(brush, 0, 0, pnl.Width, 4);
                }
                // Draw rounded corners
                DrawRoundedPanel(pnl, e, 8);
            };

            // Icon label
            Label lblIcon = new Label();
            lblIcon.Font = new Font("Segoe UI", 28F);
            lblIcon.ForeColor = accentLine;
            lblIcon.Location = new Point(0, 20);
            lblIcon.Size = new Size(width, 45);
            lblIcon.Text = icon;
            lblIcon.TextAlign = ContentAlignment.MiddleCenter;

            lblCount.Font = new Font("Segoe UI Semibold", 32F, FontStyle.Bold);
            lblCount.ForeColor = Color.White;
            lblCount.Location = new Point(0, 70);
            lblCount.Size = new Size(width, 45);
            lblCount.Text = count;
            lblCount.TextAlign = ContentAlignment.MiddleCenter;

            lblLabel.Font = new Font("Segoe UI", 11F);
            lblLabel.ForeColor = Color.FromArgb(150, 170, 180);
            lblLabel.Location = new Point(0, 120);
            lblLabel.Size = new Size(width, 25);
            lblLabel.Text = label;
            lblLabel.TextAlign = ContentAlignment.MiddleCenter;

            pnl.Controls.AddRange(new Control[] { lblIcon, lblCount, lblLabel });
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

        private Panel pnlCenterContainer;
        private Label lblWelcomeTitle;
        private Label lblWelcomeSubtitle;
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
