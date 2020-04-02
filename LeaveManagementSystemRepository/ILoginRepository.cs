using LeaveManagementSystemModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemRepository
{
    public interface ILoginRepository :IRepository
    {
        Employee GetLogin(LoginDetails loginDetails);
        bool NewLogin(NewLogin newLogin);
    }
}
