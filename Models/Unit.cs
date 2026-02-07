namespace Hospital_Management.Models
{
    /// <summary>
    /// Model class representing a Hospital Unit/Department
    /// </summary>
    public class Unit
    {
        public int Id { get; set; }
        public string UnitCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Floor { get; set; }
        public string Building { get; set; }
        public int Capacity { get; set; }
        public int CurrentOccupancy { get; set; }
        public string HeadOfUnit { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }

        public Unit()
        {
            IsActive = true;
            CurrentOccupancy = 0;
            CreatedAt = System.DateTime.Now;
            UpdatedAt = System.DateTime.Now;
        }

        /// <summary>
        /// Calculate availability percentage
        /// </summary>
        public double AvailabilityPercentage
        {
            get
            {
                if (Capacity <= 0) return 0;
                return ((double)(Capacity - CurrentOccupancy) / Capacity) * 100;
            }
        }
    }
}
