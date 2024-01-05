using BusinessObjects.TestModule;

namespace Authentication_System.DataAccessLayer
{
    public interface IAuthenticationDataAccess
    {
        //void SaveUser(Student student);
        public Task<Student> RegisterUser(Student request);
        //public Task<UserLoginResponse> UserLogin(UserLoginRequest request);
    }
}
