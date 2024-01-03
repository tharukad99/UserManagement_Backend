using Microsoft.AspNetCore.Mvc;
using Finap_Test_Backend.Controllers;
using BusinessObjects.Base;
using UserManagement_ApplicationService.TestModule;
using BusinessObjects.TestModule;

namespace UserManagement_Backend.Controllers.TestModule
{
    [Route("[controller]/[action]")]
    public class StudentController : BaseController
    {

        [HttpPost]
        public APIResponce SaveStudent([FromBody] Student data)
        {
            try
            {
                StudentApplicationService objAS = new StudentApplicationService();
                objAS.SaveStudent(data);
                return this.GenerateSucessMessage(true);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }

        [HttpGet]
        public APIResponce GetStudents()
        {
            try
            {
                StudentApplicationService objAS = new StudentApplicationService();
                var response = objAS.GetStudents();
                return this.GenerateSucessMessage(response);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }

        [HttpDelete]
        public APIResponce DeleteStudent(int studentID)
        {
            try
            {
                StudentApplicationService objAS = new StudentApplicationService();
                objAS.DeleteStudent(studentID);
                return this.GenerateSucessMessage(true);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }
    }
}
