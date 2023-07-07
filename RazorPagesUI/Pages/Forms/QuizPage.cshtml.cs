using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Plugins;

namespace RazorPagesUI.Pages.Forms
{
    public class QuizPageModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            return RedirectToPage("./DashboardPage"); //replace later to send to dashboard the second argument is a object that gets saved locally can be accessed by using @Model.Email or @Model.Password in .cshtml files
        }
    }
}
