using System.Data;
using System.Data.SqlClient;

namespace MovieLibrary.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        public SqlMovieDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }
        protected override Movie AddCore ( Movie movie )
        {
            //Using statement
            using (var conn = OpenConnection())
            {
                throw new NotImplementedException();
            };

            //Try-finally equivalent
            //SqlConnection conn = null;
            //try
            //{
            //    conn = OpenConnection();
            //    throw new NotImplementedException();
            //} finally
            //{
            //    //Clean up connection
            //    conn?.Close();
            //};
        }
        protected override Movie FindByTitle ( string title )
        {
            using (var conn = OpenConnection())
            {
                throw new NotImplementedException();
            };
        }
        protected override IEnumerable<Movie> GetAllCore ()
        {
            var ds = new DataSet();

            using (var conn = OpenConnection())
            {
                //Create command 1
                var cmd = new SqlCommand("GetMovies", conn);
               
                //Need data adapter for Dataset
                var da = new SqlDataAdapter(cmd);

                //Buffered IO
                da.Fill(ds);
            };

            //Data loaded, can work with it now
            //find table and then enumerate rows to get data
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                foreach(var row in table.Rows.OfType<DataRow>())
                {
                    yield return new Movie() {
                        Id = (int)row[0],                       //Ordinal index with cast
                        Title = row["Name"] as string,         //Name with cast
                        Description = row.IsNull(2) ? "" : row.Field<string>(2),     //Ordinal index with generic
                        Rating = row.Field<string>("Rating"),   //Column with generic
                        RunLength = row.Field<int>("RunLength"), 
                        ReleaseYear = row.Field<int>("ReleaseYear"),
                        IsClassic = row.Field<bool>("IsClassic"),
                    };
                };
            };
        }
        protected override Movie GetCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                throw new NotImplementedException();
            };
        }
        protected override void RemoveCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                throw new NotImplementedException();
            };
        }
        protected override void UpdateCore ( int id, Movie movie )
        {
            using (var conn = OpenConnection())
            {
                throw new NotImplementedException();
            };
        }
        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }

        private readonly string _connectionString;
    }
}