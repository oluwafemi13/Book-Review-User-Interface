using Book_Review_UI.Data;
using Book_Review_UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace Book_Review_UI.Pages.Identity
{
    //[BindProperties]
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Register register { get; set; }
        public void OnGet()
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    var client = new HttpClient();
                    client.BaseAddress = new Uri("https://api20230317153411.azurewebsites.net/");

                    var input = new RegisterDTO
                    {
                        email = register.Email, 
                        password = register.Password,
                        firstName = register.FirstName,
                        lastName = register.LastName,
                        userName= register.UserName,
                        phoneNumber = register.PhoneNumber,
                        confirmPassword= register.ConfirmPassword,
                        roles = register.roles

                    };
                    
                    var json = JsonSerializer.Serialize(input);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var response = client.PostAsync("api/Authentication/Register", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["success"] = "Registration Successful";
                        var responseContent = response.Content.ReadAsStringAsync().Result;

                       
                        var postResponse = JsonSerializer.Deserialize<ResponseData>(responseContent, options);


                    }
                    else
                    {
                        ModelState.AddModelError("", "Please Input All fields");
                        return Page();
                    }
                }
                

            }
            catch (Exception)
            {

                throw;
            }
           
            return RedirectToPage("Login");

         

        }
    }
}
