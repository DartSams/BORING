using System.ComponentModel.DataAnnotations;

namespace RazorPagesUI.Data
{
    // Used to assign campaigns to user who then can publish campaigns 
    public class CampaignAssignment
    {
        public Guid Id { get; set; }

        // User campaign is assigned to 
        public Guid UserId { get; set; }

        public User? User { get; set; }

        //Campaign that is assigned
        public Guid CampaignId { get; set; }
        public Campaign? Campaign { get; set; }


        //unique url generated for each assignment
        [StringLength(80)]
        public string? AssignmentURL { get; set; }
        public DateTime? AssignedOn { get; set; }
        public Guid? AssignedById { get; set; }
        public User? AssignedBy { get; set; }

        //If deactivated URL should not work anymore
        public DateTime? DeactivatedOn { get; set;  }
        public Guid? DeactivatedById { get; set; }
        public User? DeactivatedBy { get; set; }
    }
}
