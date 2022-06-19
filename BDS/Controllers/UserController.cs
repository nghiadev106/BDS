using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BDS.Services;
using BDS.Models;

namespace BDS.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginRequest model)
        {
            if (ModelState.IsValid)
            {
                var result = _service.Login(model.Username, model.Password);
                if (result == 1)
                {
                    var user = _service.GetUserDetail(model.Username, model.Password);

                    HttpContext.Session.SetString("USER_SESSION", user.FullName);
                    return Redirect("/");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng.");
                }
            }
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterRequest model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Đăng ký không thành công");
                return View(model);
            }
            var user = _service.GetUserName(model.Username);
            if (user != null)
            {
                ModelState.AddModelError("", "Tài khoản đã tồn tại.");
                return View(model);
            }

            var result = _service.Add(model);

            if (result != null)
            {
                return Redirect("/dang-nhap");
            }
            else
            {
                ModelState.AddModelError("", "Đăng ký không thành công");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            HttpContext.Session.Remove("USER_SESSION");
            return Redirect("/dang-nhap");
        }
    }

}
