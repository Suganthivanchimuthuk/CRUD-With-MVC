using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using DapperDataAccessLayer;

namespace DapperDataAccessLayer
{
    public class VehicleInfoRepository : IVehicleInfoRepository
    {

        public string connectionString;


        public VehicleInfoRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DbConnection");
        }
        public VehicleInfo InsertSP(VehicleInfo VehicleInfo)

        {

            try
            {
                //var connectionString = "Data source=desktop-blbgehj\\sqlexpress;initial catalog=batch7;user id=sa;password=Anaiyaan@123;";

                var con = new SqlConnection(connectionString);
                con.Open();
                con.Execute($"exec VehicleInfoInsert '{Location.LocationId}'{VehicleInfo.Name}',{VehicleInfo.VehicleNumber},'{VehicleInfo.RCNumber}',{VehicleInfo.OwnerPhNo},'{VehicleInfo.PurchaseDate}'");
                con.Close();

            }
            catch (SqlException Sql)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw;
            }


            return VehicleInfo;
        }

        public IEnumerable<VehicleInfo> GetVehicleInfoSP()
        {
            try
            {
                //  var connectionString = "Data source=desktop-blbgehj\\sqlexpress;initial catalog=batch7;user id=sa;password=Anaiyaan@123;";

                var con = new SqlConnection(connectionString);
                con.Open();
                var product = con.Query<VehicleInfo>($"exec ReadVehicleInfo");
                con.Close();
                return product.ToList();

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

        public void DeleteVehicleInfoSP(long id)
        {
            try
            {
                //   var connectionString = "Data source=desktop-blbgehj\\sqlexpress;initial catalog=batch7;user id=sa;password=Anaiyaan@123;";

                var con = new SqlConnection(connectionString);
                con.Open();
                var DeleteQuery = $" exec VehicleInfoDelete {id}";
                con.Execute(DeleteQuery);
                con.Close();


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
        public VehicleInfo UpdateVehicleInfoSP(long id, VehicleInfo VI)
        {
            try
            {
                //  var connectionString = "Data source=desktop-blbgehj\\sqlexpress;initial catalog=batch7;user id=sa;password=Anaiyaan@123;";

                var con = new SqlConnection(connectionString);
                con.Open();
                var UpdateQuery = $"exec  VehicleInfoUpdate {id},'{VI.Name}',{VI.VehicleNumber},{VI.RCNumber},{VI.OwnerPhNo},'{VI.PurchaseDate.ToString("MM-dd-yyyy")}'";
                var VehicleInfo = con.QueryFirstOrDefault<VehicleInfo>(UpdateQuery);
                Console.WriteLine(UpdateQuery);
                con.Close();
                return VehicleInfo;

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
        public VehicleInfo ReadVehicleInfoByNumber(long id)
        {

            try
            {
                //  var connectionString = "Data source=desktop-blbgehj\\sqlexpress;initial catalog=batch7;user id=sa;password=Anaiyaan@123;";
                var con = new SqlConnection(connectionString);
                con.Open();
                var selectQuery = $"exec  FindByNum {id}";
                var Find = con.QueryFirstOrDefault<VehicleInfo>(selectQuery);
                con.Close();
                return Find;

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
    





