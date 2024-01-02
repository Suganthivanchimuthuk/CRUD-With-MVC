using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DapperDataAccessLayer
{
    public class LocationRepository : ILocationRepository
    {
         string connectionString;
        

        public LocationRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DbConnection");
        }
        public IEnumerable<Location> GetAllLocations()
        {
            try
            {
                var con = new SqlConnection(connectionString);
                con.Open();
                var output = con.Query<Location>($"exec LocationDetails");
                con.Close();
                return output.ToList();
            }

            catch (SqlException Sql)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
