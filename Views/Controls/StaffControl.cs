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
            this.btnExport = new Button();
            this.btnRefresh = new Button();
            this.lblStatus = new Label();
            
            // Form Panel
            this.pnlForm = new Panel();
            this.lblFormTitle = new Label();
            this.txtName = new TextBox();
            this.txtCNIC = new TextBox();
            this.txtPhone = new TextBox();
            this.txtEmail = new TextBox();
            this.txtPassword = new TextBox();
            this.txtAddress = new TextBox();
            this.cmbDepartment = new ComboBox();
            this.cmbQualification = new ComboBox();
            this.cmbGender = new ComboBox();
            this.cmbFromTime = new ComboBox();
            this.cmbToTime = new ComboBox();
            this.dtpDateOfBirth = new DateTimePicker();
            this.numSalary = new NumericUpDown();
            this.cmbRole = new ComboBox();
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
            this.pnlForm.Size = new Size(800, 280);
            this.pnlForm.Visible = false;
            this.pnlForm.Padding = new Padding(20, 10, 20, 10);
            this.pnlForm.AutoScroll = true;

            // Form Title
            this.lblFormTitle.Font = new Font("Segoe UI Semibold", 14F);
            this.lblFormTitle.ForeColor = accentColor;
            this.lblFormTitle.Location = new Point(20, 10);
            this.lblFormTitle.Size = new Size(300, 25);
            this.lblFormTitle.Text = "Add New Staff";

            // Row 1: Name, CNIC, Phone, Email
            CreateFormLabel("Name:", 20, 45, 50);
            this.txtName.BackColor = cardBg;
            this.txtName.BorderStyle = BorderStyle.FixedSingle;
            this.txtName.Font = new Font("Segoe UI", 9F);
            this.txtName.ForeColor = textColor;
            this.txtName.Location = new Point(70, 42);
            this.txtName.Size = new Size(140, 22);

            CreateFormLabel("CNIC:", 220, 45, 40);
            this.txtCNIC.BackColor = cardBg;
            this.txtCNIC.BorderStyle = BorderStyle.FixedSingle;
            this.txtCNIC.Font = new Font("Segoe UI", 9F);
            this.txtCNIC.ForeColor = textColor;
            this.txtCNIC.Location = new Point(260, 42);
            this.txtCNIC.Size = new Size(130, 22);

            CreateFormLabel("Phone:", 400, 45, 45);
            this.txtPhone.BackColor = cardBg;
            this.txtPhone.BorderStyle = BorderStyle.FixedSingle;
            this.txtPhone.Font = new Font("Segoe UI", 9F);
            this.txtPhone.ForeColor = textColor;
            this.txtPhone.Location = new Point(450, 42);
            this.txtPhone.Size = new Size(120, 22);

            CreateFormLabel("Email:", 580, 45, 40);
            this.txtEmail.BackColor = cardBg;
            this.txtEmail.BorderStyle = BorderStyle.FixedSingle;
            this.txtEmail.Font = new Font("Segoe UI", 9F);
            this.txtEmail.ForeColor = textColor;
            this.txtEmail.Location = new Point(625, 42);
            this.txtEmail.Size = new Size(160, 22);

            // Row 2: DOB, Gender, Password, Qualification
            CreateFormLabel("DOB:", 20, 75, 40);
            this.dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Font = new Font("Segoe UI", 9F);
            this.dtpDateOfBirth.Location = new Point(70, 72);
            this.dtpDateOfBirth.Size = new Size(100, 22);

            CreateFormLabel("Gender:", 180, 75, 50);
            this.cmbGender.BackColor = cardBg;
            this.cmbGender.FlatStyle = FlatStyle.Flat;
            this.cmbGender.Font = new Font("Segoe UI", 9F);
            this.cmbGender.ForeColor = textColor;
            this.cmbGender.Location = new Point(235, 72);
            this.cmbGender.Size = new Size(80, 22);
            this.cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbGender.Items.AddRange(new object[] { "Male", "Female" });
            this.cmbGender.SelectedIndex = 0;

            CreateFormLabel("Password:", 325, 75, 60);
            this.txtPassword.BackColor = cardBg;
            this.txtPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtPassword.Font = new Font("Segoe UI", 9F);
            this.txtPassword.ForeColor = textColor;
            this.txtPassword.Location = new Point(390, 72);
            this.txtPassword.Size = new Size(120, 22);
            this.txtPassword.UseSystemPasswordChar = true;

            CreateFormLabel("Qualification:", 520, 75, 75);
            this.cmbQualification.BackColor = cardBg;
            this.cmbQualification.FlatStyle = FlatStyle.Flat;
            this.cmbQualification.Font = new Font("Segoe UI", 9F);
            this.cmbQualification.ForeColor = textColor;
            this.cmbQualification.Location = new Point(600, 72);
            this.cmbQualification.Size = new Size(80, 22);
            this.cmbQualification.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbQualification.Items.AddRange(new object[] { "MBBS", "MD", "MS", "DM", "MCh", "DNB", "PhD" });
            this.cmbQualification.SelectedIndex = 0;

            // Row 3: Department, From Time, To Time, Salary
            CreateFormLabel("Dept:", 20, 105, 40);
            this.cmbDepartment.BackColor = cardBg;
            this.cmbDepartment.FlatStyle = FlatStyle.Flat;
            this.cmbDepartment.Font = new Font("Segoe UI", 9F);
            this.cmbDepartment.ForeColor = textColor;
            this.cmbDepartment.Location = new Point(70, 102);
            this.cmbDepartment.Size = new Size(120, 22);
            this.cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbDepartment.Items.AddRange(new object[] { "Cardiology", "Neurology", "Orthopedics", "Pediatrics", "ICU", "Dermatology", "Surgery", "Radiology", "Emergency", "General" });

            CreateFormLabel("From:", 200, 105, 40);
            this.cmbFromTime.BackColor = cardBg;
            this.cmbFromTime.FlatStyle = FlatStyle.Flat;
            this.cmbFromTime.Font = new Font("Segoe UI", 9F);
            this.cmbFromTime.ForeColor = textColor;
            this.cmbFromTime.Location = new Point(245, 102);
            this.cmbFromTime.Size = new Size(100, 22);
            this.cmbFromTime.DropDownStyle = ComboBoxStyle.DropDownList;

            CreateFormLabel("To:", 355, 105, 25);
            this.cmbToTime.BackColor = cardBg;
            this.cmbToTime.FlatStyle = FlatStyle.Flat;
            this.cmbToTime.Font = new Font("Segoe UI", 9F);
            this.cmbToTime.ForeColor = textColor;
            this.cmbToTime.Location = new Point(385, 102);
            this.cmbToTime.Size = new Size(100, 22);
            this.cmbToTime.DropDownStyle = ComboBoxStyle.DropDownList;

            // Populate time dropdowns
            for (int hour = 0; hour < 24; hour++)
            {
                string time = DateTime.Today.AddHours(hour).ToString("h:00 tt");
                cmbFromTime.Items.Add(time);
                cmbToTime.Items.Add(time);
            }
            cmbFromTime.SelectedIndex = 8;
            cmbToTime.SelectedIndex = 16;

            CreateFormLabel("Salary:", 495, 105, 45);
            this.numSalary.BackColor = cardBg;
            this.numSalary.Font = new Font("Segoe UI", 9F);
            this.numSalary.ForeColor = textColor;
            this.numSalary.Location = new Point(545, 102);
            this.numSalary.Size = new Size(120, 22);
            this.numSalary.Maximum = 999999999;
            this.numSalary.ThousandsSeparator = true;

            // Row 4: Address
            CreateFormLabel("Address:", 20, 135, 55);
            this.txtAddress.BackColor = cardBg;
            this.txtAddress.BorderStyle = BorderStyle.FixedSingle;
            this.txtAddress.Font = new Font("Segoe UI", 9F);
            this.txtAddress.ForeColor = textColor;
            this.txtAddress.Location = new Point(80, 132);
            this.txtAddress.Size = new Size(300, 22);

            // Row 4 continued: Role
            CreateFormLabel("Role:", 400, 135, 35);
            this.cmbRole.BackColor = cardBg;
            this.cmbRole.FlatStyle = FlatStyle.Flat;
            this.cmbRole.Font = new Font("Segoe UI", 9F);
            this.cmbRole.ForeColor = textColor;
            this.cmbRole.Location = new Point(440, 132);
            this.cmbRole.Size = new Size(120, 22);
            this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            
            // Role-based filtering: Doctor can only add staff/nurse, Admin can add all
            if (RoleHelper.IsAdmin())
            {
                this.cmbRole.Items.AddRange(new object[] { "staff", "nurse", "doctor", "admin" });
            }
            else
            {
                // Doctor and other roles can only add staff and nurse
                this.cmbRole.Items.AddRange(new object[] { "staff", "nurse" });
            }
            this.cmbRole.SelectedIndex = 0;

            // Form Buttons
            CreateFormButton(btnCancel, "Cancel", Color.FromArgb(100, 100, 110), 500, 180);
            CreateFormButton(btnClear, "Clear", Color.FromArgb(80, 130, 140), 610, 180);
            CreateFormButton(btnSave, "Save", Color.FromArgb(0, 150, 136), 720, 180);

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnClear.Click += BtnClear_Click;

            this.pnlForm.Controls.AddRange(new Control[] { 
                lblFormTitle, txtName, txtCNIC, txtPhone, txtEmail, txtPassword, txtAddress,
                dtpDateOfBirth, cmbGender, cmbQualification, cmbDepartment, cmbRole,
                cmbFromTime, cmbToTime, numSalary,
                btnSave, btnCancel, btnClear 
            });

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
            this.dgvStaff.SelectionChanged += DgvStaff_SelectionChanged;
            this.dgvStaff.CellDoubleClick += DgvStaff_CellDoubleClick;

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
            btnExport.Click += BtnExport_Click;
            btnRefresh.Click += (s, e) => LoadStaffData();

            this.pnlFooter.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete, btnExport, btnRefresh, lblStatus });

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
                PopulateFormFromRow(row);
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
            txtPassword.Clear();
            txtAddress.Clear();
            cmbDepartment.SelectedIndex = -1;
            cmbQualification.SelectedIndex = 0;
            cmbGender.SelectedIndex = 0;
            cmbFromTime.SelectedIndex = 8;
            cmbToTime.SelectedIndex = 16;
            dtpDateOfBirth.Value = DateTime.Today;
            numSalary.Value = 0;
        }

        private void DgvStaff_SelectionChanged(object sender, EventArgs e)
        {
            // Jika form sedang terbuka dalam mode edit, auto-populate dengan baris yang dipilih
            if (pnlForm.Visible && isEditMode && dgvStaff.SelectedRows.Count > 0)
            {
                PopulateFormFromRow(dgvStaff.SelectedRows[0]);
            }
        }

        private void DgvStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Double-click untuk langsung masuk mode edit
            if (e.RowIndex >= 0 && dgvStaff.SelectedRows.Count > 0)
            {
                ShowForm(true, dgvStaff.SelectedRows[0]);
            }
        }

        private void PopulateFormFromRow(DataGridViewRow row)
        {
            if (row == null) return;
            
            string staffId = row.Cells["Staff ID"].Value?.ToString() ?? "";
            if (string.IsNullOrEmpty(staffId)) return;

            lblFormTitle.Text = "Edit Staff Information";
            editingStaffId = staffId;

            // Load full data from database
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM staff WHERE staff_id = @staffId";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@staffId", staffId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtName.Text = reader["name"]?.ToString() ?? "";
                            txtCNIC.Text = reader["cnic"]?.ToString() ?? "";
                            txtPhone.Text = reader["phone_no"]?.ToString() ?? "";
                            txtEmail.Text = reader["email"]?.ToString() ?? "";
                            txtPassword.Text = reader["password"]?.ToString() ?? "";
                            txtAddress.Text = reader["address"]?.ToString() ?? "";

                            // Department
                            string dept = reader["department"]?.ToString() ?? "";
                            int deptIndex = cmbDepartment.Items.IndexOf(dept);
                            cmbDepartment.SelectedIndex = deptIndex >= 0 ? deptIndex : -1;

                            // Qualification
                            string qual = reader["qualification"]?.ToString() ?? "";
                            int qualIndex = cmbQualification.Items.IndexOf(qual);
                            cmbQualification.SelectedIndex = qualIndex >= 0 ? qualIndex : 0;

                            // Gender
                            string gender = reader["gender"]?.ToString() ?? "Male";
                            int genderIndex = cmbGender.Items.IndexOf(gender);
                            cmbGender.SelectedIndex = genderIndex >= 0 ? genderIndex : 0;

                            // Date of Birth
                            if (reader["date_of_birth"] != DBNull.Value)
                            {
                                dtpDateOfBirth.Value = Convert.ToDateTime(reader["date_of_birth"]);
                            }

                            // Working Hours
                            string workFrom = reader["working_from"]?.ToString() ?? "";
                            string workTo = reader["working_to"]?.ToString() ?? "";
                            
                            // Find matching time in dropdown
                            for (int i = 0; i < cmbFromTime.Items.Count; i++)
                            {
                                if (cmbFromTime.Items[i].ToString().Contains(workFrom.Replace(":00:00", ":00")))
                                {
                                    cmbFromTime.SelectedIndex = i;
                                    break;
                                }
                            }
                            for (int i = 0; i < cmbToTime.Items.Count; i++)
                            {
                                if (cmbToTime.Items[i].ToString().Contains(workTo.Replace(":00:00", ":00")))
                                {
                                    cmbToTime.SelectedIndex = i;
                                    break;
                                }
                            }

                            // Salary
                            if (reader["salary"] != DBNull.Value)
                            {
                                numSalary.Value = Convert.ToDecimal(reader["salary"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Fallback to grid data only
                txtName.Text = row.Cells["Name"].Value?.ToString() ?? "";
                txtCNIC.Text = row.Cells["CNIC"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["Phone Number"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                
                string dept = row.Cells["Department"].Value?.ToString() ?? "";
                int deptIndex = cmbDepartment.Items.IndexOf(dept);
                cmbDepartment.SelectedIndex = deptIndex >= 0 ? deptIndex : -1;
            }
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

            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query;
                    MySqlCommand cmd;

                    if (isEditMode)
                    {
                        // Update existing staff in database
                        query = @"UPDATE staff SET name = @name, cnic = @cnic, phone_no = @phone, 
                                  email = @email, department = @dept, date_of_birth = @dob,
                                  password = @password, qualification = @qualification, gender = @gender,
                                  working_from = @workingFrom, working_to = @workingTo, 
                                  salary = @salary, address = @address
                                  WHERE staff_id = @staffId";
                        cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@staffId", editingStaffId);
                    }
                    else
                    {
                        // Generate new staff_id
                        string newStaffId = GenerateStaffId(connection);
                        
                        // Insert new staff to database
                        query = @"INSERT INTO staff (staff_id, name, cnic, phone_no, email, department, 
                                  date_of_birth, password, qualification, gender, working_from, working_to, salary, address) 
                                  VALUES (@staffId, @name, @cnic, @phone, @email, @dept, 
                                  @dob, @password, @qualification, @gender, @workingFrom, @workingTo, @salary, @address)";
                        cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@staffId", newStaffId);
                    }

                    string name = txtName.Text.Trim();
                    string password = string.IsNullOrEmpty(txtPassword.Text) ? "password123" : txtPassword.Text;
                    string email = txtEmail.Text.Trim();
                    string department = cmbDepartment.SelectedItem?.ToString() ?? "General";
                    string role = cmbRole.SelectedItem?.ToString() ?? "staff";

                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@cnic", txtCNIC.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@dept", department);
                    cmd.Parameters.AddWithValue("@dob", dtpDateOfBirth.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@qualification", cmbQualification.SelectedItem?.ToString() ?? "MBBS");
                    cmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem?.ToString() ?? "Male");
                    cmd.Parameters.AddWithValue("@workingFrom", cmbFromTime.SelectedItem?.ToString() ?? "8:00 AM");
                    cmd.Parameters.AddWithValue("@workingTo", cmbToTime.SelectedItem?.ToString() ?? "4:00 PM");
                    cmd.Parameters.AddWithValue("@salary", numSalary.Value);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Auto-create user account for login when adding new staff
                    if (!isEditMode && rowsAffected > 0)
                    {
                        // Create username from name (lowercase, replace spaces with underscore)
                        string username = name.ToLower().Replace(" ", "_");
                        
                        string userQuery = @"INSERT INTO users (username, password, email, role, department) 
                                             VALUES (@username, @password, @email, @role, @dept)";
                        MySqlCommand userCmd = new MySqlCommand(userQuery, connection);
                        userCmd.Parameters.AddWithValue("@username", username);
                        userCmd.Parameters.AddWithValue("@password", password);
                        userCmd.Parameters.AddWithValue("@email", email);
                        userCmd.Parameters.AddWithValue("@role", role);
                        userCmd.Parameters.AddWithValue("@dept", department);
                        
                        try
                        {
                            userCmd.ExecuteNonQuery();
                        }
                        catch (Exception userEx)
                        {
                            // Username might already exist, try with staff_id appended
                            MessageBox.Show($"Note: Could not create user account. {userEx.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    if (rowsAffected > 0)
                    {
                        string message = isEditMode ? "Staff updated successfully!" : $"Staff added successfully!\n\nLogin account created:\nUsername: {name.ToLower().Replace(" ", "_")}\nPassword: {password}";
                        MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStaffData(); // Refresh from database
                    }
                    else
                    {
                        MessageBox.Show("No changes were made.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            HideForm();
        }

        private string GenerateStaffId(MySqlConnection connection)
        {
            try
            {
                string query = @"SELECT MAX(CAST(SUBSTRING(staff_id, 5) AS UNSIGNED)) as max_num 
                                 FROM staff WHERE staff_id LIKE 'MED-%'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                object result = cmd.ExecuteScalar();
                
                int nextNum = 1;
                if (result != null && result != DBNull.Value)
                {
                    nextNum = Convert.ToInt32(result) + 1;
                }
                return $"MED-{nextNum}";
            }
            catch
            {
                return $"MED-{DateTime.Now:yyyyMMddHHmmss}";
            }
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
            catch (Exception ex) { MessageBox.Show($"Error loading data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error); LoadSampleData(); }
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
        private TextBox txtSearch, txtName, txtCNIC, txtPhone, txtEmail, txtPassword, txtAddress;
        private ComboBox cmbDepartment, cmbQualification, cmbGender, cmbFromTime, cmbToTime, cmbRole;
        private DateTimePicker dtpDateOfBirth;
        private NumericUpDown numSalary;
        private DataGridView dgvStaff;
        private Button btnAdd, btnEdit, btnDelete, btnExport, btnRefresh, btnSave, btnCancel, btnClear;

        private void BtnExport_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportToExcel(dgvStaff, "Staff_Data");
        }
    }
}
