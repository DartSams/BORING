using System.ComponentModel.DataAnnotations;

namespace RazorPagesUI.Data
{
    public class Campaign
    {
        public Guid Id { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "The {0} must be between {2} and {1} characters long.")]
        public string? Name { get; set; }
        public Guid UserId { get; set; }
        public User? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? InactiveDate { get; set; }
        public List<CampaignAssignment>? CampaignAssignments { get; set; }
    }

}
