using E_CommerceProject.Data;
using E_CommerceProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_CommerceProject.Controllers
{
    [Authorize("AdminRole")]
    public class CategoryController : Controller
    {
        private ApplicationDbContext Db;
        public CategoryController(ApplicationDbContext _Db)
        {
            Db = _Db;
        }
        public IActionResult Index()
        {
            return View(Db.Categories.ToList());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                Db.Categories.Add(category);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddProduct", category);
        }
        public IActionResult Edit(int id)
        {
            return View(Db.Categories.Find(id));
        }
        [HttpPost]
        public IActionResult Edit(Category category, [FromRoute] int id)
        {

            if (ModelState.IsValid)
            {
                Db.Categories.Update(category);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", category);
        }
        public IActionResult Delete([FromRoute] int id)
        {
            var c = Db.Categories.Find(id);
            Db.Remove(c);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
