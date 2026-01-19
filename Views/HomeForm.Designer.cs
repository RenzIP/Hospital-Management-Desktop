namespace Hospital_Management.Views
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Initialize all components
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblLogoText = new System.Windows.Forms.Label();
            this.pnlMenuHome = new System.Windows.Forms.Panel();
            this.lblIconHome = new System.Windows.Forms.Label();
            this.lblMenuHome = new System.Windows.Forms.Label();
            this.pnlMenuStaff = new System.Windows.Forms.Panel();
            this.lblIconStaff = new System.Windows.Forms.Label();
            this.lblMenuStaff = new System.Windows.Forms.Label();
            this.pnlMenuPatients = new System.Windows.Forms.Panel();
            this.lblIconPatients = new System.Windows.Forms.Label();
            this.lblMenuPatients = new System.Windows.Forms.Label();
            this.pnlMenuLaboratory = new System.Windows.Forms.Panel();
            this.lblIconLaboratory = new System.Windows.Forms.Label();
            this.lblMenuLaboratory = new System.Windows.Forms.Label();
            this.pnlMenuCapital = new System.Windows.Forms.Panel();
            this.lblIconCapital = new System.Windows.Forms.Label();
            this.lblMenuCapital = new System.Windows.Forms.Label();
            this.pnlMenuUnits = new System.Windows.Forms.Panel();
            this.lblIconUnits = new System.Windows.Forms.Label();
            this.lblMenuUnits = new System.Windows.Forms.Label();
            this.pnlMenuExit = new System.Windows.Forms.Panel();
            this.lblIconExit = new System.Windows.Forms.Label();
            this.lblMenuExit = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlWelcome = new System.Windows.Forms.Panel();
            this.lblWelcomeTitle = new System.Windows.Forms.Label();
            this.lblWelcomeSubtitle = new System.Windows.Forms.Label();
            this.pnlStatusBar = new System.Windows.Forms.Panel();
            this.pnlSystemStatus = new System.Windows.Forms.Panel();
            this.lblSystemStatusTitle = new System.Windows.Forms.Label();
            this.lblSystemStatusValue = new System.Windows.Forms.Label();
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.pnlCurrentShift = new System.Windows.Forms.Panel();
            this.lblCurrentShiftTitle = new System.Windows.Forms.Label();
            this.lblCurrentShiftValue = new System.Windows.Forms.Label();
            this.btnDarkMode = new System.Windows.Forms.Button();

            this.pnlSidebar.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlMenuHome.SuspendLayout();
            this.pnlMenuStaff.SuspendLayout();
            this.pnlMenuPatients.SuspendLayout();
            this.pnlMenuLaboratory.SuspendLayout();
            this.pnlMenuCapital.SuspendLayout();
            this.pnlMenuUnits.SuspendLayout();
            this.pnlMenuExit.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlWelcome.SuspendLayout();
            this.pnlStatusBar.SuspendLayout();
            this.pnlSystemStatus.SuspendLayout();
            this.pnlCurrentShift.SuspendLayout();
            this.SuspendLayout();

            // Color scheme - Dark teal theme matching reference
            System.Drawing.Color sidebarColor = System.Drawing.Color.FromArgb(29, 53, 58);
            System.Drawing.Color sidebarLightColor = System.Drawing.Color.FromArgb(38, 70, 77);
            System.Drawing.Color accentColor = System.Drawing.Color.FromArgb(0, 173, 181);
            System.Drawing.Color contentBgColor = System.Drawing.Color.FromArgb(38, 70, 77);
            System.Drawing.Color menuHoverColor = System.Drawing.Color.FromArgb(45, 85, 93);
            
            // 
            // pnlSidebar - Dark teal sidebar
            // 
            this.pnlSidebar.BackColor = sidebarColor;
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Controls.Add(this.pnlMenuHome);
            this.pnlSidebar.Controls.Add(this.pnlMenuStaff);
            this.pnlSidebar.Controls.Add(this.pnlMenuPatients);
            this.pnlSidebar.Controls.Add(this.pnlMenuLaboratory);
            this.pnlSidebar.Controls.Add(this.pnlMenuCapital);
            this.pnlSidebar.Controls.Add(this.pnlMenuUnits);
            this.pnlSidebar.Controls.Add(this.pnlMenuExit);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(160, 700);
            this.pnlSidebar.TabIndex = 0;

            // 
            // pnlLogo - Logo panel with modern healthcare icon
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogo.Controls.Add(this.lblLogo);
            this.pnlLogo.Controls.Add(this.lblLogoText);
            this.pnlLogo.Location = new System.Drawing.Point(0, 15);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(160, 100);
            this.pnlLogo.TabIndex = 0;

            // 
            // lblLogo - Healthcare heart icon
            // 
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 42F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = accentColor;
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(160, 60);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "♥";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblLogoText
            // 
            this.lblLogoText.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblLogoText.ForeColor = System.Drawing.Color.White;
            this.lblLogoText.Location = new System.Drawing.Point(0, 60);
            this.lblLogoText.Name = "lblLogoText";
            this.lblLogoText.Size = new System.Drawing.Size(160, 30);
            this.lblLogoText.TabIndex = 1;
            this.lblLogoText.Text = "HMS";
            this.lblLogoText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // pnlMenuHome
            // 
            this.pnlMenuHome.BackColor = sidebarLightColor;
            this.pnlMenuHome.Controls.Add(this.lblIconHome);
            this.pnlMenuHome.Controls.Add(this.lblMenuHome);
            this.pnlMenuHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMenuHome.Location = new System.Drawing.Point(0, 130);
            this.pnlMenuHome.Name = "pnlMenuHome";
            this.pnlMenuHome.Size = new System.Drawing.Size(160, 45);
            this.pnlMenuHome.TabIndex = 1;
            this.pnlMenuHome.Click += new System.EventHandler(this.pnlMenuHome_Click);

            // 
            // lblIconHome
            // 
            this.lblIconHome.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblIconHome.ForeColor = accentColor;
            this.lblIconHome.Location = new System.Drawing.Point(15, 10);
            this.lblIconHome.Name = "lblIconHome";
            this.lblIconHome.Size = new System.Drawing.Size(30, 25);
            this.lblIconHome.TabIndex = 0;
            this.lblIconHome.Text = "🏠";
            this.lblIconHome.Click += new System.EventHandler(this.lblMenuHome_Click);

            // 
            // lblMenuHome
            // 
            this.lblMenuHome.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMenuHome.ForeColor = System.Drawing.Color.White;
            this.lblMenuHome.Location = new System.Drawing.Point(50, 12);
            this.lblMenuHome.Name = "lblMenuHome";
            this.lblMenuHome.Size = new System.Drawing.Size(100, 21);
            this.lblMenuHome.TabIndex = 1;
            this.lblMenuHome.Text = "Home";
            this.lblMenuHome.Click += new System.EventHandler(this.lblMenuHome_Click);

            // 
            // pnlMenuStaff
            // 
            this.pnlMenuStaff.BackColor = sidebarColor;
            this.pnlMenuStaff.Controls.Add(this.lblIconStaff);
            this.pnlMenuStaff.Controls.Add(this.lblMenuStaff);
            this.pnlMenuStaff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMenuStaff.Location = new System.Drawing.Point(0, 180);
            this.pnlMenuStaff.Name = "pnlMenuStaff";
            this.pnlMenuStaff.Size = new System.Drawing.Size(160, 45);
            this.pnlMenuStaff.TabIndex = 2;
            this.pnlMenuStaff.Click += new System.EventHandler(this.pnlMenuStaff_Click);

            // 
            // lblIconStaff
            // 
            this.lblIconStaff.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblIconStaff.ForeColor = accentColor;
            this.lblIconStaff.Location = new System.Drawing.Point(15, 10);
            this.lblIconStaff.Name = "lblIconStaff";
            this.lblIconStaff.Size = new System.Drawing.Size(30, 25);
            this.lblIconStaff.TabIndex = 0;
            this.lblIconStaff.Text = "👤";
            this.lblIconStaff.Click += new System.EventHandler(this.lblMenuStaff_Click);

            // 
            // lblMenuStaff
            // 
            this.lblMenuStaff.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMenuStaff.ForeColor = System.Drawing.Color.White;
            this.lblMenuStaff.Location = new System.Drawing.Point(50, 12);
            this.lblMenuStaff.Name = "lblMenuStaff";
            this.lblMenuStaff.Size = new System.Drawing.Size(100, 21);
            this.lblMenuStaff.TabIndex = 1;
            this.lblMenuStaff.Text = "Staff";
            this.lblMenuStaff.Click += new System.EventHandler(this.lblMenuStaff_Click);

            // 
            // pnlMenuPatients
            // 
            this.pnlMenuPatients.BackColor = sidebarColor;
            this.pnlMenuPatients.Controls.Add(this.lblIconPatients);
            this.pnlMenuPatients.Controls.Add(this.lblMenuPatients);
            this.pnlMenuPatients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMenuPatients.Location = new System.Drawing.Point(0, 230);
            this.pnlMenuPatients.Name = "pnlMenuPatients";
            this.pnlMenuPatients.Size = new System.Drawing.Size(160, 45);
            this.pnlMenuPatients.TabIndex = 3;
            this.pnlMenuPatients.Click += new System.EventHandler(this.pnlMenuPatients_Click);

            // 
            // lblIconPatients
            // 
            this.lblIconPatients.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblIconPatients.ForeColor = accentColor;
            this.lblIconPatients.Location = new System.Drawing.Point(15, 10);
            this.lblIconPatients.Name = "lblIconPatients";
            this.lblIconPatients.Size = new System.Drawing.Size(30, 25);
            this.lblIconPatients.TabIndex = 0;
            this.lblIconPatients.Text = "❤";
            this.lblIconPatients.Click += new System.EventHandler(this.lblMenuPatients_Click);

            // 
            // lblMenuPatients
            // 
            this.lblMenuPatients.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMenuPatients.ForeColor = System.Drawing.Color.White;
            this.lblMenuPatients.Location = new System.Drawing.Point(50, 12);
            this.lblMenuPatients.Name = "lblMenuPatients";
            this.lblMenuPatients.Size = new System.Drawing.Size(100, 21);
            this.lblMenuPatients.TabIndex = 1;
            this.lblMenuPatients.Text = "Patients";
            this.lblMenuPatients.Click += new System.EventHandler(this.lblMenuPatients_Click);

            // 
            // pnlMenuLaboratory
            // 
            this.pnlMenuLaboratory.BackColor = sidebarColor;
            this.pnlMenuLaboratory.Controls.Add(this.lblIconLaboratory);
            this.pnlMenuLaboratory.Controls.Add(this.lblMenuLaboratory);
            this.pnlMenuLaboratory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMenuLaboratory.Location = new System.Drawing.Point(0, 280);
            this.pnlMenuLaboratory.Name = "pnlMenuLaboratory";
            this.pnlMenuLaboratory.Size = new System.Drawing.Size(160, 45);
            this.pnlMenuLaboratory.TabIndex = 4;
            this.pnlMenuLaboratory.Click += new System.EventHandler(this.pnlMenuLaboratory_Click);

            // 
            // lblIconLaboratory
            // 
            this.lblIconLaboratory.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblIconLaboratory.ForeColor = accentColor;
            this.lblIconLaboratory.Location = new System.Drawing.Point(15, 10);
            this.lblIconLaboratory.Name = "lblIconLaboratory";
            this.lblIconLaboratory.Size = new System.Drawing.Size(30, 25);
            this.lblIconLaboratory.TabIndex = 0;
            this.lblIconLaboratory.Text = "🔬";
            this.lblIconLaboratory.Click += new System.EventHandler(this.lblMenuLaboratory_Click);

            // 
            // lblMenuLaboratory
            // 
            this.lblMenuLaboratory.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMenuLaboratory.ForeColor = System.Drawing.Color.White;
            this.lblMenuLaboratory.Location = new System.Drawing.Point(50, 12);
            this.lblMenuLaboratory.Name = "lblMenuLaboratory";
            this.lblMenuLaboratory.Size = new System.Drawing.Size(100, 21);
            this.lblMenuLaboratory.TabIndex = 1;
            this.lblMenuLaboratory.Text = "Laboratory";
            this.lblMenuLaboratory.Click += new System.EventHandler(this.lblMenuLaboratory_Click);

            // 
            // pnlMenuCapital
            // 
            this.pnlMenuCapital.BackColor = sidebarColor;
            this.pnlMenuCapital.Controls.Add(this.lblIconCapital);
            this.pnlMenuCapital.Controls.Add(this.lblMenuCapital);
            this.pnlMenuCapital.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMenuCapital.Location = new System.Drawing.Point(0, 330);
            this.pnlMenuCapital.Name = "pnlMenuCapital";
            this.pnlMenuCapital.Size = new System.Drawing.Size(160, 45);
            this.pnlMenuCapital.TabIndex = 5;
            this.pnlMenuCapital.Click += new System.EventHandler(this.pnlMenuCapital_Click);

            // 
            // lblIconCapital
            // 
            this.lblIconCapital.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblIconCapital.ForeColor = accentColor;
            this.lblIconCapital.Location = new System.Drawing.Point(15, 10);
            this.lblIconCapital.Name = "lblIconCapital";
            this.lblIconCapital.Size = new System.Drawing.Size(30, 25);
            this.lblIconCapital.TabIndex = 0;
            this.lblIconCapital.Text = "💰";
            this.lblIconCapital.Click += new System.EventHandler(this.lblMenuCapital_Click);

            // 
            // lblMenuCapital
            // 
            this.lblMenuCapital.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMenuCapital.ForeColor = System.Drawing.Color.White;
            this.lblMenuCapital.Location = new System.Drawing.Point(50, 12);
            this.lblMenuCapital.Name = "lblMenuCapital";
            this.lblMenuCapital.Size = new System.Drawing.Size(100, 21);
            this.lblMenuCapital.TabIndex = 1;
            this.lblMenuCapital.Text = "Capital";
            this.lblMenuCapital.Click += new System.EventHandler(this.lblMenuCapital_Click);

            // 
            // pnlMenuUnits
            // 
            this.pnlMenuUnits.BackColor = sidebarColor;
            this.pnlMenuUnits.Controls.Add(this.lblIconUnits);
            this.pnlMenuUnits.Controls.Add(this.lblMenuUnits);
            this.pnlMenuUnits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMenuUnits.Location = new System.Drawing.Point(0, 380);
            this.pnlMenuUnits.Name = "pnlMenuUnits";
            this.pnlMenuUnits.Size = new System.Drawing.Size(160, 45);
            this.pnlMenuUnits.TabIndex = 6;
            this.pnlMenuUnits.Click += new System.EventHandler(this.pnlMenuUnits_Click);

            // 
            // lblIconUnits
            // 
            this.lblIconUnits.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblIconUnits.ForeColor = accentColor;
            this.lblIconUnits.Location = new System.Drawing.Point(15, 10);
            this.lblIconUnits.Name = "lblIconUnits";
            this.lblIconUnits.Size = new System.Drawing.Size(30, 25);
            this.lblIconUnits.TabIndex = 0;
            this.lblIconUnits.Text = "🏥";
            this.lblIconUnits.Click += new System.EventHandler(this.lblMenuUnits_Click);

            // 
            // lblMenuUnits
            // 
            this.lblMenuUnits.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMenuUnits.ForeColor = System.Drawing.Color.White;
            this.lblMenuUnits.Location = new System.Drawing.Point(50, 12);
            this.lblMenuUnits.Name = "lblMenuUnits";
            this.lblMenuUnits.Size = new System.Drawing.Size(100, 21);
            this.lblMenuUnits.TabIndex = 1;
            this.lblMenuUnits.Text = "Units";
            this.lblMenuUnits.Click += new System.EventHandler(this.lblMenuUnits_Click);

            // 
            // pnlMenuExit (Logout)
            // 
            this.pnlMenuExit.BackColor = sidebarColor;
            this.pnlMenuExit.Controls.Add(this.lblIconExit);
            this.pnlMenuExit.Controls.Add(this.lblMenuExit);
            this.pnlMenuExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMenuExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMenuExit.Location = new System.Drawing.Point(0, 655);
            this.pnlMenuExit.Name = "pnlMenuExit";
            this.pnlMenuExit.Size = new System.Drawing.Size(160, 45);
            this.pnlMenuExit.TabIndex = 7;
            this.pnlMenuExit.Click += new System.EventHandler(this.pnlMenuExit_Click);

            // 
            // lblIconExit
            // 
            this.lblIconExit.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblIconExit.ForeColor = System.Drawing.Color.FromArgb(220, 100, 100);
            this.lblIconExit.Location = new System.Drawing.Point(15, 10);
            this.lblIconExit.Name = "lblIconExit";
            this.lblIconExit.Size = new System.Drawing.Size(30, 25);
            this.lblIconExit.TabIndex = 0;
            this.lblIconExit.Text = "🚪";
            this.lblIconExit.Click += new System.EventHandler(this.lblMenuExit_Click);

            // 
            // lblMenuExit
            // 
            this.lblMenuExit.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMenuExit.ForeColor = System.Drawing.Color.White;
            this.lblMenuExit.Location = new System.Drawing.Point(50, 12);
            this.lblMenuExit.Name = "lblMenuExit";
            this.lblMenuExit.Size = new System.Drawing.Size(100, 21);
            this.lblMenuExit.TabIndex = 1;
            this.lblMenuExit.Text = "Logout";
            this.lblMenuExit.Click += new System.EventHandler(this.lblMenuExit_Click);

            // 
            // pnlContent - Main content area
            // 
            this.pnlContent.BackColor = contentBgColor;
            this.pnlContent.Controls.Add(this.pnlWelcome);
            this.pnlContent.Controls.Add(this.pnlStatusBar);
            this.pnlContent.Controls.Add(this.btnDarkMode);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(160, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(840, 700);
            this.pnlContent.TabIndex = 1;

            // 
            // pnlWelcome - Welcome text panel
            // 
            this.pnlWelcome.BackColor = System.Drawing.Color.Transparent;
            this.pnlWelcome.Controls.Add(this.lblWelcomeTitle);
            this.pnlWelcome.Controls.Add(this.lblWelcomeSubtitle);
            this.pnlWelcome.Location = new System.Drawing.Point(0, 20);
            this.pnlWelcome.Name = "pnlWelcome";
            this.pnlWelcome.Size = new System.Drawing.Size(840, 80);
            this.pnlWelcome.TabIndex = 0;

            // 
            // lblWelcomeTitle
            // 
            this.lblWelcomeTitle.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            this.lblWelcomeTitle.ForeColor = System.Drawing.Color.White;
            this.lblWelcomeTitle.Location = new System.Drawing.Point(0, 10);
            this.lblWelcomeTitle.Name = "lblWelcomeTitle";
            this.lblWelcomeTitle.Size = new System.Drawing.Size(840, 35);
            this.lblWelcomeTitle.TabIndex = 0;
            this.lblWelcomeTitle.Text = "Welcome to HMS";
            this.lblWelcomeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblWelcomeSubtitle
            // 
            this.lblWelcomeSubtitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblWelcomeSubtitle.ForeColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.lblWelcomeSubtitle.Location = new System.Drawing.Point(0, 45);
            this.lblWelcomeSubtitle.Name = "lblWelcomeSubtitle";
            this.lblWelcomeSubtitle.Size = new System.Drawing.Size(840, 25);
            this.lblWelcomeSubtitle.TabIndex = 1;
            this.lblWelcomeSubtitle.Text = "(Hospital Management System)";
            this.lblWelcomeSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // pnlStatusBar - Bottom status bar
            // 
            this.pnlStatusBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnlStatusBar.BackColor = System.Drawing.Color.FromArgb(40, 80, 88);
            this.pnlStatusBar.Controls.Add(this.pnlSystemStatus);
            this.pnlStatusBar.Controls.Add(this.pnlDivider);
            this.pnlStatusBar.Controls.Add(this.pnlCurrentShift);
            this.pnlStatusBar.Location = new System.Drawing.Point(220, 640);
            this.pnlStatusBar.Name = "pnlStatusBar";
            this.pnlStatusBar.Size = new System.Drawing.Size(400, 40);
            this.pnlStatusBar.TabIndex = 1;

            // 
            // pnlSystemStatus
            // 
            this.pnlSystemStatus.BackColor = System.Drawing.Color.Transparent;
            this.pnlSystemStatus.Controls.Add(this.lblSystemStatusTitle);
            this.pnlSystemStatus.Controls.Add(this.lblSystemStatusValue);
            this.pnlSystemStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSystemStatus.Location = new System.Drawing.Point(0, 0);
            this.pnlSystemStatus.Name = "pnlSystemStatus";
            this.pnlSystemStatus.Size = new System.Drawing.Size(160, 40);
            this.pnlSystemStatus.TabIndex = 0;

            // 
            // lblSystemStatusTitle
            // 
            this.lblSystemStatusTitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSystemStatusTitle.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.lblSystemStatusTitle.Location = new System.Drawing.Point(10, 5);
            this.lblSystemStatusTitle.Name = "lblSystemStatusTitle";
            this.lblSystemStatusTitle.Size = new System.Drawing.Size(140, 15);
            this.lblSystemStatusTitle.TabIndex = 0;
            this.lblSystemStatusTitle.Text = "SYSTEM STATUS";

            // 
            // lblSystemStatusValue
            // 
            this.lblSystemStatusValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSystemStatusValue.ForeColor = System.Drawing.Color.FromArgb(100, 220, 130);
            this.lblSystemStatusValue.Location = new System.Drawing.Point(10, 20);
            this.lblSystemStatusValue.Name = "lblSystemStatusValue";
            this.lblSystemStatusValue.Size = new System.Drawing.Size(140, 15);
            this.lblSystemStatusValue.TabIndex = 1;
            this.lblSystemStatusValue.Text = "● All Systems Online";

            // 
            // pnlDivider
            // 
            this.pnlDivider.BackColor = System.Drawing.Color.FromArgb(60, 100, 110);
            this.pnlDivider.Location = new System.Drawing.Point(170, 8);
            this.pnlDivider.Name = "pnlDivider";
            this.pnlDivider.Size = new System.Drawing.Size(1, 24);
            this.pnlDivider.TabIndex = 1;

            // 
            // pnlCurrentShift
            // 
            this.pnlCurrentShift.BackColor = System.Drawing.Color.Transparent;
            this.pnlCurrentShift.Controls.Add(this.lblCurrentShiftTitle);
            this.pnlCurrentShift.Controls.Add(this.lblCurrentShiftValue);
            this.pnlCurrentShift.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCurrentShift.Location = new System.Drawing.Point(200, 0);
            this.pnlCurrentShift.Name = "pnlCurrentShift";
            this.pnlCurrentShift.Size = new System.Drawing.Size(200, 40);
            this.pnlCurrentShift.TabIndex = 2;

            // 
            // lblCurrentShiftTitle
            // 
            this.lblCurrentShiftTitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCurrentShiftTitle.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.lblCurrentShiftTitle.Location = new System.Drawing.Point(10, 5);
            this.lblCurrentShiftTitle.Name = "lblCurrentShiftTitle";
            this.lblCurrentShiftTitle.Size = new System.Drawing.Size(180, 15);
            this.lblCurrentShiftTitle.TabIndex = 0;
            this.lblCurrentShiftTitle.Text = "CURRENT SHIFT";

            // 
            // lblCurrentShiftValue
            // 
            this.lblCurrentShiftValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCurrentShiftValue.ForeColor = System.Drawing.Color.White;
            this.lblCurrentShiftValue.Location = new System.Drawing.Point(10, 20);
            this.lblCurrentShiftValue.Name = "lblCurrentShiftValue";
            this.lblCurrentShiftValue.Size = new System.Drawing.Size(180, 15);
            this.lblCurrentShiftValue.TabIndex = 1;
            this.lblCurrentShiftValue.Text = "08:00 - Dr. Sarah Jenkins";

            // 
            // btnDarkMode
            // 
            this.btnDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnDarkMode.BackColor = System.Drawing.Color.FromArgb(50, 90, 100);
            this.btnDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDarkMode.FlatAppearance.BorderSize = 0;
            this.btnDarkMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDarkMode.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnDarkMode.ForeColor = System.Drawing.Color.White;
            this.btnDarkMode.Location = new System.Drawing.Point(780, 640);
            this.btnDarkMode.Name = "btnDarkMode";
            this.btnDarkMode.Size = new System.Drawing.Size(45, 40);
            this.btnDarkMode.TabIndex = 2;
            this.btnDarkMode.Text = "🌙";
            this.btnDarkMode.Click += new System.EventHandler(this.btnDarkMode_Click);

            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(29, 53, 58);
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital Management System - Home";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.Resize += new System.EventHandler(this.HomeForm_Resize);

            this.pnlSidebar.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlMenuHome.ResumeLayout(false);
            this.pnlMenuStaff.ResumeLayout(false);
            this.pnlMenuPatients.ResumeLayout(false);
            this.pnlMenuLaboratory.ResumeLayout(false);
            this.pnlMenuCapital.ResumeLayout(false);
            this.pnlMenuUnits.ResumeLayout(false);
            this.pnlMenuExit.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlWelcome.ResumeLayout(false);
            this.pnlStatusBar.ResumeLayout(false);
            this.pnlSystemStatus.ResumeLayout(false);
            this.pnlCurrentShift.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblLogoText;
        private System.Windows.Forms.Panel pnlMenuHome;
        private System.Windows.Forms.Label lblIconHome;
        private System.Windows.Forms.Label lblMenuHome;
        private System.Windows.Forms.Panel pnlMenuStaff;
        private System.Windows.Forms.Label lblIconStaff;
        private System.Windows.Forms.Label lblMenuStaff;
        private System.Windows.Forms.Panel pnlMenuPatients;
        private System.Windows.Forms.Label lblIconPatients;
        private System.Windows.Forms.Label lblMenuPatients;
        private System.Windows.Forms.Panel pnlMenuLaboratory;
        private System.Windows.Forms.Label lblIconLaboratory;
        private System.Windows.Forms.Label lblMenuLaboratory;
        private System.Windows.Forms.Panel pnlMenuCapital;
        private System.Windows.Forms.Label lblIconCapital;
        private System.Windows.Forms.Label lblMenuCapital;
        private System.Windows.Forms.Panel pnlMenuUnits;
        private System.Windows.Forms.Label lblIconUnits;
        private System.Windows.Forms.Label lblMenuUnits;
        private System.Windows.Forms.Panel pnlMenuExit;
        private System.Windows.Forms.Label lblIconExit;
        private System.Windows.Forms.Label lblMenuExit;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlWelcome;
        private System.Windows.Forms.Label lblWelcomeTitle;
        private System.Windows.Forms.Label lblWelcomeSubtitle;
        private System.Windows.Forms.Panel pnlStatusBar;
        private System.Windows.Forms.Panel pnlSystemStatus;
        private System.Windows.Forms.Label lblSystemStatusTitle;
        private System.Windows.Forms.Label lblSystemStatusValue;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Panel pnlCurrentShift;
        private System.Windows.Forms.Label lblCurrentShiftTitle;
        private System.Windows.Forms.Label lblCurrentShiftValue;
        private System.Windows.Forms.Button btnDarkMode;
    }
}
