//using System;
//using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc;

//namespace LMSWeb.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EmployeeController : ControllerBase
//    {


//        [HttpPost]
//        [Route("ChangePassword")]
//        public bool ChangePassword([FromBody] PasswordChange passwordChange)
//        {
//            try
//            {
//                SqlConnection sqlconn = new SqlConnection(connectionString);
//                SqlCommand sqlComm = new SqlCommand("UpdatePassword");
//                sqlconn.Open();
//                sqlComm.Connection = sqlconn;
//                sqlComm.CommandType = CommandType.StoredProcedure;
//                sqlComm.Parameters.AddWithValue("@empId", passwordChange.id);
//                sqlComm.Parameters.AddWithValue("@newPassword", passwordChange.password);
//                //SqlDataReader sdr = sqlComm.ExecuteReader();
//                sqlComm.ExecuteNonQuery();

//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }
//        [HttpGet]
//        [Route("ConfirmEmail")]
//        public int ConfirmEmail(string emailId)
//        {
//            SqlConnection sqlconn = new SqlConnection(connectionString);
//            SqlCommand sqlComm = new SqlCommand("GetEmployeeByEmail");
//            sqlconn.Open();
//            sqlComm.Connection = sqlconn;
//            sqlComm.CommandType = CommandType.StoredProcedure;
//            sqlComm.Parameters.AddWithValue("@emailId", emailId);
//            SqlDataReader sdr = sqlComm.ExecuteReader();
//            if (sdr.Read())
//            {
//                var employeeId = (int)sdr["Id"];
//                return employeeId;
//            }
//            else
//            {
//                return 0;
//            }
//        }




//        [HttpPost]
//        [Route("edit")]
//        public bool EditEmployeeDetails(Employee employee)
//        {
//            try
//            {
//                SqlConnection sqlconn = new SqlConnection(connectionString);
//                SqlCommand sqlComm = new SqlCommand("EditEmployeeDetails");
//                sqlconn.Open();
//                sqlComm.Connection = sqlconn;
//                sqlComm.CommandType = CommandType.StoredProcedure;
//                sqlComm.Parameters.AddWithValue("@id", employee.id);
//                sqlComm.Parameters.AddWithValue("@typeId", employee.typeId);
//                sqlComm.Parameters.AddWithValue("@firstName", employee.firstName.ToString());
//                sqlComm.Parameters.AddWithValue("@middleName", employee.middleName.ToString());
//                sqlComm.Parameters.AddWithValue("@lastName", employee.lastName.ToString());
//                sqlComm.Parameters.AddWithValue("@email", employee.email.ToString());
//                sqlComm.Parameters.AddWithValue("@salary", employee.salary);
//                sqlComm.Parameters.AddWithValue("@username", employee.username);
//                sqlComm.Parameters.AddWithValue("@projectId", employee.projectId);
//                sqlComm.Parameters.AddWithValue("@locationId", employee.locationId);
//                sqlComm.ExecuteNonQuery();
//                sqlconn.Close();
//                return true;
//            }
//            catch
//            {
//                return false;
//            }

//        }


//        [HttpGet]
//        [Route("allEmployees")]

//        public ActionResult<IEnumerable<Employee>> getAllEmployees()
//        {


//            List<Employee> lstemployee = new List<Employee>();
//            SqlConnection sqlconn = new SqlConnection(connectionString);
//            SqlCommand sqlCom = new SqlCommand("AllEmployees");
//            sqlconn.Open();
//            sqlCom.Connection = sqlconn;
//            sqlCom.CommandType = CommandType.StoredProcedure;
//            SqlDataReader sdr = sqlCom.ExecuteReader();
//            while (sdr.Read())
//            {
//                Employee employee = new Employee();
//                employee.id = (int)sdr["Id"];
//                employee.typeId = (int)sdr["TypeId"];
//                employee.typeName = sdr["EType"].ToString();
//                employee.firstName = sdr["FirstName"].ToString();
//                employee.middleName = sdr["MiddleName"].ToString();
//                employee.lastName = sdr["LastName"].ToString();
//                employee.email = sdr["Email"].ToString();
//                employee.salary = (int)sdr["Salary "];
//                employee.locationId = (int)sdr["LocationId"];
//                employee.locationName = sdr["LName"].ToString();
//                if (sdr["Username"] != DBNull.Value && sdr["ProjectId"] != DBNull.Value && sdr["ProjectName"] != DBNull.Value)

//                {
//                    employee.username = sdr["Username"].ToString();
//                    employee.projectId = (int)sdr["ProjectId"];
//                    employee.ProjectName = sdr["ProjectName"].ToString();

//                }
//                else
//                {
//                    employee.username = null;
//                    employee.projectId = 0;
//                    employee.ProjectName = null;
//                }

//                lstemployee.Add(employee);
//            }
//            sqlconn.Close();
//            return lstemployee;

//        }


//        [HttpPost]
//        [Route("AddEmployee")]
//        public bool AddEmployee(NewEmployee employee)
//        {
//            try
//            {
//                SqlConnection sqlconn = new SqlConnection(connectionString);
//                SqlCommand sqlComm = new SqlCommand("AddEmployee");
//                sqlconn.Open();
//                sqlComm.Connection = sqlconn;
//                sqlComm.CommandType = CommandType.StoredProcedure;
//                sqlComm.Parameters.AddWithValue("@empType", employee.empType);
//                sqlComm.Parameters.AddWithValue("@firstName", employee.firstName.ToString());
//                sqlComm.Parameters.AddWithValue("@middleName", employee.middleName.ToString());
//                sqlComm.Parameters.AddWithValue("@lastName", employee.lastName.ToString());
//                sqlComm.Parameters.AddWithValue("@email", employee.email.ToString());
//                sqlComm.Parameters.AddWithValue("@salary", employee.salary);
//                sqlComm.Parameters.AddWithValue("@project", employee.project);
//                sqlComm.Parameters.AddWithValue("@locationId", employee.location);
//                sqlComm.ExecuteNonQuery();

//                SqlCommand sqlCommand = new SqlCommand("AddToManagement");
//                sqlCommand.Connection = sqlconn;
//                sqlCommand.CommandType = CommandType.StoredProcedure;
//                sqlCommand.Parameters.AddWithValue("@manager", employee.manager);
//                sqlCommand.Parameters.AddWithValue("@email", employee.email.ToString());

//                sqlCommand.ExecuteNonQuery();

//                return true;
//            }
//            catch (Exception e)
//            {
//                return false;
//            }
//        }

//        [Route("NewDesignation")]
//        public bool NewDesignation([FromBody] newDesignation designation)
//        {
//            try
//            {
//                SqlConnection sqlconn = new SqlConnection(connectionString);
//                SqlCommand sqlComm = new SqlCommand("NewDesignation");
//                sqlconn.Open();
//                sqlComm.Connection = sqlconn;
//                sqlComm.CommandType = CommandType.StoredProcedure;
//                sqlComm.Parameters.AddWithValue("@employeeType", designation.designation);
//                sqlComm.ExecuteNonQuery();
//                sqlconn.Close();
//                return true;
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                return false;
//            }
//        }



//        [HttpGet]
//        [Route("GetManagers")]
//        public ActionResult<IEnumerable<Managers>> GetManagers()
//        {

//            List<Managers> lstManager = new List<Managers>();

//            SqlConnection sqlconn = new SqlConnection(connectionString);
//            SqlCommand sqlComm = new SqlCommand("GetManagers");
//            sqlconn.Open();
//            sqlComm.Connection = sqlconn;
//            sqlComm.CommandType = CommandType.StoredProcedure;
//            SqlDataReader sdr = sqlComm.ExecuteReader();
//            while (sdr.Read())
//            {
//                Managers manager = new Managers();
//                manager.managerId = (int)sdr["EmployeeId"];
//                manager.managerName = sdr["EmployeeName"].ToString();

//                lstManager.Add(manager);
//            }

//            return lstManager;

//        }



//        // GET: api/Employee
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET: api/Employee/5
//        [HttpGet("{id}", Name = "Get")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST: api/Employee
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }

//        // PUT: api/Employee/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE: api/ApiWithActions/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
