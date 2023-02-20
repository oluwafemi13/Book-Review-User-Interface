using Book_Review_UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book_Review_UI.Pages.Identity
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        public Register register { get; set; }
        public void OnGet()
        {
            
        }
    }
}
