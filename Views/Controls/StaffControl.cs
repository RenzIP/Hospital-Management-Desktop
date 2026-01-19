using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Hospital_Management.Helpers;
using MySql.Data.MySqlClient;

namespace Hospital_Management.Views.Controls
{
    public partial class StaffControl : UserControl
    {
        private DataTable staffDataTable;

        private Color bgColor = Color.FromArgb(38, 70, 77);
        private Color headerBg = Color.FromArgb(29, 53, 58);
        private Color cardBg = Color.FromArgb(45, 85, 93);
        private Color accentColor = Color.FromArgb(0, 173, 181);
        private Color textColor = Color.White;
        private Color rowAlt = Color.FromArgb(52, 95, 105);

        public StaffControl()
        {
            InitializeComponent();
            LoadStaffData();
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblIcon = new Label();
            this.pnlSearch = new Panel();
            this.lblSearchLabel = new Label();
            this.txtSearch = new TextBox();
            this.dgvStaff = new DataGridView();
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
            this.lblIcon.Text = "👥";

            this.lblTitle.Font = new Font("Segoe UI Semibold", 18F);
            this.lblTitle.ForeColor = textColor;
            this.lblTitle.Location = new Point(70, 15);
            this.lblTitle.Size = new Size(300, 35);
            this.lblTitle.Text = "Staff Management";

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
            this.dgvStaff.AllowUserToAddRows = false;
            this.dgvStaff.AllowUserToDeleteRows = false;
            this.dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStaff.BackgroundColor = bgColor;
            this.dgvStaff.BorderStyle = BorderStyle.None;
            this.dgvStaff.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStaff.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvStaff.ColumnHeadersHeight = 45;
            this.dgvStaff.DefaultCellStyle.BackColor = cardBg;
            this.dgvStaff.DefaultCellStyle.ForeColor = textColor;
            this.dgvStaff.DefaultCellStyle.SelectionBackColor = accentColor;
            this.dgvStaff.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvStaff.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvStaff.DefaultCellStyle.Padding = new Padding(5);
            this.dgvStaff.Dock = DockStyle.Fill;
            this.dgvStaff.EnableHeadersVisualStyles = false;
            this.dgvStaff.GridColor = Color.FromArgb(60, 100, 110);
            this.dgvStaff.ColumnHeadersDefaultCellStyle.BackColor = headerBg;
            this.dgvStaff.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(180, 200, 210);
            this.dgvStaff.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F);
            this.dgvStaff.ReadOnly = true;
            this.dgvStaff.RowHeadersVisible = false;
            this.dgvStaff.RowTemplate.Height = 45;
            this.dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaff.AlternatingRowsDefaultCellStyle.BackColor = rowAlt;
            this.dgvStaff.CellFormatting += DgvStaff_CellFormatting;

            // Footer
            this.pnlFooter.BackColor = headerBg;
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Size = new Size(800, 60);

            // Buttons - positioned on left
            CreateButton(btnAdd, "➕ Add", Color.FromArgb(0, 150, 136), 20);
            CreateButton(btnEdit, "✏️ Edit", Color.FromArgb(33, 150, 243), 120);
            CreateButton(btnDelete, "🗑️ Delete", Color.FromArgb(211, 47, 47), 220);
            CreateButton(btnRefresh, "🔄", Color.FromArgb(100, 130, 140), 330);
            btnRefresh.Size = new Size(45, 36);

            // Status label on right
            this.lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.lblStatus.Font = new Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = Color.FromArgb(100, 220, 130);
            this.lblStatus.Location = new Point(500, 20);
            this.lblStatus.Size = new Size(280, 20);
            this.lblStatus.Text = "● System Online | " + DateTime.Now.ToString("HH:mm");
            this.lblStatus.TextAlign = ContentAlignment.MiddleRight;

            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnRefresh.Click += (s, e) => LoadStaffData();

            this.pnlFooter.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete, btnRefresh, lblStatus });

            this.Controls.Add(dgvStaff);
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

        private void DgvStaff_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvStaff.Rows.Count > 0 && e.RowIndex == 0)
            {
                e.CellStyle.BackColor = accentColor;
                e.CellStyle.ForeColor = Color.White;
            }
        }

        public void LoadStaffData()
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT staff_id as 'Staff ID', name as 'Name', cnic as 'CNIC', 
                                   phone_no as 'Phone Number', email as 'Email', department as 'Department' 
                                   FROM staff ORDER BY staff_id";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    staffDataTable = new DataTable();
                    adapter.Fill(staffDataTable);
                    dgvStaff.DataSource = staffDataTable;
                }
            }
            catch { LoadSampleData(); }
        }

        private void LoadSampleData()
        {
            staffDataTable = new DataTable();
            staffDataTable.Columns.AddRange(new DataColumn[] {
                new DataColumn("Staff ID"), new DataColumn("Name"), new DataColumn("CNIC"),
                new DataColumn("Phone Number"), new DataColumn("Email"), new DataColumn("Department")
            });

            staffDataTable.Rows.Add("MED-1", "Dr. John Smith", "23123-1312312-3", "2321-3123123", "john.smith@hospital.org", "Cardiology");
            staffDataTable.Rows.Add("MED-2", "Dr. Sarah Johnson", "45678-9012345-6", "2321-4567890", "sarah.johnson@hospital.org", "Neurology");
            staffDataTable.Rows.Add("MED-3", "Dr. Michael Brown", "78901-2345678-9", "2321-7890123", "michael.brown@hospital.org", "Orthopedics");
            staffDataTable.Rows.Add("MED-4", "Dr. Emily Davis", "11223-3445566-7", "2321-1122334", "emily.davis@hospital.org", "Pediatrics");
            staffDataTable.Rows.Add("MED-5", "Dr. Robert Wilson", "99887-7665544-3", "2321-9988776", "robert.wilson@hospital.org", "ICU");
            staffDataTable.Rows.Add("MED-6", "Dr. Jennifer Martinez", "55443-3221100-9", "2321-5544332", "jennifer.martinez@hospital.org", "Dermatology");
            staffDataTable.Rows.Add("MED-7", "Dr. David Lee", "66778-8990011-2", "2321-6677889", "david.lee@hospital.org", "Surgery");
            staffDataTable.Rows.Add("MED-8", "Dr. Lisa Anderson", "22334-4556677-8", "2321-2233445", "lisa.anderson@hospital.org", "Radiology");

            dgvStaff.DataSource = staffDataTable;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (staffDataTable != null)
            {
                string filter = txtSearch.Text.Replace("'", "''");
                staffDataTable.DefaultView.RowFilter = $"Name LIKE '%{filter}%' OR Department LIKE '%{filter}%' OR [Staff ID] LIKE '%{filter}%'";
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try { new AddStaffForm().ShowDialog(); LoadStaffData(); }
            catch { MessageBox.Show("Add Staff form not available.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count > 0)
                MessageBox.Show("Edit: " + dgvStaff.SelectedRows[0].Cells["Staff ID"].Value, "Edit Staff", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count > 0)
                if (MessageBox.Show("Delete this staff member?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    MessageBox.Show("Deleted (demo)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStaffData();
                }
        }

        private Panel pnlHeader, pnlSearch, pnlFooter;
        private Label lblTitle, lblIcon, lblSearchLabel, lblStatus;
        private TextBox txtSearch;
        private DataGridView dgvStaff;
        private Button btnAdd, btnEdit, btnDelete, btnRefresh;
    }
}
