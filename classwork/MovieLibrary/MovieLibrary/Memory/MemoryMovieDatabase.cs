namespace MovieLibrary.Memory
{
    public class MemoryMovieDatabase : MovieDatabase
    {

        protected override Movie AddCore ( Movie movie )
        {
            //Array
            // Find first null element
            // If found then set to new movie
            // Else
            //   Resize the array 
            //   Copy all existing elements over
            //   Set 'oldarray.Length' to new movie

            //Add
            movie.Id = _id++;
            _movies.Add(movie.Clone());

            return movie;
        }

        protected override Movie GetCore ( int id )
        {
            return _movies.FirstOrDefault(x => x.Id == id)?.Clone();

            //Enumerate array looking for match            
            //for (var index = 0; index < _movies.Length; ++index)
            //if (_movies[index]?.Id == id)
            //return _movies[index].Clone();  //Clone because of ref type
            //foreach (var movie in _movies)
            //    if (movie?.Id == id)
            //        return movie.Clone();  //Clone because of ref type

            //return null;
        }

        //When method returns IEnumerable<T> you MAY use an iterator instead
        protected override IEnumerable<Movie> GetAllCore ()
        {
            //Select transforms IEnumerable<S> into IEnumerable<T>
            //return _movies.Select(x => x.Clone());

            //LINQ syntax version
            // from tempVar in IEnumerable<T>
            // where <condition>
            // order by
            // select <expression>
            return from movie in _movies
                   //where movie.Id > 10
                   orderby movie.Title, movie.ReleaseYear
                   select movie.Clone();

            //var items = new List<Movie>();

            //When returning an array, clone it...
            //var items = new Movie[_movies.Count];
            //for (var index = 0; index < _movies.Length; ++index)
            //    items[index] = _movies[index]?.Clone();
            //var index = 0;
            //foreach (var movie in _movies)
            //{
            //    //items[index++] = movie.Clone();
            //    //items.Add(movie.Clone());
            //    yield return movie.Clone();
            //};

            //return items;
        }

        protected override void RemoveCore ( int id )
        {
            var movie = FindById(id);
            if (movie != null)
                _movies.Remove(movie);

            //Enumerate array looking for match
            //for (var index = 0; index < _movies.Count; ++index)
            //    if (_movies[index]?.Id == id)
            //    {
            //        //_movies[index] = null;
            //        _movies.RemoveAt(index);
            //        return;
            //    };
        }

        protected override void UpdateCore ( int id, Movie movie )
        {
            //Copy 
            var oldMovie = FindById(id);
            if (oldMovie == null)
                throw new NotSupportedException("Movie does not exist.");

            movie.CopyTo(oldMovie);
            oldMovie.Id = id;
        }

        private Movie FindById ( int id )
        {
            //Where takes a IEnumerable<T> and returns all items that match the predicate
            //defined by Func<Movie, bool>
            //return _movies.Where(FilterById)
            //              .FirstOrDefault();
            // Line below is same as above two lines
            //return _movies.FirstOrDefault(FilterById);

            //lambda-anonymous method/function
            // foo (Movie x) { returns x.Id == id; }
            return _movies.FirstOrDefault(x => x.Id == id);

            //foreach (var movie in _movies)
            //    if (movie.Id == id)
            //        return movie;

            //return null;
        }

        private bool FilterById ( Movie movie )
        {
            return true;
        }

        protected override Movie FindByTitle ( string title )
        {
            return _movies.FirstOrDefault(
                x => String.Equals(x.Title, title, StringComparison.OrdinalIgnoreCase));

            //foreach (var movie in _movies)
            //    if (String.Equals(movie.Title, title, StringComparison.OrdinalIgnoreCase))
            //        return movie;

            //return null;
        }

        private int _id = 1;

        //System.Collections.Generic
        //private Movie[] _movies = new Movie[100];
        private List<Movie> _movies  = new List<Movie>();
        //private Collection<Movie> _movies = new Collection<Movie>();
        //List<string>;
        //  List<int>;
    }
}
