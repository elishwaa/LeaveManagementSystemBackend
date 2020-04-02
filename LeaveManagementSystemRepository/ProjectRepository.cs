using LeaveManagementSystemModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LeaveManagementSystemRepository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly string connectionString;

        public ProjectRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public IEnumerable<Projects> GetProject()
        {

            List<Projects> lst = new List<Projects>();

            SqlConnection sqlconn = new SqlConnection(connectionString);
            SqlCommand sqlComm = new SqlCommand("GetProjects");
            sqlconn.Open();
            sqlComm.Connection = sqlconn;
            sqlComm.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sqlComm.ExecuteReader();
            while (sdr.Read())
            {
                Projects projects = new Projects();
                projects.projectId = (int)sdr["Id"];
                projects.projectName = sdr["ProjectName"].ToString();

                lst.Add(projects);

            }
            return lst;
        }

        public bool NewProject(NewProject newProject)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("NewProject");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@project", newProject.project);
                sqlComm.ExecuteNonQuery();
                sqlconn.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
