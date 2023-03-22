using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Book_Review_UI.Models
{
    public class Register:Login
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [StringLength(11)]
        [Display(Name =  "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Role { get; set; }

    }

   
}
