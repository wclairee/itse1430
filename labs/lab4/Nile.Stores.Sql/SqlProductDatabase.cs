/*
 * Claire Walker
 * ITSE 1430
 * Fall 2022
 */
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace Nile.Stores.Sql
{
    public class SqlProductDatabase : ProductDatabase
    {
        public SqlProductDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }

        protected override Product AddCore ( Product product )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("AddProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

                //Execute the command
                object result = cmd.ExecuteScalar();
                product.Id = Convert.ToInt32(result);

                return product;
            }

        }

        protected override Product FindByName ( string name )
        {
            using (var conn = OpenConnection())
            {
                {
                    var cmd = new SqlCommand("GetAllProducts", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.Equals(name))
                            {
                                return new Product() {
                                    Id = reader.GetFieldValue<int>("Id"),
                                    Name = reader.GetFieldValue<string>("Name"),
                                    Description = reader.GetFieldValue<string>("Description"),
                                    Price = reader.GetFieldValue<decimal>("Price"),
                                    IsDiscontinued = reader.GetFieldValue<bool>("IsDiscontinued"),
                                };
                            };
                        };
                    };
                };

                return null;
            };
        }

        protected override IEnumerable<Product> GetAllCore ()
        {
            var ds = new DataSet();

            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetAllProducts", conn);
                var da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            };

            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                foreach (var row in table.Rows.OfType<DataRow>())
                {
                    yield return new Product() {
                        Id = row.Field<int>("Id"),
                        Name = row.Field<string>("Name"),
                        Description = row.IsNull("Description") ? "" : row.Field<string>("Description"),
                        Price = row.Field<decimal>("Price"),
                        IsDiscontinued = row.Field<bool>("IsDiscontinued"),
                    };
                };
            };
        }

        protected override Product GetCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Product() {
                            Id = reader.GetFieldValue<int>("Id"),
                            Name = reader.GetFieldValue<string>("Name"),
                            Description = reader.IsDBNull("Description") ?
                                "" : reader.GetFieldValue<string>("Description"),
                            Price = reader.GetFieldValue<decimal>("Price"),
                            IsDiscontinued = reader.GetFieldValue<bool>("IsDiscontinued"),
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
                var cmd = new SqlCommand("RemoveProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            };
        }
        protected override void UpdateCore ( Product product )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("UpdateProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", product.Id);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

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