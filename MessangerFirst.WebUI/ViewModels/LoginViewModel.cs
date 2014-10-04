using System;
using System.ComponentModel.DataAnnotations;

namespace MessangerFirst.WebUI.ViewModels
{
    public class LoginViewModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = @"Введите email")]
        [Display(Name = @"Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = @"Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = @"Пароль")]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}