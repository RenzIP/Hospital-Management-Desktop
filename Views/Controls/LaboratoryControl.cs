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
        private bool isEditMode = false;
        private string editingLabId = "";

        private Color bgColor = Color.FromArgb(38, 70, 77);
        private Color headerBg = Color.FromArgb(29, 53, 58);
        private Color cardBg = Color.FromArgb(45, 85, 93);
        private Color accentColor = Color.FromArgb(0, 173, 181);
        private Color textColor = Color.White;
        private Color rowAlt = Color.FromArgb(52, 95, 105);
        private Color formBg = Color.FromArgb(35, 65, 72);

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
            
            this.pnlForm = new Panel();
            this.lblFormTitle = new Label();
            this.txtTestName = new TextBox();
            this.txtPatient = new TextBox();
            this.dtpDate = new DateTimePicker();
            this.cmbStatus = new ComboBox();
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

            // Form Panel
            this.pnlForm.BackColor = formBg;
            this.pnlForm.Dock = DockStyle.Top;
            this.pnlForm.Size = new Size(800, 140);
            this.pnlForm.Visible = false;

            this.lblFormTitle.Font = new Font("Segoe UI Semibold", 14F);
            this.lblFormTitle.ForeColor = accentColor;
            this.lblFormTitle.Location = new Point(20, 10);
            this.lblFormTitle.Size = new Size(300, 25);
            this.lblFormTitle.Text = "Add New Lab Test";

            CreateFormLabel("Test Name:", 20, 45, 80);
            this.txtTestName.BackColor = cardBg;
            this.txtTestName.BorderStyle = BorderStyle.FixedSingle;
            this.txtTestName.Font = new Font("Segoe UI", 10F);
            this.txtTestName.ForeColor = textColor;
            this.txtTestName.Location = new Point(105, 42);
            this.txtTestName.Size = new Size(150, 25);

            CreateFormLabel("Patient:", 270, 45, 55);
            this.txtPatient.BackColor = cardBg;
            this.txtPatient.BorderStyle = BorderStyle.FixedSingle;
            this.txtPatient.Font = new Font("Segoe UI", 10F);
            this.txtPatient.ForeColor = textColor;
            this.txtPatient.Location = new Point(330, 42);
            this.txtPatient.Size = new Size(150, 25);

            CreateFormLabel("Date:", 495, 45, 40);
            this.dtpDate.Font = new Font("Segoe UI", 10F);
            this.dtpDate.Location = new Point(540, 42);
            this.dtpDate.Size = new Size(150, 25);
            this.dtpDate.Format = DateTimePickerFormat.Short;

            CreateFormLabel("Status:", 20, 80, 55);
            this.cmbStatus.BackColor = cardBg;
            this.cmbStatus.FlatStyle = FlatStyle.Flat;
            this.cmbStatus.Font = new Font("Segoe UI", 10F);
            this.cmbStatus.ForeColor = textColor;
            this.cmbStatus.Location = new Point(80, 77);
            this.cmbStatus.Size = new Size(120, 25);
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] { "Pending", "In Progress", "Completed" });

            CreateFormButton(btnCancel, "Cancel", Color.FromArgb(100, 100, 110), 450, 95);
            CreateFormButton(btnClear, "Clear", Color.FromArgb(80, 130, 140), 560, 95);
            CreateFormButton(btnSave, "Save", Color.FromArgb(0, 150, 136), 670, 95);

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnClear.Click += BtnClear_Click;

            this.pnlForm.Controls.AddRange(new Control[] { lblFormTitle, txtTestName, txtPatient, dtpDate, cmbStatus, btnSave, btnCancel, btnClear });

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
            btnRefresh.Click += (s, e) => LoadLabData();

            this.pnlFooter.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete, btnRefresh, lblStatus });

            this.Controls.Add(dgvLaboratory);
            this.Controls.Add(pnlForm);
            this.Controls.Add(pnlSearch);
            this.Controls.Add(pnlHeader);
            this.Controls.Add(pnlFooter);

            this.ResumeLayout(false);
        }

        private void SetupDataGridView()
        {
            this.dgvLaboratory.AllowUserToAddRows = false;
            this.dgvLaboratory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLaboratory.BackgroundColor = bgColor;
            this.dgvLaboratory.BorderStyle = BorderStyle.None;
            this.dgvLaboratory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvLaboratory.ColumnHeadersHeight = 45;
            this.dgvLaboratory.DefaultCellStyle.BackColor = cardBg;
            this.dgvLaboratory.DefaultCellStyle.ForeColor = textColor;
            this.dgvLaboratory.DefaultCellStyle.SelectionBackColor = accentColor;
            this.dgvLaboratory.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvLaboratory.Dock = DockStyle.Fill;
            this.dgvLaboratory.EnableHeadersVisualStyles = false;
            this.dgvLaboratory.GridColor = Color.FromArgb(60, 100, 110);
            this.dgvLaboratory.ColumnHeadersDefaultCellStyle.BackColor = headerBg;
            this.dgvLaboratory.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(180, 200, 210);
            this.dgvLaboratory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F);
            this.dgvLaboratory.ReadOnly = true;
            this.dgvLaboratory.RowHeadersVisible = false;
            this.dgvLaboratory.RowTemplate.Height = 40;
            this.dgvLaboratory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvLaboratory.AlternatingRowsDefaultCellStyle.BackColor = rowAlt;
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
                lblFormTitle.Text = "Edit Lab Test";
                editingLabId = row.Cells["Lab ID"].Value?.ToString() ?? "";
                txtTestName.Text = row.Cells["Test Name"].Value?.ToString() ?? "";
                txtPatient.Text = row.Cells["Patient"].Value?.ToString() ?? "";
                cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString() ?? "";
            }
            else { lblFormTitle.Text = "Add New Lab Test"; ClearForm(); }
        }

        private void HideForm() { pnlForm.Visible = false; ClearForm(); isEditMode = false; }
        private void ClearForm() { txtTestName.Clear(); txtPatient.Clear(); dtpDate.Value = DateTime.Now; cmbStatus.SelectedIndex = -1; }

        private void BtnAdd_Click(object sender, EventArgs e) => ShowForm(false);
        private void BtnEdit_Click(object sender, EventArgs e) { if (dgvLaboratory.SelectedRows.Count > 0) ShowForm(true, dgvLaboratory.SelectedRows[0]); else MessageBox.Show("Please select a test.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        private void BtnDelete_Click(object sender, EventArgs e) { if (dgvLaboratory.SelectedRows.Count > 0 && MessageBox.Show("Delete this test?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) { labDataTable.Rows[dgvLaboratory.SelectedRows[0].Index].Delete(); MessageBox.Show("Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); } }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTestName.Text)) { MessageBox.Show("Please enter test name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (isEditMode) { foreach (DataRow row in labDataTable.Rows) { if (row["Lab ID"].ToString() == editingLabId) { row["Test Name"] = txtTestName.Text; row["Patient"] = txtPatient.Text; row["Date"] = dtpDate.Value.ToString("yyyy-MM-dd"); row["Status"] = cmbStatus.SelectedItem?.ToString() ?? "Pending"; break; } } MessageBox.Show("Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else { string newId = "LAB-" + (labDataTable.Rows.Count + 1).ToString("000"); labDataTable.Rows.Add(newId, txtTestName.Text, txtPatient.Text, dtpDate.Value.ToString("yyyy-MM-dd"), cmbStatus.SelectedItem?.ToString() ?? "Pending"); MessageBox.Show("Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            HideForm();
        }

        private void BtnCancel_Click(object sender, EventArgs e) => HideForm();
        private void BtnClear_Click(object sender, EventArgs e) => ClearForm();

        public void LoadLabData()
        {
            try { using (var conn = DatabaseHelper.Instance.GetConnection()) { conn.Open(); MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT lab_id as 'Lab ID', test_name as 'Test Name', patient_name as 'Patient', test_date as 'Date', status as 'Status' FROM laboratory", conn); labDataTable = new DataTable(); adapter.Fill(labDataTable); dgvLaboratory.DataSource = labDataTable; } }
            catch { LoadSampleData(); }
        }

        private void LoadSampleData()
        {
            labDataTable = new DataTable();
            labDataTable.Columns.AddRange(new DataColumn[] { new DataColumn("Lab ID"), new DataColumn("Test Name"), new DataColumn("Patient"), new DataColumn("Date"), new DataColumn("Status") });
            labDataTable.Rows.Add("LAB-001", "Blood Test", "Ahmad Malik", "2026-01-20", "Completed");
            labDataTable.Rows.Add("LAB-002", "X-Ray", "Fatima Khan", "2026-01-19", "Pending");
            labDataTable.Rows.Add("LAB-003", "CT Scan", "Ali Hassan", "2026-01-18", "In Progress");
            labDataTable.Rows.Add("LAB-004", "MRI", "Sara Ahmed", "2026-01-17", "Completed");
            dgvLaboratory.DataSource = labDataTable;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e) { if (labDataTable != null) { string filter = txtSearch.Text.Replace("'", "''"); labDataTable.DefaultView.RowFilter = $"[Test Name] LIKE '%{filter}%' OR Patient LIKE '%{filter}%'"; } }

        private Panel pnlHeader, pnlSearch, pnlFooter, pnlForm;
        private Label lblTitle, lblIcon, lblSearchLabel, lblStatus, lblFormTitle;
        private TextBox txtSearch, txtTestName, txtPatient;
        private DateTimePicker dtpDate;
        private ComboBox cmbStatus;
        private DataGridView dgvLaboratory;
        private Button btnAdd, btnEdit, btnDelete, btnRefresh, btnSave, btnCancel, btnClear;
    }
}
