using Microsoft.AspNetCore.Mvc;

namespace BookShopping.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
