using Book_Review_UI.Data;
using Book_Review_UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Win32;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text;

namespace Book_Review_UI.Pages.Identity
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login login { get; set; }
        public string Code { get; set; }
        public void OnGet(string code)
        {
            
           // code = Code?? throw new ArgumentNullException(nameof(code));
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://api20230317153411.azurewebsites.net/");

                if (ModelState.IsValid)
                {
                    var json = JsonSerializer.Serialize(login);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var response = client.PostAsync("api/Authentication/login", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["success"] = "Login Successful";
                        var responseContent = response.Content.ReadAsStringAsync().Result;
                        Code = responseContent.ToString();

                        var postResponse = JsonSerializer.Deserialize<ResponseData>(responseContent, options);


                    }
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
