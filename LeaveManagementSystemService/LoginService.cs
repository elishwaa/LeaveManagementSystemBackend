using LeaveManagementSystemModels;
using LeaveManagementSystemRepository;
using System;
using System.Collections.Generic;
using System.Text;


namespace LeaveManagementSystemService
{
    public class LoginService :ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public Employee GetLogin(LoginDetails loginDetails )
        {
            try
            {
                return _loginRepository.GetLogin(loginDetails);
            }
            catch(Exception e)
            {
                return null;
            }

        }
        public bool NewLogin(NewLogin newLogin)
        {
            return _loginRepository.NewLogin(newLogin);
        }
    }
}
