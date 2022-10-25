using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class MovieDatabase
    {
        public virtual Movie Add ( Movie movie, out string errorMessage )
        {
            //Array
            //Find first null element
            //If found then set to new movie
            //else 
            //  resize the array
            //      copy all existing elements over
            //      set 'oldarray.Length' to new movie
            //var numberOfElements = _movies.Length;

            //Validate movie
            if (movie == null)
            {
                errorMessage = "Movie cannot be null.";
                return null;
            };
            if (!movie.Validate(out errorMessage))
                return null;

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
            {
                errorMessage = "Movie must be unique.";
                return null;
            };

            //Add
            movie.Id = _id++;
            _movies.Add(movie.Clone());

            errorMessage = null;
            return movie;
        }

        public Movie Get ( int id )
        {
            //Enumerate array looking for match
            //for (var index = 0; index < _movies.Length; ++index)
            //  if (_movies[index]?.Id == id)
            //   return _movies[index].Clone();
            foreach (var movie in _movies)
                if (movie?.Id == id)
                    return movie.Clone(); //Clone becuase of ref type


            //if (_movie != null && _movie.Id == id)
               // return _movie;

            return null;
        }

        public Movie[] GetAll ()
        {
            var items = new Movie[_movies.Count];
            //for (var index = 0; index < _movies.Length; ++index)
            //    items[index] = _movies[index]?.Clone();
            var index = 0;
            foreach (var movie in _movies)
                items[index++] = movie.Clone();

            //Empty array
            //new Movie[0];

            return items;
        }

        public void Remove ( int id )
        {
            //TODO: Switch to foreach
            //enumerate array looking for match
            for (var index = 0; index < _movies.Count; ++index)
                if (_movies[index]?.Id == id)
                {
                    //_movies[index] = null;
                    _movies.RemoveAt(index);
                    return;
                };
           
        }

        public bool Update ( int id, Movie movie, out string errorMessage )
        {
            //Validate movie
            if (movie == null)
            {
                errorMessage = "Movie cannot be null.";
                return false;
            };
            if (!movie.Validate(out errorMessage))
                return false;

            //Movie must already exist
            var oldMovie = FindById(id);
            if (oldMovie == null)
            {
                errorMessage = "Movie does not exist.";
                return false;
            }
            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null && existing.Id != id)
            {
                errorMessage = "Movie must be unique.";
                return false;
            };

            movie.CopyTo(oldMovie);
            oldMovie.Id = id;

            errorMessage = null;
            return true;
        }

        private Movie FindById ( int id )
        {
            foreach (var movie in _movies)
                if (movie.Id == id)
                    return movie;

            return null;
        }


        private Movie FindByTitle( string title )
        {
            foreach (var movie in _movies)
                if (String.Equals(movie.Title, title, StringComparison.OrdinalIgnoreCase))
                    return movie;

            return null;
        }

        private int _id = 1;
       
       // private Movie[] _movies = new Movie[100];
       private List<Movie> _movies = new List<Movie>();
    }
}
