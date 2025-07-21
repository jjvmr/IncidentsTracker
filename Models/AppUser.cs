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
        public string DisplayName { get; set; }
        public ICollection<Project>? AssignedProjects { get; set; } // Projects this user is assigned to
        public ICollection<Ticket>? SubmittedTickets { get; set; } // Tickets this user submitted

        public ICollection<Role>? AppUserRoles { get; set; } // Navigation property for roles
    }
}
