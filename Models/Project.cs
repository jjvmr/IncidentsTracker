using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncidentsTrackingSystem.Models
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int ProjectId { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTimeOffset Created { get; set; }
        [DisplayFormat(NullDisplayText = "Not yet updated")]
        public DateTimeOffset? Updated { get; set; }
        public AppUser UserAssigned { get; set; }
        public int UserAssignedId { get; set; }
        public ICollection<Ticket>? ProjectIncidents { get; set; }
        public bool IsArchived { get; set; }

        public Project()
        {
            Created = DateTime.Now;
            IsArchived = false;
        }
    }
}
