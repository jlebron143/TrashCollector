using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class ViewAccounts
    {
       [Key]
       [Required]
       [Display (Name = "Email")] 
       public string Email { get; set; }
    }

    public class ViewExternalLoginModel
    {
        public string ReturnUrl { get; set; }

    }

    public class ViewSendCodeModel
    {
        public string ChosenProvider { get; set; }
        public string ReturnUrl { get; set; }
        public bool SavePassword { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }

    public class VerifiedCode
    {
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name ="Would you like for this to be remembered?")]

        public bool SavePassword { get; set; }
        public bool SaveBrowser { get; set; }

    }

    public class RegistrationModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [StringLength(150, ErrorMessage = "Your{0} must be at least {2} characters long .")]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       

        [Display(Name = "Password Confirmation")]
        [Compare("Password", ErrorMessage = "Sorry, This is not a match." )]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get;  set;}


    }

    public class ForgottenPassword
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

}