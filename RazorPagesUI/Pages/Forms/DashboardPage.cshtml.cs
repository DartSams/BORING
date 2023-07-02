using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Plugins;

namespace RazorPagesUI.Pages.Forms
{
    public class DashboardPageModel : PageModel
    {
        //[BindProperty] //needed to take data from frontend to backend
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            return RedirectToPage("../Index"); //replace later to send to dashboard the second argument is a object that gets saved locally can be accessed by using @Model.Email or @Model.Password in .cshtml files
        }
    }
}
