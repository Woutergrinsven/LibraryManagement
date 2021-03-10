using Bibliotheek.Models.DTO;
using Bibliotheek.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotheek.Controllers
{
    public class UserController : BaseController
    {
        private IUserService _userService = null;
        private IJwtService _bearerService = null;

        public UserController(IUserService userService, IJwtService bearerService) : base()
        {
            _userService = userService;
            _bearerService = bearerService;
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(UserRegistrationModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Email)
                    || string.IsNullOrEmpty(model.Username)
                    || string.IsNullOrEmpty(model.Password))
                {
                    return BadRequest("Not all required data provided");
                }

                // TODO add restrictions to password/username/email?


                if (_userService.Register(model))
                {
                    // TODO return new view?
                    return Redirect("/Home/Index");
                }
                else
                {
                    var result = new ContentResult();
                    result.Content = "Invalid data.";
                    return result;
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login([FromBody] UserLoginModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.UserName)
                    || string.IsNullOrEmpty(model.Password))
                {
                    return BadRequest("Some required data not provided.");
                }

                bool result = _userService.Login(HttpContext, model).Result;
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult JwtBearer()
        {
            try
            {
                string bearerToken = _bearerService.GenerateJwt(LoggedInUserId.ToString());
                return Ok(bearerToken);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            try
            {
                _userService.Logout(HttpContext);
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
