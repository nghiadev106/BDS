using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using BDS.Areas.Admin.Models.Topic;
using BDS.Models;
using BDS.Services;

namespace BDS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TopicController : BaseController
    {
        private readonly ITopicService _service;

        public TopicController(ITopicService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var lstTopic = await _service.GetAll();
            ViewBag.lstTopic = lstTopic;
            return View();
        }

        public async Task<SelectList> loadTopic()
        {
            List<TopicViewModel> categories = await _service.GetAll();
            categories.Insert(0, new TopicViewModel { Id = -1, Name = "-- Chọn chủ đề cha --" });
            SelectList lstTopic = new SelectList(categories, "Id", "Name");
            ViewBag.lstTopic = lstTopic;
            return lstTopic;
        }

        public async Task<IActionResult> Create()
        {
            await loadTopic();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TopicRequest request)
        {
            await loadTopic();
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Bạn nhập thiếu dữ liệu";
                return View(request);
            }

            var result = await _service.Create(request);

            if (result != -1)
            {
                TempData["success"] = "Thêm mới chủ đề sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm chủ đề sản phẩm thất bại");
            TempData["error"] = "Thêm mới chủ đề sản phẩm thất bại";
            return View(request);
        }

        public async Task<SelectList> loadTopicEdit(int id)
        {
            List<TopicViewModel> categories = await _service.GetEdit(id);
            categories.Insert(0, new TopicViewModel { Id = -1, Name = "-- Chọn chủ đề cha --" });
            SelectList lstTopic = new SelectList(categories, "Id", "Name");
            ViewBag.lstTopic = lstTopic;
            return lstTopic;
        }

        public async Task<IActionResult> Edit(int id)
        {
            await loadTopicEdit(id);
            var category = await _service.Edit(id);
            if (category == null)
            {
                TempData["warning"] = "Chủ đề không tồn tại";
                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TopicRequest request)
        {
            await loadTopicEdit(request.Id);
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Bạn nhập thiếu dữ liệu";
                return View(request);
            }

            if (request.ParentId == -1)
            {
                request.ParentId = null;
            }

            var result = await _service.Update(request);

            if (result == 1)
            {
                TempData["success"] = "Cập nhật chủ đề sản phẩm thành công";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật chủ đề sản phẩm thất bại");
                TempData["error"] = "Cập nhật chủ đề sản phẩm thất bại";
                return View(request);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _service.Detail(id);
            if (model == null)
            {
                TempData["warning"] = "Chủ đề không tồn tại";
                return RedirectToAction("Index");
            }

            var result = await _service.Delete(id);
            if (result != 1)
            {
                TempData["warning"] = "Chủ đề chứa sản phẩm ko thể xóa";
                ModelState.AddModelError("", "Chủ đề chứa sản phẩm ko thể xóa");
                return RedirectToAction("Index");
            }
            TempData["success"] = "Xóa chủ đề thành công";
            return RedirectToAction("Index");
        }
    }
}
