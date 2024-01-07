using BusinessObjects.TestModule;
using UserManagement_BusinessObjects.User;

namespace Authentication_System.DataAccessLayer
{
    public interface IAuthenticationDataAccess
    {
        public Task<User> RegisterUser(User request);
        User UserLogin(Login request);
    }
}
