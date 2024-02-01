using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SingASongAPI.Models;

namespace SingASongAPI.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : ControllerBase
    {

        private const string jsonfilepath = "./Data/Data.json";


        [HttpPost("Add")]
        public IActionResult AddAlbum([FromBody] Album newAlbum)
        {
            List<Album> albums = LoadAlbumsFromJson();
            //newAlbum.AlbumID = GetUniqueAlbumID(albums);

            albums.Add(newAlbum);
            SaveAlbumsToJson(albums);
            return Ok(newAlbum);
        }

        [HttpPost("Delete/{albumId}")]
        public IActionResult DeleteAlbum(int albumId)
        {
            List<Album> albums = LoadAlbumsFromJson();
            Album albumToDelete = albums.First(a => a.AlbumID == albumId);
            albums.Remove(albumToDelete);
            SaveAlbumsToJson(albums);
            return Ok(albums);
        }


        [HttpPut("Update")]
        public IActionResult UpdateAlbum([FromBody] Album currAlbum)
        {
            List<Album> albums = LoadAlbumsFromJson();
            int albumId = currAlbum.AlbumID;
            Album updatedAlbum = albums.First(a => a.AlbumID == albumId);

            updatedAlbum.AlbumName = currAlbum.AlbumName;
            updatedAlbum.ArtistName = currAlbum.ArtistName;
            updatedAlbum.AlbumPrice = currAlbum.AlbumPrice;
            updatedAlbum.AlbumRating = currAlbum.AlbumRating;
            updatedAlbum.AlbumGenre = currAlbum.AlbumGenre;
            return Ok(updatedAlbum);

        }


        [HttpGet("Retreive")]
        public IActionResult ReadAlbums()
        {
            List<Album> albums = LoadAlbumsFromJson();
            return Ok(albums);
        }

        private List<Album> LoadAlbumsFromJson()
        {
            string json = System.IO.File.ReadAllText(jsonfilepath);
            return JsonConvert.DeserializeObject<List<Album>>(json);
        }

        private void SaveAlbumsToJson(List<Album> albums)
        {
            string json = JsonConvert.SerializeObject(albums, Formatting.Indented);
            System.IO.File.WriteAllText(jsonfilepath, json);
        }
    }
}
