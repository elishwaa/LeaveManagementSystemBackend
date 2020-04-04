﻿using LeaveManagementSystemModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemService
{
    public interface ILoginService : IService
    {
      Employee Get(LoginDetails loginDetails);
      bool Login(Login login);
      bool EditPassword(LeaveManagementSystemModels.EmployeePasswordChange passwordChange);
    }
}
