using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class MovieDatabase
    {
        public virtual Movie Add ( Movie movie )
        {
            var numberOfElements = _movies.Length;
            _movie = movie;
            return movie;
        }

        public Movie Get ( int id )
        {
            if (_movie != null && _movie.Id == id)
                return _movie;

            return null;
        }

        public Movie[] GetAll ()
        {
            //TODO: Filter out null
            var items = new Movie[_movies.Length];
            for (var index = 0; index < _movies.Length; ++index)
                items[index] = _movies[index]?.Clone();

            //Empty array
            //new Movie[0];

            return items;
        }

        //Todo: remove this
        private Movie _movie;
        private Movie[] _movies = new Movie[100];
    }
}
