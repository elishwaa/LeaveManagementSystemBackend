using LeaveManagementSystemModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
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


        public Employee Get(LoginDetails loginDetails)
        {
            try
            {
                Employee employee = new Employee();

                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlcomm = new SqlCommand("loginValidation");
                sqlconn.Open();
                sqlcomm.Connection = sqlconn;
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.AddWithValue("@Username", loginDetails.Username);
                SqlDataReader sdr = sqlcomm.ExecuteReader();

                if (sdr.Read())
                {
                    employee.Id = (int)sdr["id"];
                    sdr.Close();
                    SqlCommand sqlcom = new SqlCommand("employeeDetails");
                    sqlcom.Connection = sqlconn;
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.AddWithValue("@employeeid", employee.Id);
                    SqlDataReader datareader = sqlcom.ExecuteReader();
                    if (datareader.Read())
                    {
                        employee.Id = (int)datareader["Id"];
                        employee.TypeId = (int)datareader["Typeid"];
                        employee.TypeName = datareader["Etype"].ToString();
                        employee.FirstName = datareader["Firstname"].ToString();
                        employee.MiddleName = datareader["Middlename"].ToString();
                        employee.LastName = datareader["Lastname"].ToString();
                        employee.Email = datareader["Email"].ToString();
                        employee.Salary = (int)datareader["Salary "];
                        employee.Username = datareader["Username"].ToString();
                        employee.LocationId = (int)datareader["LocationId"];
                        employee.LocationName = datareader["Lname"].ToString();
                        employee.ProjectId = (int)datareader["ProjectId"];
                        employee.ProjectName = datareader["ProjectName"].ToString();
                    }
                }
                return employee;
            }
            catch(Exception ex)
            {
                throw ex;
            }
         
        }

        public bool Add(Login login)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("newLogin");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@employeeId", login.EmployeeId);
                sqlComm.Parameters.AddWithValue("@username", login.Username);
                sqlComm.Parameters.AddWithValue("@password", login.Password);

                SqlParameter returnParameter = sqlComm.Parameters.Add("RetVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                sqlComm.ExecuteNonQuery();

                int id = (int)returnParameter.Value;
                if (id != 0)
                {
                    returnValue = true;
                }
                else
                {
                    returnValue = false;
                }

                return returnValue;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public bool EditPassword(EmployeePasswordChange passwordChange)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("updatePassword");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@empId", passwordChange.Id);
                sqlComm.Parameters.AddWithValue("@newPassword", passwordChange.Password);
                sqlComm.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
       
    }
}
