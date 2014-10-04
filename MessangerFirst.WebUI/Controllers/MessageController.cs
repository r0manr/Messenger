using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper;
using MessangerFirst.Core.Model;
using MessangerFirst.Core.Service;
using MessangerFirst.WebUI.ViewModels;

namespace MessangerFirst.WebUI.Controllers
{
    [Authorize(Roles = "user")]
    public class MessageController : ApiController
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        public IHttpActionResult Get()
        {
            var userMail = HttpContext.Current.User.Identity.Name;
            var user = _userService.FindByName(userMail);

            if (user == null) return InternalServerError();

            var messages = _messageService.GetMessages(user.Id);
            //var users = _userService.GetAll().ToList();

            IList<MessageViewModel> viewModel = new List<MessageViewModel>();
            Mapper.Map(messages, viewModel);
            viewModel = viewModel.OrderBy(x => x.CreatedOn).ToList();
            return Ok(viewModel);
        }

        /// <summary>
        /// Получить сообщения на определенной странице
        /// </summary>
        /// <param name="pageNum">Номер страницы</param>
        /// <param name="pageSize">Количество элементов на странице</param>
        /// <returns></returns>
        public IHttpActionResult Get(int pageNum, int pageSize)
        {
            var userMail = HttpContext.Current.User.Identity.Name;
            var user = _userService.FindByName(userMail);

            if (user == null) return InternalServerError();

            var messages = _messageService.GetMessages(user.Id);
            //var users = _userService.GetAll().ToList();

            IList<MessageViewModel> viewModel = new List<MessageViewModel>();
            Mapper.Map(messages, viewModel);
            viewModel = viewModel.OrderByDescending(x => x.CreatedOn).Skip(pageNum * pageSize).Take(pageSize).ToList();
            return Ok(viewModel);
        }

        public IHttpActionResult Get(Guid id)
        {
            var message = _messageService.Get(id);
            var viewModel = new MessageViewModel();
            Mapper.Map(message, viewModel);
            return Ok(viewModel);
        }

        public IHttpActionResult Put(Guid id, MessageViewModel viewModel)
        {

            return Ok();
        }

        public IHttpActionResult Post(MessageViewModel viewModel)
        {
            var reciever = _userService.Where(x => x.Email == viewModel.Reciever).Single();

            var userEmail = HttpContext.Current.User.Identity.Name;
            var user = _userService.FindByName(userEmail);
            if (user == null) return InternalServerError();

            var message = new Message();
            //Mapper.Map(viewModel, message);
            //todo: сопоставить
            message.Sender = user;
            message.Reciever = reciever;
            message.Subject = viewModel.Subject;
            message.Body = viewModel.Body;

            _messageService.Create(message);
            Mapper.Map(message, viewModel);
            return Ok();
        }

        public IHttpActionResult Delete(Guid id)
        {
            var userEmail = HttpContext.Current.User.Identity.Name;
            var user = _userService.FindByName(userEmail);

            _messageService.DeleteMessage(id, user.Id);
            return Ok();
        }

    }
}