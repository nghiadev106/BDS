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
        private readonly IWardService _wardService;

        private readonly IDistrictService _districtService;
        private readonly IProvinceService _provinceService;
        private readonly IPriceTypeService _priceTypeService;
        private readonly IDirectionService _directionService;

        public ProjectController(IProjectService service,
            ICategoryService categoryService,
            IWardService wardService,
            IDistrictService districtService,
            IProvinceService provinceService,
            IPriceTypeService priceTypeService,
            IDirectionService directionService
            )
        {
            _service = service;
            _categoryService = categoryService;
            _wardService = wardService;
            _directionService = directionService;
            _districtService = districtService;
            _provinceService = provinceService;
            _priceTypeService = priceTypeService;
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
            categories.Insert(0, new CategoryViewModel { Id = -1, Name = "Chọn danh mục" });
            SelectList categoryList = new SelectList(categories, "Id", "Name");

            var provinces = await _provinceService.GetAll();
            provinces.Insert(0, new Province { Id = -1, Name = "Chọn Tỉnh/Thành phố" });
            SelectList provinceList = new SelectList(await _provinceService.GetAll(), "Id", "Name");

            SelectList priceTypeList = new SelectList(await _priceTypeService.GetAll(), "Id", "Name");

            SelectList directionList = new SelectList(await _directionService.GetAll(), "Id", "Name");

            ViewBag.categoryList = categoryList;
            ViewBag.provinceList = provinceList;
            ViewBag.priceTypeList = priceTypeList;
            ViewBag.directionList = directionList;
            return categoryList;
        }

        public async Task<SelectList> loadAddress(int provinceId,int districtId)
        {
            List<District> districts = await _districtService.GetByProvince(provinceId);
            districts.Insert(0, new District { Id = -1, Name = "Chọn Quận/Huyện" });
            SelectList districtList = new SelectList(districts, "Id", "Name");

            var wards = await _wardService.GetByDistirct(districtId);
            wards.Insert(0, new Ward { Id = -1, Name = "Chọn Xã/Phường" });
            SelectList wardList = new SelectList(wards, "Id", "Name");

            ViewBag.districtList = districtList;
            ViewBag.wardList = wardList;
            return wardList;
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

            if (request.WardId == -1 || request.WardId==null)
            {
                ModelState.AddModelError("", "Bạn chưa chọn địa chỉ");
                TempData["warning"] = "Bạn chưa chọn địa chỉ";
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
            var project = await _service.Edit(id);
            if (project == null)
            {
                TempData["warning"] = "Sản phẩm không tồn tại";
                return RedirectToAction("Index");
            }
            
            await loadCategory();
            await loadAddress(project.ProvinceId.Value, project.DistrictId.Value);
            return View(project);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit(ProjectUpdateRequest request)
        {
            await loadCategory();
            await loadAddress(request.ProvinceId.Value, request.DistrictId.Value);
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

            if (request.WardId == -1)
            {
                ModelState.AddModelError("", "Bạn chưa chọn địa chỉ");
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
