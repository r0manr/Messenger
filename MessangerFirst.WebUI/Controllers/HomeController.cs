using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MessangerFirst.Core.Service;
using MessangerFirst.WebUI.ViewModels;


namespace MessangerFirst.WebUI.Controllers
{
    [Authorize(Roles = "user")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;

        public HomeController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        /// <summary>
        /// Домашняя страница - SPA
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Получает всех пользователей сети
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUsers()
        {
            var users = _userService.GetAll().ToList();
            IList<UserViewModel> viewModel = new List<UserViewModel>();
            Mapper.Map(users, viewModel);
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Возвращает email пользователя, которому отсылается сообщение
        /// </summary>
        /// <param name="messId">Идентификатор сообщения</param>
        public JsonResult GetRecieverMail(Guid messId)
        {
            var userMail = System.Web.HttpContext.Current.User.Identity.Name;
            var user = _userService.FindByName(userMail);
            var message = _messageService.Get(messId);
            if (message == null) return null;
            if (message.RecieverId == user.Id) return Json(new { Mail = message.Sender.Email }, JsonRequestBehavior.AllowGet);
            return Json(new { Mail = message.Reciever.Email }, JsonRequestBehavior.AllowGet);
        }
    }
}