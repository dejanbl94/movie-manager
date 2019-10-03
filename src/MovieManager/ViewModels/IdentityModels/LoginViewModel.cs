using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.ViewModels
{
    public class LoginViewModel
    {

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email address format.")]
        [Display(Name ="Email")]
        public string LoginEmail { get; set; } 

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string LoginPassword { get; set; }
    }
}
