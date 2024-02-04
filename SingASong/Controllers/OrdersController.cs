using Microsoft.AspNetCore.Mvc;
using SingASong.Models;
using System.Text.Json;

namespace SingASong.Controllers
{
    public class OrdersController : Controller
    {

        private HttpClient _client;


        public OrdersController()
        {
            _client = new HttpClient();
        }


        [HttpPost]
        public async Task<IActionResult> AddToCart(int userID, int albumID)
        {
            HttpResponseMessage response = await _client.PostAsync($"https://localhost:7238/api/User/AddToCart?userID={userID}&albumID={albumID}", null);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductCatalogue", "Product");
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var userId = HttpContext.Session?.GetInt32("UserID");

            if (userId.HasValue)
            {
                HttpResponseMessage response = await _client.GetAsync($"https://localhost:7238/api/User/FetchCart?userId={userId.Value}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var cart = JsonSerializer.Deserialize<Cart>(data);
                    return View(cart);
                }
            }

            return RedirectToAction("Login", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteFromCart(int albumID)
        {
            var userId = HttpContext.Session?.GetInt32("UserID");

            if (userId.HasValue)
            {
                HttpResponseMessage response = await _client.PostAsync($"https://localhost:7238/api/User/DeleteCart?albumId={albumID}", null);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Cart", "Orders");
                }
            }

            return RedirectToAction("Login", "Home");
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
