using System.ComponentModel.DataAnnotations;


namespace RazorPagesUI.Data
{
    public class User
    {
        public Guid Id { get; set; }
        [StringLength(60, MinimumLength = 5, ErrorMessage = "The {0} must be between {2} and {1} characters long.")]
        [Required]
        public string? EMail { get; set; }
        [StringLength(60, MinimumLength = 5, ErrorMessage = "The {0} must be between {2} and {1} characters long.")]
        public string? Name { get; set; }

        public Guid InstitutionId { get; set; }
        public Institution? Institution { get; set; }
        public List<UserRight>? UserRights { get; set; }
        public List<Campaign>? CampaignsCreated { get; set; }
        public List<CampaignAssignment>? CampaignAssignments { get; set; }
    }
}
