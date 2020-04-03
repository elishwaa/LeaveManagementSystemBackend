using LeaveManagementSystemModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemRepository
{
    public interface ILoginRepository :IRepository
    {
        Employee Get(LoginDetails loginDetails);
        bool Login(Login login);
    }
}
