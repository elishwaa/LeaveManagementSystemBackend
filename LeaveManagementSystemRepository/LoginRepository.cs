using LeaveManagementSystemModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LeaveManagementSystemRepository
{
    public class LoginRepository : ILoginRepository
    {

        private readonly string connectionString;
        private bool returnValue;
        public const string SessionName = "username";
        public LoginRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");

        }


        public Employee GetLogin(LoginDetails loginDetails)
        {
            Employee employee = new Employee();

            SqlConnection sqlconn = new SqlConnection(connectionString);
            SqlCommand sqlcomm = new SqlCommand("loginvalidation");
            sqlconn.Open();
            sqlcomm.Connection = sqlconn;
            sqlcomm.CommandType = CommandType.StoredProcedure;
            sqlcomm.Parameters.AddWithValue("@username", loginDetails.Username);
            sqlcomm.Parameters.AddWithValue("@password", loginDetails.Password);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            if (sdr.Read())
            {
                employee.Id = (int)sdr["id"];
                sdr.Close();
                SqlCommand sqlcom = new SqlCommand("employeedetails");
                sqlcom.Connection = sqlconn;
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.AddWithValue("@employeeid", employee.Id);
                SqlDataReader datareader = sqlcom.ExecuteReader();
                if (datareader.Read())
                {
                    employee.Id = (int)datareader["id"];
                    employee.TypeId = (int)datareader["typeid"];
                    employee.TypeName = datareader["etype"].ToString();
                    employee.FirstName = datareader["firstname"].ToString();
                    employee.MiddleName = datareader["middlename"].ToString();
                    employee.LastName = datareader["lastname"].ToString();
                    employee.Email = datareader["email"].ToString();
                    employee.Salary = (int)datareader["salary "];
                    employee.Username = datareader["username"].ToString();
                    employee.LocationId = (int)datareader["locationid"];
                    employee.LocationName = datareader["lname"].ToString();
                }
                //HttpContext.Session.SetString(SessionName, employee.Username)

            }
            return employee;
        }

        public IEnumerable<EmployeeType> GetEmpType()
        {
            List<EmployeeType> lstEmpType = new List<EmployeeType>();

            //if (HttpContext.Session.GetString(SessionName) != null)
            //{

            SqlConnection sqlconn = new SqlConnection(connectionString);
            SqlCommand sqlComm = new SqlCommand("GetEmployeeType");
            sqlconn.Open();
            sqlComm.Connection = sqlconn;
            sqlComm.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sqlComm.ExecuteReader();
            while (sdr.Read())
            {
                EmployeeType empType = new EmployeeType();
                empType.id = (int)sdr["Id"];
                empType.empType = sdr["EType"].ToString();
                lstEmpType.Add(empType);
            }


            return lstEmpType;
        }
        public bool NewLogin(NewLogin newLogin)
        {
            //if (HttpContext.Session.GetString(SessionName) == null)
            //{
                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("newLogin");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@employeeId", newLogin.employeeId);
                sqlComm.Parameters.AddWithValue("@username", newLogin.username);
                sqlComm.Parameters.AddWithValue("@password", newLogin.password);

                SqlParameter returnParameter = sqlComm.Parameters.Add("RetVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                sqlComm.ExecuteNonQuery();

                int id = (int)returnParameter.Value;
                if (id == 0)
                {
                    returnValue = false;
                }
                else
                {
                    returnValue = true;
                }
            //}
            return returnValue;
        }
    }
}
