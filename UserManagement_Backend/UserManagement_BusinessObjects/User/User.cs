using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement_BusinessObjects.User
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NIC { get; set; }
        public int MobileNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
    public class res
    {
        public bool IsSuccess { get; set; }
    }

    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }

    }

    public class Status
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }






}
