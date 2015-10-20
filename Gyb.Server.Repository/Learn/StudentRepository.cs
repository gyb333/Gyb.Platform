using Gyb.Server.IRepository;
using Gyb.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gyb.Server.Data;

namespace Gyb.Server.Repository.Learn
{
    public class StudentRepository : IStudentRepository
    {
        private DataBaseContext _ctx;
        public StudentRepository(DataBaseContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Student> GetAllStudentsWithEnrollments()
        {
            return _ctx.Students
                   .Include("Enrollments")
                   .Include("Enrollments.Course")
                    .Include("Enrollments.Course.CourseSubject")
                    .Include("Enrollments.Course.CourseTutor")
                   .AsQueryable();
        }

        public IQueryable<Student> GetAllStudentsSummary()
        {
            return _ctx.Students
                    .AsQueryable();
        }

        public IQueryable<Student> GetEnrolledStudentsInCourse(int courseId)
        {
            return _ctx.Students
                    .Include("Enrollments")
                    .Where(c => c.Enrollments.Any(s => s.Course.Id == courseId))
                    .AsQueryable();
        }

        public Student GetStudentEnrollments(string userName)
        {
            var student = _ctx.Students
                           .Include("Enrollments")
                           .Include("Enrollments.Course")
                           .Include("Enrollments.Course.CourseSubject")
                           .Include("Enrollments.Course.CourseTutor")
                           .Where(s => s.UserName == userName)
                           .SingleOrDefault();

            return student;
        }

        public Student GetStudent(string userName)
        {
            var student = _ctx.Students
                          .Include("Enrollments")
                          .Where(s => s.UserName == userName)
                          .SingleOrDefault();

            return student;
        }

        public bool LoginStudent(string userName, string password)
        {
            var student = _ctx.Students.Where(s => s.UserName == userName).SingleOrDefault();

            if (student != null)
            {
                if (student.Password == password)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Insert(Student student)
        {
            try
            {
                _ctx.Students.Add(student);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Student originalStudent, Student updatedStudent)
        {
            _ctx.Entry(originalStudent).CurrentValues.SetValues(updatedStudent);
            return true;
        }

        public bool DeleteStudent(int id)
        {
            try
            {
                var entity = _ctx.Students.Find(id);
                if (entity != null)
                {
                    _ctx.Students.Remove(entity);
                    return true;
                }
            }
            catch
            {
                // TODO Logging
            }

            return false;
        }
    }
}
