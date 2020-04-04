using LeaveManagementSystemModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LeaveManagementSystemRepository
{
    public class LocationRepository :ILocationRepository
    {
        private readonly string connectionString;

        public LocationRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public bool Add(LocationAddRequest location)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("newLocation");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@location", location.Location);
                sqlComm.ExecuteNonQuery();
                sqlconn.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Locations> Get()
        {
            try
            {
                List<Locations> lstLocation = new List<Locations>();

                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("getLocations");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = sqlComm.ExecuteReader();
                while (sdr.Read())
                {
                    Locations location = new Locations();
                    location.LocationId = (int)sdr["Id"];
                    location.LocationName = sdr["LName"].ToString();
                    lstLocation.Add(location);
                }
                return lstLocation;
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
