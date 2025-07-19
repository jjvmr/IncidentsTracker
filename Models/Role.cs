namespace IncidentsTrackingSystem.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; } // e.g., "Admin", "User", etc.
        public DateTime CreatedAt { get; set; } // Timestamp for when the role was created
        public DateTime UpdatedAt { get; set; } // Timestamp for when the role was last updated
        
        
        public Role()
        {
            Id = Guid.NewGuid(); // Automatically generate a unique ID for the role
            CreatedAt = DateTime.UtcNow; // Set the creation time to the current UTC time
            UpdatedAt = DateTime.UtcNow; // Set the update time to the current UTC time
        }
    }
}
