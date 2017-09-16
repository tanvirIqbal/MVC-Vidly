using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }
        [Route("Movies")]
        public ActionResult ShowMovies()
        {
            MovieViewModel oMovieViewModel = new MovieViewModel();
            oMovieViewModel.Movies = _context.Movies.Include(x => x.Genre).ToList();

            return View("Movies",oMovieViewModel);
        }

        public ActionResult Details(int Id)
        {
            Movie oMovie = _context.Movies.Include(x => x.Genre).FirstOrDefault(x => x.Id == Id);
            return View(oMovie);
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