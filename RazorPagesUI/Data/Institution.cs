using System.ComponentModel.DataAnnotations;

namespace RazorPagesUI.Data
{
    public class Institution
    {
        public Guid Id { get; set; } = Guid.Empty;
        [StringLength(60, MinimumLength = 5, ErrorMessage = "The {0} must be between {2} and {1} characters long.")]
        public string? Name { get; set; }

        public List<User>? Users { get; set; }   
    }

}
