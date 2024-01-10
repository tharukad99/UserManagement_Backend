using Authentication_System.DataAccessLayer;
using DataAccessLayer;
using UserManagement_BusinessObjects.User;

namespace UserManagement_ApplicationService
{
    public class AuthenticationApplicationService
    {
        public Status SignUp(User data)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();  
            try
            {
                //dataService.BeginTransaction();
                IAuthenticationDataAccess objDS = new AuthenticationDataAccess(dataService);

                var existUsers  = objDS.UserExist(data.UserName);

               // dataService.CommitTransaction();

                if (existUsers.Result.IsSuccess == true)
                {
                    return existUsers.Result;
                }
                else
                {
                    var a = objDS.RegisterUser(data);
                    return a.Result;
                }      
            }
            catch (Exception)
            {
                //dataService.RollbackTransaction();
                throw;
            }
            finally
            {
                dataService.Dispose();
            }
        }

        public Login UserLogin(Login data)
        {
            Login login = new Login();
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                dataService.BeginTransaction();
                IAuthenticationDataAccess objDA = new AuthenticationDataAccess(dataService);

                var res = objDA.UserLogin(data);
                login.UserID = res.UserID;
                login.UserName = res.UserName;
                login.Password = res.Password;
                login.Token = res.Token;

                return login;
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

            //return login;
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

