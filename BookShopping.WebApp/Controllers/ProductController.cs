using Microsoft.AspNetCore.Mvc;

namespace BookShopping.WebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
