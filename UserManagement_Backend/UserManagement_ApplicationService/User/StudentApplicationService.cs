using BusinessObjects.TestModule;
using DataAccessLayer;
using UserManagement_DAL.IDataAccessLayer.User;
using UserManagement_DAL.TestModule;

namespace UserManagement_ApplicationService.TestModule
{
    public class StudentApplicationService
    {
        public void SaveStudent(Student student)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                dataService.BeginTransaction();

                IStudentDataService objDS = new StudentDataService(dataService);
                objDS.SaveStudent(student);
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
        public List<Student> GetStudents()
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                IStudentDataService objDS = new StudentDataService(dataService);
                return objDS.GetStudents();
                
            }
            catch (Exception)
            {
                dataService.Dispose();
                throw;
            }
            finally
            {
                dataService.Dispose();
            }
        }
        public void DeleteStudent(int studentID)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                dataService.BeginTransaction();

                IStudentDataService objDS = new StudentDataService(dataService);
                objDS.DeleteStudent(studentID);
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
