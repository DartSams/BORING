using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Plugins;
using RazorPagesUI.Models;

namespace RazorPagesUI.Pages.Forms
{
    public class RegisterPage : PageModel
    {
        [BindProperty] //needed to take data from frontend to backend
        public RegisterModel Register { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            return RedirectToPage("../Index", new { Contact = Register.ContactPerson, Email = Register.Email,Password = Register.Password, Address = Register.Address, Zipcode = Register.Zipcode, City = Register.City, State = Register.State,  });
        }
    }
}
