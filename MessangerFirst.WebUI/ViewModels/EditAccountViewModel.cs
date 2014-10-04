using System;
using System.ComponentModel.DataAnnotations;

namespace MessangerFirst.WebUI.ViewModels
{
    public class EditAccountViewModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string Email { get; set; }

        [Display(Name = @"Введите имя")]
        public string FirstName { get; set; }

        [Display(Name = @"Введите фамилию")]
        public string LastName { get; set; }

        [Display(Name = @"Номер телефона")]
        public string PhoneNumber { get; set; }
    }
}