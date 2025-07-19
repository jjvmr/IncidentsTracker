using System.ComponentModel.DataAnnotations;
using System.Data;

namespace IncidentsTrackingSystem.Models
{
    public class AppUser
    {
        public int ID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public ICollection<Role>? UserRoles { get; set; } // Navigation property for roles
    }
}
