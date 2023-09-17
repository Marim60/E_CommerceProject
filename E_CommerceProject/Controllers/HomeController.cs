using E_CommerceProject.Data;
using E_CommerceProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace E_CommerceProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext Db;
        //public HomeController(ApplicationDbContext _Db)
        //{
        //    Db = _Db;
        //}
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _Db)
        {
            _logger = logger;
            Db = _Db;
        }

        public IActionResult Index()
        {
            ViewBag.Category = Db.Categories.ToList();
            return View(Db.Products.ToList());
        }
       
        public IActionResult ListByCategory(int categoryId)
        {
            if(categoryId == 0)
            {
                return RedirectToAction("Index");
            }
            var products = Db.Products.Where(p => p.CategoryId == categoryId).ToList();
            ViewBag.Category = Db.Categories.ToList();
            return View("Index",products);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //public IActionResult Browse()
        //{
        //    return View(Db.Products.ToList());
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}