using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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
        [Route("Movies/New")]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel()
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var genres = _context.Genres.ToList();
                var viewModel = new NewMovieViewModel()
                {
                    Genres = genres
                };
                return View("MovieForm", viewModel);
            }
            movie.AddedDate = DateTime.Today;
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.AvailableStock = movie.AvailableStock;
                movie.AddedDate = movie.AddedDate;

            }
            _context.SaveChanges();
            return RedirectToAction("ShowMovies", "Movies");
        }

        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewMovieViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
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