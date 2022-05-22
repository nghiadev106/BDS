using BDS.Model;
using BDS.Models;
using BDS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BDS.Controllers
{
    public class ProjectController : Controller
    {
        private readonly BDSContext _context;
        private readonly IProjectService _service;

        public ProjectController(BDSContext context, IProjectService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<IActionResult> ListProject(int page = 1)
        {
            int totalRow = 0;
            var pageSize = 1;
            var projects = await _context.Projects.Where(x => x.Status == 1).OrderBy(x => x.DisplayOrder).ToListAsync();
            totalRow = projects.Count();
            var sanphams = projects.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var paginationSet = new PaginationSet<Project>()
            {
                Items = sanphams,
                MaxPage = 5,
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };

            ViewBag.ListCate = await _context.Categories.ToListAsync();
            ViewBag.ListProjects = await _context.Projects.Where(x => x.Status == 1).OrderBy(x => x.CreateDate).ToListAsync();
            return View(paginationSet);
        }

        public async Task<IActionResult> Search(string keyword,int categoryId,int provinceId,int districtId,int wardId, string fromPrice,int fromPriceType,string toPrice, int toPriceType, string fromAcreage,string toAcreage)
        {
            ViewBag.categories = _context.Categories.Where(x => x.Status == 1).ToList();
            ViewBag.provinces = _context.Provinces.ToList();
            ViewBag.priceTypes = _context.PriceTypes.ToList();
            ViewBag.ListProjects = await _context.Projects.Where(x => x.Status == 1).OrderBy(x => x.CreateDate).ToListAsync();
            ViewBag.ListProjectSearch = _service.Search(keyword, categoryId, provinceId, districtId, wardId, fromPrice, fromPriceType, toPrice, toPriceType, fromAcreage, toAcreage);
            return View();
        }

        public async Task<IActionResult> ProjectCategories(int id, int page = 1)
        {
            int totalRow = 0;
            var pageSize = 1;
            var projects = await _service.GetByCategoryId(id);
            totalRow = projects.Count();
            var sanphams = projects.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var paginationSet = new PaginationSet<ProjectViewModel>()
            {
                Items = sanphams,
                MaxPage = 5,
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };

            ViewBag.categories = _context.Categories.Where(x => x.Status == 1).ToList();
            ViewBag.provinces = _context.Provinces.ToList();
            ViewBag.priceTypes = _context.PriceTypes.ToList();
            ViewBag.category = await _context.Categories.Where(x => x.Status == 1 && x.Id == id).SingleOrDefaultAsync();
            ViewBag.ListProjects = await _context.Projects.Where(x => x.Status == 1).OrderBy(x => x.CreateDate).ToListAsync();
            return View(paginationSet);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var project = await _service.Detail(id);
            var allProject = await _service.GetAll();
            ViewBag.categories = _context.Categories.Where(x => x.Status == 1).ToList();
            ViewBag.provinces = _context.Provinces.ToList();
            ViewBag.priceTypes = _context.PriceTypes.ToList();
            ViewBag.ListProject = await _context.Projects.Where(x => x.Status == 1).OrderBy(x => x.CreateDate).Take(5).ToListAsync();
            ViewBag.relatedProject = allProject.Where(x => x.Id != project.Id).Take(8).ToList();
            ViewBag.category = await _context.Categories.Where(x=>x.Id==project.CategoryId).SingleOrDefaultAsync();
            return View(project);
        }
    }
}
