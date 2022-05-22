using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using BDS.Model;
using BDS.Models;

namespace BDS.Controllers
{
    public class FurnitureController : Controller
    {
        private readonly BDSContext _context;

        public FurnitureController(BDSContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int totalRow = 0;
            var pageSize = 1;
            var blogs = await _context.Furnitures.Where(x => x.Status == 1).OrderBy(x => x.DisplayOrder).ToListAsync();
            totalRow = blogs.Count();
            var sanphams = blogs.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var paginationSet = new PaginationSet<Furniture>()
            {
                Items = sanphams,
                MaxPage = 5,
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };

            ViewBag.ListProject = await _context.Projects.Where(x => x.Status == 1).OrderBy(x => x.CreateDate).Take(5).ToListAsync();
            return View(paginationSet);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var furniture = await _context.Furnitures.Where(x => x.Status == 1 && x.Id == id).SingleOrDefaultAsync();
            ViewBag.relateds = await _context.Furnitures.Where(x => x.CategoryId == furniture.CategoryId && x.Id != id && x.Status == 1).OrderBy(x => x.DisplayOrder).Take(5).ToListAsync();
            ViewBag.ListProject = await _context.Projects.Where(x => x.Status == 1).OrderBy(x => x.CreateDate).Take(5).ToListAsync();
            return View(furniture);
        }
    }
}
