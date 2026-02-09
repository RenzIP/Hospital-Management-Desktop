# Fitur Hospital Management yang Belum Dipelajari di Praktikum

Dokumen ini berisi daftar fitur dan konsep yang digunakan dalam proyek **Hospital Management** namun **belum tercakup** dalam materi praktikum (PEMOGRAMMAN-2-PBO).

---

## 1. Environment Variables (.env)

Kredensial database disimpan di file `.env`, bukan di-hardcode dalam kode.

```
DB_HOST=43.106.25.105
DB_NAME=hospital_management
DB_USER=root
DB_PASS=password123
```

**Keuntungan:**

- Keamanan lebih baik (tidak expose password di source code)
- Mudah ganti konfigurasi tanpa ubah kode
- Berbeda environment (dev/staging/prod) bisa pakai file `.env` berbeda

**File:** [DatabaseHelper.cs](file:///d:/Kegabutan/TuBes/Hospital%20Management/Helpers/DatabaseHelper.cs)

---

## 2. Singleton Pattern

Pattern design untuk memastikan hanya ada **satu instance** dari class.

```csharp
public class DatabaseHelper
{
    private static DatabaseHelper _instance;

    public static DatabaseHelper Instance
    {
        get { return _instance ?? (_instance = new DatabaseHelper()); }
    }

    private DatabaseHelper() { } // Private constructor
}

// Penggunaan:
var conn = DatabaseHelper.Instance.GetConnection();
```

**Keuntungan:**

- Resource efisien (hanya satu koneksi database)
- Global access point
- Lazy initialization

**File:** [DatabaseHelper.cs](file:///d:/Kegabutan/TuBes/Hospital%20Management/Helpers/DatabaseHelper.cs)

---

## 3. UserControl (Custom Component)

Komponen UI reusable yang bisa di-load ke dalam Panel.

```csharp
public partial class StaffControl : UserControl
{
    public StaffControl()
    {
        InitializeComponent();
        LoadStaffData();
    }
}
```

**Perbedaan dengan Form:**
| Form | UserControl |
|------|-------------|
| Jendela terpisah | Bagian dari Form lain |
| Punya title bar | Tidak punya title bar |
| `ShowDialog()` | Ditambahkan ke Panel |

**File:** Semua file di `Views/Controls/`

---

## 4. Panel-based Navigation (tanpa MDI)

Navigasi modern menggunakan Panel untuk load UserControl, bukan MDI Parent-Child.

```csharp
private void LoadContent(UserControl control)
{
    pnlMainContent.Controls.Clear();
    control.Dock = DockStyle.Fill;
    pnlMainContent.Controls.Add(control);
}

// Penggunaan:
LoadContent(new StaffControl());
LoadContent(new PatientControl());
```

**Keuntungan:**

- Tampilan lebih modern (single-window)
- Lebih ringan dari MDI
- Lebih mudah styling

**File:** [HomeForm.cs](file:///d:/Kegabutan/TuBes/Hospital%20Management/Views/HomeForm.cs)

---

## 5. Responsive Form Events

Auto-populate form saat selection berubah di DataGridView.

```csharp
dgvStaff.SelectionChanged += DgvStaff_SelectionChanged;
dgvStaff.CellDoubleClick += DgvStaff_CellDoubleClick;

private void DgvStaff_SelectionChanged(object sender, EventArgs e)
{
    if (pnlForm.Visible && isEditMode && dgvStaff.SelectedRows.Count > 0)
    {
        PopulateFormFromRow(dgvStaff.SelectedRows[0]);
    }
}
```

**Behavior:**

- Klik baris → Form auto-update dengan data baris itu
- Double-click → Langsung buka form edit

---

## 6. DataGridView Styling Lanjutan

Styling profesional untuk DataGridView.

```csharp
dgvStaff.EnableHeadersVisualStyles = false;
dgvStaff.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 173, 181);
dgvStaff.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
dgvStaff.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(52, 95, 105);
dgvStaff.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 150, 160);
```

**Fitur:**

- Custom header colors
- Alternating row colors
- Selection highlight

---

## 7. Parameterized SQL Queries (Pencegahan SQL Injection)

Menggunakan parameter untuk mencegah SQL Injection.

```csharp
// ❌ TIDAK AMAN (Di praktikum)
string query = "SELECT * FROM users WHERE name = '" + txtName.Text + "'";

// ✅ AMAN (Di Hospital Management)
string query = "SELECT * FROM users WHERE name = @name";
cmd.Parameters.AddWithValue("@name", txtName.Text);
```

**Penting:** Parameterized query mencegah serangan SQL Injection.

---

## 8. Auto-generate ID dari Database

Generate ID unik berurutan dari nilai maksimum di database.

```csharp
private string GeneratePatientId(MySqlConnection connection)
{
    string query = "SELECT MAX(CAST(SUBSTRING(patient_id, 5) AS UNSIGNED)) FROM patients";
    MySqlCommand cmd = new MySqlCommand(query, connection);
    object result = cmd.ExecuteScalar();

    int nextId = (result != DBNull.Value && result != null)
        ? Convert.ToInt32(result) + 1
        : 1;

    return $"PAT-{nextId:D3}"; // PAT-001, PAT-002, dst.
}
```

**Keuntungan:**

- ID selalu unik
- Berurutan
- Format konsisten

---

## 9. Try-Catch dengan Fallback

Jika operasi gagal, jangan crash tapi gunakan "plan B".

```csharp
public void LoadPatientData()
{
    try
    {
        // Coba ambil data dari database
        using (var conn = DatabaseHelper.Instance.GetConnection())
        {
            // ... query database
        }
    }
    catch (Exception ex)
    {
        // FALLBACK: Jika gagal, tampilkan data sample
        MessageBox.Show($"Error: {ex.Message}");
        LoadSampleData();  // ← Rencana cadangan
    }
}
```

**Kapan pakai:**

- Demo tanpa database
- Testing UI
- Graceful degradation

---

## 10. Role-Based Access Control (RBAC)

Menampilkan menu berbeda berdasarkan role user.

```csharp
public static class RoleHelper
{
    public const string ROLE_ADMIN = "admin";
    public const string ROLE_DOCTOR = "doctor";
    public const string ROLE_NURSE = "nurse";

    public static bool CanAccessMenu(string menuName)
    {
        string role = CurrentUser.Role?.ToLower();
        switch (menuName)
        {
            case "Staff":
                return role == ROLE_ADMIN;
            case "Laboratory":
                return role == ROLE_ADMIN || role == ROLE_DOCTOR || role == ROLE_NURSE;
            // ...
        }
    }
}
```

**File:** [RoleHelper.cs](file:///d:/Kegabutan/TuBes/Hospital%20Management/Helpers/RoleHelper.cs)

---

## Ringkasan

| No  | Konsep                 | Di Praktikum       | Di Hospital Management       |
| --- | ---------------------- | ------------------ | ---------------------------- |
| 1   | Environment Variables  | ❌                 | ✅ `.env` file               |
| 2   | Singleton Pattern      | ❌                 | ✅ `DatabaseHelper.Instance` |
| 3   | UserControl            | ❌                 | ✅ `*Control.cs`             |
| 4   | Panel-based Navigation | ❌ (pakai MDI)     | ✅                           |
| 5   | Responsive Form Events | ❌                 | ✅ SelectionChanged          |
| 6   | DataGridView Styling   | Basic              | Advanced (colors, alt rows)  |
| 7   | Parameterized Queries  | ❌ (string concat) | ✅ `@parameter`              |
| 8   | Auto-generate ID       | Count lokal        | Query MAX dari DB            |
| 9   | Try-Catch Fallback     | Basic              | Fallback to sample data      |
| 10  | Role-Based Access      | ❌                 | ✅ RBAC                      |

---

_Dokumen ini dibuat untuk membantu memahami fitur-fitur tambahan yang digunakan dalam proyek Hospital Management._
