using Microsoft.AspNetCore.Mvc;
using SingASongAPI.Models;
using SingASongAPI.Repository;

namespace SingASongAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DBAccess _dbDataAccess;

        public AdminController(DBAccess dbDataAccess)
        {
            _dbDataAccess = dbDataAccess;
        }

        //Working
        // GET: api/Music
        [HttpGet("FetchAlbums")]
        public ActionResult<IEnumerable<Album>> GetAlbums()
        {
            return Ok(_dbDataAccess.GetAllAlbums());
        }

        //Working
        // GET: api/Music/5
        [HttpGet("FetchAlbums/{albumID}")]
        public ActionResult<Album> GetAlbums(int albumID)
        {
            var music = _dbDataAccess.GetAlbumById(albumID);

            if (music == null)
            {
                return NotFound();
            }

            return Ok(music);
        }


        [HttpGet("SearchAlbums/{albumName}")]
        public ActionResult<Album> GetSearchedAlbum(string? albumName)
        {
            var music = _dbDataAccess.GetAlbumByName(albumName);

            if (music == null)
            {
                return NotFound();
            }

            return Ok(music);
        }



        //Working
        // POST: api/Music
        [HttpPost("AddAlbums")]
        public ActionResult<Album> AddAlbum(Album album)
        {
            _dbDataAccess.AddAlbum(album);

            return Ok(album);
        }

        //Working
        // PUT: api/Music/5
        [HttpPut("UpdateAlbums/{albumID}")]
        public IActionResult UpdateAlbum(int albumID, [FromBody] Album updatedAlbum)
        {
            if (albumID != updatedAlbum.albumID)
            {
                return BadRequest();
            }

            _dbDataAccess.UpdateAlbum(updatedAlbum);

            var redirectUrl = Url.Action("AdminPage", "Admin");
            return Ok(new { RedirectUrl = redirectUrl });
        }




        //Working
        // DELETE: api/Music/5
        [HttpDelete("DeleteAlbums/{albumID}")]
        public IActionResult DeleteAlbum(int albumID)
        {
            _dbDataAccess.DeleteAlbum(albumID);

            return NoContent();
        }
    }
}