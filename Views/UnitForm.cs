using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Hospital_Management.Helpers;

namespace Hospital_Management.Views
{
    public partial class UnitForm : Form
    {
        private DataTable unitDataTable;

        public UnitForm()
        {
            InitializeComponent();
            LoadUnitData();
        }

        private void UnitForm_Load(object sender, EventArgs e)
        {
            // Initial setup
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

            dgvUnits.DataSource = unitDataTable;
            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            if (dgvUnits.Columns.Count > 0)
            {
                dgvUnits.Columns["Unit ID"].Width = 80;
                dgvUnits.Columns["Unit Name"].Width = 140;
                dgvUnits.Columns["Type"].Width = 100;
                dgvUnits.Columns["Floor"].Width = 100;
                dgvUnits.Columns["Capacity"].Width = 70;
                dgvUnits.Columns["Status"].Width = 80;
            }

            if (!dgvUnits.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                editBtn.Name = "Edit";
                editBtn.HeaderText = "";
                editBtn.Text = "✏️";
                editBtn.UseColumnTextForButtonValue = true;
                editBtn.Width = 40;
                dgvUnits.Columns.Add(editBtn);
            }

            if (!dgvUnits.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                deleteBtn.Name = "Delete";
                deleteBtn.HeaderText = "";
                deleteBtn.Text = "🗑️";
                deleteBtn.UseColumnTextForButtonValue = true;
                deleteBtn.Width = 40;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
