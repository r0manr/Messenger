using System;
using System.ComponentModel.DataAnnotations;

namespace MessangerFirst.WebUI.ViewModels
{
    public class RegisterViewModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = @"Введите email")]
        [StringLength(25, ErrorMessage = @"Длина email не менее {2} символов", MinimumLength = 4)]
        [EmailAddress(ErrorMessage = @"Неправильный email")]
        [Display(Name = @"Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = @"Введите пароль")]
        [StringLength(25, ErrorMessage = @"Пароль должен быть не менее {2} символов", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = @"Пароль")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = @"Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = @"Подтвердить пароль")]
        public string ConfirmPassword { get; set; }

        [Display(Name = @"Имя")]
        public string FirstName { get; set; }

        [Display(Name = @"Фамилия")]
        public string LastName { get; set; }

        [Display(Name = @"Номер телефона")]
        public string PhoneNumber { get; set; }
    }
}