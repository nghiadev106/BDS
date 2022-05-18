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

        public async Task<IActionResult> ProjectCategories(int id, int page = 1)
        {
            int totalRow = 0;
            var pageSize = 1;
            var projects = await _context.Projects.Where(x => x.Status == 1 && x.CategoryId == id).OrderBy(x => x.DisplayOrder).ToListAsync();
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

            ViewBag.category = await _context.Categories.Where(x => x.Status == 1 && x.Id == id).SingleOrDefaultAsync();
            ViewBag.ListCate = await _context.Categories.ToListAsync();
            ViewBag.ListProjects = await _context.Projects.Where(x => x.Status == 1).OrderBy(x => x.CreateDate).ToListAsync();
            return View(paginationSet);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var project = await _service.Detail(id);
            ViewBag.ListProject = await _context.Projects.Where(x => x.Status == 1).OrderBy(x => x.CreateDate).ToListAsync();
            ViewBag.relatedProject = await _context.Projects.Where(x => x.CategoryId == project.CategoryId && x.Id != id && x.Status == 1).OrderBy(x => x.DisplayOrder).Take(5).ToListAsync();
            ViewBag.category = await _context.Categories.Where(x=>x.Id==project.CategoryId).SingleOrDefaultAsync();
            return View(project);
        }
    }
}
