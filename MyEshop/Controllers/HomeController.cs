using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MyEshop.Data;
using MyEshop.Models;

namespace MyEshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
      private  MyEshopContext _context;
        private static Cart _cart = new Cart();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p=>p.Id == id);


            if (product == null)
            {
                return NotFound();
            }

            var categories = _context.Categories.Where(p => p.Id == id).SelectMany(c=> c.categoryToProducts).Select(ca => ca.Category ).ToList();


            var vm = new DetailsViewModel()
            {
                Product = product,
                categories = categories
            };

            return View(vm);
        }


        public IActionResult AddToCart(int itemId)
        {

            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p=>p.ItemId == itemId);
            if (product != null)
            {

                var cartItem = new CartItem()
                {
                    Item = product.Item,
                    Quantity=1

                };
                _cart.addItem(cartItem);
            }
            return RedirectToAction("ShowCart");
            
        }
        public IActionResult ShowCart()
        {
            var CartVM = new CartViewModel()
            {
                cartItems = _cart.CartItems,
                OrderTotal = _cart.CartItems.Sum(c => c.getTotalPrice())

            };

            return View(CartVM);
        }

        public IActionResult RemoveCart(int itemid)
        {

            _cart.removeItem(itemid);
            return RedirectToAction("ShowCart");
        }
        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
