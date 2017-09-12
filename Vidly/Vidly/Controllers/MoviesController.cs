using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }
        [Route("Movies")]
        public ActionResult ShowMovies()
        {
            MovieViewModel oMovieViewModel = new MovieViewModel();
            oMovieViewModel.Movies = GetMovies();

            return View("Movies",oMovieViewModel);
        }

        public List<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie(){ Name = "Misson Impossible"},
                new Movie(){ Name = "Captain America"}
            };
        }
    }
}