using BusinessObjects.Base;
using Finap_Test_Backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using UserManagement_ApplicationService;
using UserManagement_BusinessObjects.User;

namespace UserManagement_Backend.Controllers.TestModule
{
    [Route("[controller]/[action]")]
    public class UserController : BaseController
    {

        [HttpPost]
        public APIResponce SignUp([FromBody] User data)
        {
            try
            {
                AuthenticationApplicationService objAS = new AuthenticationApplicationService();
                var response = objAS.SignUp(data);

                return this.GenerateSucessMessage(response);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }

        [HttpPost]
        public APIResponce UserLogin([FromBody] Login data)
        {
            
            try
            {
                AuthenticationApplicationService objAS = new AuthenticationApplicationService();

                var response = objAS.UserLogin(data);

                return this.GenerateSucessMessage(response);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }
    }
}
