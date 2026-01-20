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
        private bool isEditMode = false;
        private string editingId = "";

        private Color bgColor = Color.FromArgb(38, 70, 77);
        private Color headerBg = Color.FromArgb(29, 53, 58);
        private Color cardBg = Color.FromArgb(45, 85, 93);
        private Color accentColor = Color.FromArgb(0, 173, 181);
        private Color textColor = Color.White;
        private Color rowAlt = Color.FromArgb(52, 95, 105);
        private Color formBg = Color.FromArgb(35, 65, 72);

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
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnRefresh = new Button();
            this.lblStatus = new Label();
            
            this.pnlForm = new Panel();
            this.lblFormTitle = new Label();
            this.cmbType = new ComboBox();
            this.txtCategory = new TextBox();
            this.txtAmount = new TextBox();
            this.dtpDate = new DateTimePicker();
            this.txtDescription = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.btnClear = new Button();

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
            this.pnlSummary.Size = new Size(800, 50);

            this.lblIncome.Font = new Font("Segoe UI", 11F);
            this.lblIncome.ForeColor = Color.FromArgb(100, 220, 130);
            this.lblIncome.Location = new Point(20, 15);
            this.lblIncome.Size = new Size(200, 22);
            this.lblIncome.Text = "💵 Income: Rp 0";

            this.lblExpense.Font = new Font("Segoe UI", 11F);
            this.lblExpense.ForeColor = Color.FromArgb(255, 100, 100);
            this.lblExpense.Location = new Point(250, 15);
            this.lblExpense.Size = new Size(200, 22);
            this.lblExpense.Text = "💸 Expense: Rp 0";

            this.lblBalance.Font = new Font("Segoe UI Semibold", 11F);
            this.lblBalance.ForeColor = accentColor;
            this.lblBalance.Location = new Point(480, 15);
            this.lblBalance.Size = new Size(200, 22);
            this.lblBalance.Text = "📊 Balance: Rp 0";

            this.pnlSummary.Controls.AddRange(new Control[] { lblIncome, lblExpense, lblBalance });

            // Form Panel
            this.pnlForm.BackColor = formBg;
            this.pnlForm.Dock = DockStyle.Top;
            this.pnlForm.Size = new Size(800, 140);
            this.pnlForm.Visible = false;

            this.lblFormTitle.Font = new Font("Segoe UI Semibold", 14F);
            this.lblFormTitle.ForeColor = accentColor;
            this.lblFormTitle.Location = new Point(20, 10);
            this.lblFormTitle.Size = new Size(300, 25);
            this.lblFormTitle.Text = "Add Transaction";

            CreateFormLabel("Type:", 20, 45, 45);
            this.cmbType.BackColor = cardBg;
            this.cmbType.FlatStyle = FlatStyle.Flat;
            this.cmbType.Font = new Font("Segoe UI", 10F);
            this.cmbType.ForeColor = textColor;
            this.cmbType.Location = new Point(70, 42);
            this.cmbType.Size = new Size(100, 25);
            this.cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbType.Items.AddRange(new object[] { "Income", "Expense" });

            CreateFormLabel("Category:", 185, 45, 70);
            this.txtCategory.BackColor = cardBg;
            this.txtCategory.BorderStyle = BorderStyle.FixedSingle;
            this.txtCategory.Font = new Font("Segoe UI", 10F);
            this.txtCategory.ForeColor = textColor;
            this.txtCategory.Location = new Point(260, 42);
            this.txtCategory.Size = new Size(120, 25);

            CreateFormLabel("Amount:", 395, 45, 60);
            this.txtAmount.BackColor = cardBg;
            this.txtAmount.BorderStyle = BorderStyle.FixedSingle;
            this.txtAmount.Font = new Font("Segoe UI", 10F);
            this.txtAmount.ForeColor = textColor;
            this.txtAmount.Location = new Point(460, 42);
            this.txtAmount.Size = new Size(120, 25);

            CreateFormLabel("Date:", 595, 45, 40);
            this.dtpDate.Font = new Font("Segoe UI", 10F);
            this.dtpDate.Location = new Point(640, 42);
            this.dtpDate.Size = new Size(130, 25);
            this.dtpDate.Format = DateTimePickerFormat.Short;

            CreateFormLabel("Desc:", 20, 80, 45);
            this.txtDescription.BackColor = cardBg;
            this.txtDescription.BorderStyle = BorderStyle.FixedSingle;
            this.txtDescription.Font = new Font("Segoe UI", 10F);
            this.txtDescription.ForeColor = textColor;
            this.txtDescription.Location = new Point(70, 77);
            this.txtDescription.Size = new Size(310, 25);

            CreateFormButton(btnCancel, "Cancel", Color.FromArgb(100, 100, 110), 450, 95);
            CreateFormButton(btnClear, "Clear", Color.FromArgb(80, 130, 140), 560, 95);
            CreateFormButton(btnSave, "Save", Color.FromArgb(0, 150, 136), 670, 95);

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnClear.Click += BtnClear_Click;

            this.pnlForm.Controls.AddRange(new Control[] { lblFormTitle, cmbType, txtCategory, txtAmount, dtpDate, txtDescription, btnSave, btnCancel, btnClear });

            // DataGridView
            SetupDataGridView();

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

            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnRefresh.Click += (s, e) => LoadCapitalData();

            this.pnlFooter.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete, btnRefresh, lblStatus });

            this.Controls.Add(dgvCapital);
            this.Controls.Add(pnlForm);
            this.Controls.Add(pnlSummary);
            this.Controls.Add(pnlHeader);
            this.Controls.Add(pnlFooter);

            this.ResumeLayout(false);
        }

        private void SetupDataGridView()
        {
            this.dgvCapital.AllowUserToAddRows = false;
            this.dgvCapital.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCapital.BackgroundColor = bgColor;
            this.dgvCapital.BorderStyle = BorderStyle.None;
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
            this.dgvCapital.RowTemplate.Height = 40;
            this.dgvCapital.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCapital.AlternatingRowsDefaultCellStyle.BackColor = rowAlt;
        }

        private void CreateFormLabel(string text, int x, int y, int width) { Label lbl = new Label { Font = new Font("Segoe UI", 10F), ForeColor = Color.FromArgb(180, 200, 210), Location = new Point(x, y), Size = new Size(width, 20), Text = text }; pnlForm.Controls.Add(lbl); }
        private void CreateFormButton(Button btn, string text, Color bg, int x, int y) { btn.BackColor = bg; btn.FlatAppearance.BorderSize = 0; btn.FlatStyle = FlatStyle.Flat; btn.Font = new Font("Segoe UI", 10F); btn.ForeColor = Color.White; btn.Location = new Point(x, y); btn.Size = new Size(100, 35); btn.Text = text; btn.Cursor = Cursors.Hand; }
        private void CreateButton(Button btn, string text, Color bg, int x) { btn.BackColor = bg; btn.FlatAppearance.BorderSize = 0; btn.FlatStyle = FlatStyle.Flat; btn.Font = new Font("Segoe UI", 10F); btn.ForeColor = Color.White; btn.Location = new Point(x, 12); btn.Size = new Size(90, 36); btn.Text = text; btn.Cursor = Cursors.Hand; }

        private void ShowForm(bool editMode, DataGridViewRow row = null)
        {
            isEditMode = editMode;
            pnlForm.Visible = true;
            if (editMode && row != null)
            {
                lblFormTitle.Text = "Edit Transaction";
                editingId = row.Cells["ID"].Value?.ToString() ?? "";
                cmbType.SelectedItem = row.Cells["Type"].Value?.ToString() ?? "";
                txtCategory.Text = row.Cells["Category"].Value?.ToString() ?? "";
                txtAmount.Text = row.Cells["Amount"].Value?.ToString().Replace("Rp ", "").Replace(",", "") ?? "";
                txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";
            }
            else { lblFormTitle.Text = "Add Transaction"; ClearForm(); }
        }

        private void HideForm() { pnlForm.Visible = false; ClearForm(); isEditMode = false; }
        private void ClearForm() { cmbType.SelectedIndex = -1; txtCategory.Clear(); txtAmount.Clear(); dtpDate.Value = DateTime.Now; txtDescription.Clear(); }

        private void BtnAdd_Click(object sender, EventArgs e) => ShowForm(false);
        private void BtnEdit_Click(object sender, EventArgs e) { if (dgvCapital.SelectedRows.Count > 0) ShowForm(true, dgvCapital.SelectedRows[0]); else MessageBox.Show("Please select a transaction.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        private void BtnDelete_Click(object sender, EventArgs e) { if (dgvCapital.SelectedRows.Count > 0 && MessageBox.Show("Delete this transaction?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) { capitalDataTable.Rows[dgvCapital.SelectedRows[0].Index].Delete(); UpdateSummary(); MessageBox.Show("Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); } }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex < 0) { MessageBox.Show("Please select type.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            string amountStr = "Rp " + txtAmount.Text;
            if (isEditMode) { foreach (DataRow row in capitalDataTable.Rows) { if (row["ID"].ToString() == editingId) { row["Type"] = cmbType.SelectedItem.ToString(); row["Category"] = txtCategory.Text; row["Amount"] = amountStr; row["Date"] = dtpDate.Value.ToString("yyyy-MM-dd"); row["Description"] = txtDescription.Text; break; } } MessageBox.Show("Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else { string newId = "TRX-" + (capitalDataTable.Rows.Count + 1).ToString("000"); capitalDataTable.Rows.Add(newId, cmbType.SelectedItem.ToString(), txtCategory.Text, amountStr, dtpDate.Value.ToString("yyyy-MM-dd"), txtDescription.Text); MessageBox.Show("Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            UpdateSummary(); HideForm();
        }

        private void UpdateSummary()
        {
            decimal income = 0, expense = 0;
            foreach (DataRow row in capitalDataTable.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                string amtStr = row["Amount"].ToString().Replace("Rp ", "").Replace(",", "");
                decimal.TryParse(amtStr, out decimal amt);
                if (row["Type"].ToString() == "Income") income += amt;
                else expense += amt;
            }
            lblIncome.Text = $"💵 Income: Rp {income:N0}";
            lblExpense.Text = $"💸 Expense: Rp {expense:N0}";
            lblBalance.Text = $"📊 Balance: Rp {(income - expense):N0}";
        }

        private void BtnCancel_Click(object sender, EventArgs e) => HideForm();
        private void BtnClear_Click(object sender, EventArgs e) => ClearForm();

        public void LoadCapitalData()
        {
            try { using (var conn = DatabaseHelper.Instance.GetConnection()) { conn.Open(); MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT transaction_id as 'ID', type as 'Type', category as 'Category', amount as 'Amount', date as 'Date', description as 'Description' FROM capital", conn); capitalDataTable = new DataTable(); adapter.Fill(capitalDataTable); dgvCapital.DataSource = capitalDataTable; } }
            catch { LoadSampleData(); }
            UpdateSummary();
        }

        private void LoadSampleData()
        {
            capitalDataTable = new DataTable();
            capitalDataTable.Columns.AddRange(new DataColumn[] { new DataColumn("ID"), new DataColumn("Type"), new DataColumn("Category"), new DataColumn("Amount"), new DataColumn("Date"), new DataColumn("Description") });
            capitalDataTable.Rows.Add("TRX-001", "Income", "Patient Fee", "Rp 5000000", "2026-01-20", "Consultation");
            capitalDataTable.Rows.Add("TRX-002", "Expense", "Medicine", "Rp 2500000", "2026-01-19", "Supply");
            capitalDataTable.Rows.Add("TRX-003", "Income", "Lab Test", "Rp 3000000", "2026-01-18", "Services");
            capitalDataTable.Rows.Add("TRX-004", "Expense", "Utilities", "Rp 1500000", "2026-01-17", "Electric");
            dgvCapital.DataSource = capitalDataTable;
        }

        private Panel pnlHeader, pnlSummary, pnlFooter, pnlForm;
        private Label lblTitle, lblIcon, lblIncome, lblExpense, lblBalance, lblStatus, lblFormTitle;
        private TextBox txtCategory, txtAmount, txtDescription;
        private DateTimePicker dtpDate;
        private ComboBox cmbType;
        private DataGridView dgvCapital;
        private Button btnAdd, btnEdit, btnDelete, btnRefresh, btnSave, btnCancel, btnClear;
    }
}
