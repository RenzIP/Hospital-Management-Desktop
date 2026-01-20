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
        private bool isEditMode = false;
        private string editingPatientId = "";

        private Color bgColor = Color.FromArgb(38, 70, 77);
        private Color headerBg = Color.FromArgb(29, 53, 58);
        private Color cardBg = Color.FromArgb(45, 85, 93);
        private Color accentColor = Color.FromArgb(0, 173, 181);
        private Color textColor = Color.White;
        private Color rowAlt = Color.FromArgb(52, 95, 105);
        private Color formBg = Color.FromArgb(35, 65, 72);

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
            
            this.pnlForm = new Panel();
            this.lblFormTitle = new Label();
            this.txtName = new TextBox();
            this.txtCNIC = new TextBox();
            this.txtPhone = new TextBox();
            this.txtEmail = new TextBox();
            this.cmbGender = new ComboBox();
            this.cmbBloodGroup = new ComboBox();
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

            // Form Panel
            this.pnlForm.BackColor = formBg;
            this.pnlForm.Dock = DockStyle.Top;
            this.pnlForm.Size = new Size(800, 180);
            this.pnlForm.Visible = false;

            this.lblFormTitle.Font = new Font("Segoe UI Semibold", 14F);
            this.lblFormTitle.ForeColor = accentColor;
            this.lblFormTitle.Location = new Point(20, 10);
            this.lblFormTitle.Size = new Size(300, 25);
            this.lblFormTitle.Text = "Add New Patient";

            CreateFormLabel("Name:", 20, 45, 50);
            this.txtName.BackColor = cardBg;
            this.txtName.BorderStyle = BorderStyle.FixedSingle;
            this.txtName.Font = new Font("Segoe UI", 10F);
            this.txtName.ForeColor = textColor;
            this.txtName.Location = new Point(75, 42);
            this.txtName.Size = new Size(150, 25);

            CreateFormLabel("CNIC:", 240, 45, 45);
            this.txtCNIC.BackColor = cardBg;
            this.txtCNIC.BorderStyle = BorderStyle.FixedSingle;
            this.txtCNIC.Font = new Font("Segoe UI", 10F);
            this.txtCNIC.ForeColor = textColor;
            this.txtCNIC.Location = new Point(290, 42);
            this.txtCNIC.Size = new Size(140, 25);

            CreateFormLabel("Phone:", 445, 45, 50);
            this.txtPhone.BackColor = cardBg;
            this.txtPhone.BorderStyle = BorderStyle.FixedSingle;
            this.txtPhone.Font = new Font("Segoe UI", 10F);
            this.txtPhone.ForeColor = textColor;
            this.txtPhone.Location = new Point(500, 42);
            this.txtPhone.Size = new Size(120, 25);

            CreateFormLabel("Email:", 20, 80, 50);
            this.txtEmail.BackColor = cardBg;
            this.txtEmail.BorderStyle = BorderStyle.FixedSingle;
            this.txtEmail.Font = new Font("Segoe UI", 10F);
            this.txtEmail.ForeColor = textColor;
            this.txtEmail.Location = new Point(75, 77);
            this.txtEmail.Size = new Size(180, 25);

            CreateFormLabel("Gender:", 270, 80, 55);
            this.cmbGender.BackColor = cardBg;
            this.cmbGender.FlatStyle = FlatStyle.Flat;
            this.cmbGender.Font = new Font("Segoe UI", 10F);
            this.cmbGender.ForeColor = textColor;
            this.cmbGender.Location = new Point(330, 77);
            this.cmbGender.Size = new Size(100, 25);
            this.cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbGender.Items.AddRange(new object[] { "Male", "Female" });

            CreateFormLabel("Blood:", 445, 80, 45);
            this.cmbBloodGroup.BackColor = cardBg;
            this.cmbBloodGroup.FlatStyle = FlatStyle.Flat;
            this.cmbBloodGroup.Font = new Font("Segoe UI", 10F);
            this.cmbBloodGroup.ForeColor = textColor;
            this.cmbBloodGroup.Location = new Point(495, 77);
            this.cmbBloodGroup.Size = new Size(80, 25);
            this.cmbBloodGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbBloodGroup.Items.AddRange(new object[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" });

            CreateFormButton(btnCancel, "Cancel", Color.FromArgb(100, 100, 110), 450, 130);
            CreateFormButton(btnClear, "Clear", Color.FromArgb(80, 130, 140), 560, 130);
            CreateFormButton(btnSave, "Save", Color.FromArgb(0, 150, 136), 670, 130);

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnClear.Click += BtnClear_Click;

            this.pnlForm.Controls.AddRange(new Control[] { lblFormTitle, txtName, txtCNIC, txtPhone, txtEmail, cmbGender, cmbBloodGroup, btnSave, btnCancel, btnClear });

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
            btnRefresh.Click += (s, e) => LoadPatientData();

            this.pnlFooter.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete, btnRefresh, lblStatus });

            this.Controls.Add(dgvPatients);
            this.Controls.Add(pnlForm);
            this.Controls.Add(pnlSearch);
            this.Controls.Add(pnlHeader);
            this.Controls.Add(pnlFooter);

            this.ResumeLayout(false);
        }

        private void SetupDataGridView()
        {
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
            this.dgvPatients.Dock = DockStyle.Fill;
            this.dgvPatients.EnableHeadersVisualStyles = false;
            this.dgvPatients.GridColor = Color.FromArgb(60, 100, 110);
            this.dgvPatients.ColumnHeadersDefaultCellStyle.BackColor = headerBg;
            this.dgvPatients.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(180, 200, 210);
            this.dgvPatients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F);
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.RowHeadersVisible = false;
            this.dgvPatients.RowTemplate.Height = 40;
            this.dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatients.AlternatingRowsDefaultCellStyle.BackColor = rowAlt;
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
                lblFormTitle.Text = "Edit Patient Information";
                editingPatientId = row.Cells["Patient ID"].Value?.ToString() ?? "";
                txtName.Text = row.Cells["Name"].Value?.ToString() ?? "";
                txtCNIC.Text = row.Cells["CNIC"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                cmbGender.SelectedItem = row.Cells["Gender"].Value?.ToString() ?? "";
                cmbBloodGroup.SelectedItem = row.Cells["Blood Group"].Value?.ToString() ?? "";
            }
            else
            {
                lblFormTitle.Text = "Add New Patient";
                ClearForm();
            }
        }

        private void HideForm() { pnlForm.Visible = false; ClearForm(); isEditMode = false; }
        private void ClearForm() { txtName.Clear(); txtCNIC.Clear(); txtPhone.Clear(); txtEmail.Clear(); cmbGender.SelectedIndex = -1; cmbBloodGroup.SelectedIndex = -1; }

        private void BtnAdd_Click(object sender, EventArgs e) => ShowForm(false);

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count > 0) ShowForm(true, dgvPatients.SelectedRows[0]);
            else MessageBox.Show("Please select a patient to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count > 0)
            {
                string name = dgvPatients.SelectedRows[0].Cells["Name"].Value?.ToString() ?? "";
                if (MessageBox.Show($"Delete patient '{name}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    patientDataTable.Rows[dgvPatients.SelectedRows[0].Index].Delete();
                    MessageBox.Show("Patient deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Please enter a name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (isEditMode)
            {
                foreach (DataRow row in patientDataTable.Rows)
                {
                    if (row["Patient ID"].ToString() == editingPatientId)
                    {
                        row["Name"] = txtName.Text; row["CNIC"] = txtCNIC.Text; row["Phone"] = txtPhone.Text;
                        row["Email"] = txtEmail.Text; row["Gender"] = cmbGender.SelectedItem?.ToString() ?? "";
                        row["Blood Group"] = cmbBloodGroup.SelectedItem?.ToString() ?? "";
                        break;
                    }
                }
                MessageBox.Show("Patient updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string newId = "PAT-" + (patientDataTable.Rows.Count + 1).ToString("000");
                patientDataTable.Rows.Add(newId, txtName.Text, txtCNIC.Text, txtPhone.Text, txtEmail.Text, cmbGender.SelectedItem?.ToString() ?? "", cmbBloodGroup.SelectedItem?.ToString() ?? "");
                MessageBox.Show("Patient added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            HideForm();
        }

        private void BtnCancel_Click(object sender, EventArgs e) => HideForm();
        private void BtnClear_Click(object sender, EventArgs e) => ClearForm();

        public void LoadPatientData()
        {
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT patient_id as 'Patient ID', name as 'Name', cnic as 'CNIC', phone_no as 'Phone', email as 'Email', gender as 'Gender', blood_group as 'Blood Group' FROM patients", conn);
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
            patientDataTable.Columns.AddRange(new DataColumn[] { new DataColumn("Patient ID"), new DataColumn("Name"), new DataColumn("CNIC"), new DataColumn("Phone"), new DataColumn("Email"), new DataColumn("Gender"), new DataColumn("Blood Group") });
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

        private Panel pnlHeader, pnlSearch, pnlFooter, pnlForm;
        private Label lblTitle, lblIcon, lblSearchLabel, lblStatus, lblFormTitle;
        private TextBox txtSearch, txtName, txtCNIC, txtPhone, txtEmail;
        private ComboBox cmbGender, cmbBloodGroup;
        private DataGridView dgvPatients;
        private Button btnAdd, btnEdit, btnDelete, btnRefresh, btnSave, btnCancel, btnClear;
    }
}
