using Microsoft.AspNetCore.Mvc;
using SearchingOMDB.Models;
using System.Diagnostics;

namespace SearchingOMDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieSearch()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieSearch(string title)
        {
            SearchModel result = MovieDAL.SearchMovies(title);
            return View(result);
           
        }
        [HttpGet]
        public IActionResult MovieNight()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieNight(string t1, string t2, string t3)
        {
            MovieModel result1 = MovieDAL.GetMovie(t1);
            MovieModel result2 = MovieDAL.GetMovie(t2);
            MovieModel result3 = MovieDAL.GetMovie(t3);
            List<MovieModel> allMovies = new List<MovieModel>();

            allMovies.Add(result1);
            allMovies.Add(result2);
            allMovies.Add(result3);

            
            return View(allMovies);
        }
        public IActionResult MovieDetails(string Title)
        {
            MovieModel result = MovieDAL.GetMovie(Title);
            return View(result);

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
