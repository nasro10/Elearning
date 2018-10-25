using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Mémoriser ce navigateur ?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "PassWord")]
        public string Password { get; set; }

        [Display(Name = "Remember me ?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm your Password ")]
        [Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }

        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string Image { get; set; }

        [Required]
        [Display(Name = "User Type")]
        public string UserType { get; set; }
    }

    public class EditProfileViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm your Password ")]
        [Compare("NewPassword", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }

        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string Image { get; set; }

        
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm your Password")]
        [Compare("Password", ErrorMessage = "Le nouveau mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
