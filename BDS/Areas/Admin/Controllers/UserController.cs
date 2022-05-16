using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;
using BDS.Areas.Admin.Models.Authen;

namespace BDS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<UserController> _logger;

        public UserController(SignInManager<IdentityUser> signInManager,
            ILogger<UserController> logger,
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request,string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/admin/news/index");
              // Đã đăng nhập nên chuyển hướng về Index
            if (_signInManager.IsSignedIn(User))
            {
                HttpContext.Session.SetString("Token", JsonConvert.SerializeObject(request));
                return Redirect(returnUrl);
            }
              

            if (ModelState.IsValid)
            {
                // Thử login bằng username/password
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
                    _logger.LogInformation("Đăng nhập thành công");
                    HttpContext.Session.SetString("Token", JsonConvert.SerializeObject(request));
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = request.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Đăng nhập không thành công");
                    return View();
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }


        public async Task<IActionResult> LogOut()
        {
            if (!_signInManager.IsSignedIn(User)) return RedirectToPage("/Index");

            await _signInManager.SignOutAsync();
            _logger.LogInformation("Người dùng đăng xuất");
            HttpContext.Session.Remove("Token");

            return  Redirect("/Admin/User/Login");
        }
    }
}
