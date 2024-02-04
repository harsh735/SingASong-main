using Microsoft.AspNetCore.Mvc;
using SingASong.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;


namespace SingASong.Controllers
{


    public class HomeController : Controller
    {
        private HttpClient _client;
        public HomeController()
        {
            _client = new HttpClient();

        }




        public IActionResult HomePage()
        {
            return View();
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync("https://localhost:7238/api/User/Register", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login");
                }
            }
            return View(user);
        }




        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("https://localhost:7238/api/User/Login", content);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var authenticatedUser = JsonSerializer.Deserialize<User>(data);

                // Log user details
                Console.WriteLine($"Authenticated User: {JsonSerializer.Serialize(authenticatedUser)}");

                HttpContext.Session?.SetInt32("UserID", authenticatedUser?.userID ?? 0);
                HttpContext.Session?.SetString("UserName", authenticatedUser?.userName ?? "");
                HttpContext.Session.SetString("UserEmail", authenticatedUser.userEmail);
                HttpContext.Session.SetString("UserPhoneNo", authenticatedUser.userPhoneNo);
                HttpContext.Session.SetString("UserAddress", authenticatedUser.userAddress);

                if (authenticatedUser.isAdmin)
                {
                    // Log admin redirection
                    Console.WriteLine("Redirecting to AdminPage");
                    return RedirectToAction("AdminPage", "Admin");
                }
                else
                {
                    // Log user redirection
                    Console.WriteLine("Redirecting to ProductCatalogue");
                    return RedirectToAction("ProductCatalogue", "Product");
                }
            }
            else
            {
                // Log API error
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Error: {error}");

                ModelState.AddModelError("LoginError", "Invalid username or password");
                return View(user);
            }
        }






        public IActionResult Thankyou()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
