namespace IncidentsTrackingSystem.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } // e.g., "Admin", "User", etc.
        public DateTime CreatedAt { get; set; } // Timestamp for when the role was created
        public DateTime? UpdatedAt { get; set; } // Timestamp for when the role was last updated
        public ICollection<AppUser> Users { get; set; } // Navigation property for users associated with this role

        public Role()
        {
            CreatedAt = DateTime.UtcNow; // Set the creation time to the current UTC time
            UpdatedAt = DateTime.UtcNow; // Set the update time to the current UTC time
        }
    }
}
