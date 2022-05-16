using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BDS.Model;

namespace BDS.Controllers
{
    public class HomeController : Controller
    {
        private readonly BDSContext _context;

        public HomeController(BDSContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var newsHot= _context.News.Where(x => x.IsNew == true && x.Status == 1).FirstOrDefault();
            ViewBag.newsHot = newsHot;
            ViewBag.ListNews = _context.News.Where(x => x.Status == 1 && x.Id!=newsHot.Id).Take(8).ToList();
            ViewBag.ListProject = _context.Projects.Where(x => x.Status == 1).Take(8).ToList();
            ViewBag.ListProjectHot = _context.Projects.Where(x => x.IsHot==true && x.Status==1).Take(8).ToList();
            return View();
        }

        public IActionResult Categories(int id, string sort, int page = 1,int pageSize=12)
        {
           
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
