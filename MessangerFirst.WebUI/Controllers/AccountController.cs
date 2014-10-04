using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MessangerFirst.Core.Model;
using MessangerFirst.Core.Repository;
using MessangerFirst.Core.Security;
using MessangerFirst.Core.Service;
using MessangerFirst.WebUI.ViewModels;

namespace MessangerFirst.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IFormsAuthentication _formsAuth;
        private readonly IUserService _userService;
        private readonly IRepo<Role> _roleRepo;
        public AccountController(IFormsAuthentication formsAuth, IUserService userService, IRepo<Role> roleRepo)
        {
            _formsAuth = formsAuth;
            _userService = userService;
            _roleRepo = roleRepo;
        }

        [HttpGet]
        public ActionResult RegisterAccount()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult RegisterAccount(RegisterViewModel viewModel)
        {
            viewModel.Id = Guid.NewGuid();

            if (!ModelState.IsValid) return View();

            var user = new User();
            Mapper.Map(viewModel, user);

            var role = _roleRepo.Where(x => x.Name == "user").Single();
            user.Roles = new Collection<Role> { role };

            _userService.Create(user);

            return RedirectToAction("LogIn");
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = _userService.Get(viewModel.Email, viewModel.Password);

            if (user == null)
            {
                ModelState.AddModelError("", @"Неверный логин или пароль");
                return View();
            }
            var roles = user.Roles.Select(o => o.Name);
            _formsAuth.SignIn(user.Email, viewModel.Remember, roles);

            return RedirectToAction("Index", "Home");

        }

        public ActionResult LogOff()
        {
            _formsAuth.SignOut();
            return RedirectToAction("LogIn", "Account");
        }

        [Authorize]
        public ActionResult EditAccount()
        {
            var userMail = HttpContext.User.Identity.Name;
            var user = _userService.Where(u => u.Email == userMail).First();
            var viewModel = new EditAccountViewModel();
            Mapper.Map(user, viewModel);
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditAccount(EditAccountViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var userMail = HttpContext.User.Identity.Name;
            var user = _userService.FindByName(userMail);
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.PhoneNumber = viewModel.PhoneNumber;

            _userService.Update(user);

            TempData["AlertMessage"] = "Изменения сделаны";

            return View(viewModel);
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View(new EditPasswordViewModel());
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(EditPasswordViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var userMail = HttpContext.User.Identity.Name;
            var user = _userService.FindByName(userMail);
            _userService.ChangePassword(user.Id, viewModel.Password);

            TempData["AlertMessage"] = "Пароль изменён";

            return RedirectToAction("EditAccount");
        }
    }
}