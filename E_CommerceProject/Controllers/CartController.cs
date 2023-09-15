//cartController
using E_CommerceProject.Data;
using E_CommerceProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis;

namespace E_CommerceProject.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<IdentityUser> userManager; // Add UserManager

        public CartController(ApplicationDbContext _db, UserManager<IdentityUser> _userManager)
        {
            db = _db;
            userManager = _userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddToCart(int id)
        {
            string userId = userManager.GetUserName(User); // Get the current user's ID
            string cartKey = $"cart_{userId}";

            var product = db.Products.Find(id); // Find the product

            if (product == null)
            {
                return NotFound(); // Handle the case where the product does not exist
            }

            if (HttpContext.Session.GetString(cartKey) == null)
            {
                List<Item> cart = new List<Item>
        {
            new Item() { Product = product, Quantity = 1 }
        };
                var jsonCart = JsonConvert.SerializeObject(cart);
                HttpContext.Session.SetString(cartKey, jsonCart);

                // Reduce the product quantity in the database
                product.Quantity--;
                db.SaveChanges();
            }
            else
            {
                var jsonString = HttpContext.Session.GetString(cartKey);
                var retriveCart = JsonConvert.DeserializeObject<List<Item>>(jsonString);
                List<Item> cart = retriveCart;
                int index = IsInCart(cart, id);

                if (index != -1)
                {
                    // Check if there are enough products in stock before increasing the cart quantity
                    if (product.Quantity > cart[index].Quantity)
                    {
                        cart[index].Quantity++;
                        cart[index].Product.Quantity--;
                        db.SaveChanges(); // Update the product quantity in the database
                    }
                   
                }
                else
                {
                    // Check if there are enough products in stock before adding to the cart
                    if (product.Quantity > 0)
                    {
                        cart?.Add(new Item() { Product = product, Quantity = 1 });
                        cart[cart.Count - 1].Product.Quantity--;
                        db.SaveChanges(); // Update the product quantity in the database
                    }
                    
                }
                var jsonCart = JsonConvert.SerializeObject(cart);
                HttpContext.Session.SetString(cartKey, jsonCart);
            }
            return RedirectToAction("Index");
        }


        public IActionResult RemoveFromCart(int id)
        {
            string userId = userManager.GetUserName(User); // Get the current user's ID
            string cartKey = $"cart_{userId}";
            var jsonString = HttpContext.Session.GetString(cartKey);
            if (!string.IsNullOrEmpty(jsonString))
            {
                var retriveCart = JsonConvert.DeserializeObject<List<Item>>(jsonString);
                List<Item> cart = retriveCart;
                int index = IsInCart(id);

                var product = cart[index].Product;

                // Increase the product quantity in the database by 1
                Product p = db.Products.Find(product.Id);

                if (cart[index].Quantity != 1)
                {
                    cart[index].Quantity--;
                }
                else
                {
                    cart.RemoveAt(index);
                   
                }
                p.Quantity++;
                db.SaveChanges();
                var jsonCart = JsonConvert.SerializeObject(cart);
                HttpContext.Session.SetString(cartKey, jsonCart);
            }
            
            return RedirectToAction("Index");

        }
        public int IsInCart(int id)
        {
            string userId = userManager.GetUserName(User); // Get the current user's ID
            string cartKey = $"cart_{userId}";
            var jsonString = HttpContext.Session.GetString(cartKey);
            var retriveCart = JsonConvert.DeserializeObject<List<Item>>(jsonString);
            List<Item> cart = retriveCart;
            for (int i = 0; i < cart?.Count; i++)
            {
                if (cart[i].Product.Id == id)
                { return i; }
            }
            return -1;

        }


        public int IsInCart(List<Item> cart, int id)
        {
            for (int i = 0; i < cart?.Count; i++)
            {
                if (cart[i].Product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public IActionResult CheckOut()
        {

            TempData["check"] = "Thank you Check out process is done successfully";
            return View("CheckOut");
        }
    }
}
//    var jsonString = Context.Session.GetString("cart_"+User.Identity.Name);
