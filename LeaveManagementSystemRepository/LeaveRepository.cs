using LeaveManagementSystemModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LeaveManagementSystemRepository
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly string connectionString;

        public LeaveRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<LeaveRequestHistory> GetAllRequest(int id)
        {
            List<LeaveRequestHistory> lstLeaveRequest = new List<LeaveRequestHistory>();
            SqlConnection sqlconn = new SqlConnection(connectionString);
            SqlCommand sqlComm = new SqlCommand("allLeaveRequests");
            sqlconn.Open();
            sqlComm.Connection = sqlconn;
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@Id", id);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            while (sdr.Read())
            {
                LeaveRequestHistory leaveRequestHistory = new LeaveRequestHistory();
                leaveRequestHistory.Id = (int)sdr["Id"];
                leaveRequestHistory.EmpId = (int)sdr["EmployeeId"];
                leaveRequestHistory.EmployeeName = sdr["EmpName"].ToString();
                leaveRequestHistory.StartDate = (DateTime)sdr["StartDate"];
                leaveRequestHistory.EndDate = (DateTime)sdr["EndDate"];
                leaveRequestHistory.LeaveId = (int)sdr["LeaveId"];
                leaveRequestHistory.Leave = sdr["EType"].ToString();
                leaveRequestHistory.Status = sdr["Status"].ToString();
                leaveRequestHistory.Reason = sdr["Reason"].ToString();
                lstLeaveRequest.Add(leaveRequestHistory);
            }
            sqlconn.Close();
            return lstLeaveRequest;
        }

        public bool Approve(LeaveRequestHistory leave)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("approveLeaveRequest");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@Id", leave.Id);
                sqlComm.Parameters.AddWithValue("@empId", leave.EmpId);
                sqlComm.Parameters.AddWithValue("@startDate", leave.StartDate);
                sqlComm.Parameters.AddWithValue("@endDate", leave.EndDate);
                sqlComm.Parameters.AddWithValue("@leaveId", leave.LeaveId);
                sqlComm.Parameters.AddWithValue("@reason", leave.Reason);
                SqlParameter returnParameter = sqlComm.Parameters.Add("RetVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                sqlComm.ExecuteNonQuery();
                int id = (int)returnParameter.Value;
                if (id == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Audit(AuditLeaves audit)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("auditLeaves");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@year", audit.Year);
                sqlComm.Parameters.AddWithValue("@leaveId", audit.LeaveId);
                sqlComm.Parameters.AddWithValue("@days", audit.NumberOfDays);
                sqlComm.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("deleteRequest");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@leaveRequestId", id);
                sqlComm.ExecuteNonQuery();
                sqlconn.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Edit(LeaveRequestHistory leaveRequest)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("editAndApprove");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@id", leaveRequest.Id);
                sqlComm.Parameters.AddWithValue("@empId", leaveRequest.EmpId);
                sqlComm.Parameters.AddWithValue("@startDate", leaveRequest.StartDate.ToString());
                sqlComm.Parameters.AddWithValue("@endDate", leaveRequest.EndDate.ToString());
                sqlComm.Parameters.AddWithValue("@leaveId", leaveRequest.LeaveId.ToString());
                sqlComm.Parameters.AddWithValue("@leave", leaveRequest.Leave.ToString());
                sqlComm.ExecuteNonQuery();
                sqlconn.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetLeaveBalance(int id)
        {
            SqlConnection sqlconn = new SqlConnection(connectionString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet dataset = new DataSet();
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand("getLeaveBalance", sqlconn);
            sqlComm.Parameters.Add(new SqlParameter("@id", id));
            sqlComm.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand = sqlComm;
            dataAdapter.Fill(dataset);
            
            dataset.Tables[0].TableName = "LeaveBalanceData";
            dataset.Tables[1].TableName = "Leaves";
            string json = JsonConvert.SerializeObject(dataset, Formatting.Indented);

            return json;
        }

        public IEnumerable<LeaveRequestHistory> GetRequest(int id)
        {
            List<LeaveRequestHistory> lstLeaveRequest = new List<LeaveRequestHistory>();
            SqlConnection sqlconn = new SqlConnection(connectionString);
            SqlCommand sqlComm = new SqlCommand("getLeaveRequests");
            sqlconn.Open();
            sqlComm.Connection = sqlconn;
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@empId", id);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            while (sdr.Read())
            {
                LeaveRequestHistory leaveRequestHistory = new LeaveRequestHistory();
                leaveRequestHistory.Id = (int)sdr["Id"];
                leaveRequestHistory.EmpId = (int)sdr["EmployeeId"];
                leaveRequestHistory.EmployeeName = sdr["FirstName"].ToString();
                leaveRequestHistory.StartDate = (DateTime)sdr["StartDate"];
                leaveRequestHistory.EndDate = (DateTime)sdr["EndDate"];
                leaveRequestHistory.LeaveId = (int)sdr["LeaveId"];
                leaveRequestHistory.Leave = sdr["EType"].ToString();
                leaveRequestHistory.Status = sdr["Status"].ToString();
                leaveRequestHistory.Reason = sdr["Reason"].ToString();
                lstLeaveRequest.Add(leaveRequestHistory);
            }
            sqlconn.Close();
            return lstLeaveRequest;
        }

        public IEnumerable<Leaves> Get()
        {
            List<Leaves> lstLeaves = new List<Leaves>();

            SqlConnection sqlconn = new SqlConnection(connectionString);
            SqlCommand sqlComm = new SqlCommand("getLeaves");
            sqlconn.Open();
            sqlComm.Connection = sqlconn;
            sqlComm.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sqlComm.ExecuteReader();
            while (sdr.Read())
            {
                Leaves leaves = new Leaves();
                leaves.Id = (int)sdr["Id"];
                leaves.LeaveName = sdr["EType"].ToString();
                lstLeaves.Add(leaves);
            }

            return lstLeaves;
        }

        public bool Add(LeaveAddRequest newLeave)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("newLeave");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@leave", newLeave.Leave);
                sqlComm.ExecuteNonQuery();
                sqlconn.Close();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool AddRequest(LeaveRequest leaverequest)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("leaveRequest");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@empId", leaverequest.EmpId);
                sqlComm.Parameters.AddWithValue("@startDate", leaverequest.StartDate.ToString("MM-dd-yyyy"));
                sqlComm.Parameters.AddWithValue("@endDate", leaverequest.EndDate.ToString("MM-dd-yyyy"));
                sqlComm.Parameters.AddWithValue("@leaveId", leaverequest.Leave);
                sqlComm.Parameters.AddWithValue("@reason", leaverequest.Reason);
                SqlParameter returnParameter = sqlComm.Parameters.Add("RetVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                sqlComm.ExecuteNonQuery();
                int id = (int)returnParameter.Value;
                if (id == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<LeaveTransactions> Transactions(int id)
        {
            List<LeaveTransactions> lstTransactions = new List<LeaveTransactions>();

            SqlConnection sqlconn = new SqlConnection(connectionString);
            SqlCommand sqlComm = new SqlCommand("transactions");
            sqlconn.Open();
            sqlComm.Connection = sqlconn;
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@employeeId", id);
            SqlDataReader sdr = sqlComm.ExecuteReader();

            while (sdr.Read())
            {
                LeaveTransactions transactions = new LeaveTransactions();
                transactions.EmpId = (int)sdr["Id"];
                transactions.EmpName = sdr["EmployeeName"].ToString();
                transactions.LeaveType = sdr["leave"].ToString();
                transactions.StartDate = (DateTime)sdr["Startdate"];
                transactions.EndDate = (DateTime)sdr["EndDate"];
                transactions.Totaldays = (int)sdr["NumberOfDays"];
                transactions.Status = sdr["Status"].ToString();
                lstTransactions.Add(transactions);
            }

            return lstTransactions;
        }

        public bool EditLeaveBalance(List<EmployeeUpdatedLeaveBalance> leaveBalance)
        {
            try
            {
                foreach (var i in leaveBalance[0].Leaves)
                {
                    SqlConnection sqlconn = new SqlConnection(connectionString);
                    SqlCommand sqlComm = new SqlCommand("updateLeaveBalance");
                    sqlconn.Open();
                    sqlComm.Connection = sqlconn;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@employeeId", leaveBalance[0].EmployeeId);
                    sqlComm.Parameters.AddWithValue("@leaveId", i.LeaveId);
                    sqlComm.Parameters.AddWithValue("@value", i.Value);
                    sqlComm.Parameters.AddWithValue("@year", leaveBalance[0].Year);
                    sqlComm.ExecuteNonQuery();
                    sqlconn.Close();
                }
                return true;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
