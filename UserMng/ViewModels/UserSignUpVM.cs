using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserMng.ViewModels
{
    public class UserSignUpVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Login { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Compare("Password", ErrorMessage = "Password are different")]
        public string ConfirmPassword { get; set; }
    }
}
