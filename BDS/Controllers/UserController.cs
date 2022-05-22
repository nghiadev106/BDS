using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;
using BDS.Areas.Admin.Models.Authen;
using BDS.Model;
using System;

namespace BDS.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request, string returnUrl = null)
        {
            returnUrl ??= Url.Content("/");
            // Đã đăng nhập nên chuyển hướng về Index
            if (_signInManager.IsSignedIn(User))
            {
                HttpContext.Session.SetString("Token", JsonConvert.SerializeObject(request));
                return Redirect(returnUrl);
            }


            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    request.UserNameOrEmail,
                    request.Password,
                    request.RememberMe,
                    true
                );

                if (!result.Succeeded)
                {
                    // Thất bại username/password -> tìm user theo email, nếu thấy thì thử đăng nhập
                    // bằng user tìm được
                    var user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);
                    if (user != null)
                    {
                        result = await _signInManager.PasswordSignInAsync(
                            user,
                            request.Password,
                            request.RememberMe,
                            true
                        );
                    }
                }

                if (result.Succeeded)
                {
                    HttpContext.Session.SetString("Token", JsonConvert.SerializeObject(request));
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    TempData["error"] = "Tài khoản hoặc mật khẩu không chính xác";
                    return View();
                }
            }
            TempData["error"] = "Đăng nhập không thành công";
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Đăng ký không thành công";
                return View(request);
            }

            var user = new IdentityUser
            {
                Email = request.Email,
                UserName = request.UserName,
                EmailConfirmed = true,
                PhoneNumber = request.PhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                return Redirect("/dang-nhap");
            }
            else
            {
                TempData["error"] = "Đăng ký không thành công";
            }
            TempData["error"] = "Đăng ký không thành công";
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            if (!_signInManager.IsSignedIn(User)) return RedirectToPage("/");
            await _signInManager.SignOutAsync();
            HttpContext.Session.Remove("Token");
            return Redirect("/dang-nhap");
        }
    }
}
