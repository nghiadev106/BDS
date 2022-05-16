using BDS.Model;
using BDS.Models;
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

        public ProjectController(BDSContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListProject(int page = 1)
        {
            int totalRow = 0;
            var pageSize = 1;
            var blogs = await _context.Projects.Where(x => x.Status == 1).OrderBy(x => x.DisplayOrder).ToListAsync();
            totalRow = blogs.Count();
            var sanphams = blogs.Skip((page - 1) * pageSize).Take(pageSize).ToList();
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
            var blogs = await _context.Projects.Where(x => x.Status == 1 && x.CategoryId == id).OrderBy(x => x.DisplayOrder).ToListAsync();
            totalRow = blogs.Count();
            var sanphams = blogs.Skip((page - 1) * pageSize).Take(pageSize).ToList();
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
            var blog = await _context.Projects.Where(x => x.Status == 1 && x.Id == id).SingleOrDefaultAsync();
            ViewBag.ListProjects = await _context.Projects.Where(x => x.Status == 1).OrderBy(x => x.CreateDate).ToListAsync();
            ViewBag.relatedProjects = await _context.Projects.Where(x => x.CategoryId == blog.CategoryId && x.Id != id && x.Status == 1).OrderBy(x => x.DisplayOrder).Take(5).ToListAsync();
            ViewBag.categories = await _context.Categories.ToListAsync();
            return View(blog);
        }
    }
}
