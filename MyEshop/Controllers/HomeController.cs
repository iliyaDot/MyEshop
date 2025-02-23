using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEshop.Data;
using MyEshop.Models;

namespace MyEshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
      private  MyEshopContext _context;

        public HomeController(ILogger<HomeController> logger, MyEshopContext context )
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p=p=>p.Id == id);


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
            return null;
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
