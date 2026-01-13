using System;
using MySql.Data.MySqlClient;
using Hospital_Management.Helpers;

namespace Hospital_Management.Controllers
{
    public class LoginController
    {
        private readonly DatabaseHelper _db;

        public LoginController()
        {
            _db = DatabaseHelper.Instance;
        }

        /// <summary>
        /// Authenticate user against database.
        /// </summary>
        /// <param name="usernameOrEmail">Username or Email</param>
        /// <param name="password">Plain text password</param>
        /// <returns>True if authentication successful</returns>
        public bool PerformLogin(string usernameOrEmail, string password)
        {
            try
            {
                using (var connection = _db.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT id, username, email, role, department 
                        FROM users 
                        WHERE (username = @username OR email = @email) 
                        AND password = @password 
                        AND is_active = TRUE";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", usernameOrEmail);
                        command.Parameters.AddWithValue("@email", usernameOrEmail);
                        command.Parameters.AddWithValue("@password", password);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Store user info for session
                                CurrentUser.Id = reader.GetInt32("id");
                                CurrentUser.Username = reader.GetString("username");
                                CurrentUser.Email = reader.IsDBNull(reader.GetOrdinal("email")) ? "" : reader.GetString("email");
                                CurrentUser.Role = reader.GetString("role");
                                CurrentUser.Department = reader.IsDBNull(reader.GetOrdinal("department")) ? "" : reader.GetString("department");

                                return true;
                            }
                        }
                    }
                }
            }z
            catch (Exception ex)
            {
                // Log error (in production, use proper logging)
                System.Diagnostics.Debug.WriteLine($"Login error: {ex.Message}");
            }

            return false;
        }

        /// <summary>
        /// Test database connection.
        /// </summary>
        public bool TestDatabaseConnection()
        {
            return _db.TestConnection();
        }
    }

    /// <summary>
    /// Static class to hold current logged-in user info.
    /// </summary>
    public static class CurrentUser
    {
        public static int Id { get; set; }
        public static string Username { get; set; }
        public static string Email { get; set; }
        public static string Role { get; set; }
        public static string Department { get; set; }
        public static bool IsLoggedIn => Id > 0;

        public static void Clear()
        {
            Id = 0;
            Username = null;
            Email = null;
            Role = null;
            Department = null;
        }
    }
}
