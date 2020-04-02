//using System;
//using System.Collections.Generic;
//using LMSWeb.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Data.SqlClient;
//using Microsoft.Extensions.Configuration;
//using System.Data;
//using Newtonsoft.Json;

//namespace LMSWeb.Controllers
//{

//    [Route("api/[controller]")]
//    [ApiController]
//    public class LeaveController : ControllerBase
//    {
//        private readonly string connectionString;
//        List<LeaveRequestHistory> lstLeaveRequest = new List<LeaveRequestHistory>();
        

//        public LeaveController(IConfiguration configuration)
//        {
//            connectionString = configuration.GetConnectionString("DefaultConnection");
//        }
//        // GET: api/LeaveRequest
//        [HttpPost]
//        [Route("SaveLeave")]
//        public bool SaveLeaveRequests(LeaveRequest leaverequest)
//        {
//            try
//            {
//                SqlConnection sqlconn = new SqlConnection(connectionString);
//                SqlCommand sqlComm = new SqlCommand("LeaveRequest");
//                sqlconn.Open();
//                sqlComm.Connection = sqlconn;
//                sqlComm.CommandType = CommandType.StoredProcedure;
//                sqlComm.Parameters.AddWithValue("@empId", leaverequest.empId);
//                sqlComm.Parameters.AddWithValue("@startDate", leaverequest.startDate.ToString("MM-dd-yyyy"));
//                sqlComm.Parameters.AddWithValue("@endDate", leaverequest.endDate.ToString("MM-dd-yyyy"));
//                sqlComm.Parameters.AddWithValue("@leaveId", leaverequest.leave);
//                sqlComm.Parameters.AddWithValue("@reason", leaverequest.reason);
//                SqlParameter returnParameter = sqlComm.Parameters.Add("RetVal", SqlDbType.Int);
//                returnParameter.Direction = ParameterDirection.ReturnValue;
//                sqlComm.ExecuteNonQuery();
//                int id = (int)returnParameter.Value;
//                if (id == 1)
//                {
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }

//            }
//            catch
//            {
//                return false;
//            }
//        }

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

//        [HttpGet]
//        [Route("GetLeaveRequests")]
//        public ActionResult<IEnumerable<LeaveRequestHistory>> GetLeaveRequests(int id)
//        {
//            List<LeaveRequestHistory> lstLeaveRequest = new List<LeaveRequestHistory>();
//            SqlConnection sqlconn = new SqlConnection(connectionString);
//            SqlCommand sqlComm = new SqlCommand("GetLeaveRequests");
//            sqlconn.Open();
//            sqlComm.Connection = sqlconn;
//            sqlComm.CommandType = CommandType.StoredProcedure;
//            sqlComm.Parameters.AddWithValue("@empId", id);
//            SqlDataReader sdr = sqlComm.ExecuteReader();
//            while (sdr.Read())
//            {
//                LeaveRequestHistory leaveRequestHistory = new LeaveRequestHistory();
//                leaveRequestHistory.id = (int)sdr["Id"];
//                leaveRequestHistory.empId = (int)sdr["EmployeeId"];
//                leaveRequestHistory.employeeName = sdr["FirstName"].ToString();
//                leaveRequestHistory.startDate = (DateTime)sdr["StartDate"];
//                leaveRequestHistory.endDate = (DateTime)sdr["EndDate"];
//                leaveRequestHistory.leaveId = (int)sdr["LeaveId"];
//                leaveRequestHistory.leave = sdr["EType"].ToString();
//                leaveRequestHistory.status = sdr["Status"].ToString();
//                leaveRequestHistory.reason = sdr["Reason"].ToString();
//                lstLeaveRequest.Add(leaveRequestHistory);
//            }
//            sqlconn.Close();
//            return lstLeaveRequest;
//        }

//        [HttpGet]
//        [Route("allLeaveRequests")]
//        public ActionResult<IEnumerable<LeaveRequestHistory>> AllLeaveRequests(int id)
//        {
//            List<LeaveRequestHistory> lstLeaveRequest = new List<LeaveRequestHistory>();
//            SqlConnection sqlconn = new SqlConnection(connectionString);
//            SqlCommand sqlComm = new SqlCommand("AllLeaveRequests");
//            sqlconn.Open();
//            sqlComm.Connection = sqlconn;
//            sqlComm.CommandType = CommandType.StoredProcedure;
//            sqlComm.Parameters.AddWithValue("@Id", id);
//            SqlDataReader sdr = sqlComm.ExecuteReader();
//            while (sdr.Read())
//            {
//                LeaveRequestHistory leaveRequestHistory = new LeaveRequestHistory();
//                leaveRequestHistory.id = (int)sdr["Id"];
//                leaveRequestHistory.empId = (int)sdr["EmployeeId"];
//                leaveRequestHistory.employeeName = sdr["EmpName"].ToString();
//                leaveRequestHistory.startDate = (DateTime)sdr["StartDate"];
//                leaveRequestHistory.endDate = (DateTime)sdr["EndDate"];
//                leaveRequestHistory.leaveId = (int)sdr["LeaveId"];
//                leaveRequestHistory.leave = sdr["EType"].ToString();
//                leaveRequestHistory.status = sdr["Status"].ToString();
//                leaveRequestHistory.reason = sdr["Reason"].ToString();
//                lstLeaveRequest.Add(leaveRequestHistory);
//            }
//            sqlconn.Close();
//            return lstLeaveRequest;

//        }
//        [HttpDelete]
//        [Route("delete")]
//        public bool Delete(int id)
//        {
//            try
//            {
//                SqlConnection sqlconn = new SqlConnection(connectionString);
//                SqlCommand sqlComm = new SqlCommand("DeleteRequest");
//                sqlconn.Open();
//                sqlComm.Connection = sqlconn;
//                sqlComm.CommandType = CommandType.StoredProcedure;
//                sqlComm.Parameters.AddWithValue("@leaveRequestId", id);
//                sqlComm.ExecuteNonQuery();
//                sqlconn.Close();
//                return true;
//            }
//            catch
//            {
//                return false;
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

     
//        [HttpPost]
//        [Route("EditAndApprove")]
//        public bool EditAndApprove(LeaveRequestHistory leaveRequest)
//        {
//            try
//            {
//                SqlConnection sqlconn = new SqlConnection(connectionString);
//                SqlCommand sqlComm = new SqlCommand("EditAndApprove");
//                sqlconn.Open();
//                sqlComm.Connection = sqlconn;
//                sqlComm.CommandType = CommandType.StoredProcedure;
//                sqlComm.Parameters.AddWithValue("@id", leaveRequest.id);
//                sqlComm.Parameters.AddWithValue("@empId", leaveRequest.empId);
//                sqlComm.Parameters.AddWithValue("@startDate", leaveRequest.startDate.ToString());
//                sqlComm.Parameters.AddWithValue("@endDate", leaveRequest.endDate.ToString());
//                sqlComm.Parameters.AddWithValue("@leaveId", leaveRequest.leaveId.ToString());
//                sqlComm.Parameters.AddWithValue("@leave", leaveRequest.leave.ToString());
//                sqlComm.ExecuteNonQuery();
//                sqlconn.Close();
//                return true;
//            }
//            catch
//            {
//                return false;
//            }

//        }
//        [HttpPost]
//        [Route("Approve")]
//        public bool ApproveLeaveRequest(LeaveRequestHistory leave)
//        {
//            try
//            {
//                SqlConnection sqlconn = new SqlConnection(connectionString);
//                SqlCommand sqlComm = new SqlCommand("ApproveLeaveRequest");
//                sqlconn.Open();
//                sqlComm.Connection = sqlconn;
//                sqlComm.CommandType = CommandType.StoredProcedure;
//                sqlComm.Parameters.AddWithValue("@Id", leave.id);
//                sqlComm.Parameters.AddWithValue("@empId", leave.empId);
//                sqlComm.Parameters.AddWithValue("@startDate", leave.startDate);
//                sqlComm.Parameters.AddWithValue("@endDate", leave.endDate);
//                sqlComm.Parameters.AddWithValue("@leaveId", leave.leaveId);
//                sqlComm.Parameters.AddWithValue("@reason", leave.reason);
//                SqlParameter returnParameter = sqlComm.Parameters.Add("RetVal", SqlDbType.Int);
//                returnParameter.Direction = ParameterDirection.ReturnValue;
//                sqlComm.ExecuteNonQuery();
//                int id = (int)returnParameter.Value;
//                if (id == 1)
//                {
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
              
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
//        [HttpPost]
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
//        [HttpPost]
//        [Route("NewLocation")]
//        public bool NewLocation([FromBody] NewLocation newLocation)
//        {
//            try
//            {
//                SqlConnection sqlconn = new SqlConnection(connectionString);
//                SqlCommand sqlComm = new SqlCommand("NewLocation");
//                sqlconn.Open();
//                sqlComm.Connection = sqlconn;
//                sqlComm.CommandType = CommandType.StoredProcedure;
//                sqlComm.Parameters.AddWithValue("@location", newLocation.location);
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
//        [HttpPost]
//        [Route("NewLeave")]
//        public bool NewLeave([FromBody] NewLeave newLeave)
//        {
//            try
//            {
//                SqlConnection sqlconn = new SqlConnection(connectionString);
//                SqlCommand sqlComm = new SqlCommand("NewLeave");
//                sqlconn.Open();
//                sqlComm.Connection = sqlconn;
//                sqlComm.CommandType = CommandType.StoredProcedure;
//                sqlComm.Parameters.AddWithValue("@leave", newLeave.leave);
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
//        [HttpPost]
//        [Route("NewProject")]
//        public bool NewProject([FromBody] NewProject newProject)
//        {
//            try
//            {
//                SqlConnection sqlconn = new SqlConnection(connectionString);
//                SqlCommand sqlComm = new SqlCommand("NewProject");
//                sqlconn.Open();
//                sqlComm.Connection = sqlconn;
//                sqlComm.CommandType = CommandType.StoredProcedure;
//                sqlComm.Parameters.AddWithValue("@project", newProject.project);
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
//        [Route("Transactions")]
//        public ActionResult<IEnumerable<Transactions>> Transactions(int id)
//        {
//            List<Transactions> lstTransactions = new List<Transactions>();

//            SqlConnection sqlconn = new SqlConnection(connectionString);
//            SqlCommand sqlComm = new SqlCommand("Transactions");
//            sqlconn.Open();
//            sqlComm.Connection = sqlconn;
//            sqlComm.CommandType = CommandType.StoredProcedure;
//            sqlComm.Parameters.AddWithValue("@employeeId", id);
//            SqlDataReader sdr = sqlComm.ExecuteReader();

//            while (sdr.Read())
//            {
//                Transactions transactions = new Transactions();
//                transactions.empId = (int)sdr["Id"];
//                transactions.empName = sdr["EmployeeName"].ToString();
//                transactions.leaveType = sdr["leave"].ToString();
//                transactions.startDate =(DateTime) sdr["Startdate"];
//                transactions.endDate = (DateTime)sdr["EndDate"];
//                transactions.totaldays = (int)sdr["NumberOfDays"];
//                transactions.status = sdr["Status"].ToString();
//                lstTransactions.Add(transactions);
//            }

//            return lstTransactions;

//        }
        

//        [HttpGet]
//        [Route("GetLocations")]
//        public ActionResult<IEnumerable<Locations>> GetLocations()
//        {

//            List<Locations> lstLocation = new List<Locations>();

//            SqlConnection sqlconn = new SqlConnection(connectionString);
//            SqlCommand sqlComm = new SqlCommand("GetLocations");
//            sqlconn.Open();
//            sqlComm.Connection = sqlconn;
//            sqlComm.CommandType = CommandType.StoredProcedure;
//            SqlDataReader sdr = sqlComm.ExecuteReader();
//            while (sdr.Read())
//            {
//                Locations location = new Locations();
//                location.locationId = (int)sdr["Id"];
//                location.locationName = sdr["LName"].ToString();
//                lstLocation.Add(location);
//            }

//            return lstLocation;

//        }
//        [HttpGet]
//        [Route("GetLeaves")]
//        public ActionResult<IEnumerable<Leaves>> GetLeaves()
//        {

//            List<Leaves> lstLeaves = new List<Leaves>();

//            SqlConnection sqlconn = new SqlConnection(connectionString);
//            SqlCommand sqlComm = new SqlCommand("GetLeaves");
//            sqlconn.Open();
//            sqlComm.Connection = sqlconn;
//            sqlComm.CommandType = CommandType.StoredProcedure;
//            SqlDataReader sdr = sqlComm.ExecuteReader();
//            while (sdr.Read())
//            {
//                Leaves leaves = new Leaves();
//                leaves.id = (int)sdr["Id"];
//                leaves.leaveName = sdr["EType"].ToString();
//                lstLeaves.Add(leaves);
//            }

//            return lstLeaves;

//        }
//        [HttpGet]
//        [Route("GetLeaveBalance")]
//        public string GetLeaveBalance(int id)
//        {
//            SqlConnection sqlconn = new SqlConnection(connectionString);
//            SqlDataAdapter dataAdapter = new SqlDataAdapter();
//            DataSet dataset = new DataSet();
//            sqlconn.Open();
//            SqlCommand sqlComm = new SqlCommand("GetLeaveBalance",sqlconn);
//            sqlComm.Parameters.Add(new SqlParameter("@id", id));
//            sqlComm.CommandType = CommandType.StoredProcedure;
//            dataAdapter.SelectCommand = sqlComm;
//            dataAdapter.Fill(dataset);
            
//            //dataset.Tables[0].TableName = "LeaveBalanceData";
//            //dataset.Tables[1].TableName = "Leaves";
//            string json = JsonConvert.SerializeObject(dataset, Formatting.Indented);

//            return json;

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
//        [HttpGet]
//        [Route("GetProjects")]
//        public ActionResult<IEnumerable<Projects>> GetProjects()
//        {

//            List<Projects> lst = new List<Projects>();

//            SqlConnection sqlconn = new SqlConnection(connectionString);
//            SqlCommand sqlComm = new SqlCommand("GetProjects");
//            sqlconn.Open();
//            sqlComm.Connection = sqlconn;
//            sqlComm.CommandType = CommandType.StoredProcedure;
//            SqlDataReader sdr = sqlComm.ExecuteReader();
//            while (sdr.Read())
//            {
//                Projects projects = new Projects();
//                projects.projectId= (int)sdr["Id"];
//                projects.projectName = sdr["ProjectName"].ToString();

//                lst.Add(projects);
//            }

//            return lst;

//        }

//        [HttpPost]
//        [Route("audit")]
//        public bool AuditProcess(AuditLeaves audit)
//        {
//            try
//            {
//                SqlConnection sqlconn = new SqlConnection(connectionString);
//                SqlCommand sqlComm = new SqlCommand("AuditLeaves");
//                sqlconn.Open();
//                sqlComm.Connection = sqlconn;
//                sqlComm.CommandType = CommandType.StoredProcedure;
//                sqlComm.Parameters.AddWithValue("@year", audit.year);
//                sqlComm.Parameters.AddWithValue("@leaveId", audit.leaveId);
//                sqlComm.Parameters.AddWithValue("@days", audit.numberOfDays);
//                sqlComm.ExecuteNonQuery();
//                return true;
//            }
//            catch(Exception e )
//            {
//                return false;
//            }
           
//        }

//        [HttpPost]
//        [Route("editLeaveBalance")]

//        public bool UpdateLeaveBalance([FromBody] List<EmployeeUpdatedLeaveBalance> leaveBalance)
//        {
//            try
//            {
//                foreach( var i in leaveBalance[0].leaves)
//                {
//                    SqlConnection sqlconn = new SqlConnection(connectionString);
//                    SqlCommand sqlComm = new SqlCommand("UpdateLeaveBalance");
//                    sqlconn.Open();
//                    sqlComm.Connection = sqlconn;
//                    sqlComm.CommandType = CommandType.StoredProcedure;
//                    sqlComm.Parameters.AddWithValue("@employeeId", leaveBalance[0].employeeId);
//                    sqlComm.Parameters.AddWithValue("@leaveId", i.leaveId);
//                    sqlComm.Parameters.AddWithValue("@value", i.value);
//                    sqlComm.Parameters.AddWithValue("@year", leaveBalance[0].year); 
//                    sqlComm.ExecuteNonQuery();
//                    sqlconn.Close();
//                }
//                return true;
//            }

//            catch(Exception e)
//            {
//                return false;
//            }
//        }

//    }

//}

