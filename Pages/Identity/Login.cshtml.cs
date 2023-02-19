using Book_Review_UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Book_Review_UI.Pages.Identity
{
    public class LoginModel : PageModel
    {

        public Login login { get; set; }
        public void OnGet()
        {
        }
    }
}
