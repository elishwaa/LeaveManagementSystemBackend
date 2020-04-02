using LeaveManagementSystemModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemService
{
    public interface ILoginService : IService
    {
      Employee GetLogin(LoginDetails loginDetails);
      IEnumerable<EmployeeType> GetEmpType();
      bool NewLogin(NewLogin newLogin);
    }
}
