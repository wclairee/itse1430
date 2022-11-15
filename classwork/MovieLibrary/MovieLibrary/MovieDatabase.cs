namespace MovieLibrary
{
    /// <summary>Provides a database of movies.</summary>
    public abstract class MovieDatabase : IMovieDatabase
    {
        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <param name="errorMessage">The error message, if any.</param>
        /// <returns>The new movie.</returns>
        /// <remarks>
        /// Fails if:
        ///   - Movie is null
        ///   - Movie is not valid
        ///   - Movie title already exists
        /// </remarks>

        public Movie Add ( Movie movie)
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
                throw new ArgumentNullException(nameof(movie));
            ObjectValidator.Validate(movie);

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
                throw new InvalidOperationException("Movie title must be unique.");

            //Add
            movie = AddCore(movie);
            return movie;
        }

        protected abstract Movie AddCore ( Movie movie );

        /// <summary>Gets a movie.</summary>
        /// <param name="id">ID of the movie.</param>
        /// <returns>The movie, if any.</returns>
        /// <remarks>
        /// Fails if:
        ///    - Id is less than 1
        /// </remarks>
        public Movie Get ( int id )
        {
            
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            //foreach (var movie in _movies)
            //    if (movie?.Id == id)
            //        return movie.Clone();  //Clone because of ref type
            return GetCore(id);
        }

        protected abstract Movie GetCore ( int id );

        /// <summary>Gets all the movies.</summary>
        /// <returns>The movies.</returns>
        //public Movie[] GetAll ()
        //When method returns IEnumerable<T> you MAY use an iterator instead
        public IEnumerable<Movie> GetAll ()
        {
            return GetAllCore();
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

        protected abstract IEnumerable<Movie> GetAllCore ();

        /// <summary>Remove a movie.</summary>
        /// <param name="id">ID of the movie to remove.</param>
        /// <remarks>
        /// Fails if:
        /// - Id <= 0
        /// </remarks>
        public void Remove ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            RemoveCore(id);
            //Enumerate array looking for match
            //for (var index = 0; index < _movies.Count; ++index)
            //    if (_movies[index]?.Id == id)
            //    {
            //        //_movies[index] = null;
            //        _movies.RemoveAt(index);
            //        return;
            //    };
        }
        protected abstract void RemoveCore ( int id );

        /// <summary>Updates a movie in the database.</summary>
        /// <param name="movie">The new movie information.</param>
        /// <param name="errorMessage">The error message, if any.</param>
        /// <returns>true if successful or false otherwise.</returns>
        /// <remarks>
        /// Fails if:
        ///   - Id is <= 0
        ///   - Movie does not already exist
        ///   - Movie is null
        ///   - Movie is not valid
        ///   - Movie title already exists
        /// </remarks>

        public void Update ( int id, Movie movie )
        {
            //Validate movie
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            if (movie == null)
                throw new ArgumentOutOfRangeException(nameof(movie));

            ObjectValidator.Validate(movie);

            var oldMovie = GetCore(id);
            if (oldMovie == null)
                throw new ArgumentException("Movie does not exist.", nameof(movie));

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null && existing.Id != id)
                throw new InvalidOperationException("Movie title must be unique.");

            try
            {
                UpdateCore(id, movie);
            } catch ( Exception e )
            {
                throw new Exception("Update failed", e);
            };
            ////Copy 
            //movie.CopyTo(oldMovie);
            //oldMovie.Id = id;
        }

        protected abstract void UpdateCore ( int id, Movie movie );

        protected abstract Movie FindByTitle ( string title );
    }
}
