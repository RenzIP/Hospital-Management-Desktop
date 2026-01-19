using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Hospital_Management.Helpers;
using MySql.Data.MySqlClient;

namespace Hospital_Management.Views.Controls
{
    public partial class PatientControl : UserControl
    {
        private DataTable patientDataTable;

        private Color bgColor = Color.FromArgb(38, 70, 77);
        private Color headerBg = Color.FromArgb(29, 53, 58);
        private Color cardBg = Color.FromArgb(45, 85, 93);
        private Color accentColor = Color.FromArgb(0, 173, 181);
        private Color textColor = Color.White;
        private Color rowAlt = Color.FromArgb(52, 95, 105);

        public PatientControl()
        {
            InitializeComponent();
            LoadPatientData();
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblIcon = new Label();
            this.pnlSearch = new Panel();
            this.lblSearchLabel = new Label();
            this.txtSearch = new TextBox();
            this.dgvPatients = new DataGridView();
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
            this.lblIcon.Text = "❤";

            this.lblTitle.Font = new Font("Segoe UI Semibold", 18F);
            this.lblTitle.ForeColor = textColor;
            this.lblTitle.Location = new Point(70, 15);
            this.lblTitle.Size = new Size(300, 35);
            this.lblTitle.Text = "Patient Management";

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
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.AllowUserToDeleteRows = false;
            this.dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatients.BackgroundColor = bgColor;
            this.dgvPatients.BorderStyle = BorderStyle.None;
            this.dgvPatients.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPatients.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvPatients.ColumnHeadersHeight = 45;
            this.dgvPatients.DefaultCellStyle.BackColor = cardBg;
            this.dgvPatients.DefaultCellStyle.ForeColor = textColor;
            this.dgvPatients.DefaultCellStyle.SelectionBackColor = accentColor;
            this.dgvPatients.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvPatients.DefaultCellStyle.Padding = new Padding(5);
            this.dgvPatients.Dock = DockStyle.Fill;
            this.dgvPatients.EnableHeadersVisualStyles = false;
            this.dgvPatients.GridColor = Color.FromArgb(60, 100, 110);
            this.dgvPatients.ColumnHeadersDefaultCellStyle.BackColor = headerBg;
            this.dgvPatients.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(180, 200, 210);
            this.dgvPatients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F);
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.RowHeadersVisible = false;
            this.dgvPatients.RowTemplate.Height = 45;
            this.dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatients.AlternatingRowsDefaultCellStyle.BackColor = rowAlt;

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

            btnAdd.Click += (s, e) => MessageBox.Show("Add Patient", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnRefresh.Click += (s, e) => LoadPatientData();

            this.pnlFooter.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete, btnRefresh, lblStatus });

            this.Controls.Add(dgvPatients);
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

        public void LoadPatientData()
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT patient_id as 'Patient ID', name as 'Name', cnic as 'CNIC', 
                                   phone_no as 'Phone', email as 'Email', gender as 'Gender', blood_group as 'Blood Group' 
                                   FROM patients ORDER BY patient_id";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    patientDataTable = new DataTable();
                    adapter.Fill(patientDataTable);
                    dgvPatients.DataSource = patientDataTable;
                }
            }
            catch { LoadSampleData(); }
        }

        private void LoadSampleData()
        {
            patientDataTable = new DataTable();
            patientDataTable.Columns.AddRange(new DataColumn[] {
                new DataColumn("Patient ID"), new DataColumn("Name"), new DataColumn("CNIC"),
                new DataColumn("Phone"), new DataColumn("Email"), new DataColumn("Gender"), new DataColumn("Blood Group")
            });

            patientDataTable.Rows.Add("PAT-001", "Ahmad Malik", "12345-6789012-3", "0321-1234567", "ahmad@email.com", "Male", "O+");
            patientDataTable.Rows.Add("PAT-002", "Fatima Khan", "23456-7890123-4", "0322-2345678", "fatima@email.com", "Female", "A+");
            patientDataTable.Rows.Add("PAT-003", "Ali Hassan", "34567-8901234-5", "0323-3456789", "ali@email.com", "Male", "B+");
            patientDataTable.Rows.Add("PAT-004", "Sara Ahmed", "45678-9012345-6", "0324-4567890", "sara@email.com", "Female", "AB+");
            patientDataTable.Rows.Add("PAT-005", "Usman Raza", "56789-0123456-7", "0325-5678901", "usman@email.com", "Male", "O-");

            dgvPatients.DataSource = patientDataTable;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (patientDataTable != null)
            {
                string filter = txtSearch.Text.Replace("'", "''");
                patientDataTable.DefaultView.RowFilter = $"Name LIKE '%{filter}%' OR [Patient ID] LIKE '%{filter}%'";
            }
        }

        private Panel pnlHeader, pnlSearch, pnlFooter;
        private Label lblTitle, lblIcon, lblSearchLabel, lblStatus;
        private TextBox txtSearch;
        private DataGridView dgvPatients;
        private Button btnAdd, btnEdit, btnDelete, btnRefresh;
    }
}
