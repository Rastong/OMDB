using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OMDB_Excercise.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OMDB_Excercise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieSearchDAL movieSearchDAL = new MovieSearchDAL();

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

        public IActionResult MovieNight()
        {
            return View();
        }
        public IActionResult MovieSearch()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieNight(string title1, string title2, string title3)
        {
            MovieModel result1 = movieSearchDAL.GetMovieSearch(title1);
            MovieModel result2 = movieSearchDAL.GetMovieSearch(title2);
            MovieModel result3 = movieSearchDAL.GetMovieSearch(title3);
            List<MovieModel> results =new List<MovieModel>() { result1, result2, result3 };
            return View(results);
        }

        [HttpPost]
        public IActionResult MovieSearch(string title)
        {
            MovieModel result = movieSearchDAL.GetMovieSearch(title);
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
