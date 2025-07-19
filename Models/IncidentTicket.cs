using System.ComponentModel.DataAnnotations;

namespace IncidentsTrackingSystem.Models
{
    public class IncidentTicket
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [DisplayFormat(NullDisplayText = "Does not contain a description")]
        public string? Description { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }

        public Project? Project { get; set; }
        public int ProjectId { get; set; }

        //public TicketType TicketType { get; set; }
        //public int TicketTypeId { get; set; }

        //public TicketStatus TicketStatus { get; set; }
        //public int TicketStatusId { get; set; }

        //public TicketPriority TicketPriority { get; set; }
        //public int TicketPriorityId { get; set; }

        //public ApplicationUser Submitter { get; set; }
        //public string SubmitterId { get; set; }

        //public ApplicationUser AssignedDev { get; set; }
        //public string AssignedDevId { get; set; }

        //public ICollection<TicketUpdate> TicketUpdates { get; set; }
        //public ICollection<Comment> Comments { get; set; }
        //public ICollection<Attachment> Attachments { get; set; }

        public IncidentTicket()
        {
            {
                Created = DateTime.Now;
            }
            //TicketUpdates = new List<TicketUpdate>();
            //Comments = new List<Comment>();
            //Attachments = new List<Attachment>();
        }
    }
}
