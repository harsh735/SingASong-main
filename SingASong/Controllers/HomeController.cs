using Microsoft.AspNetCore.Mvc;
using SingASong.Models;
using System.Diagnostics;

namespace SingASong.Controllers
{


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[Authorize(Users="Harsh,Anshuman", Roles = "Admin")]
        public IActionResult Index()
        {


            return View();
        }

        public IActionResult HomePage()
        {

            //string ConnectionString = "Data Source=G1-HPML114-L\\SQLEXPRESS;Initial Catalog=master;";
            //SqlConnection con = new SqlConnection(ConnectionString);
            //con.Open();
            //SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter dbadapt = new SqlDataAdapter();
            //dbadapt.SelectCommand.CommandType = CommandType.Text;
            //dbadapt.SelectCommand.CommandText = "Select * from spt_fallback_db";
            //dbadapt.SelectCommand.Connection = con;


            //DataSet ds = new DataSet();
            //dbadapt.Fill(ds);
            //var model = ds.Tables[0];
            //return View(model);

            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Thankyou()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
