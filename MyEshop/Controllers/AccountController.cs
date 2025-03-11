using Microsoft.AspNetCore.Mvc;
using MyEshop.Data.Repositories;
using MyEshop.Models;

namespace MyEshop.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        #region Register


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            if (_userRepository.IsExistUserByEmail(register.Email.ToLower()))
            {
                ModelState.AddModelError("email", "The following Email has been registered before already !");
                return View(register);
            }
            Users user = new Users()
            {
                Email = register.Email.ToLower(),
                Password = register.Password,
                IsAdmin = false,
                RegisterDate = DateTime.Now
            };
            _userRepository.AddUser(user);
            return View("SuccessRegister", register);
        }
        #endregion


        #region Login

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {

            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var user = _userRepository.GetUserForLogin(login.Email.ToLower(), login.Password);
            if (user == null) {
                ModelState.AddModelError("email", " your information is not correct");
                return View(login);
            }

            return View();
        }
        #endregion

    }
}