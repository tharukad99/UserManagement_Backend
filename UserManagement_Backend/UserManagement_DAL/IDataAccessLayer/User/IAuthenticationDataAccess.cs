using BusinessObjects.TestModule;
using UserManagement_BusinessObjects.User;

namespace Authentication_System.DataAccessLayer
{
    public interface IAuthenticationDataAccess
    {
        public Task<Status> RegisterUser(User request);
        public Task<Status> UserExist(string UserName);
        User UserLogin(Login request);
    }
}
