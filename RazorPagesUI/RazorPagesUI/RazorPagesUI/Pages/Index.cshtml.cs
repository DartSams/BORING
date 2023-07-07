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
        [BindProperty(SupportsGet = true)] //needed to take data from frontend to backend
        public string Email { get; set; } //use this to get url parameters
        [BindProperty(SupportsGet = true)] //needed to take data from frontend to backend
        public string Password { get; set; } //use this to get url parameters

        public void OnGet()
        {
            //
        }

        public void OnPost()
        {

        }
    }
}