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
            returnUrl ??= Url.Content("/admin/dashboard/index");
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
