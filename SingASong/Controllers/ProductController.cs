using Microsoft.AspNetCore.Mvc;
using SingASong.Models;
using System.Text;
using System.Text.Json;
namespace SingASong.Controllers
{

    public class ProductController : Controller
    {
        private HttpClient _client;

        public ProductController()
        {
            _client = new HttpClient();
        }


        [HttpGet]
        public async Task<ActionResult> ProductCatalogue()
        {
            HttpResponseMessage response = await _client.GetAsync("https://localhost:7238/api/Admin/FetchAlbums");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var music = JsonSerializer.Deserialize<IList<Album>>(data);
                return View(music);
            }
            return View(new List<Album>());
        }


        [HttpGet]
        public async Task<ActionResult> SearchAlbum(int? searchAlbumId)
        {
            HttpResponseMessage response = await _client.GetAsync($"https://localhost:7238/api/Admin/FetchAlbums/{searchAlbumId}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                try
                {
                    var album = JsonSerializer.Deserialize<Album>(data);
                    var music = new List<Album> { album };
                    return View("ProductCatalogue", music);
                }
                catch (JsonException ex)
                {
                    ViewData["ErrorMessage"] = "Error deserializing JSON response.";
                    return View("ProductCatalogue", new List<Album>());
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "No matching albums found.";
                return View("AdminPage", new List<Album>());
            }
        }



        public IActionResult UserProfile()
        {
            int userId = HttpContext.Session.GetInt32("UserID") ?? 0;
            string userName = HttpContext.Session.GetString("UserName");
            string userEmail = HttpContext.Session.GetString("UserEmail");
            string userPhoneNo = HttpContext.Session.GetString("UserPhoneNo");
            string userAddress = HttpContext.Session.GetString("UserAddress");

            if (userId != 0)
            {
                User user = new User
                {
                    userID = userId,
                    userName = userName,
                    userEmail = userEmail,
                    userPhoneNo = userPhoneNo,
                    userAddress = userAddress
                };

                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

    }
}
