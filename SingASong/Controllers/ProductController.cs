using Microsoft.AspNetCore.Mvc;

namespace SingASong.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult ProductCatalogue()
        {
            return View();
        }
    }
}
