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
        private bool isEditMode = false;
        private string editingId = "";

        private Color bgColor = Color.FromArgb(38, 70, 77);
        private Color headerBg = Color.FromArgb(29, 53, 58);
        private Color cardBg = Color.FromArgb(45, 85, 93);
        private Color accentColor = Color.FromArgb(0, 173, 181);
        private Color textColor = Color.White;
        private Color rowAlt = Color.FromArgb(52, 95, 105);
        private Color formBg = Color.FromArgb(35, 65, 72);

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
            this.btnExport = new Button();
            this.btnRefresh = new Button();
            this.lblStatus = new Label();
            
            this.pnlForm = new Panel();
            this.lblFormTitle = new Label();
            this.txtUnitName = new TextBox();
            this.cmbType = new ComboBox();
            this.txtFloor = new TextBox();
            this.txtCapacity = new TextBox();
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

            // Form Panel
            this.pnlForm.BackColor = formBg;
            this.pnlForm.Dock = DockStyle.Top;
            this.pnlForm.Size = new Size(800, 140);
            this.pnlForm.Visible = false;

            this.lblFormTitle.Font = new Font("Segoe UI Semibold", 14F);
            this.lblFormTitle.ForeColor = accentColor;
            this.lblFormTitle.Location = new Point(20, 10);
            this.lblFormTitle.Size = new Size(300, 25);
            this.lblFormTitle.Text = "Add New Unit";

            CreateFormLabel("Name:", 20, 45, 50);
            this.txtUnitName.BackColor = cardBg;
            this.txtUnitName.BorderStyle = BorderStyle.FixedSingle;
            this.txtUnitName.Font = new Font("Segoe UI", 10F);
            this.txtUnitName.ForeColor = textColor;
            this.txtUnitName.Location = new Point(75, 42);
            this.txtUnitName.Size = new Size(160, 25);

            CreateFormLabel("Type:", 250, 45, 40);
            this.cmbType.BackColor = cardBg;
            this.cmbType.FlatStyle = FlatStyle.Flat;
            this.cmbType.Font = new Font("Segoe UI", 10F);
            this.cmbType.ForeColor = textColor;
            this.cmbType.Location = new Point(295, 42);
            this.cmbType.Size = new Size(130, 25);
            this.cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbType.Items.AddRange(new object[] { "Emergency", "Intensive Care", "General", "Pediatric", "Surgery", "Diagnostic", "Outpatient" });

            CreateFormLabel("Floor:", 440, 45, 45);
            this.txtFloor.BackColor = cardBg;
            this.txtFloor.BorderStyle = BorderStyle.FixedSingle;
            this.txtFloor.Font = new Font("Segoe UI", 10F);
            this.txtFloor.ForeColor = textColor;
            this.txtFloor.Location = new Point(490, 42);
            this.txtFloor.Size = new Size(50, 25);

            CreateFormLabel("Capacity:", 555, 45, 65);
            this.txtCapacity.BackColor = cardBg;
            this.txtCapacity.BorderStyle = BorderStyle.FixedSingle;
            this.txtCapacity.Font = new Font("Segoe UI", 10F);
            this.txtCapacity.ForeColor = textColor;
            this.txtCapacity.Location = new Point(625, 42);
            this.txtCapacity.Size = new Size(50, 25);

            CreateFormLabel("Status:", 20, 80, 50);
            this.cmbStatus.BackColor = cardBg;
            this.cmbStatus.FlatStyle = FlatStyle.Flat;
            this.cmbStatus.Font = new Font("Segoe UI", 10F);
            this.cmbStatus.ForeColor = textColor;
            this.cmbStatus.Location = new Point(75, 77);
            this.cmbStatus.Size = new Size(100, 25);
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] { "Active", "Inactive", "Maintenance" });

            CreateFormButton(btnCancel, "Cancel", Color.FromArgb(100, 100, 110), 450, 95);
            CreateFormButton(btnClear, "Clear", Color.FromArgb(80, 130, 140), 560, 95);
            CreateFormButton(btnSave, "Save", Color.FromArgb(0, 150, 136), 670, 95);

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnClear.Click += BtnClear_Click;

            this.pnlForm.Controls.AddRange(new Control[] { lblFormTitle, txtUnitName, cmbType, txtFloor, txtCapacity, cmbStatus, btnSave, btnCancel, btnClear });

            // DataGridView
            SetupDataGridView();

            // Footer
            this.pnlFooter.BackColor = headerBg;
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Size = new Size(800, 60);

            CreateButton(btnAdd, "➕ Add", Color.FromArgb(0, 150, 136), 20);
            CreateButton(btnEdit, "✏️ Edit", Color.FromArgb(33, 150, 243), 120);
            CreateButton(btnDelete, "🗑️ Delete", Color.FromArgb(211, 47, 47), 220);
            CreateButton(btnExport, "📊 Export", Color.FromArgb(40, 167, 69), 330);
            CreateButton(btnRefresh, "🔄", Color.FromArgb(100, 130, 140), 440);
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
            btnExport.Click += (s, ev) => ExcelHelper.ExportToExcel(dgvUnits, "Unit_Data");
            btnRefresh.Click += (s, e) => LoadUnitData();

            this.pnlFooter.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete, btnExport, btnRefresh, lblStatus });

            this.Controls.Add(dgvUnits);
            this.Controls.Add(pnlForm);
            this.Controls.Add(pnlSearch);
            this.Controls.Add(pnlHeader);
            this.Controls.Add(pnlFooter);

            this.ResumeLayout(false);
        }

        private void SetupDataGridView()
        {
            this.dgvUnits.AllowUserToAddRows = false;
            this.dgvUnits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUnits.BackgroundColor = bgColor;
            this.dgvUnits.BorderStyle = BorderStyle.None;
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
            this.dgvUnits.RowTemplate.Height = 40;
            this.dgvUnits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnits.AlternatingRowsDefaultCellStyle.BackColor = rowAlt;
            this.dgvUnits.SelectionChanged += DgvUnits_SelectionChanged;
            this.dgvUnits.CellDoubleClick += DgvUnits_CellDoubleClick;
        }

        private void CreateFormLabel(string text, int x, int y, int width) { Label lbl = new Label { Font = new Font("Segoe UI", 10F), ForeColor = Color.FromArgb(180, 200, 210), Location = new Point(x, y), Size = new Size(width, 20), Text = text }; pnlForm.Controls.Add(lbl); }
        private void CreateFormButton(Button btn, string text, Color bg, int x, int y) { btn.BackColor = bg; btn.FlatAppearance.BorderSize = 0; btn.FlatStyle = FlatStyle.Flat; btn.Font = new Font("Segoe UI", 10F); btn.ForeColor = Color.White; btn.Location = new Point(x, y); btn.Size = new Size(100, 35); btn.Text = text; btn.Cursor = Cursors.Hand; }
        private void CreateButton(Button btn, string text, Color bg, int x) { btn.BackColor = bg; btn.FlatAppearance.BorderSize = 0; btn.FlatStyle = FlatStyle.Flat; btn.Font = new Font("Segoe UI", 10F); btn.ForeColor = Color.White; btn.Location = new Point(x, 12); btn.Size = new Size(90, 36); btn.Text = text; btn.Cursor = Cursors.Hand; }

        private void ShowForm(bool editMode, DataGridViewRow row = null)
        {
            isEditMode = editMode;
            pnlForm.Visible = true;
            if (editMode && row != null) { PopulateFormFromRow(row); }
            else { lblFormTitle.Text = "Add New Unit"; ClearForm(); }
        }

        private void DgvUnits_SelectionChanged(object sender, EventArgs e)
        {
            if (pnlForm.Visible && isEditMode && dgvUnits.SelectedRows.Count > 0)
            {
                PopulateFormFromRow(dgvUnits.SelectedRows[0]);
            }
        }

        private void DgvUnits_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUnits.SelectedRows.Count > 0)
            {
                ShowForm(true, dgvUnits.SelectedRows[0]);
            }
        }

        private void PopulateFormFromRow(DataGridViewRow row)
        {
            if (row == null) return;
            lblFormTitle.Text = "Edit Unit";
            editingId = row.Cells["Unit ID"].Value?.ToString() ?? "";
            txtUnitName.Text = row.Cells["Unit Name"].Value?.ToString() ?? "";
            cmbType.SelectedItem = row.Cells["Type"].Value?.ToString() ?? "";
            txtFloor.Text = row.Cells["Floor"].Value?.ToString() ?? "";
            txtCapacity.Text = row.Cells["Capacity"].Value?.ToString() ?? "";
            cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString() ?? "";
        }

        private void HideForm() { pnlForm.Visible = false; ClearForm(); isEditMode = false; }
        private void ClearForm() { txtUnitName.Clear(); cmbType.SelectedIndex = -1; txtFloor.Clear(); txtCapacity.Clear(); cmbStatus.SelectedIndex = -1; }

        private void BtnAdd_Click(object sender, EventArgs e) => ShowForm(false);
        private void BtnEdit_Click(object sender, EventArgs e) { if (dgvUnits.SelectedRows.Count > 0) ShowForm(true, dgvUnits.SelectedRows[0]); else MessageBox.Show("Please select a unit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        private void BtnDelete_Click(object sender, EventArgs e) { if (dgvUnits.SelectedRows.Count > 0 && MessageBox.Show("Delete this unit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) { unitDataTable.Rows[dgvUnits.SelectedRows[0].Index].Delete(); MessageBox.Show("Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); } }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUnitName.Text)) { MessageBox.Show("Please enter unit name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query;
                    MySqlCommand cmd;
                    
                    // Map UI type to DB enum
                    string uiType = cmbType.SelectedItem?.ToString() ?? "ward";
                    string dbType = MapTypeToDbEnum(uiType);
                    
                    // Parse capacity and floor
                    int capacity = 0;
                    int.TryParse(txtCapacity.Text, out capacity);
                    int floor = 0;
                    int.TryParse(txtFloor.Text, out floor);

                    if (isEditMode)
                    {
                        query = @"UPDATE units SET unit_name = @name, unit_type = @type, 
                                  capacity = @capacity, floor_number = @floor, is_active = @active 
                                  WHERE unit_id = @unitId";
                        cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@unitId", editingId);
                    }
                    else
                    {
                        string newUnitId = GenerateUnitId(connection);
                        query = @"INSERT INTO units (unit_id, unit_name, unit_type, capacity, floor_number, is_active) 
                                  VALUES (@unitId, @name, @type, @capacity, @floor, @active)";
                        cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@unitId", newUnitId);
                    }

                    cmd.Parameters.AddWithValue("@name", txtUnitName.Text.Trim());
                    cmd.Parameters.AddWithValue("@type", dbType);
                    cmd.Parameters.AddWithValue("@capacity", capacity);
                    cmd.Parameters.AddWithValue("@floor", floor);
                    cmd.Parameters.AddWithValue("@active", cmbStatus.SelectedItem?.ToString() == "Active" ? 1 : 0);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(isEditMode ? "Updated!" : "Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUnitData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            HideForm();
        }

        private string MapTypeToDbEnum(string uiType)
        {
            switch (uiType)
            {
                case "Emergency": return "emergency";
                case "Intensive Care": return "icu";
                case "General": return "ward";
                case "Pediatric": return "ward";
                case "Surgery": return "ot";
                case "Diagnostic": return "laboratory";
                case "Outpatient": return "outpatient";
                default: return "ward";
            }
        }

        private string GenerateUnitId(MySqlConnection connection)
        {
            try
            {
                string query = "SELECT MAX(CAST(SUBSTRING(unit_id, 6) AS UNSIGNED)) FROM units WHERE unit_id LIKE 'UNIT-%'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                object result = cmd.ExecuteScalar();
                int nextNum = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) + 1 : 1;
                return $"UNIT-{nextNum:000}";
            }
            catch { return $"UNIT-{DateTime.Now:yyyyMMddHHmmss}"; }
        }

        private void BtnCancel_Click(object sender, EventArgs e) => HideForm();
        private void BtnClear_Click(object sender, EventArgs e) => ClearForm();

        public void LoadUnitData()
        {
            try { using (var conn = DatabaseHelper.Instance.GetConnection()) { conn.Open(); MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT unit_id as 'Unit ID', unit_name as 'Unit Name', unit_type as 'Type', floor_number as 'Floor', capacity as 'Capacity', CASE WHEN is_active = 1 THEN 'Active' ELSE 'Inactive' END as 'Status' FROM units ORDER BY unit_id", conn); unitDataTable = new DataTable(); adapter.Fill(unitDataTable); dgvUnits.DataSource = unitDataTable; } }
            catch (Exception ex) { MessageBox.Show($"Error loading data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error); LoadSampleData(); }
        }

        private void LoadSampleData()
        {
            unitDataTable = new DataTable();
            unitDataTable.Columns.AddRange(new DataColumn[] { new DataColumn("Unit ID"), new DataColumn("Unit Name"), new DataColumn("Type"), new DataColumn("Floor"), new DataColumn("Capacity"), new DataColumn("Status") });
            unitDataTable.Rows.Add("UNIT-001", "Emergency Room", "Emergency", "1", "20", "Active");
            unitDataTable.Rows.Add("UNIT-002", "ICU Ward", "Intensive Care", "2", "15", "Active");
            unitDataTable.Rows.Add("UNIT-003", "General Ward A", "General", "3", "50", "Active");
            unitDataTable.Rows.Add("UNIT-004", "Pediatric Ward", "Pediatric", "4", "30", "Active");
            unitDataTable.Rows.Add("UNIT-005", "Operation Theatre", "Surgery", "2", "5", "Active");
            dgvUnits.DataSource = unitDataTable;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e) { if (unitDataTable != null) { string filter = txtSearch.Text.Replace("'", "''"); unitDataTable.DefaultView.RowFilter = $"[Unit Name] LIKE '%{filter}%' OR Type LIKE '%{filter}%'"; } }

        private Panel pnlHeader, pnlSearch, pnlFooter, pnlForm;
        private Label lblTitle, lblIcon, lblSearchLabel, lblStatus, lblFormTitle;
        private TextBox txtSearch, txtUnitName, txtFloor, txtCapacity;
        private ComboBox cmbType, cmbStatus;
        private DataGridView dgvUnits;
        private Button btnAdd, btnEdit, btnDelete, btnExport, btnRefresh, btnSave, btnCancel, btnClear;
    }
}
