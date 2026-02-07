namespace Hospital_Management.Models
{
    /// <summary>
    /// Model class representing a Laboratory test record
    /// </summary>
    public class Laboratory
    {
        public int Id { get; set; }
        public string LabId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string TestType { get; set; }
        public string TestName { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }
        public string Status { get; set; } // Pending, In Progress, Completed
        public decimal Cost { get; set; }
        public System.DateTime TestDate { get; set; }
        public System.DateTime? ResultDate { get; set; }
        public string Notes { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }

        // Navigation properties (for display)
        public string PatientName { get; set; }
        public string DoctorName { get; set; }

        public Laboratory()
        {
            Status = "Pending";
            TestDate = System.DateTime.Now;
            CreatedAt = System.DateTime.Now;
            UpdatedAt = System.DateTime.Now;
        }
    }
}
