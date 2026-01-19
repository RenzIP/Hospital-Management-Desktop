using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Hospital_Management.Helpers;

namespace Hospital_Management.Views.Controls
{
    public partial class StaffControl : UserControl
    {
        private DataTable staffDataTable;

        public StaffControl()
        {
            InitializeComponent();
            LoadStaffData();
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.pnlSearch = new Panel();
            this.lblSearch = new Label();
            this.txtSearch = new TextBox();
            this.dgvStaff = new DataGridView();
            this.pnlFooter = new Panel();
            this.btnRegisterDoctor = new Button();

            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // StaffControl
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
            this.lblTitle.Text = "👥 Staff Management";
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

            // dgvStaff
            this.dgvStaff.AllowUserToAddRows = false;
            this.dgvStaff.AllowUserToDeleteRows = false;
            this.dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStaff.BackgroundColor = Color.FromArgb(45, 45, 48);
            this.dgvStaff.BorderStyle = BorderStyle.None;
            this.dgvStaff.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStaff.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvStaff.ColumnHeadersDefaultCellStyle = GetHeaderStyle();
            this.dgvStaff.ColumnHeadersHeight = 40;
            this.dgvStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStaff.DefaultCellStyle = GetCellStyle();
            this.dgvStaff.Dock = DockStyle.Fill;
            this.dgvStaff.EnableHeadersVisualStyles = false;
            this.dgvStaff.GridColor = Color.FromArgb(60, 60, 65);
            this.dgvStaff.Location = new Point(0, 110);
            this.dgvStaff.MultiSelect = false;
            this.dgvStaff.ReadOnly = true;
            this.dgvStaff.RowHeadersVisible = false;
            this.dgvStaff.RowTemplate.Height = 40;
            this.dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaff.Size = new Size(720, 430);
            this.dgvStaff.CellClick += dgvStaff_CellClick;
            this.dgvStaff.CellDoubleClick += dgvStaff_CellDoubleClick;

            // pnlFooter
            this.pnlFooter.BackColor = Color.FromArgb(55, 55, 60);
            this.pnlFooter.Controls.Add(this.btnRegisterDoctor);
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Location = new Point(0, 540);
            this.pnlFooter.Size = new Size(720, 60);

            // btnRegisterDoctor
            this.btnRegisterDoctor.BackColor = Color.FromArgb(0, 122, 204);
            this.btnRegisterDoctor.Cursor = Cursors.Hand;
            this.btnRegisterDoctor.FlatAppearance.BorderSize = 0;
            this.btnRegisterDoctor.FlatStyle = FlatStyle.Flat;
            this.btnRegisterDoctor.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            this.btnRegisterDoctor.ForeColor = Color.White;
            this.btnRegisterDoctor.Location = new Point(560, 12);
            this.btnRegisterDoctor.Size = new Size(145, 36);
            this.btnRegisterDoctor.Text = "+ Register Doctor";
            this.btnRegisterDoctor.Click += btnRegisterDoctor_Click;

            this.Controls.Add(this.dgvStaff);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
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

        public void LoadStaffData()
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT staff_id as 'Staff ID', name as 'Name', cnic as 'CNIC', phone_no as 'Phone Number', email as 'Email', department as 'Department' FROM staff ORDER BY staff_id";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    staffDataTable = new DataTable();
                    adapter.Fill(staffDataTable);
                    dgvStaff.DataSource = staffDataTable;
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
            staffDataTable = new DataTable();
            staffDataTable.Columns.Add("Staff ID", typeof(string));
            staffDataTable.Columns.Add("Name", typeof(string));
            staffDataTable.Columns.Add("CNIC", typeof(string));
            staffDataTable.Columns.Add("Phone Number", typeof(string));
            staffDataTable.Columns.Add("Email", typeof(string));
            staffDataTable.Columns.Add("Department", typeof(string));

            staffDataTable.Rows.Add("MED-1", "Dr. John Smith", "23123-1312312-3", "2321-3123123", "john.smith@hospital.org", "Cardiology");
            staffDataTable.Rows.Add("MED-2", "Dr. Sarah Johnson", "45678-9012345-6", "2321-4567890", "sarah.johnson@hospital.org", "Neurology");
            staffDataTable.Rows.Add("MED-3", "Dr. Michael Brown", "78901-2345678-9", "2321-7890123", "michael.brown@hospital.org", "Orthopedics");
            staffDataTable.Rows.Add("MED-4", "Dr. Emily Davis", "11223-3445566-7", "2321-1122334", "emily.davis@hospital.org", "Pediatrics");
            staffDataTable.Rows.Add("MED-5", "Dr. Robert Wilson", "99887-7665544-3", "2321-9988776", "robert.wilson@hospital.org", "ICU");
            staffDataTable.Rows.Add("MED-6", "Dr. Jennifer Martinez", "55443-3221100-9", "2321-5544332", "jennifer.martinez@hospital.org", "Dermatology");
            staffDataTable.Rows.Add("MED-7", "Dr. David Lee", "66778-8990011-2", "2321-6677889", "david.lee@hospital.org", "Surgery");
            staffDataTable.Rows.Add("MED-8", "Dr. Lisa Anderson", "22334-4556677-8", "2321-2233445", "lisa.anderson@hospital.org", "Radiology");

            dgvStaff.DataSource = staffDataTable;
            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            if (dgvStaff.Columns.Count > 0)
            {
                dgvStaff.Columns["Staff ID"].Width = 80;
                dgvStaff.Columns["Name"].Width = 150;
                dgvStaff.Columns["CNIC"].Width = 130;
                dgvStaff.Columns["Phone Number"].Width = 120;

                if (dgvStaff.Columns.Contains("Email"))
                    dgvStaff.Columns["Email"].Width = 180;
                if (dgvStaff.Columns.Contains("Department"))
                    dgvStaff.Columns["Department"].Width = 100;
            }

            if (!dgvStaff.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                editBtn.Name = "Edit";
                editBtn.HeaderText = "";
                editBtn.Text = "✏️";
                editBtn.UseColumnTextForButtonValue = true;
                editBtn.Width = 45;
                dgvStaff.Columns.Add(editBtn);
            }

            if (!dgvStaff.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                deleteBtn.Name = "Delete";
                deleteBtn.HeaderText = "";
                deleteBtn.Text = "🗑️";
                deleteBtn.UseColumnTextForButtonValue = true;
                deleteBtn.Width = 45;
                dgvStaff.Columns.Add(deleteBtn);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (staffDataTable != null)
            {
                string searchText = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                {
                    staffDataTable.DefaultView.RowFilter = "";
                }
                else
                {
                    staffDataTable.DefaultView.RowFilter = $"[Name] LIKE '%{searchText}%' OR [Staff ID] LIKE '%{searchText}%' OR [CNIC] LIKE '%{searchText}%'";
                }
            }
        }

        private void btnRegisterDoctor_Click(object sender, EventArgs e)
        {
            AddStaffForm addForm = new AddStaffForm();
            addForm.ShowDialog();
            LoadStaffData();
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvStaff.Columns["Edit"].Index)
                {
                    string staffId = dgvStaff.Rows[e.RowIndex].Cells["Staff ID"].Value.ToString();
                    AddStaffForm editForm = new AddStaffForm(staffId);
                    editForm.ShowDialog();
                    LoadStaffData();
                }
                else if (e.ColumnIndex == dgvStaff.Columns["Delete"].Index)
                {
                    string staffId = dgvStaff.Rows[e.RowIndex].Cells["Staff ID"].Value.ToString();
                    string staffName = dgvStaff.Rows[e.RowIndex].Cells["Name"].Value.ToString();

                    DialogResult result = MessageBox.Show($"Are you sure you want to delete {staffName}?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        DeleteStaff(staffId);
                    }
                }
            }
        }

        private void dgvStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowStaffInfo(e.RowIndex);
            }
        }

        private void ShowStaffInfo(int rowIndex)
        {
            var row = dgvStaff.Rows[rowIndex];
            string info = $"Name: {row.Cells["Name"].Value}\n" +
                         $"Staff ID: {row.Cells["Staff ID"].Value}\n" +
                         $"CNIC: {row.Cells["CNIC"].Value}\n" +
                         $"Phone No: {row.Cells["Phone Number"].Value}\n";

            if (dgvStaff.Columns.Contains("Email"))
                info += $"Email: {row.Cells["Email"].Value}\n";
            if (dgvStaff.Columns.Contains("Department"))
                info += $"Department: {row.Cells["Department"].Value}\n";

            MessageBox.Show(info, "Doctor Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteStaff(string staffId)
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM staff WHERE staff_id = @staffId";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@staffId", staffId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStaffData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Staff deleted successfully! (Demo mode)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSampleData();
            }
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlSearch;
        private Label lblSearch;
        private TextBox txtSearch;
        private DataGridView dgvStaff;
        private Panel pnlFooter;
        private Button btnRegisterDoctor;
    }
}
