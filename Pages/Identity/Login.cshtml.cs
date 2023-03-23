using Book_Review_UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Book_Review_UI.Pages.Identity
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login login { get; set; }
       // public string Code { get; set; }
        public void OnGet(string code = null)
        {
           // code = Code?? throw new ArgumentNullException(nameof(code));
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var client = new HttpClient();
                    client.BaseAddress =new Uri( "https://api20230317153411.azurewebsites.net/api/Authentication/login");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Page();
        }
    }
}
