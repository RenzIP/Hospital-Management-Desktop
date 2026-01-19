using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Hospital_Management.Helpers;
using MySql.Data.MySqlClient;

namespace Hospital_Management.Views.Controls
{
    public partial class CapitalControl : UserControl
    {
        private DataTable capitalDataTable;

        private Color bgColor = Color.FromArgb(38, 70, 77);
        private Color headerBg = Color.FromArgb(29, 53, 58);
        private Color cardBg = Color.FromArgb(45, 85, 93);
        private Color accentColor = Color.FromArgb(0, 173, 181);
        private Color textColor = Color.White;
        private Color rowAlt = Color.FromArgb(52, 95, 105);

        public CapitalControl()
        {
            InitializeComponent();
            LoadCapitalData();
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblIcon = new Label();
            this.pnlSummary = new Panel();
            this.lblIncome = new Label();
            this.lblExpense = new Label();
            this.lblBalance = new Label();
            this.dgvCapital = new DataGridView();
            this.pnlFooter = new Panel();
            this.btnAdd = new Button();
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
            this.lblIcon.Text = "💰";

            this.lblTitle.Font = new Font("Segoe UI Semibold", 18F);
            this.lblTitle.ForeColor = textColor;
            this.lblTitle.Location = new Point(70, 15);
            this.lblTitle.Size = new Size(300, 35);
            this.lblTitle.Text = "Capital Management";

            this.pnlHeader.Controls.AddRange(new Control[] { lblIcon, lblTitle });

            // Summary Panel
            this.pnlSummary.BackColor = headerBg;
            this.pnlSummary.Dock = DockStyle.Top;
            this.pnlSummary.Size = new Size(800, 60);

            this.lblIncome.Font = new Font("Segoe UI", 12F);
            this.lblIncome.ForeColor = Color.FromArgb(100, 220, 130);
            this.lblIncome.Location = new Point(20, 18);
            this.lblIncome.Size = new Size(200, 25);
            this.lblIncome.Text = "💵 Income: Rp 150,000,000";

            this.lblExpense.Font = new Font("Segoe UI", 12F);
            this.lblExpense.ForeColor = Color.FromArgb(255, 100, 100);
            this.lblExpense.Location = new Point(250, 18);
            this.lblExpense.Size = new Size(200, 25);
            this.lblExpense.Text = "💸 Expense: Rp 75,000,000";

            this.lblBalance.Font = new Font("Segoe UI Semibold", 12F);
            this.lblBalance.ForeColor = accentColor;
            this.lblBalance.Location = new Point(500, 18);
            this.lblBalance.Size = new Size(250, 25);
            this.lblBalance.Text = "📊 Balance: Rp 75,000,000";

            this.pnlSummary.Controls.AddRange(new Control[] { lblIncome, lblExpense, lblBalance });

            // DataGridView
            this.dgvCapital.AllowUserToAddRows = false;
            this.dgvCapital.AllowUserToDeleteRows = false;
            this.dgvCapital.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCapital.BackgroundColor = bgColor;
            this.dgvCapital.BorderStyle = BorderStyle.None;
            this.dgvCapital.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCapital.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvCapital.ColumnHeadersHeight = 45;
            this.dgvCapital.DefaultCellStyle.BackColor = cardBg;
            this.dgvCapital.DefaultCellStyle.ForeColor = textColor;
            this.dgvCapital.DefaultCellStyle.SelectionBackColor = accentColor;
            this.dgvCapital.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvCapital.Dock = DockStyle.Fill;
            this.dgvCapital.EnableHeadersVisualStyles = false;
            this.dgvCapital.GridColor = Color.FromArgb(60, 100, 110);
            this.dgvCapital.ColumnHeadersDefaultCellStyle.BackColor = headerBg;
            this.dgvCapital.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(180, 200, 210);
            this.dgvCapital.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F);
            this.dgvCapital.ReadOnly = true;
            this.dgvCapital.RowHeadersVisible = false;
            this.dgvCapital.RowTemplate.Height = 45;
            this.dgvCapital.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCapital.AlternatingRowsDefaultCellStyle.BackColor = rowAlt;

            // Footer
            this.pnlFooter.BackColor = headerBg;
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Size = new Size(800, 60);

            CreateButton(btnAdd, "➕ Add Transaction", Color.FromArgb(0, 150, 136), 20);
            btnAdd.Size = new Size(150, 36);
            CreateButton(btnRefresh, "🔄", Color.FromArgb(100, 130, 140), 180);
            btnRefresh.Size = new Size(45, 36);

            this.lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.lblStatus.Font = new Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = Color.FromArgb(100, 220, 130);
            this.lblStatus.Location = new Point(500, 20);
            this.lblStatus.Size = new Size(280, 20);
            this.lblStatus.Text = "● System Online | " + DateTime.Now.ToString("HH:mm");
            this.lblStatus.TextAlign = ContentAlignment.MiddleRight;

            btnRefresh.Click += (s, e) => LoadCapitalData();

            this.pnlFooter.Controls.AddRange(new Control[] { btnAdd, btnRefresh, lblStatus });

            this.Controls.Add(dgvCapital);
            this.Controls.Add(pnlSummary);
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

        public void LoadCapitalData()
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT transaction_id as 'ID', type as 'Type', category as 'Category', 
                                   amount as 'Amount', date as 'Date', description as 'Description' 
                                   FROM capital ORDER BY date DESC";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    capitalDataTable = new DataTable();
                    adapter.Fill(capitalDataTable);
                    dgvCapital.DataSource = capitalDataTable;
                }
            }
            catch { LoadSampleData(); }
        }

        private void LoadSampleData()
        {
            capitalDataTable = new DataTable();
            capitalDataTable.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID"), new DataColumn("Type"), new DataColumn("Category"),
                new DataColumn("Amount"), new DataColumn("Date"), new DataColumn("Description")
            });

            capitalDataTable.Rows.Add("TRX-001", "Income", "Patient Fee", "Rp 5,000,000", "2026-01-20", "Consultation Fee");
            capitalDataTable.Rows.Add("TRX-002", "Expense", "Medicine", "Rp 2,500,000", "2026-01-19", "Monthly Supply");
            capitalDataTable.Rows.Add("TRX-003", "Income", "Lab Test", "Rp 3,000,000", "2026-01-18", "Lab Services");
            capitalDataTable.Rows.Add("TRX-004", "Expense", "Utilities", "Rp 1,500,000", "2026-01-17", "Electricity Bill");
            capitalDataTable.Rows.Add("TRX-005", "Income", "Surgery", "Rp 15,000,000", "2026-01-16", "Surgery Fee");

            dgvCapital.DataSource = capitalDataTable;
        }

        private Panel pnlHeader, pnlSummary, pnlFooter;
        private Label lblTitle, lblIcon, lblIncome, lblExpense, lblBalance, lblStatus;
        private DataGridView dgvCapital;
        private Button btnAdd, btnRefresh;
    }
}
