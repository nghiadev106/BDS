using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BDS.Model;
using BDS.Services;
using System.Threading.Tasks;
using BDS.Areas.Admin.Models.FeedBack;
using System;

namespace BDS.Controllers
{
    public class HomeController : Controller
    {
        private readonly BDSContext _context;
        private readonly IDistrictService _districtService;
        private readonly IWardService _wardService;
        private readonly IProjectService _service;

        public HomeController(BDSContext context, IDistrictService districtService, IWardService wardService, IProjectService service)
        {
            _context = context;
            _districtService = districtService;
            _wardService = wardService;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ListNews = _context.News.Where(x => x.Status == 1).Take(8).ToList();
            ViewBag.categories = _context.Categories.Where(x => x.Status == 1).ToList();
            ViewBag.provinces = _context.Provinces.ToList();
            ViewBag.priceTypes = _context.PriceTypes.ToList();
            ViewBag.ListNewsHot = _context.News.Where(x => x.Status == 1&&x.IsNew==true).Take(8).ToList();
            ViewBag.ListFengShui = _context.FengShuis.Where(x => x.Status == 1).Take(8).ToList();
            ViewBag.ListFurniture = _context.Furnitures.Where(x => x.Status == 1).Take(8).ToList();
            ViewBag.ListProject = (await _service.GetAll()).OrderByDescending(x=>x.CreateDate).Take(20).ToList();
            ViewBag.ListProjectNew = _context.Projects.Where(x => x.Status == 1 && x.IsNew==true).OrderByDescending(x => x.CreateDate).Take(8).ToList();
            ViewBag.ListProjectHot = _context.Projects.Where(x => x.IsHot==true && x.Status==1).OrderByDescending(x => x.CreateDate).Take(8).ToList();
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(FeedBackRequest request)
        {
            if (ModelState.IsValid)
            {
                Feedback model = new Feedback()
                {
                    Name = request.Name,
                    Message = request.Message,
                    CreateDate = DateTime.Now,
                    Status = 0,
                    Address = request.Address,
                    Phone = request.Phone,
                    Email = request.Email
                };

                _context.Feedbacks.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(request);
        }

        public async Task<IActionResult> GetDistrict(int id)
        {
            var district =await _districtService.GetByProvince(id);
            return Ok(district);
        }

        public async Task<IActionResult> GetWard(int id)
        {
            var ward = await _wardService.GetByDistirct(id);
            return Ok(ward);
        }
    }
}
