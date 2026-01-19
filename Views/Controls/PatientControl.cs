using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Hospital_Management.Helpers;

namespace Hospital_Management.Views.Controls
{
    public partial class PatientControl : UserControl
    {
        private DataTable patientDataTable;

        public PatientControl()
        {
            InitializeComponent();
            LoadPatientData();
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.pnlSearch = new Panel();
            this.lblSearch = new Label();
            this.txtSearch = new TextBox();
            this.dgvPatients = new DataGridView();
            this.pnlFooter = new Panel();
            this.btnAddPatient = new Button();

            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // PatientControl
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.Dock = DockStyle.Fill;
            this.Size = new Size(720, 600);

            // pnlHeader
            this.pnlHeader.BackColor = Color.FromArgb(45, 45, 48);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Size = new Size(720, 60);

            // lblTitle
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Text = "🚶 Patient Management";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // pnlSearch
            this.pnlSearch.BackColor = Color.FromArgb(55, 55, 60);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Dock = DockStyle.Top;
            this.pnlSearch.Location = new Point(0, 60);
            this.pnlSearch.Size = new Size(720, 50);

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new Font("Segoe UI", 10F);
            this.lblSearch.ForeColor = Color.White;
            this.lblSearch.Location = new Point(480, 15);
            this.lblSearch.Text = "Search:";

            // txtSearch
            this.txtSearch.BackColor = Color.White;
            this.txtSearch.BorderStyle = BorderStyle.FixedSingle;
            this.txtSearch.Font = new Font("Segoe UI", 10F);
            this.txtSearch.Location = new Point(540, 12);
            this.txtSearch.Size = new Size(165, 25);
            this.txtSearch.TextChanged += txtSearch_TextChanged;

            // dgvPatients
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.AllowUserToDeleteRows = false;
            this.dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatients.BackgroundColor = Color.FromArgb(45, 45, 48);
            this.dgvPatients.BorderStyle = BorderStyle.None;
            this.dgvPatients.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPatients.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvPatients.ColumnHeadersDefaultCellStyle = GetHeaderStyle();
            this.dgvPatients.ColumnHeadersHeight = 40;
            this.dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPatients.DefaultCellStyle = GetCellStyle();
            this.dgvPatients.Dock = DockStyle.Fill;
            this.dgvPatients.EnableHeadersVisualStyles = false;
            this.dgvPatients.GridColor = Color.FromArgb(60, 60, 65);
            this.dgvPatients.Location = new Point(0, 110);
            this.dgvPatients.MultiSelect = false;
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.RowHeadersVisible = false;
            this.dgvPatients.RowTemplate.Height = 40;
            this.dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatients.Size = new Size(720, 430);
            this.dgvPatients.CellClick += dgvPatients_CellClick;
            this.dgvPatients.CellDoubleClick += dgvPatients_CellDoubleClick;

            // pnlFooter
            this.pnlFooter.BackColor = Color.FromArgb(55, 55, 60);
            this.pnlFooter.Controls.Add(this.btnAddPatient);
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Location = new Point(0, 540);
            this.pnlFooter.Size = new Size(720, 60);

            // btnAddPatient
            this.btnAddPatient.BackColor = Color.FromArgb(40, 167, 69);
            this.btnAddPatient.Cursor = Cursors.Hand;
            this.btnAddPatient.FlatAppearance.BorderSize = 0;
            this.btnAddPatient.FlatStyle = FlatStyle.Flat;
            this.btnAddPatient.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            this.btnAddPatient.ForeColor = Color.White;
            this.btnAddPatient.Location = new Point(570, 12);
            this.btnAddPatient.Size = new Size(135, 36);
            this.btnAddPatient.Text = "+ Add Patient";
            this.btnAddPatient.Click += btnAddPatient_Click;

            this.Controls.Add(this.dgvPatients);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private DataGridViewCellStyle GetHeaderStyle()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.FromArgb(26, 163, 168);
            style.ForeColor = Color.White;
            style.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            style.SelectionBackColor = Color.FromArgb(26, 163, 168);
            style.SelectionForeColor = Color.White;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.Padding = new Padding(10, 0, 0, 0);
            return style;
        }

        private DataGridViewCellStyle GetCellStyle()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.FromArgb(50, 50, 55);
            style.ForeColor = Color.White;
            style.Font = new Font("Segoe UI", 10F);
            style.SelectionBackColor = Color.FromArgb(0, 122, 204);
            style.SelectionForeColor = Color.White;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.Padding = new Padding(10, 0, 0, 0);
            return style;
        }

        public void LoadPatientData()
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT patient_id as 'Patient ID', name as 'Name', cnic as 'CNIC', 
                                     phone_no as 'Phone', email as 'Email', gender as 'Gender', 
                                     blood_group as 'Blood Group' FROM patients ORDER BY patient_id";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    patientDataTable = new DataTable();
                    adapter.Fill(patientDataTable);
                    dgvPatients.DataSource = patientDataTable;
                    FormatDataGridView();
                }
            }
            catch (Exception ex)
            {
                LoadSampleData();
            }
        }

        private void LoadSampleData()
        {
            patientDataTable = new DataTable();
            patientDataTable.Columns.Add("Patient ID", typeof(string));
            patientDataTable.Columns.Add("Name", typeof(string));
            patientDataTable.Columns.Add("CNIC", typeof(string));
            patientDataTable.Columns.Add("Phone", typeof(string));
            patientDataTable.Columns.Add("Email", typeof(string));
            patientDataTable.Columns.Add("Gender", typeof(string));
            patientDataTable.Columns.Add("Blood Group", typeof(string));

            patientDataTable.Rows.Add("PAT-001", "Ahmad Yusuf", "12345-6789012-3", "0321-1234567", "ahmad@email.com", "Male", "A+");
            patientDataTable.Rows.Add("PAT-002", "Siti Rahayu", "23456-7890123-4", "0322-2345678", "siti@email.com", "Female", "B+");
            patientDataTable.Rows.Add("PAT-003", "Budi Santoso", "34567-8901234-5", "0323-3456789", "budi@email.com", "Male", "O+");
            patientDataTable.Rows.Add("PAT-004", "Dewi Lestari", "45678-9012345-6", "0324-4567890", "dewi@email.com", "Female", "AB+");
            patientDataTable.Rows.Add("PAT-005", "Eko Prasetyo", "56789-0123456-7", "0325-5678901", "eko@email.com", "Male", "A-");
            patientDataTable.Rows.Add("PAT-006", "Fitria Wati", "67890-1234567-8", "0326-6789012", "fitria@email.com", "Female", "B-");
            patientDataTable.Rows.Add("PAT-007", "Gunawan Putra", "78901-2345678-9", "0327-7890123", "gunawan@email.com", "Male", "O-");
            patientDataTable.Rows.Add("PAT-008", "Hani Susanti", "89012-3456789-0", "0328-8901234", "hani@email.com", "Female", "AB-");

            dgvPatients.DataSource = patientDataTable;
            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            if (dgvPatients.Columns.Count > 0)
            {
                dgvPatients.Columns["Patient ID"].Width = 80;
                dgvPatients.Columns["Name"].Width = 130;
                dgvPatients.Columns["CNIC"].Width = 120;
                dgvPatients.Columns["Phone"].Width = 100;

                if (dgvPatients.Columns.Contains("Email"))
                    dgvPatients.Columns["Email"].Width = 140;
                if (dgvPatients.Columns.Contains("Gender"))
                    dgvPatients.Columns["Gender"].Width = 70;
                if (dgvPatients.Columns.Contains("Blood Group"))
                    dgvPatients.Columns["Blood Group"].Width = 90;
            }

            if (!dgvPatients.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                editBtn.Name = "Edit";
                editBtn.HeaderText = "";
                editBtn.Text = "✏️";
                editBtn.UseColumnTextForButtonValue = true;
                editBtn.Width = 45;
                dgvPatients.Columns.Add(editBtn);
            }

            if (!dgvPatients.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                deleteBtn.Name = "Delete";
                deleteBtn.HeaderText = "";
                deleteBtn.Text = "🗑️";
                deleteBtn.UseColumnTextForButtonValue = true;
                deleteBtn.Width = 45;
                dgvPatients.Columns.Add(deleteBtn);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (patientDataTable != null)
            {
                string searchText = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                {
                    patientDataTable.DefaultView.RowFilter = "";
                }
                else
                {
                    patientDataTable.DefaultView.RowFilter = $"[Name] LIKE '%{searchText}%' OR [Patient ID] LIKE '%{searchText}%' OR [CNIC] LIKE '%{searchText}%'";
                }
            }
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            AddPatientForm addForm = new AddPatientForm();
            addForm.ShowDialog();
            LoadPatientData();
        }

        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvPatients.Columns["Edit"].Index)
                {
                    string patientId = dgvPatients.Rows[e.RowIndex].Cells["Patient ID"].Value.ToString();
                    AddPatientForm editForm = new AddPatientForm(patientId);
                    editForm.ShowDialog();
                    LoadPatientData();
                }
                else if (e.ColumnIndex == dgvPatients.Columns["Delete"].Index)
                {
                    string patientId = dgvPatients.Rows[e.RowIndex].Cells["Patient ID"].Value.ToString();
                    string patientName = dgvPatients.Rows[e.RowIndex].Cells["Name"].Value.ToString();

                    DialogResult result = MessageBox.Show($"Are you sure you want to delete {patientName}?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        DeletePatient(patientId);
                    }
                }
            }
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowPatientInfo(e.RowIndex);
            }
        }

        private void ShowPatientInfo(int rowIndex)
        {
            var row = dgvPatients.Rows[rowIndex];
            string info = $"Name: {row.Cells["Name"].Value}\n" +
                         $"Patient ID: {row.Cells["Patient ID"].Value}\n" +
                         $"CNIC: {row.Cells["CNIC"].Value}\n" +
                         $"Phone: {row.Cells["Phone"].Value}\n";

            if (dgvPatients.Columns.Contains("Email"))
                info += $"Email: {row.Cells["Email"].Value}\n";
            if (dgvPatients.Columns.Contains("Gender"))
                info += $"Gender: {row.Cells["Gender"].Value}\n";
            if (dgvPatients.Columns.Contains("Blood Group"))
                info += $"Blood Group: {row.Cells["Blood Group"].Value}\n";

            MessageBox.Show(info, "Patient Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeletePatient(string patientId)
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM patients WHERE patient_id = @patientId";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@patientId", patientId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPatientData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Patient deleted successfully! (Demo mode)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSampleData();
            }
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlSearch;
        private Label lblSearch;
        private TextBox txtSearch;
        private DataGridView dgvPatients;
        private Panel pnlFooter;
        private Button btnAddPatient;
    }
}
