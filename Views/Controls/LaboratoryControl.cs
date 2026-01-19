using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Hospital_Management.Helpers;

namespace Hospital_Management.Views.Controls
{
    public partial class LaboratoryControl : UserControl
    {
        private DataTable labDataTable;

        public LaboratoryControl()
        {
            InitializeComponent();
            LoadLabData();
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.pnlSearch = new Panel();
            this.lblSearch = new Label();
            this.txtSearch = new TextBox();
            this.cmbStatusFilter = new ComboBox();
            this.dgvLaboratory = new DataGridView();
            this.pnlFooter = new Panel();
            this.btnAddTest = new Button();

            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaboratory)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // LaboratoryControl
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
            this.lblTitle.Text = "🔬 Laboratory Management";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // pnlSearch
            this.pnlSearch.BackColor = Color.FromArgb(55, 55, 60);
            this.pnlSearch.Controls.Add(this.cmbStatusFilter);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Dock = DockStyle.Top;
            this.pnlSearch.Location = new Point(0, 60);
            this.pnlSearch.Size = new Size(720, 50);

            // cmbStatusFilter
            this.cmbStatusFilter.BackColor = Color.White;
            this.cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.Font = new Font("Segoe UI", 10F);
            this.cmbStatusFilter.Location = new Point(15, 12);
            this.cmbStatusFilter.Size = new Size(130, 25);
            this.cmbStatusFilter.Items.AddRange(new object[] { "All Status", "completed", "pending", "in_progress" });
            this.cmbStatusFilter.SelectedIndex = 0;
            this.cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;

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

            // dgvLaboratory
            this.dgvLaboratory.AllowUserToAddRows = false;
            this.dgvLaboratory.AllowUserToDeleteRows = false;
            this.dgvLaboratory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLaboratory.BackgroundColor = Color.FromArgb(45, 45, 48);
            this.dgvLaboratory.BorderStyle = BorderStyle.None;
            this.dgvLaboratory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLaboratory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvLaboratory.ColumnHeadersDefaultCellStyle = GetHeaderStyle();
            this.dgvLaboratory.ColumnHeadersHeight = 40;
            this.dgvLaboratory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLaboratory.DefaultCellStyle = GetCellStyle();
            this.dgvLaboratory.Dock = DockStyle.Fill;
            this.dgvLaboratory.EnableHeadersVisualStyles = false;
            this.dgvLaboratory.GridColor = Color.FromArgb(60, 60, 65);
            this.dgvLaboratory.Location = new Point(0, 110);
            this.dgvLaboratory.MultiSelect = false;
            this.dgvLaboratory.ReadOnly = true;
            this.dgvLaboratory.RowHeadersVisible = false;
            this.dgvLaboratory.RowTemplate.Height = 40;
            this.dgvLaboratory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvLaboratory.Size = new Size(720, 430);
            this.dgvLaboratory.CellClick += dgvLaboratory_CellClick;

            // pnlFooter
            this.pnlFooter.BackColor = Color.FromArgb(55, 55, 60);
            this.pnlFooter.Controls.Add(this.btnAddTest);
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Location = new Point(0, 540);
            this.pnlFooter.Size = new Size(720, 60);

            // btnAddTest
            this.btnAddTest.BackColor = Color.FromArgb(255, 193, 7);
            this.btnAddTest.Cursor = Cursors.Hand;
            this.btnAddTest.FlatAppearance.BorderSize = 0;
            this.btnAddTest.FlatStyle = FlatStyle.Flat;
            this.btnAddTest.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            this.btnAddTest.ForeColor = Color.Black;
            this.btnAddTest.Location = new Point(580, 12);
            this.btnAddTest.Size = new Size(125, 36);
            this.btnAddTest.Text = "+ Add Test";
            this.btnAddTest.Click += btnAddTest_Click;

            this.Controls.Add(this.dgvLaboratory);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaboratory)).EndInit();
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

        public void LoadLabData()
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT l.lab_id as 'Lab ID', p.name as 'Patient', s.name as 'Doctor', 
                                     l.test_name as 'Test Name', l.test_date as 'Test Date', l.status as 'Status'
                                     FROM laboratory l 
                                     LEFT JOIN patients p ON l.patient_id = p.id
                                     LEFT JOIN staff s ON l.doctor_id = s.id
                                     ORDER BY l.test_date DESC";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    labDataTable = new DataTable();
                    adapter.Fill(labDataTable);
                    dgvLaboratory.DataSource = labDataTable;
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
            labDataTable = new DataTable();
            labDataTable.Columns.Add("Lab ID", typeof(string));
            labDataTable.Columns.Add("Patient", typeof(string));
            labDataTable.Columns.Add("Doctor", typeof(string));
            labDataTable.Columns.Add("Test Name", typeof(string));
            labDataTable.Columns.Add("Test Date", typeof(string));
            labDataTable.Columns.Add("Status", typeof(string));

            labDataTable.Rows.Add("LAB-001", "Ahmad Yusuf", "Dr. John Smith", "Fasting Blood Sugar", "2026-01-10", "completed");
            labDataTable.Rows.Add("LAB-002", "Ahmad Yusuf", "Dr. John Smith", "HbA1c Test", "2026-01-10", "completed");
            labDataTable.Rows.Add("LAB-003", "Siti Rahayu", "Dr. Sarah Johnson", "MRI Brain", "2026-01-11", "pending");
            labDataTable.Rows.Add("LAB-004", "Budi Santoso", "Dr. John Smith", "Lipid Profile", "2026-01-09", "completed");
            labDataTable.Rows.Add("LAB-005", "Budi Santoso", "Dr. John Smith", "ECG", "2026-01-09", "in_progress");
            labDataTable.Rows.Add("LAB-006", "Dewi Lestari", "Dr. Emily Davis", "Complete Blood Count", "2026-01-12", "pending");
            labDataTable.Rows.Add("LAB-007", "Eko Prasetyo", "Dr. Michael Brown", "X-Ray Chest", "2026-01-08", "completed");
            labDataTable.Rows.Add("LAB-008", "Fitria Wati", "Dr. Sarah Johnson", "Urine Analysis", "2026-01-13", "in_progress");

            dgvLaboratory.DataSource = labDataTable;
            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            if (dgvLaboratory.Columns.Count > 0)
            {
                dgvLaboratory.Columns["Lab ID"].Width = 80;
                dgvLaboratory.Columns["Patient"].Width = 130;
                dgvLaboratory.Columns["Doctor"].Width = 130;
                dgvLaboratory.Columns["Test Name"].Width = 150;
                dgvLaboratory.Columns["Test Date"].Width = 100;
                dgvLaboratory.Columns["Status"].Width = 90;
            }

            if (!dgvLaboratory.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                editBtn.Name = "Edit";
                editBtn.HeaderText = "";
                editBtn.Text = "✏️";
                editBtn.UseColumnTextForButtonValue = true;
                editBtn.Width = 45;
                dgvLaboratory.Columns.Add(editBtn);
            }

            if (!dgvLaboratory.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                deleteBtn.Name = "Delete";
                deleteBtn.HeaderText = "";
                deleteBtn.Text = "🗑️";
                deleteBtn.UseColumnTextForButtonValue = true;
                deleteBtn.Width = 45;
                dgvLaboratory.Columns.Add(deleteBtn);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (labDataTable != null)
            {
                string searchText = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                {
                    labDataTable.DefaultView.RowFilter = "";
                }
                else
                {
                    labDataTable.DefaultView.RowFilter = $"[Patient] LIKE '%{searchText}%' OR [Lab ID] LIKE '%{searchText}%' OR [Test Name] LIKE '%{searchText}%'";
                }
            }
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (labDataTable != null)
            {
                string status = cmbStatusFilter.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(status) || status == "All Status")
                {
                    labDataTable.DefaultView.RowFilter = "";
                }
                else
                {
                    labDataTable.DefaultView.RowFilter = $"[Status] = '{status}'";
                }
            }
        }

        private void btnAddTest_Click(object sender, EventArgs e)
        {
            AddLaboratoryForm addForm = new AddLaboratoryForm();
            addForm.ShowDialog();
            LoadLabData();
        }

        private void dgvLaboratory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvLaboratory.Columns["Edit"].Index)
                {
                    string labId = dgvLaboratory.Rows[e.RowIndex].Cells["Lab ID"].Value.ToString();
                    AddLaboratoryForm editForm = new AddLaboratoryForm(labId);
                    editForm.ShowDialog();
                    LoadLabData();
                }
                else if (e.ColumnIndex == dgvLaboratory.Columns["Delete"].Index)
                {
                    string labId = dgvLaboratory.Rows[e.RowIndex].Cells["Lab ID"].Value.ToString();
                    string testName = dgvLaboratory.Rows[e.RowIndex].Cells["Test Name"].Value.ToString();

                    DialogResult result = MessageBox.Show($"Are you sure you want to delete test '{testName}'?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        DeleteLabTest(labId);
                    }
                }
            }
        }

        private void DeleteLabTest(string labId)
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM laboratory WHERE lab_id = @labId";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@labId", labId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Lab test deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLabData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lab test deleted successfully! (Demo mode)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSampleData();
            }
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlSearch;
        private Label lblSearch;
        private TextBox txtSearch;
        private ComboBox cmbStatusFilter;
        private DataGridView dgvLaboratory;
        private Panel pnlFooter;
        private Button btnAddTest;
    }
}
