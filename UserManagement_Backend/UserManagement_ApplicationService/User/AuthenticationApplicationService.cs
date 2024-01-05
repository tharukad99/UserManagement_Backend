using Authentication_System.DataAccessLayer;
using BusinessObjects.TestModule;
using DataAccessLayer;
using UserManagement_DAL.IDataAccessLayer.User;
using UserManagement_DAL.TestModule;

namespace UserManagement_ApplicationService.User
{
    public class AuthenticationApplicationService
    {
        public void SaveUser(Student student)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                dataService.BeginTransaction();

                IAuthenticationDataAccess objDS = new AuthenticationDataAccess(dataService);
                objDS.RegisterUser(student);
                dataService.CommitTransaction();
            }
            catch (Exception)
            {
                dataService.RollbackTransaction();
                throw;
            }
            finally
            {
                dataService.Dispose();
            }
        }

    }
}



//namespace UserManagement_ApplicationService.TestModule
//{
//    public class StudentApplicationService
//    {
//        public void SaveStudent(Student student)
//        {
//            IDataService dataService = DataServiceBuilder.CreateDataService();
//            try
//            {
//                dataService.BeginTransaction();

//                IStudentDataService objDS = new StudentDataService(dataService);
//                objDS.SaveStudent(student);
//                dataService.CommitTransaction();
//            }
//            catch (Exception)
//            {
//                dataService.RollbackTransaction();
//                throw;
//            }
//            finally
//            {
//                dataService.Dispose();
//            }
//        }
        
//    }
//}

