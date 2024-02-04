using Microsoft.AspNetCore.Mvc;
using SingASong.Models;
using System.Text;
using System.Text.Json;


namespace SingASong.Controllers
{
    public class AdminController : Controller
    {
        private HttpClient _client;

        public AdminController()
        {
            _client = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult> AdminPage()
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

                Console.WriteLine($"JSON Response: {data}");

                try
                {
                    var album = JsonSerializer.Deserialize<Album>(data);
                    var music = new List<Album> { album };
                    return View("AdminPage", music);
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error deserializing JSON: {ex}");
                    ViewData["ErrorMessage"] = "Error deserializing JSON response.";
                    return View("AdminPage", new List<Album>());
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "No matching albums found.";
                return View("AdminPage", new List<Album>());
            }
        }




        [HttpPost]
        public async Task<ActionResult> AddAlbum(Album newAlbum)
        {
            var content = new StringContent(JsonSerializer.Serialize(newAlbum), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("https://localhost:7238/api/Admin/AddAlbums", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminPage");
            }
            return View(newAlbum);
        }


        [HttpPost]
        public async Task<ActionResult> UpdateAlbum(int albumID, Album updatedAlbum)
        {
            var content = new StringContent(JsonSerializer.Serialize(updatedAlbum), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync($"https://localhost:7238/api/Admin/UpdateAlbums/{albumID}", content);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<Dictionary<string, string>>(data);

                return RedirectToAction("AdminPage", "Admin");

            }

            return NotFound();
        }



        [HttpPost]
        public async Task<ActionResult> DeleteAlbum(int albumID)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"https://localhost:7238/api/Admin/DeleteAlbums/{albumID}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(AdminPage));
            }
            return NotFound();
        }


        public IActionResult GenerateReports()
        {
            return View();
        }
    }
}
