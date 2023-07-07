using System.ComponentModel.DataAnnotations;

namespace RazorPagesUI.Data
{
    public class Right
    {
        public int Id { get; set; }
        [StringLength(25)]
        public string? Name { get; set; }

        public List<UserRight>? UserRights { get; set; }
    }
}
