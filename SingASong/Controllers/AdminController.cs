using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SingASong.Models;

namespace SingASong.Controllers
{

    public class AdminController : Controller
    {


        private const string jsonFilePath = "C:\\Users\\harshendra.singh\\OneDrive - Incedo Technology Solutions Ltd\\Desktop\\SingASong-master\\SingASong\\Data\\Data.json";
        public IActionResult AdminPage([FromQuery] int? searchAlbumId)
        {
            List<Album> albums = LoadAlbumsFromJson();
            if (searchAlbumId.HasValue && searchAlbumId > 0)
            {
                albums = albums.Where(a => a.AlbumID == searchAlbumId).ToList();
            }
            return View(albums);
        }



        [HttpPost]
        //[Route("Admin/AddAlbum")]
        public IActionResult AddAlbum([FromBody] Album newAlbum)
        {
            List<Album> albums = LoadAlbumsFromJson();
            newAlbum.AlbumID = GetUniqueAlbumID(albums);

            albums.Add(newAlbum);
            SaveAlbumsToJson(albums);
            return RedirectToAction("AdminPage");
        }


        [HttpPost]
        public IActionResult DeleteAlbum(int albumID)
        {
            List<Album> albums = LoadAlbumsFromJson();
            Album albumToDelete = albums.First(a => a.AlbumID == albumID);
            albums.Remove(albumToDelete);
            SaveAlbumsToJson(albums);


            return RedirectToAction("AdminPage");
        }





        //Helper functions to load,save json data

        private int GetUniqueAlbumID(List<Album> albums)
        {
            return albums.Count > 0 ? albums.Max(a => a.AlbumID) + 1 : 1;
        }

        private List<Album> LoadAlbumsFromJson()
        {
            string json = System.IO.File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<List<Album>>(json);
        }

        private void SaveAlbumsToJson(List<Album> albums)
        {
            string json = JsonConvert.SerializeObject(albums, Formatting.Indented);
            System.IO.File.WriteAllText(jsonFilePath, json);
        }
    }
}
