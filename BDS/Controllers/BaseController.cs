using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BDS.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sessions = context.HttpContext.Session.GetString("USER_SESSION");
            if (sessions == null)
            {
                context.Result = new RedirectToActionResult("Login", "User", null);
            }
            base.OnActionExecuting(context);
        }
    }
}
