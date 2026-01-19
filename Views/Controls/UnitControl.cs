using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Hospital_Management.Helpers;
using MySql.Data.MySqlClient;

namespace Hospital_Management.Views.Controls
{
    public partial class UnitControl : UserControl
    {
        private DataTable unitDataTable;

        private Color bgColor = Color.FromArgb(38, 70, 77);
        private Color headerBg = Color.FromArgb(29, 53, 58);
        private Color cardBg = Color.FromArgb(45, 85, 93);
        private Color accentColor = Color.FromArgb(0, 173, 181);
        private Color textColor = Color.White;
        private Color rowAlt = Color.FromArgb(52, 95, 105);

        public UnitControl()
        {
            InitializeComponent();
            LoadUnitData();
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblIcon = new Label();
            this.pnlSearch = new Panel();
            this.lblSearchLabel = new Label();
            this.txtSearch = new TextBox();
            this.dgvUnits = new DataGridView();
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
            this.lblIcon.Text = "🏥";

            this.lblTitle.Font = new Font("Segoe UI Semibold", 18F);
            this.lblTitle.ForeColor = textColor;
            this.lblTitle.Location = new Point(70, 15);
            this.lblTitle.Size = new Size(300, 35);
            this.lblTitle.Text = "Unit Management";

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
            this.dgvUnits.AllowUserToAddRows = false;
            this.dgvUnits.AllowUserToDeleteRows = false;
            this.dgvUnits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUnits.BackgroundColor = bgColor;
            this.dgvUnits.BorderStyle = BorderStyle.None;
            this.dgvUnits.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUnits.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvUnits.ColumnHeadersHeight = 45;
            this.dgvUnits.DefaultCellStyle.BackColor = cardBg;
            this.dgvUnits.DefaultCellStyle.ForeColor = textColor;
            this.dgvUnits.DefaultCellStyle.SelectionBackColor = accentColor;
            this.dgvUnits.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvUnits.Dock = DockStyle.Fill;
            this.dgvUnits.EnableHeadersVisualStyles = false;
            this.dgvUnits.GridColor = Color.FromArgb(60, 100, 110);
            this.dgvUnits.ColumnHeadersDefaultCellStyle.BackColor = headerBg;
            this.dgvUnits.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(180, 200, 210);
            this.dgvUnits.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F);
            this.dgvUnits.ReadOnly = true;
            this.dgvUnits.RowHeadersVisible = false;
            this.dgvUnits.RowTemplate.Height = 45;
            this.dgvUnits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnits.AlternatingRowsDefaultCellStyle.BackColor = rowAlt;

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

            btnRefresh.Click += (s, e) => LoadUnitData();

            this.pnlFooter.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete, btnRefresh, lblStatus });

            this.Controls.Add(dgvUnits);
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

        public void LoadUnitData()
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT unit_id as 'Unit ID', unit_name as 'Unit Name', unit_type as 'Type', 
                                   floor as 'Floor', capacity as 'Capacity', status as 'Status' 
                                   FROM units ORDER BY unit_id";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    unitDataTable = new DataTable();
                    adapter.Fill(unitDataTable);
                    dgvUnits.DataSource = unitDataTable;
                }
            }
            catch { LoadSampleData(); }
        }

        private void LoadSampleData()
        {
            unitDataTable = new DataTable();
            unitDataTable.Columns.AddRange(new DataColumn[] {
                new DataColumn("Unit ID"), new DataColumn("Unit Name"), new DataColumn("Type"),
                new DataColumn("Floor"), new DataColumn("Capacity"), new DataColumn("Status")
            });

            unitDataTable.Rows.Add("UNIT-001", "Emergency Room", "Emergency", "1", "20", "Active");
            unitDataTable.Rows.Add("UNIT-002", "ICU Ward", "Intensive Care", "2", "15", "Active");
            unitDataTable.Rows.Add("UNIT-003", "General Ward A", "General", "3", "50", "Active");
            unitDataTable.Rows.Add("UNIT-004", "Pediatric Ward", "Pediatric", "4", "30", "Active");
            unitDataTable.Rows.Add("UNIT-005", "Operation Theatre", "Surgery", "2", "5", "Active");
            unitDataTable.Rows.Add("UNIT-006", "Radiology", "Diagnostic", "1", "10", "Active");

            dgvUnits.DataSource = unitDataTable;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (unitDataTable != null)
            {
                string filter = txtSearch.Text.Replace("'", "''");
                unitDataTable.DefaultView.RowFilter = $"[Unit Name] LIKE '%{filter}%' OR Type LIKE '%{filter}%'";
            }
        }

        private Panel pnlHeader, pnlSearch, pnlFooter;
        private Label lblTitle, lblIcon, lblSearchLabel, lblStatus;
        private TextBox txtSearch;
        private DataGridView dgvUnits;
        private Button btnAdd, btnEdit, btnDelete, btnRefresh;
    }
}
