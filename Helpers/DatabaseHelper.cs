using System;
using System.IO;
using MySql.Data.MySqlClient;

namespace Hospital_Management.Helpers
{
    public class DatabaseHelper
    {
        private static DatabaseHelper _instance;
        private readonly string _connectionString;

        // Singleton pattern - satu koneksi untuk seluruh aplikasi
        public static DatabaseHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DatabaseHelper();
                }
                return _instance;
            }
        }

        private DatabaseHelper()
        {
            // Load .env file
            LoadEnvFile();

            // Baca dari Environment Variables (yang di-set dari .env)
            string server = GetEnvOrDefault("DB_HOST", "localhost");
            string database = GetEnvOrDefault("DB_NAME", "hospital_management");
            string user = GetEnvOrDefault("DB_USER", "root");
            string password = GetEnvOrDefault("DB_PASSWORD", "");
            string port = GetEnvOrDefault("DB_PORT", "3306");

            _connectionString = $"Server={server};Port={port};Database={database};Uid={user};Pwd={password};";
        }

        /// <summary>
        /// Load .env file dan set ke Environment Variables.
        /// </summary>
        private void LoadEnvFile()
        {
            // Cari file .env di direktori aplikasi
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string envPath = Path.Combine(basePath, ".env");

            // Jika tidak ada di bin folder, coba cari di project root (untuk development)
            if (!File.Exists(envPath))
            {
                // Naik 2 level dari bin/Debug ke root project
                envPath = Path.Combine(basePath, "..", "..", ".env");
            }

            if (File.Exists(envPath))
            {
                foreach (var line in File.ReadAllLines(envPath))
                {
                    // Skip komentar dan baris kosong
                    if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                        continue;

                    var parts = line.Split(new[] { '=' }, 2);
                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();
                        Environment.SetEnvironmentVariable(key, value);
                    }
                }
            }
        }

        /// <summary>
        /// Get environment variable atau return default value.
        /// </summary>
        private string GetEnvOrDefault(string key, string defaultValue)
        {
            string value = Environment.GetEnvironmentVariable(key);
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }

        /// <summary>
        /// Mendapatkan koneksi MySQL baru. Jangan lupa Close() setelah selesai.
        /// </summary>
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        /// <summary>
        /// Test koneksi ke database.
        /// </summary>
        public bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Contoh: Execute SELECT query dan return DataTable.
        /// </summary>
        public System.Data.DataTable ExecuteQuery(string query)
        {
            var dataTable = new System.Data.DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                using (var adapter = new MySqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        /// <summary>
        /// Contoh: Execute INSERT/UPDATE/DELETE dan return rows affected.
        /// </summary>
        public int ExecuteNonQuery(string query)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
