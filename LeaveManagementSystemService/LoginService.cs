using LeaveManagementSystemModels;
using LeaveManagementSystemRepository;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
                loginDetails.Password = Encrypt(loginDetails.Password, "sblw-3hn8-sqoy19");
                return _loginRepository.Get(loginDetails);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public bool Add(Login login)
        {
            try
            {
                login.Password = Encrypt(login.Password, "sblw-3hn8-sqoy19");
                return _loginRepository.Add(login);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool EditPassword(EmployeePasswordChange passwordChange)
        {
            try
            {
                passwordChange.Password = Encrypt(passwordChange.Password, "sblw-3hn8-sqoy19");
                return _loginRepository.EditPassword(passwordChange);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string Encrypt(string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
    }
}
