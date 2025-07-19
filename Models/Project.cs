using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncidentsTrackingSystem.Models
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int ProjectId { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        [DisplayFormat(NullDisplayText = "Not yet updated")]
        public DateTimeOffset? Updated { get; set; }
        public ICollection<AppUser> UsersAssigned { get; set; }
        public ICollection<IncidentTicket> ProjectIncidents { get; set; }
        public bool IsArchived { get; set; }

        public Project()
        {
            Created = DateTime.Now;
            UsersAssigned = new List<AppUser>();
            IsArchived = false;
        }
    }
}
