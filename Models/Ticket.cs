using System.ComponentModel.DataAnnotations;

namespace IncidentsTrackingSystem.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        [Required]
        public string Title { get; set; }

        [DisplayFormat(NullDisplayText = "Does not contain a description")]
        public string? Description { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }

        public Project? Project { get; set; }
        public int ProjectId { get; set; }
        public AppUser Submitter { get; set; }
        public int SubmitterId { get; set; }


        // TODO: Uncomment and implement these properties when the related classes are available
        //public TicketType TicketType { get; set; }
        //public int TicketTypeId { get; set; }

        //public TicketStatus TicketStatus { get; set; }
        //public int TicketStatusId { get; set; }

        //public TicketPriority TicketPriority { get; set; }
        //public int TicketPriorityId { get; set; }

        //public AppUser AssignedDev { get; set; }
        //public string AssignedDevId { get; set; }

        //public ICollection<TicketUpdate> TicketUpdates { get; set; }
        //public ICollection<Comment> Comments { get; set; }
        //public ICollection<Attachment> Attachments { get; set; }

        public Ticket()
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
