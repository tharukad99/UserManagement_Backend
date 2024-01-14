using System;

namespace BusinessObjects.TestModule
{
    public class Student
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NIC { get; set; }
        public int MobileNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Password { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class res
    {
        public bool IsSuccess { get; set; }
    }



}