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

        public bool NewLocation(NewLocation newLocation)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("NewLocation");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@location", newLocation.Location);
                sqlComm.ExecuteNonQuery();
                sqlconn.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Locations> GetLocations()
        {
            List<Locations> lstLocation = new List<Locations>();

            SqlConnection sqlconn = new SqlConnection(connectionString);
            SqlCommand sqlComm = new SqlCommand("GetLocations");
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
    }
}
