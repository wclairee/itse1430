namespace MovieLibrary.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        protected override Movie AddCore ( Movie movie ) => throw new NotImplementedException();
        protected override Movie FindByTitle ( string title ) => throw new NotImplementedException();
        protected override IEnumerable<Movie> GetAllCore () => throw new NotImplementedException();
        protected override Movie GetCore ( int id ) => throw new NotImplementedException();
        protected override void RemoveCore ( int id ) => throw new NotImplementedException();
        protected override void UpdateCore ( int id, Movie movie ) => throw new NotImplementedException();
    }
}