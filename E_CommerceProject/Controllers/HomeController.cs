using E_CommerceProject.Data;
using E_CommerceProject.Models;
using Microsoft.AspNetCore.Mvc;
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
            return View(Db.Products.ToList());
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