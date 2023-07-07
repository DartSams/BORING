using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesUI.Models;

namespace RazorPagesUI.Pages.Forms
{
    public class LoginPage : PageModel
    {
        [BindProperty] //needed to take data from frontend to backend
        public LoginModel Login { get; set; }
        public void OnGet()
        {
        }

          
        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            return RedirectToPage("./DashboardPage", new { Email = Login.Email,Password = Login.Password}) ; //replace later to send to dashboard the second argument is a object that gets saved locally can be accessed by using @Model.Email or @Model.Password in .cshtml files
        }
    }
}
