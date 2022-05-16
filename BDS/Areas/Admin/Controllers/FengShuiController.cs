using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using BDS.Areas.Admin.Models.FengShui;
using BDS.Models;
using BDS.Services;

namespace BDS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FengShuiController : BaseController
    {
        private readonly IFengShuiService _service;
        private readonly ITopicService _topicService;
        private IHostingEnvironment _env;

        public FengShuiController(IFengShuiService service, ITopicService topicService, IHostingEnvironment env)
        {
            _service = service;
            _topicService = topicService;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var lstFengShui = await _service.GetAll();
            ViewBag.lstFengShui = lstFengShui;
            return View();
        }


        public async Task<SelectList> loadCategory()
        {
            List<TopicViewModel> categories = await _topicService.GetAll();
            categories.Insert(0, new TopicViewModel { Id = -1, Name = "-- Chọn danh mục --" });
            SelectList categoryList = new SelectList(categories, "Id", "Name");
            ViewBag.categoryList = categoryList;
            return categoryList;
        }


        public async Task<IActionResult> Create()
        {
            await loadCategory();
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create(FengShuiCreateRequest request)
        {
            await loadCategory();
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Bạn nhập thiếu dữ liệu";
                return View(request);
            }

            if (request.CategoryId == -1)
            {
                ModelState.AddModelError("", "Bạn chưa chọn danh mục");
                TempData["warning"] = "Bạn chưa chọn danh mục";
                return View(request);
            }

            var result = await _service.Create(request);

            if (result != -1)
            {
                TempData["success"] = "Thêm mới bài viết thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm bài viết thất bại");
            TempData["error"] = "Thêm mới bài viết thất bại";
            return View(request);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var news = await _service.Edit(id);
            if (news == null)
            {
                TempData["warning"] = "Bài viết không tồn tại";
                return RedirectToAction("Index");
            }

            await loadCategory();
            return View(news);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit(FengShuiUpdateRequest request)
        {
            await loadCategory();
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Bạn nhập thiếu dữ liệu";
                return View(request);
            }

            if (request.CategoryId == -1)
            {
                ModelState.AddModelError("", "Bạn chưa chọn danh mục");
                TempData["warning"] = "Bạn chưa chọn danh mục";
                return View(request);
            }

            var result = await _service.Update(request);

            if (result == 1)
            {
                TempData["success"] = "Cập nhật bài viết thành công";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật bài viết thất bại");
                TempData["error"] = "Cập nhật bài viết thất bại";
                return View(request);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _service.Detail(id);
            if (model == null)
            {
                TempData["warning"] = "Bài viết không tồn tại";
                return RedirectToAction("Index");
            }
            var result = await _service.Delete(id);
            if (result == 1)
            {
                TempData["success"] = "Xóa bài viết thành công";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Xóa bài viết thất bại";
            return RedirectToAction("Index");
        }
    }
}
