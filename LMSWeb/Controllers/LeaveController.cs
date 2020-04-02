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
//        public bool DeleteRequest(int id)
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

