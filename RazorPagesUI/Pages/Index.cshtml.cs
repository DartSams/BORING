using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty(SupportsGet = true)]
        public string FirstName { get; set; } //use this to get url parameters

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                FirstName = "User";
            }
        }

        public void OnPost()
        {

        }
    }
}