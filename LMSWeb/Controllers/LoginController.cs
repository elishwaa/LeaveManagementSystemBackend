using LMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly string connectionString;
        //Employee employee = new Employee();
        //List<Employee> lstemployee = new List<Employee>();

        public LoginController(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
    
        // GET: api/Login
        [HttpPost]
        [Route("GetLogin")]
        public Employee GetLogin(LoginDetails loginDetails)
        {
            Employee employee = new Employee();

            SqlConnection sqlconn = new SqlConnection(connectionString);
            SqlCommand sqlComm = new SqlCommand("LoginValidation");
            sqlconn.Open();
            sqlComm.Connection = sqlconn;
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@Username", loginDetails.username);
            sqlComm.Parameters.AddWithValue("@Password", loginDetails.password);
            sqlComm.Parameters.AddWithValue("@EmpType", loginDetails.empType);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            if (sdr.Read())
            {
                employee.id = (int)sdr["Id"];
                sdr.Close();
                SqlCommand sqlCom = new SqlCommand("EmployeeDetails");
                sqlCom.Connection = sqlconn;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.Parameters.AddWithValue("@employeeId", employee.id);
                SqlDataReader dataReader = sqlCom.ExecuteReader();
                if (dataReader.Read())
                {
                    employee.id = (int)dataReader["Id"];
                    employee.typeId = (int)dataReader["TypeId"];
                    employee.typeName = dataReader["EType"].ToString();
                    employee.firstName = dataReader["FirstName"].ToString();
                    employee.middleName = dataReader["MiddleName"].ToString();
                    employee.lastName = dataReader["LastName"].ToString();
                    employee.email = dataReader["Email"].ToString();
                    employee.salary = (int)dataReader["Salary "];
                    employee.username = dataReader["Username"].ToString();
                    employee.locationId =(int)dataReader["LocationId"];
                    employee.locationName = dataReader["LName"].ToString();
                    //lstemployee.Add(employee);
                }
               
            }
            return employee;
        }

        [HttpGet]
        [Route("GetEmpType")]
        public ActionResult<IEnumerable<EmployeeType>> GetEmpType()
        {
            
            List<EmployeeType> lstEmpType = new List<EmployeeType>();

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
        [HttpPost]
        [Route("newLogin")]
        public bool newLogin([FromBody] NewLogin newLogin)
        {
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
            if(id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        // POST: api/Login

        //// GET: api/Login/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}



        //// PUT: api/Login/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
