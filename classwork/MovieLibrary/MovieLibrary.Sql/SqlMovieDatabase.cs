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
                //Create command option 2 - the long way
                var cmd = new SqlCommand();
                cmd.CommandText = "AddMovie";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                //Add parameters 1 - the best way
                cmd.Parameters.AddWithValue("@name", movie.Title);

                //Add parameters 2 - long way (or with type specified)
                var paramRating = new SqlParameter("@rating", movie.Rating);
                cmd.Parameters.Add(paramRating);

                //Add parameters 3 - generic
                var paramDescription = cmd.CreateParameter();
                paramDescription.ParameterName = "@description";
                paramDescription.Value = movie.Description;
                paramDescription.DbType = DbType.String;
                cmd.Parameters.Add(paramDescription);

                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                //Execute command
                object result = cmd.ExecuteScalar();
                movie.Id = Convert.ToInt32(result);

                return movie;
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
                var cmd = new SqlCommand("FindByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", title);

                //Read with streamed IO
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Movie() {
                            Id = (int)reader[0],   //Ordinal with cast
                            Title = reader["Name"] as string,   //Column name with cast
                            Description = reader.IsDBNull(2) ? "" : reader.GetString(2),   //Typed name with ordinal
                            Rating = reader.GetString("Rating"),
                            RunLength = reader.GetInt32("RunLength"),   //Typed name with column
                            ReleaseYear = reader.GetFieldValue<int>("ReleaseYear"),  //professor preferred
                            IsClassic = reader.GetFieldValue<bool>("IsClassic"),
                        };
                    };
                };
            };

            return null;
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
                var cmd = new SqlCommand("GetMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                //Read with streamed IO
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Movie() {
                            Id = (int)reader[0],   //Ordinal with cast
                            Title = reader["Name"] as string,   //Column name with cast
                            Description = reader.IsDBNull(2) ? "" : reader.GetString(2),   //Typed name with ordinal
                            Rating = reader.GetString("Rating"),
                            RunLength = reader.GetInt32("RunLength"),   //Typed name with column
                            ReleaseYear = reader.GetFieldValue<int>("ReleaseYear"),  //professor preferred
                            IsClassic = reader.GetFieldValue<bool>("IsClassic"),
                        };
                    };
                };
            };

            return null;
        }
        protected override void RemoveCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                //Create command option 3 - generic
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DeleteMovie";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                //Set parameters
                cmd.Parameters.AddWithValue("@id", id);

                //Execute command 2 - no results/don't care
                cmd.ExecuteNonQuery();
            };
        }
        protected override void UpdateCore ( int id, Movie movie )
        {
            using (var conn = OpenConnection())
            {
                //Create command option 2 - the long way
                var cmd = new SqlCommand();
                cmd.CommandText = "UpdateMovie";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", movie.Title);
                cmd.Parameters.AddWithValue("@rating", movie.Rating);
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                cmd.ExecuteNonQuery();
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