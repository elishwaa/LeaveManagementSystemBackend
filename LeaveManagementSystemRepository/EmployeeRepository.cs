using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using LeaveManagementSystemModels;
using Microsoft.Extensions.Configuration;

namespace LeaveManagementSystemRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string connectionString;
        public EmployeeRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool Add(EmployeeAddRequest employee)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("AddEmployee");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@empType", employee.EmpType);
                sqlComm.Parameters.AddWithValue("@firstName", employee.FirstName.ToString());
                sqlComm.Parameters.AddWithValue("@middleName", employee.MiddleName.ToString());
                sqlComm.Parameters.AddWithValue("@lastName", employee.LastName.ToString());
                sqlComm.Parameters.AddWithValue("@email", employee.Email.ToString());
                sqlComm.Parameters.AddWithValue("@salary", employee.Salary);
                sqlComm.Parameters.AddWithValue("@project", employee.Project);
                sqlComm.Parameters.AddWithValue("@locationId", employee.Location);
                sqlComm.ExecuteNonQuery();

                SqlCommand sqlCommand = new SqlCommand("AddToManagement");
                sqlCommand.Connection = sqlconn;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@manager", employee.Manager);
                sqlCommand.Parameters.AddWithValue("@email", employee.Email.ToString());

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EditPassword(EmployeePasswordChange passwordChange)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("UpdatePassword");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@empId", passwordChange.Id);
                sqlComm.Parameters.AddWithValue("@newPassword", passwordChange.Password);
                sqlComm.ExecuteNonQuery();

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int GetEmail(string emailId)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("GetEmployeeByEmail");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@emailId", emailId);
                SqlDataReader sdr = sqlComm.ExecuteReader();
                if (sdr.Read())
                {
                    var employeeId = (int)sdr["Id"];
                    return employeeId;
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        public bool Edit(Employee employee)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("EditEmployeeDetails");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@id", employee.Id);
                sqlComm.Parameters.AddWithValue("@typeId", employee.TypeId);
                sqlComm.Parameters.AddWithValue("@firstName", employee.FirstName.ToString());
                sqlComm.Parameters.AddWithValue("@middleName", employee.MiddleName.ToString());
                sqlComm.Parameters.AddWithValue("@lastName", employee.LastName.ToString());
                sqlComm.Parameters.AddWithValue("@email", employee.Email.ToString());
                sqlComm.Parameters.AddWithValue("@salary", employee.Salary);
                sqlComm.Parameters.AddWithValue("@username", employee.Username);
                sqlComm.Parameters.AddWithValue("@projectId", employee.ProjectId);
                sqlComm.Parameters.AddWithValue("@locationId", employee.LocationId);
                sqlComm.ExecuteNonQuery();
                sqlconn.Close();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            List<Employee> lstemployee = new List<Employee>();
            SqlConnection sqlconn = new SqlConnection(connectionString);
            SqlCommand sqlCom = new SqlCommand("AllEmployees");
            sqlconn.Open();
            sqlCom.Connection = sqlconn;
            sqlCom.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sqlCom.ExecuteReader();
            while (sdr.Read())
            {
                Employee employee = new Employee();
                employee.Id = (int)sdr["Id"];
                employee.TypeId = (int)sdr["TypeId"];
                employee.TypeName = sdr["EType"].ToString();
                employee.FirstName = sdr["FirstName"].ToString();
                employee.MiddleName = sdr["MiddleName"].ToString();
                employee.LastName = sdr["LastName"].ToString();
                employee.Email = sdr["Email"].ToString();
                employee.Salary = (int)sdr["Salary "];
                employee.LocationId = (int)sdr["LocationId"];
                employee.LocationName = sdr["LName"].ToString();
                if (sdr["Username"] != DBNull.Value && sdr["ProjectId"] != DBNull.Value && sdr["ProjectName"] != DBNull.Value)
                {
                    employee.Username = sdr["Username"].ToString();
                    employee.ProjectId = (int)sdr["ProjectId"];
                    employee.ProjectName = sdr["ProjectName"].ToString();
                }
                else
                {
                    employee.Username = null;
                    employee.ProjectId = 0;
                    employee.ProjectName = null;
                }
                lstemployee.Add(employee);
            }
            sqlconn.Close();
            return lstemployee;
        }

        public IEnumerable<EmployeeType> GetType()
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
                empType.Id = (int)sdr["Id"];
                empType.EmpType = sdr["EType"].ToString();
                lstEmpType.Add(empType);
            }


            return lstEmpType;
        }

        public IEnumerable<Managers> GetManagers()
        {
            List<Managers> lstManager = new List<Managers>();

            SqlConnection sqlconn = new SqlConnection(connectionString);
            SqlCommand sqlComm = new SqlCommand("GetManagers");
            sqlconn.Open();
            sqlComm.Connection = sqlconn;
            sqlComm.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sqlComm.ExecuteReader();
            while (sdr.Read())
            {
                Managers manager = new Managers();
                manager.ManagerId = (int)sdr["EmployeeId"];
                manager.ManagerName = sdr["EmployeeName"].ToString();

                lstManager.Add(manager);
            }

            return lstManager;
        }

        public bool AddDesignation(EmployeeAddDesignation designation)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand("NewDesignation");
                sqlconn.Open();
                sqlComm.Connection = sqlconn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@employeeType", designation.Designation);
                sqlComm.ExecuteNonQuery();
                sqlconn.Close();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
