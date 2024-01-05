//using Authentication_System.DataAccessLayer;
//using BusinessObjects.Base;
//using BusinessObjects.TestModule;
//using Finap_Test_Backend.Controllers;
//using Microsoft.AspNetCore.Mvc;
//using UserManagement_ApplicationService.TestModule;
//using UserManagement_ApplicationService.User;

//namespace Authentication_System.Controllers
//{
//    [Route("api/[controller]/[Action]")]
//    [ApiController]
//    public class AuthenticationController : BaseController
//    {

//        //public readonly IAuthenticationDataAccess _authenticationDataAccess;

//        //public AuthenticationController(IAuthenticationDataAccess authenticationDataAccess)
//        //{
//        //    _authenticationDataAccess = authenticationDataAccess;
//        //}

//        //[HttpPost]
//        //public APIResponce SaveUser(Student data)
//        //public IActionResult SaveUser(Student data)
//        //{

//        //    res response = new res();
//        //    try
//        //    {
//        //        AuthenticationApplicationService objAS = new AuthenticationApplicationService();
//        //        objAS.SaveUser(data);


//        //        //response = await _authenticationDataAccess.SaveUser(data);
//        //        return Ok(response); ;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        //return GenerateExceptionMessage(null, ex);
//        //        return Ok(response);
//        //    }
//        //}

//        //public APIResponce SaveUser([FromBody] Student data)
//        //{
//        //    try
//        //    {
//        //        StudentApplicationService objAS = new StudentApplicationService();
//        //        objAS.SaveStudent(data);
//        //        return this.GenerateSucessMessage(true);
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return GenerateExceptionMessage(null, ex);
//        //    }
//        //}





//        //This method use to user registration
//        //[HttpPost]
//        //public async Task<IActionResult> RegisterUser(RegisterUserRequest request)
//        //{
//        //    RegisterUserResponse response = new RegisterUserResponse();
//        //    try
//        //    {
//        //        response = await _authenticationDataAccess.RegisterUser(request);

//        //    }catch(Exception ex)
//        //    {
//        //        response.IsSuccess = false;
//        //        response.Message = ex.Message;
//        //    }

//        //    return Ok(response);
//        //}

//        //This method use to user Login
//        //[HttpPost]
//        //public async Task<IActionResult> UserLogin(UserLoginRequest request)
//        //{
//        //    UserLoginResponse response = new UserLoginResponse();
//        //    try
//        //    {
//        //        response = await _authenticationDataAccess.UserLogin(request);
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        response.IsSuccess = false;
//        //        response.Message = ex.Message;
//        //    }

//        //    return Ok(response);
//        //}

//    }
//}
