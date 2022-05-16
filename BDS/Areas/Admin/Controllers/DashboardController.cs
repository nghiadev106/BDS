using BDS.Areas.Admin.Models.Dashboard;
using BDS.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly BDSContext _context;

        public DashboardController(BDSContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var counts = new DashboardViewModel
            {
                Project = _context.Projects.ToList().Count(),
                News=_context.News.ToList().Count(),
                Category=_context.Categories.ToList().Count(),
                NewsCategory=_context.NewsCategories.ToList().Count(),
                FengShui=_context.FengShuis.ToList().Count(),
                Furnitute=_context.Furnitures.ToList().Count()              
            };
            ViewBag.ListProject = _context.Projects.Where(x => x.IsHot == true && x.IsNew == true && x.Status==1).ToList();
            ViewBag.counts = counts;
            return View();
        }
    }
}
