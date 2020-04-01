using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveBalanceController : ControllerBase
    {
        private readonly string connectionString;
        public LeaveBalanceController(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        private dynamic SqlDataReaderToExpando(SqlDataReader reader)
        {
            var expandoObject = new ExpandoObject() as IDictionary<string, object>;

            for (var i = 0; i < reader.FieldCount; i++)
                expandoObject.Add(reader.GetName(i), reader[i]);

            return expandoObject;
        }

        private IEnumerable<dynamic> GetDynamicSqlData(string connectionString, string LeaveRequest)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var comm = new SqlCommand(LeaveRequest, conn))
                {
                    conn.Open();
                    using (var reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return SqlDataReaderToExpando(reader);
                        }
                    }
                    conn.Close();
                }
            }
        }

        [HttpGet]
        [Route("LeaveBalance")]

        //public IEnumerable<dynamic> GetLeaveBalance()
        //{
        //    string Command = "getLeaveBalance";
        //    GetDynamicSqlData(connectionString, Command);
        //    return 
        //}

        //private static IEnumerable<T> GetSqlData<T>(string connectionstring, string LeaveRequest)
        //{
        //    var properties = typeof(T).GetProperties();

        //    using (var conn = new SqlConnection(connectionstring))
        //    {
        //        using (var comm = new SqlCommand(LeaveRequest, conn))
        //        {
        //            conn.Open();
        //            using (var reader = comm.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {

        //                    var element = Activator.CreateInstance<T>();

        //                    foreach (var f in properties)
        //                    {
        //                        var o = reader[f.Name];
        //                        if (o.GetType() != typeof(DBNull)) f.SetValue(element, o, null);
        //                    }
        //                    yield return element;
        //                }
        //            }
        //            conn.Close();
        //        }
        //    }
        //}































        // GET: api/LeaveBalance
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LeaveBalance/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/LeaveBalance
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/LeaveBalance/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
