using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
        private string _title;

        public string Title
        {
            get {
                if (Movie != null && Movie.Id != 0)
                {
                    _title = "Edit Movie";
                }
                else
                {
                    _title = "New Movie";
                }
                return _title; }
        }

    }
}