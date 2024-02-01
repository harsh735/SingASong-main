using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SingASongAPI.Models;

namespace SingASongAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private const string jsonFilePath = "./Data/Data.json";

        [HttpGet]
        public IActionResult GetAllData()
        {
            List<Album> albums = LoadAlbumsFromJson();
            return Ok(albums);
        }




        [HttpGet("search/{id}")]
        public IActionResult GetDataById(int? id)
        {
            List<Album> albums = LoadAlbumsFromJson();
            List<Album> searchedAlbumById = albums.Where(a => a.AlbumID == id).ToList();
            return Ok(searchedAlbumById);
        }



        [HttpGet("artist/{artistName}")]
        public IActionResult GetDataByArtistName(string artistName)
        {
            List<Album> albums = LoadAlbumsFromJson();
            List<Album> searchedAlbumByName = albums.Where(a => a.ArtistName == artistName).ToList();
            return Ok(searchedAlbumByName);
        }


        [HttpGet("genre/{genreName}")]
        public IActionResult GetDataByGenre(string genreName)
        {
            List<Album> albums = LoadAlbumsFromJson();
            List<Album> searchedAlbumByGenre = albums.Where(a => a.AlbumGenre == genreName).ToList();
            return Ok(searchedAlbumByGenre);
        }



        // Helper functions to load/save JSON data
        private List<Album> LoadAlbumsFromJson()
        {
            string json = System.IO.File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<List<Album>>(json);
        }
    }
}
