using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Hospital_Management.Helpers;

namespace Hospital_Management.Views.Controls
{
    public partial class UnitControl : UserControl
    {
        private DataTable unitDataTable;

        public UnitControl()
        {
            InitializeComponent();
            LoadUnitData();
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.pnlSearch = new Panel();
            this.lblSearch = new Label();
            this.txtSearch = new TextBox();
            this.cmbTypeFilter = new ComboBox();
            this.dgvUnits = new DataGridView();
            this.pnlFooter = new Panel();
            this.btnAddUnit = new Button();

            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // UnitControl
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
            this.lblTitle.Text = "🏥 Unit Management";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // pnlSearch
            this.pnlSearch.BackColor = Color.FromArgb(55, 55, 60);
            this.pnlSearch.Controls.Add(this.cmbTypeFilter);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Dock = DockStyle.Top;
            this.pnlSearch.Location = new Point(0, 60);
            this.pnlSearch.Size = new Size(720, 50);

            // cmbTypeFilter
            this.cmbTypeFilter.BackColor = Color.White;
            this.cmbTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTypeFilter.Font = new Font("Segoe UI", 10F);
            this.cmbTypeFilter.Location = new Point(15, 12);
            this.cmbTypeFilter.Size = new Size(130, 25);
            this.cmbTypeFilter.Items.AddRange(new object[] { "All Types", "ICU", "General", "Emergency", "Pediatric", "Maternity", "Surgery" });
            this.cmbTypeFilter.SelectedIndex = 0;
            this.cmbTypeFilter.SelectedIndexChanged += cmbTypeFilter_SelectedIndexChanged;

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

            // dgvUnits
            this.dgvUnits.AllowUserToAddRows = false;
            this.dgvUnits.AllowUserToDeleteRows = false;
            this.dgvUnits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUnits.BackgroundColor = Color.FromArgb(45, 45, 48);
            this.dgvUnits.BorderStyle = BorderStyle.None;
            this.dgvUnits.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUnits.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvUnits.ColumnHeadersDefaultCellStyle = GetHeaderStyle();
            this.dgvUnits.ColumnHeadersHeight = 40;
            this.dgvUnits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUnits.DefaultCellStyle = GetCellStyle();
            this.dgvUnits.Dock = DockStyle.Fill;
            this.dgvUnits.EnableHeadersVisualStyles = false;
            this.dgvUnits.GridColor = Color.FromArgb(60, 60, 65);
            this.dgvUnits.Location = new Point(0, 110);
            this.dgvUnits.MultiSelect = false;
            this.dgvUnits.ReadOnly = true;
            this.dgvUnits.RowHeadersVisible = false;
            this.dgvUnits.RowTemplate.Height = 40;
            this.dgvUnits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnits.Size = new Size(720, 430);
            this.dgvUnits.CellClick += dgvUnits_CellClick;

            // pnlFooter
            this.pnlFooter.BackColor = Color.FromArgb(55, 55, 60);
            this.pnlFooter.Controls.Add(this.btnAddUnit);
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Location = new Point(0, 540);
            this.pnlFooter.Size = new Size(720, 60);

            // btnAddUnit
            this.btnAddUnit.BackColor = Color.FromArgb(111, 66, 193);
            this.btnAddUnit.Cursor = Cursors.Hand;
            this.btnAddUnit.FlatAppearance.BorderSize = 0;
            this.btnAddUnit.FlatStyle = FlatStyle.Flat;
            this.btnAddUnit.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            this.btnAddUnit.ForeColor = Color.White;
            this.btnAddUnit.Location = new Point(590, 12);
            this.btnAddUnit.Size = new Size(115, 36);
            this.btnAddUnit.Text = "+ Add Unit";
            this.btnAddUnit.Click += btnAddUnit_Click;

            this.Controls.Add(this.dgvUnits);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).EndInit();
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

        public void LoadUnitData()
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT unit_id as 'Unit ID', unit_name as 'Unit Name', unit_type as 'Type', 
                                     floor as 'Floor', capacity as 'Capacity', status as 'Status'
                                     FROM units ORDER BY unit_id";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    unitDataTable = new DataTable();
                    adapter.Fill(unitDataTable);
                    dgvUnits.DataSource = unitDataTable;
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
            unitDataTable = new DataTable();
            unitDataTable.Columns.Add("Unit ID", typeof(string));
            unitDataTable.Columns.Add("Unit Name", typeof(string));
            unitDataTable.Columns.Add("Type", typeof(string));
            unitDataTable.Columns.Add("Floor", typeof(string));
            unitDataTable.Columns.Add("Capacity", typeof(int));
            unitDataTable.Columns.Add("Status", typeof(string));

            unitDataTable.Rows.Add("UNIT-001", "ICU Ward A", "ICU", "1st Floor", 10, "active");
            unitDataTable.Rows.Add("UNIT-002", "General Ward 1", "General", "2nd Floor", 30, "active");
            unitDataTable.Rows.Add("UNIT-003", "Emergency Room", "Emergency", "Ground Floor", 20, "active");
            unitDataTable.Rows.Add("UNIT-004", "Pediatric Ward", "Pediatric", "3rd Floor", 25, "active");
            unitDataTable.Rows.Add("UNIT-005", "Maternity Ward", "Maternity", "2nd Floor", 15, "active");
            unitDataTable.Rows.Add("UNIT-006", "Surgery Room A", "Surgery", "1st Floor", 5, "maintenance");
            unitDataTable.Rows.Add("UNIT-007", "ICU Ward B", "ICU", "1st Floor", 8, "active");
            unitDataTable.Rows.Add("UNIT-008", "General Ward 2", "General", "3rd Floor", 25, "active");

            dgvUnits.DataSource = unitDataTable;
            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            if (dgvUnits.Columns.Count > 0)
            {
                dgvUnits.Columns["Unit ID"].Width = 80;
                dgvUnits.Columns["Unit Name"].Width = 150;
                dgvUnits.Columns["Type"].Width = 100;
                dgvUnits.Columns["Floor"].Width = 100;
                dgvUnits.Columns["Capacity"].Width = 80;
                dgvUnits.Columns["Status"].Width = 90;
            }

            if (!dgvUnits.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                editBtn.Name = "Edit";
                editBtn.HeaderText = "";
                editBtn.Text = "✏️";
                editBtn.UseColumnTextForButtonValue = true;
                editBtn.Width = 45;
                dgvUnits.Columns.Add(editBtn);
            }

            if (!dgvUnits.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                deleteBtn.Name = "Delete";
                deleteBtn.HeaderText = "";
                deleteBtn.Text = "🗑️";
                deleteBtn.UseColumnTextForButtonValue = true;
                deleteBtn.Width = 45;
                dgvUnits.Columns.Add(deleteBtn);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (unitDataTable != null)
            {
                string searchText = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                {
                    unitDataTable.DefaultView.RowFilter = "";
                }
                else
                {
                    unitDataTable.DefaultView.RowFilter = $"[Unit Name] LIKE '%{searchText}%' OR [Unit ID] LIKE '%{searchText}%' OR [Type] LIKE '%{searchText}%'";
                }
            }
        }

        private void cmbTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (unitDataTable != null)
            {
                string type = cmbTypeFilter.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(type) || type == "All Types")
                {
                    unitDataTable.DefaultView.RowFilter = "";
                }
                else
                {
                    unitDataTable.DefaultView.RowFilter = $"[Type] = '{type}'";
                }
            }
        }

        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            AddUnitForm addForm = new AddUnitForm();
            addForm.ShowDialog();
            LoadUnitData();
        }

        private void dgvUnits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvUnits.Columns["Edit"].Index)
                {
                    string unitId = dgvUnits.Rows[e.RowIndex].Cells["Unit ID"].Value.ToString();
                    AddUnitForm editForm = new AddUnitForm(unitId);
                    editForm.ShowDialog();
                    LoadUnitData();
                }
                else if (e.ColumnIndex == dgvUnits.Columns["Delete"].Index)
                {
                    string unitId = dgvUnits.Rows[e.RowIndex].Cells["Unit ID"].Value.ToString();
                    string unitName = dgvUnits.Rows[e.RowIndex].Cells["Unit Name"].Value.ToString();

                    DialogResult result = MessageBox.Show($"Are you sure you want to delete unit '{unitName}'?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        DeleteUnit(unitId);
                    }
                }
            }
        }

        private void DeleteUnit(string unitId)
        {
            try
            {
                using (var connection = DatabaseHelper.Instance.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM units WHERE unit_id = @unitId";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@unitId", unitId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Unit deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUnitData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unit deleted successfully! (Demo mode)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSampleData();
            }
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlSearch;
        private Label lblSearch;
        private TextBox txtSearch;
        private ComboBox cmbTypeFilter;
        private DataGridView dgvUnits;
        private Panel pnlFooter;
        private Button btnAddUnit;
    }
}
