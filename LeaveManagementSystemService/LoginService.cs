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

        public Employee Get(LoginDetails loginDetails )
        {
            try
            {
                return _loginRepository.Get(loginDetails);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public bool Login(Login login)
        {
            try
            {
                return _loginRepository.Login(login);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
