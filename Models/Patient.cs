namespace Hospital_Management.Models
{
    /// <summary>
    /// Model class representing a Patient
    /// </summary>
    public class Patient
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string BloodType { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyPhone { get; set; }
        public string InsuranceNumber { get; set; }
        public string MedicalHistory { get; set; }
        public string Allergies { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }

        public Patient()
        {
            IsActive = true;
            CreatedAt = System.DateTime.Now;
            UpdatedAt = System.DateTime.Now;
        }

        /// <summary>
        /// Calculate patient age based on date of birth
        /// </summary>
        public int Age
        {
            get
            {
                var today = System.DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age)) age--;
                return age;
            }
        }
    }
}
