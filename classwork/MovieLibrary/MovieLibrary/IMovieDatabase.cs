namespace MovieLibrary
{
    /// <summary> Provides a database of movies.</summary>
    public interface IMovieDatabase
    {
        /// <summary>Adds a movie to the database.</summary>
        Movie Add ( Movie movie, out string errorMessage );
        Movie Get ( int id );
        IEnumerable<Movie> GetAll ();
        void Remove ( int id );
        bool Update ( int id, Movie movie, out string errorMessage );
    }
}
