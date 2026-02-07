using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Hospital_Management.Helpers
{
    /// <summary>
    /// Helper class for exporting data to Excel-compatible format
    /// </summary>
    public static class ExcelHelper
    {
        /// <summary>
        /// Export DataGridView data to Excel-compatible file (Tab-separated for universal compatibility)
        /// </summary>
        public static void ExportToExcel(DataGridView dataGridView, string fileName = "Export")
        {
            if (dataGridView == null || dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel Files (*.xls)|*.xls|Text Files (*.txt)|*.txt";
            saveDialog.Title = "Export Data to Excel";
            saveDialog.FileName = $"{fileName}_{DateTime.Now:yyyyMMdd_HHmmss}";
            saveDialog.DefaultExt = "xls";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    // Add HTML table header for proper Excel formatting
                    sb.AppendLine("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
                    sb.AppendLine("<head>");
                    sb.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
                    sb.AppendLine("<style>");
                    sb.AppendLine("table { border-collapse: collapse; width: 100%; }");
                    sb.AppendLine("th { background-color: #2D5A5E; color: white; font-weight: bold; padding: 10px; border: 1px solid #1D3A3C; text-align: left; }");
                    sb.AppendLine("td { padding: 8px; border: 1px solid #ddd; }");
                    sb.AppendLine("tr:nth-child(even) { background-color: #f2f2f2; }");
                    sb.AppendLine("tr:hover { background-color: #e0f7fa; }");
                    sb.AppendLine(".title { font-size: 18px; font-weight: bold; color: #2D5A5E; margin-bottom: 10px; }");
                    sb.AppendLine(".info { font-size: 12px; color: #666; margin-bottom: 15px; }");
                    sb.AppendLine("</style>");
                    sb.AppendLine("</head>");
                    sb.AppendLine("<body>");

                    // Add title and export info
                    sb.AppendLine($"<p class='title'>📊 {fileName.Replace("_", " ")} Report</p>");
                    sb.AppendLine($"<p class='info'>Exported on: {DateTime.Now:dddd, dd MMMM yyyy HH:mm:ss}</p>");
                    sb.AppendLine($"<p class='info'>Total Records: {dataGridView.Rows.Count}</p>");

                    sb.AppendLine("<table>");

                    // Write column headers
                    sb.Append("<tr>");
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        if (dataGridView.Columns[i].Visible)
                        {
                            sb.Append($"<th>{EscapeHtml(dataGridView.Columns[i].HeaderText)}</th>");
                        }
                    }
                    sb.AppendLine("</tr>");

                    // Write data rows
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            sb.Append("<tr>");
                            for (int i = 0; i < dataGridView.Columns.Count; i++)
                            {
                                if (dataGridView.Columns[i].Visible)
                                {
                                    var value = row.Cells[i].Value?.ToString() ?? "";
                                    sb.Append($"<td>{EscapeHtml(value)}</td>");
                                }
                            }
                            sb.AppendLine("</tr>");
                        }
                    }

                    sb.AppendLine("</table>");

                    // Footer
                    sb.AppendLine("<br/>");
                    sb.AppendLine("<p class='info'>© Hospital Management System</p>");
                    sb.AppendLine("</body>");
                    sb.AppendLine("</html>");

                    // Write to file with UTF-8 encoding
                    File.WriteAllText(saveDialog.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show($"Data exported successfully to:\n{saveDialog.FileName}\n\nTotal: {dataGridView.Rows.Count} records", 
                        "✅ Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Export failed: {ex.Message}", "Export Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Export DataTable to Excel-compatible file
        /// </summary>
        public static void ExportDataTableToExcel(DataTable dataTable, string fileName = "Export")
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel Files (*.xls)|*.xls|Text Files (*.txt)|*.txt";
            saveDialog.Title = "Export Data to Excel";
            saveDialog.FileName = $"{fileName}_{DateTime.Now:yyyyMMdd_HHmmss}";
            saveDialog.DefaultExt = "xls";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    // Add HTML table for Excel
                    sb.AppendLine("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
                    sb.AppendLine("<head>");
                    sb.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
                    sb.AppendLine("<style>");
                    sb.AppendLine("table { border-collapse: collapse; width: 100%; }");
                    sb.AppendLine("th { background-color: #2D5A5E; color: white; font-weight: bold; padding: 10px; border: 1px solid #1D3A3C; }");
                    sb.AppendLine("td { padding: 8px; border: 1px solid #ddd; }");
                    sb.AppendLine("tr:nth-child(even) { background-color: #f2f2f2; }");
                    sb.AppendLine("</style>");
                    sb.AppendLine("</head>");
                    sb.AppendLine("<body>");

                    sb.AppendLine($"<h2>📊 {fileName.Replace("_", " ")} Report</h2>");
                    sb.AppendLine($"<p>Exported: {DateTime.Now:yyyy-MM-dd HH:mm}</p>");

                    sb.AppendLine("<table>");

                    // Write column headers
                    sb.Append("<tr>");
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        sb.Append($"<th>{EscapeHtml(dataTable.Columns[i].ColumnName)}</th>");
                    }
                    sb.AppendLine("</tr>");

                    // Write data rows
                    foreach (DataRow row in dataTable.Rows)
                    {
                        sb.Append("<tr>");
                        for (int i = 0; i < dataTable.Columns.Count; i++)
                        {
                            var value = row[i]?.ToString() ?? "";
                            sb.Append($"<td>{EscapeHtml(value)}</td>");
                        }
                        sb.AppendLine("</tr>");
                    }

                    sb.AppendLine("</table>");
                    sb.AppendLine("</body>");
                    sb.AppendLine("</html>");

                    File.WriteAllText(saveDialog.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show($"Data exported successfully to:\n{saveDialog.FileName}", 
                        "✅ Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Export failed: {ex.Message}", "Export Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Escape HTML special characters
        /// </summary>
        private static string EscapeHtml(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            return value
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;");
        }
    }
}
