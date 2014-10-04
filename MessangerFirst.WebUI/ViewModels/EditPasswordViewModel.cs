using System;
using System.ComponentModel.DataAnnotations;

namespace MessangerFirst.WebUI.ViewModels
{
    public class EditPasswordViewModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string Email { get; set; }

        [Required(ErrorMessage = @"Введите новый пароль")]
        [StringLength(25, ErrorMessage = @"Пароль должен быть не менее {2} символов", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = @"Пароль")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = @"Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = @"Подтвердить пароль")]
        public string ConfirmPassword { get; set; }
    }
}