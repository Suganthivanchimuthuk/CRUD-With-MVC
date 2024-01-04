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
                var selectQuery = $"select LocationId,LocationName from Location";
                var list = con.Query<Location>(selectQuery);
                con.Close();
                return list.ToList();
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
        public VehicleInfo UpdateLocation(long id, VehicleInfo VI)
        {
            try
            {

                var con = new SqlConnection(connectionString);
                con.Open();
                var UpdateQuery = $"Update  VehicleInfo {id},'{VI.Name}',{VI.VehicleNumber},{VI.RCNumber},{VI.OwnerPhNo},'{VI.PurchaseDate.ToString("MM-dd-yyyy")},'{VI.LocationId} where Id={id}";
                var result = con.QueryFirstOrDefault<VehicleInfo>(UpdateQuery);
                con.Close();
                return result;

            }
            catch (SqlException sql)
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

