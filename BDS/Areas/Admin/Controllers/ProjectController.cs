using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using BDS.Models;
using BDS.Services;
using BDS.Areas.Admin.Models.Project;
using BDS.Model;

namespace BDS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : BaseController
    {
        private readonly IProjectService _service;
        private readonly ICategoryService _categoryService;
        private readonly IAddressService _addressService;

        public ProjectController(IProjectService service, ICategoryService categoryService, IAddressService addressService)
        {
            _service = service;
            _categoryService = categoryService;
            _addressService = addressService;
        }
        public async Task<IActionResult> Index()
        {
            var lstProject = await _service.GetAll();
            ViewBag.lstProject = lstProject;
            return View();
        }


        public async Task<SelectList> loadCategory()
        {
            List<CategoryViewModel> categories = await _categoryService.GetAll();
            categories.Insert(0, new CategoryViewModel { Id = -1, Name = "-- Chọn danh mục --" });
            SelectList categoryList = new SelectList(categories, "Id", "Name");
            List<Address> lstAddress = await _addressService.GetAll();
            SelectList addressList = new SelectList(lstAddress, "Id", "Name");
            ViewBag.categoryList = categoryList;
            ViewBag.addressList = addressList;
            return categoryList;
        }


        public async Task<IActionResult> Create()
        {
            await loadCategory();
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create(ProjectCreateRequest request)
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
                TempData["success"] = "Thêm mới dự án thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm dự án thất bại");
            TempData["error"] = "Thêm mới dự án thất bại";
            return View(request);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _service.Edit(id);
            if (product == null)
            {
                TempData["warning"] = "Sản phẩm không tồn tại";
                return RedirectToAction("Index");
            }

            await loadCategory();
            return View(product);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit(ProjectUpdateRequest request)
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
                TempData["success"] = "Cập nhật dự án thành công";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật dự án thất bại");
                TempData["error"] = "Cập nhật dự án thất bại";
                return View(request);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _service.Detail(id);
            if (model == null)
            {
                TempData["warning"] = "Sản phẩm không tồn tại";
                return RedirectToAction("Index");
            }
            var result = await _service.Delete(id);
            if (result == 1)
            {
                TempData["success"] = "Xóa dự án thành công";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Sản phẩm có hóa đơn không thể xóa";
            return RedirectToAction("Index");
        }
    }
}
