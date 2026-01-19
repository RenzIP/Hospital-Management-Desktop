using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Hospital_Management.Helpers;
using MySql.Data.MySqlClient;

namespace Hospital_Management.Views.Controls
{
    public partial class LaboratoryControl : UserControl
    {
        private DataTable labDataTable;

        private Color bgColor = Color.FromArgb(38, 70, 77);
        private Color headerBg = Color.FromArgb(29, 53, 58);
        private Color cardBg = Color.FromArgb(45, 85, 93);
        private Color accentColor = Color.FromArgb(0, 173, 181);
        private Color textColor = Color.White;
        private Color rowAlt = Color.FromArgb(52, 95, 105);

        public LaboratoryControl()
        {
            InitializeComponent();
            LoadLabData();
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblIcon = new Label();
            this.pnlSearch = new Panel();
            this.lblSearchLabel = new Label();
            this.txtSearch = new TextBox();
            this.dgvLaboratory = new DataGridView();
            this.pnlFooter = new Panel();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnRefresh = new Button();
            this.lblStatus = new Label();

            this.SuspendLayout();
            this.BackColor = bgColor;
            this.Dock = DockStyle.Fill;

            // Header
            this.pnlHeader.BackColor = headerBg;
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Size = new Size(800, 60);

            this.lblIcon.Font = new Font("Segoe UI", 24F);
            this.lblIcon.ForeColor = accentColor;
            this.lblIcon.Location = new Point(20, 12);
            this.lblIcon.Size = new Size(50, 40);
            this.lblIcon.Text = "🔬";

            this.lblTitle.Font = new Font("Segoe UI Semibold", 18F);
            this.lblTitle.ForeColor = textColor;
            this.lblTitle.Location = new Point(70, 15);
            this.lblTitle.Size = new Size(350, 35);
            this.lblTitle.Text = "Laboratory Management";

            this.pnlHeader.Controls.AddRange(new Control[] { lblIcon, lblTitle });

            // Search
            this.pnlSearch.BackColor = headerBg;
            this.pnlSearch.Dock = DockStyle.Top;
            this.pnlSearch.Size = new Size(800, 50);

            this.lblSearchLabel.Font = new Font("Segoe UI", 10F);
            this.lblSearchLabel.ForeColor = Color.FromArgb(150, 170, 180);
            this.lblSearchLabel.Location = new Point(20, 15);
            this.lblSearchLabel.Size = new Size(60, 20);
            this.lblSearchLabel.Text = "Search:";

            this.txtSearch.BackColor = cardBg;
            this.txtSearch.BorderStyle = BorderStyle.None;
            this.txtSearch.Font = new Font("Segoe UI", 11F);
            this.txtSearch.ForeColor = textColor;
            this.txtSearch.Location = new Point(85, 13);
            this.txtSearch.Size = new Size(300, 25);
            this.txtSearch.TextChanged += TxtSearch_TextChanged;

            this.pnlSearch.Controls.AddRange(new Control[] { lblSearchLabel, txtSearch });

            // DataGridView
            this.dgvLaboratory.AllowUserToAddRows = false;
            this.dgvLaboratory.AllowUserToDeleteRows = false;
            this.dgvLaboratory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLaboratory.BackgroundColor = bgColor;
            this.dgvLaboratory.BorderStyle = BorderStyle.None;
            this.dgvLaboratory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLaboratory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvLaboratory.ColumnHeadersHeight = 45;
            this.dgvLaboratory.DefaultCellStyle.BackColor = cardBg;
            this.dgvLaboratory.DefaultCellStyle.ForeColor = textColor;
            this.dgvLaboratory.DefaultCellStyle.SelectionBackColor = accentColor;
            this.dgvLaboratory.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvLaboratory.DefaultCellStyle.Padding = new Padding(5);
            this.dgvLaboratory.Dock = DockStyle.Fill;
            this.dgvLaboratory.EnableHeadersVisualStyles = false;
            this.dgvLaboratory.GridColor = Color.FromArgb(60, 100, 110);
            this.dgvLaboratory.ColumnHeadersDefaultCellStyle.BackColor = headerBg;
            this.dgvLaboratory.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(180, 200, 210);
            this.dgvLaboratory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F);
            this.dgvLaboratory.ReadOnly = true;
            this.dgvLaboratory.RowHeadersVisible = false;
            this.dgvLaboratory.RowTemplate.Height = 45;
            this.dgvLaboratory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvLaboratory.AlternatingRowsDefaultCellStyle.BackColor = rowAlt;

            // Footer
            this.pnlFooter.BackColor = headerBg;
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Size = new Size(800, 60);

            CreateButton(btnAdd, "➕ Add", Color.FromArgb(0, 150, 136), 20);
            CreateButton(btnEdit, "✏️ Edit", Color.FromArgb(33, 150, 243), 120);
            CreateButton(btnDelete, "🗑️ Delete", Color.FromArgb(211, 47, 47), 220);
            CreateButton(btnRefresh, "🔄", Color.FromArgb(100, 130, 140), 330);
            btnRefresh.Size = new Size(45, 36);

            this.lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.lblStatus.Font = new Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = Color.FromArgb(100, 220, 130);
            this.lblStatus.Location = new Point(500, 20);
            this.lblStatus.Size = new Size(280, 20);
            this.lblStatus.Text = "● System Online | " + DateTime.Now.ToString("HH:mm");
            this.lblStatus.TextAlign = ContentAlignment.MiddleRight;

            btnRefresh.Click += (s, e) => LoadLabData();

            this.pnlFooter.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete, btnRefresh, lblStatus });

            this.Controls.Add(dgvLaboratory);
            this.Controls.Add(pnlSearch);
            this.Controls.Add(pnlHeader);
            this.Controls.Add(pnlFooter);

            this.ResumeLayout(false);
        }

        private void CreateButton(Button btn, string text, Color bg, int x)
        {
            btn.BackColor = bg;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI", 10F);
            btn.ForeColor = Color.White;
            btn.Location = new Point(x, 12);
            btn.Size = new Size(90, 36);
            btn.Text = text;
            btn.Cursor = Cursors.Hand;
        }

        public void LoadLabData()
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT lab_id as 'Lab ID', test_name as 'Test Name', patient_name as 'Patient', 
                                   test_date as 'Date', status as 'Status' FROM laboratory ORDER BY test_date DESC";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    labDataTable = new DataTable();
                    adapter.Fill(labDataTable);
                    dgvLaboratory.DataSource = labDataTable;
                }
            }
            catch { LoadSampleData(); }
        }

        private void LoadSampleData()
        {
            labDataTable = new DataTable();
            labDataTable.Columns.AddRange(new DataColumn[] {
                new DataColumn("Lab ID"), new DataColumn("Test Name"), new DataColumn("Patient"),
                new DataColumn("Date"), new DataColumn("Status")
            });

            labDataTable.Rows.Add("LAB-001", "Blood Test", "Ahmad Malik", "2026-01-20", "Completed");
            labDataTable.Rows.Add("LAB-002", "X-Ray", "Fatima Khan", "2026-01-19", "Pending");
            labDataTable.Rows.Add("LAB-003", "CT Scan", "Ali Hassan", "2026-01-18", "In Progress");
            labDataTable.Rows.Add("LAB-004", "MRI", "Sara Ahmed", "2026-01-17", "Completed");
            labDataTable.Rows.Add("LAB-005", "Urine Test", "Usman Raza", "2026-01-16", "Pending");

            dgvLaboratory.DataSource = labDataTable;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (labDataTable != null)
            {
                string filter = txtSearch.Text.Replace("'", "''");
                labDataTable.DefaultView.RowFilter = $"[Test Name] LIKE '%{filter}%' OR Patient LIKE '%{filter}%'";
            }
        }

        private Panel pnlHeader, pnlSearch, pnlFooter;
        private Label lblTitle, lblIcon, lblSearchLabel, lblStatus;
        private TextBox txtSearch;
        private DataGridView dgvLaboratory;
        private Button btnAdd, btnEdit, btnDelete, btnRefresh;
    }
}
