using System.ComponentModel.DataAnnotations;

namespace MyEshop.Models
{

    public class RegisterViewModel
    {
        
        [Required(ErrorMessage ="Please enter {0}")]
        [MaxLength(100)]
        [EmailAddress]
        [Display(Name ="Email : ")]

        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter {0}")]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        [Display(Name = "Password : ")]

        public string Password { get; set; }


        [Required(ErrorMessage = "Please enter {0}")]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Enter your Password again : ")]

        public string RePassword { get; set; }

    }
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter {0}")]
        [MaxLength(100)]
        [EmailAddress]
        [Display(Name = "Email : ")]

        public string Email { get; set; }




        [Required(ErrorMessage = "Please enter {0}")]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        [Display(Name = "Password : ")]
        public string Password { get; set; }

        [Display(Name ="Remember Me ! ")]
        public bool RememberMe { get; set; }
    }

}

