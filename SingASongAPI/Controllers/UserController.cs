using Microsoft.AspNetCore.Mvc;
using SingASongAPI.Models;
using SingASongAPI.Repository;

namespace SingASongAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserDataAccess _userDataAccess;

        public UserController(UserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        //Working
        // POST: api/User/Register
        [HttpPost("Register")]
        public ActionResult<User> Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userDataAccess.RegisterUser(user);
            return Ok(user);
        }

        //Working
        // POST: api/User/Login
        [HttpPost("Login")]
        public ActionResult<User> Login(Login login)
        {
            var authenticatedUser = _userDataAccess.ValidateUser(login.userEmail, login.userPassword);

            if (authenticatedUser != null)
            {
                bool isAdmin = _userDataAccess.CheckAdminPrivileges(authenticatedUser.userID);
                authenticatedUser.isAdmin = isAdmin;
                return Ok(authenticatedUser);
            }

            return Unauthorized();
        }
        //Working
        // POST: api/User/AddToCart
        [HttpPost("AddToCart")]
        public IActionResult AddToCart(int userID, int albumID)
        {
            _userDataAccess.AddToCart(userID, albumID);
            return NoContent();
        }

        //Working
        // GET: api/User/Cart
        [HttpGet("FetchCart")]
        public ActionResult<Cart> Cart(int userId)
        {
            var cart = _userDataAccess.GetCartAlbums(userId);
            if (cart != null)
            {
                return Ok(cart);
            }

            return NotFound();
        }

        [HttpPost("DeleteCart")]
        public ActionResult<Cart> DeleteFromCart(int albumID)
        {
            try
            {
                _userDataAccess.DeleteFromCart(albumID);
                return Ok(new { Message = "Successfully deleted from the cart.", SomeOtherData = "Additional information" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "An error occurred while deleting from the cart.", SomeOtherData = "Additional information" });
            }
        }
    }

}