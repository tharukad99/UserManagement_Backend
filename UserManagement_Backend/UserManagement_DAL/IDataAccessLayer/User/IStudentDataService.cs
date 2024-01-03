using BusinessObjects.TestModule;

namespace UserManagement_DAL.IDataAccessLayer.User
{
    public interface IStudentDataService
    {
        void SaveStudent(Student student);
        void DeleteStudent(int studentID);
        List<Student> GetStudents();
    }
}

