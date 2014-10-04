using System;
using System.ComponentModel.DataAnnotations;

namespace MessangerFirst.WebUI.ViewModels
{
    public class HistoryViewModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
        public DateTime CreateOn { get; set; }

        [Required(ErrorMessage = @"Введите заголовок")]
        [Display(Name = @"Заголовок")]
        public string Title { get; set; }

        [Required(ErrorMessage = @"Введите текст")]
        [Display(Name = @"Контекст")]
        public string Content { get; set; }
    }
}