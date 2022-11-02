namespace MovieLibrary
{
    public interface IMovieDatabase
    {
        Movie Add ( Movie movie, out string errorMessage );
        Movie Get ( int id );
        IEnumerable<Movie> GetAll ();
        void Remove ( int id );
        bool Update ( int id, Movie movie, out string errorMessage );
    }
}
