using BDS.Model;
using BDS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BDS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeedBackController : BaseController
    {
        private readonly IFeedbackService _service;

        public FeedBackController(IFeedbackService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var fbs =await  _service.GetAll();
            ViewBag.fbs = fbs;
            return View();
        }

        public async Task<IActionResult> Detail(int id)
        {
            var res =await _service.Detail(id);
            return View(res);
        }

        public async Task<IActionResult> Confirm(Feedback fb)
        {
            var result =await _service.Update(fb.Id);
            if (result == 1)
            {
                TempData["success"] = "Xác nhận thành công";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Xác nhận thất bại";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _service.Detail(id);
            if (model == null)
            {
                TempData["warning"] = "Phản hồi không tồn tại";
                return RedirectToAction("Index");
            }
            var result = await _service.Delete(id);
            if (result == 1)
            {
                TempData["success"] = "Xóa thành công";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Xóa thất bại";
            return RedirectToAction("Index");
        }

    }
}
