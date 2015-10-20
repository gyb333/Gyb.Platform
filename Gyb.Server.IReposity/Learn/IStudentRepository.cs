using Gyb.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Server.IRepository 
{
    public interface IStudentRepository
    {
        IQueryable<Student> GetAllStudentsWithEnrollments();
        IQueryable<Student> GetAllStudentsSummary();

        IQueryable<Student> GetEnrolledStudentsInCourse(int courseId);
        Student GetStudentEnrollments(string userName);
        Student GetStudent(string userName);


        bool LoginStudent(string userName, string password);

        bool Insert(Student student);
        bool Update(Student originalStudent, Student updatedStudent);
        bool DeleteStudent(int id);
    }
}
