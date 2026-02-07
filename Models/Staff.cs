namespace Hospital_Management.Models
{
    /// <summary>
    /// Model class representing a Staff member (Doctor, Nurse, etc.)
    /// </summary>
    public class Staff
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Specialization { get; set; }
        public decimal Salary { get; set; }
        public System.DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }

        public Staff()
        {
            IsActive = true;
            HireDate = System.DateTime.Now;
            CreatedAt = System.DateTime.Now;
            UpdatedAt = System.DateTime.Now;
        }
    }
}
