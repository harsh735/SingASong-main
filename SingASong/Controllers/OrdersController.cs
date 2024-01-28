using Microsoft.AspNetCore.Mvc;

namespace SingASong.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Payments()
        {
            return View();
        }

        public IActionResult PaymentsThanks()
        {
            return View();  
        }
    }
}
