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
        private bool isEditMode = false;
        private string editingStaffId = "";

        private Color bgColor = Color.FromArgb(38, 70, 77);
        private Color headerBg = Color.FromArgb(29, 53, 58);
        private Color cardBg = Color.FromArgb(45, 85, 93);
        private Color accentColor = Color.FromArgb(0, 173, 181);
        private Color textColor = Color.White;
        private Color rowAlt = Color.FromArgb(52, 95, 105);
        private Color formBg = Color.FromArgb(35, 65, 72);

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
            
            // Form Panel
            this.pnlForm = new Panel();
            this.lblFormTitle = new Label();
            this.txtName = new TextBox();
            this.txtCNIC = new TextBox();
            this.txtPhone = new TextBox();
            this.txtEmail = new TextBox();
            this.cmbDepartment = new ComboBox();
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

            // Form Panel (initially hidden)
            this.pnlForm.BackColor = formBg;
            this.pnlForm.Dock = DockStyle.Top;
            this.pnlForm.Size = new Size(800, 180);
            this.pnlForm.Visible = false;
            this.pnlForm.Padding = new Padding(20, 10, 20, 10);

            // Form Title
            this.lblFormTitle.Font = new Font("Segoe UI Semibold", 14F);
            this.lblFormTitle.ForeColor = accentColor;
            this.lblFormTitle.Location = new Point(20, 10);
            this.lblFormTitle.Size = new Size(300, 25);
            this.lblFormTitle.Text = "Add New Staff";

            // Form fields - Row 1
            CreateFormLabel("Name:", 20, 45, 60);
            this.txtName.BackColor = cardBg;
            this.txtName.BorderStyle = BorderStyle.FixedSingle;
            this.txtName.Font = new Font("Segoe UI", 10F);
            this.txtName.ForeColor = textColor;
            this.txtName.Location = new Point(80, 42);
            this.txtName.Size = new Size(180, 25);

            CreateFormLabel("CNIC:", 280, 45, 50);
            this.txtCNIC.BackColor = cardBg;
            this.txtCNIC.BorderStyle = BorderStyle.FixedSingle;
            this.txtCNIC.Font = new Font("Segoe UI", 10F);
            this.txtCNIC.ForeColor = textColor;
            this.txtCNIC.Location = new Point(330, 42);
            this.txtCNIC.Size = new Size(150, 25);

            CreateFormLabel("Phone:", 500, 45, 50);
            this.txtPhone.BackColor = cardBg;
            this.txtPhone.BorderStyle = BorderStyle.FixedSingle;
            this.txtPhone.Font = new Font("Segoe UI", 10F);
            this.txtPhone.ForeColor = textColor;
            this.txtPhone.Location = new Point(555, 42);
            this.txtPhone.Size = new Size(150, 25);

            // Form fields - Row 2
            CreateFormLabel("Email:", 20, 80, 60);
            this.txtEmail.BackColor = cardBg;
            this.txtEmail.BorderStyle = BorderStyle.FixedSingle;
            this.txtEmail.Font = new Font("Segoe UI", 10F);
            this.txtEmail.ForeColor = textColor;
            this.txtEmail.Location = new Point(80, 77);
            this.txtEmail.Size = new Size(200, 25);

            CreateFormLabel("Dept:", 300, 80, 45);
            this.cmbDepartment.BackColor = cardBg;
            this.cmbDepartment.FlatStyle = FlatStyle.Flat;
            this.cmbDepartment.Font = new Font("Segoe UI", 10F);
            this.cmbDepartment.ForeColor = textColor;
            this.cmbDepartment.Location = new Point(350, 77);
            this.cmbDepartment.Size = new Size(150, 25);
            this.cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbDepartment.Items.AddRange(new object[] { "Cardiology", "Neurology", "Orthopedics", "Pediatrics", "ICU", "Dermatology", "Surgery", "Radiology", "Emergency", "General" });

            // Form Buttons
            CreateFormButton(btnCancel, "Cancel", Color.FromArgb(100, 100, 110), 450, 130);
            CreateFormButton(btnClear, "Clear", Color.FromArgb(80, 130, 140), 560, 130);
            CreateFormButton(btnSave, "Save", Color.FromArgb(0, 150, 136), 670, 130);

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnClear.Click += BtnClear_Click;

            this.pnlForm.Controls.AddRange(new Control[] { lblFormTitle, txtName, txtCNIC, txtPhone, txtEmail, cmbDepartment, btnSave, btnCancel, btnClear });

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
            this.dgvStaff.RowTemplate.Height = 40;
            this.dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaff.AlternatingRowsDefaultCellStyle.BackColor = rowAlt;

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
            btnRefresh.Click += (s, e) => LoadStaffData();

            this.pnlFooter.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete, btnRefresh, lblStatus });

            this.Controls.Add(dgvStaff);
            this.Controls.Add(pnlForm);
            this.Controls.Add(pnlSearch);
            this.Controls.Add(pnlHeader);
            this.Controls.Add(pnlFooter);

            this.ResumeLayout(false);
        }

        private void CreateFormLabel(string text, int x, int y, int width)
        {
            Label lbl = new Label();
            lbl.Font = new Font("Segoe UI", 10F);
            lbl.ForeColor = Color.FromArgb(180, 200, 210);
            lbl.Location = new Point(x, y);
            lbl.Size = new Size(width, 20);
            lbl.Text = text;
            this.pnlForm.Controls.Add(lbl);
        }

        private void CreateFormButton(Button btn, string text, Color bg, int x, int y)
        {
            btn.BackColor = bg;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI", 10F);
            btn.ForeColor = Color.White;
            btn.Location = new Point(x, y);
            btn.Size = new Size(100, 35);
            btn.Text = text;
            btn.Cursor = Cursors.Hand;
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

        private void ShowForm(bool editMode, DataGridViewRow row = null)
        {
            isEditMode = editMode;
            pnlForm.Visible = true;
            
            if (editMode && row != null)
            {
                lblFormTitle.Text = "Edit Staff Information";
                editingStaffId = row.Cells["Staff ID"].Value?.ToString() ?? "";
                txtName.Text = row.Cells["Name"].Value?.ToString() ?? "";
                txtCNIC.Text = row.Cells["CNIC"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["Phone Number"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                string dept = row.Cells["Department"].Value?.ToString() ?? "";
                cmbDepartment.SelectedItem = dept;
            }
            else
            {
                lblFormTitle.Text = "Add New Staff";
                ClearForm();
            }
        }

        private void HideForm()
        {
            pnlForm.Visible = false;
            ClearForm();
            isEditMode = false;
            editingStaffId = "";
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtCNIC.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            cmbDepartment.SelectedIndex = -1;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ShowForm(false);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count > 0)
            {
                ShowForm(true, dgvStaff.SelectedRows[0]);
            }
            else
            {
                MessageBox.Show("Please select a staff member to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count > 0)
            {
                string name = dgvStaff.SelectedRows[0].Cells["Name"].Value?.ToString() ?? "";
                if (MessageBox.Show($"Delete staff member '{name}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // Demo mode - just remove from DataTable
                    int rowIndex = dgvStaff.SelectedRows[0].Index;
                    if (staffDataTable != null && rowIndex < staffDataTable.Rows.Count)
                    {
                        staffDataTable.Rows[rowIndex].Delete();
                        MessageBox.Show("Staff deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a staff member to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isEditMode)
            {
                // Update existing row
                foreach (DataRow row in staffDataTable.Rows)
                {
                    if (row["Staff ID"].ToString() == editingStaffId)
                    {
                        row["Name"] = txtName.Text;
                        row["CNIC"] = txtCNIC.Text;
                        row["Phone Number"] = txtPhone.Text;
                        row["Email"] = txtEmail.Text;
                        row["Department"] = cmbDepartment.SelectedItem?.ToString() ?? "";
                        break;
                    }
                }
                MessageBox.Show("Staff updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Add new row
                string newId = "MED-" + (staffDataTable.Rows.Count + 1);
                staffDataTable.Rows.Add(newId, txtName.Text, txtCNIC.Text, txtPhone.Text, txtEmail.Text, cmbDepartment.SelectedItem?.ToString() ?? "");
                MessageBox.Show("Staff added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            HideForm();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            HideForm();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
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

        private Panel pnlHeader, pnlSearch, pnlFooter, pnlForm;
        private Label lblTitle, lblIcon, lblSearchLabel, lblStatus, lblFormTitle;
        private TextBox txtSearch, txtName, txtCNIC, txtPhone, txtEmail;
        private ComboBox cmbDepartment;
        private DataGridView dgvStaff;
        private Button btnAdd, btnEdit, btnDelete, btnRefresh, btnSave, btnCancel, btnClear;
    }
}
