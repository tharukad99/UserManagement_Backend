//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace UserManagement_Backend.Controllers.User
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        //public AuthenticationController(IAuthenticationDataAccess authenticationDataAccess)
//        //{
//        //    _authenticationDataAccess = authenticationDataAccess;
//        //}

//    }
//}
using Microsoft.AspNetCore.Mvc;
using Finap_Test_Backend.Controllers;
using BusinessObjects.Base;
using UserManagement_ApplicationService.TestModule;
using BusinessObjects.TestModule;
using UserManagement_ApplicationService.User;

namespace UserManagement_Backend.Controllers.TestModule
{
    [Route("[controller]/[action]")]
    public class UserController : BaseController
    {

        [HttpPost]
        public APIResponce SaveUser([FromBody] Student data)
        {
            try
            {
                AuthenticationApplicationService objAS = new AuthenticationApplicationService();
                objAS.SaveUser(data);
                return this.GenerateSucessMessage(true);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }
    }
}
