using BusinessObjects.TestModule;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Common;
using UserManagement_DAL.IDataAccessLayer.User;

namespace UserManagement_DAL.TestModule
{
    public class StudentDataService : IStudentDataService
    {
        IDataService _dataService;

        public StudentDataService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public void SaveStudent(Student student)
        {
            try
            {

                DbParameter[] arrSqlParam = new DbParameter[8];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@StudentID", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, value: student.StudentID);
                arrSqlParam[1] = DataServiceBuilder.CreateDBParameter("@FirstName", System.Data.DbType.String, System.Data.ParameterDirection.Input, value: student.FirstName);
                arrSqlParam[2] = DataServiceBuilder.CreateDBParameter("@LastName", System.Data.DbType.String, System.Data.ParameterDirection.Input, student.LastName);
                arrSqlParam[3] = DataServiceBuilder.CreateDBParameter("@ContactPerson", System.Data.DbType.String, System.Data.ParameterDirection.Input, student.ContactPerson);
                arrSqlParam[4] = DataServiceBuilder.CreateDBParameter("@ContactNo", System.Data.DbType.String, System.Data.ParameterDirection.Input, student.ContactNo);
                arrSqlParam[5] = DataServiceBuilder.CreateDBParameter("@EmailAddress", System.Data.DbType.String, System.Data.ParameterDirection.Input, student.EmailAddress);
                arrSqlParam[6] = DataServiceBuilder.CreateDBParameter("@Dateofbirth", System.Data.DbType.Date, System.Data.ParameterDirection.Input, student.Dateofbirth);
                arrSqlParam[7] = DataServiceBuilder.CreateDBParameter("@ClassroomID", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, student.ClassroomID);

                _dataService.ExecuteNonQuery("[dbo].[InsertStudent]", arrSqlParam);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Student> GetStudents()
        {
            try
            {
                List<Student> students = new List<Student>();
                DbDataReader reader = _dataService.ExecuteReader("[dbo].[GetStudent]", null);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataReader dataReader = new DataReader(reader);
                        students.Add(new Student
                        {
                            StudentID = dataReader.GetInt32("StudentID"),
                            FirstName = dataReader.GetString("FirstName"),
                            LastName = dataReader.GetString("LastName"),
                            ContactPerson = dataReader.GetString("ContactPerson"),
                            ContactNo = dataReader.GetString("ContactNo"),
                            EmailAddress = dataReader.GetString("EmailAddress"),
                            Dateofbirth = dataReader.GetDateTime("Dateofbirth"),
                            ClassroomID = dataReader.GetInt32("ClassroomID"),
                            ClassroomName = dataReader.GetString("ClassroomName")
                        });
                    }
                    reader.Close();
                }

                return students;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteStudent(int studentID)
        {
            try
            {
                DbParameter[] arrSqlParam = new DbParameter[1];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@StudentID", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, studentID);

                _dataService.ExecuteNonQuery("[dbo].[DeleteStudent]", arrSqlParam);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

