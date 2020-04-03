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
                var encryptedPassword = Encrypt(loginDetails.Password, "sblw-3hn8-sqoy19");
                Employee employee = new Employee();

                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlcomm = new SqlCommand("LoginValidation");
                sqlconn.Open();
                sqlcomm.Connection = sqlconn;
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.AddWithValue("@Username", loginDetails.Username);
                sqlcomm.Parameters.AddWithValue("@Password", encryptedPassword);
                SqlDataReader sdr = sqlcomm.ExecuteReader();

                if (sdr.Read())
                {
                    employee.Id = (int)sdr["id"];
                    sdr.Close();
                    SqlCommand sqlcom = new SqlCommand("EmployeeDetails");
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
                        employee.LocationId = (int)datareader["Locationid"];
                        employee.LocationName = datareader["Lname"].ToString();
                    }
                }
                return employee;
            }
            catch(Exception ex)
            {
                throw ex;
            }
         
        }

        public bool Login(Login login)
        {
            try
            {
                var encryptedPassword = Encrypt(login.Password, "sblw-3hn8-sqoy19");
                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("NewLogin");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@employeeId", login.EmployeeId);
                sqlComm.Parameters.AddWithValue("@username", login.Username);
                sqlComm.Parameters.AddWithValue("@password", encryptedPassword);

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

                return returnValue;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public static string Encrypt(string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
       
    }
}
