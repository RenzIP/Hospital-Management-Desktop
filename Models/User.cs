namespace Hospital_Management.Models
{
    /// <summary>
    /// Model class representing a User in the system
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }

        public User()
        {
            IsActive = true;
            CreatedAt = System.DateTime.Now;
            UpdatedAt = System.DateTime.Now;
        }
    }
}
