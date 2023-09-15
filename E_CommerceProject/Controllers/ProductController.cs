using E_CommerceProject.Data;
using E_CommerceProject.Data.Migrations;
using E_CommerceProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_CommerceProject.Controllers
{
    [Authorize("AdminRole")]
    public class ProductController : Controller
    {

        private ApplicationDbContext Db;
        public ProductController(ApplicationDbContext _Db)
        {
            Db = _Db;
        }
        [AcceptVerbs("Get", "Post")]
        public IActionResult IsProductNameUnique(string name, int id)
        {
            // Check if the name is unique among products except for the current product being edited (if applicable)
            var isUnique = !Db.Products.Any(p => p.Name == name && (id == 0 || p.Id != id));

            return Json(isUnique);
        }
        public IActionResult Index()
        {
            return View(Db.Products.ToList());
        }
        public IActionResult AddProduct()
        {
            ViewBag.Category = Db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product, IFormFile imageFile)
        {
            
                if (ModelState.IsValid)
                {

                    if (imageFile != null && imageFile.Length > 0)
                    {
                        // Generate a unique file name (e.g., using a GUID)
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;

                        // Define the path where the image will be saved on the server
                        string filePath = Path.Combine("wwwroot/images", uniqueFileName);

                        // Save the uploaded image to the server
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            imageFile.CopyTo(stream);
                        }

                        // Set the ImageFileName property with the unique file name
                        product.Image = uniqueFileName;
                    }
                    Db.Products.Add(product);
                    Db.SaveChanges();
                    return RedirectToAction("Index");
                 }
            ViewBag.Category = Db.Categories.ToList();
            return View("AddProduct", product);
        }
        public IActionResult EditProduct(int id)
        {
            ViewBag.Category = Db.Categories.ToList();
            return View(Db.Products.Find(id));
        }
        [HttpPost]
        public IActionResult EditProduct(Product product, [FromRoute] int id, IFormFile imageFile)
        {
			if (ModelState.IsValid)
            {
				
				if (imageFile != null && imageFile.Length > 0)
                {
                    // Generate a unique file name (e.g., using a GUID)
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;

                    // Define the path where the image will be saved on the server
                    string filePath = Path.Combine("wwwroot/images", uniqueFileName);

                    // Save the uploaded image to the server
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    // Set the ImageFileName property with the unique file name
                    product.Image = uniqueFileName;
                }
                Db.Products.Update(product);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = Db.Categories.ToList();
            return View("EditProduct", product);
        }
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            var p = Db.Products.Find(id);
            Db.Remove(p);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DetailsProduct([FromRoute] int id)
        {
            return View(Db.Products.Find(id));
        }

    }
}
