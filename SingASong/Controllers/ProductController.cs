using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SingASong.Models;

namespace SingASong.Controllers
{

    public class ProductController : Controller
    {
        private const string jsonFilePath = "C:\\Users\\harshendra.singh\\OneDrive - Incedo Technology Solutions Ltd\\Desktop\\SingASong-master\\SingASong\\Data\\Data.json";

        public IActionResult ProductCatalogue(string? searchAlbumName)
        {
            List<Album> albums = LoadAlbumsFromJson();
            if (searchAlbumName != null)
            {
                albums = albums.Where(a => a.AlbumName == searchAlbumName).ToList();
            }
            return View(albums);
        }

        private List<Album> LoadAlbumsFromJson()
        {
            string json = System.IO.File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<List<Album>>(json);
        }
    }
}
