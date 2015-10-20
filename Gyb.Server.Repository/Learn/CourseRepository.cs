using Gyb.Server.Data;
using Gyb.Server.Entities;
using Gyb.Server.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Server.Repository.Learn
{
    public class CourseRepository : ICourseRepository
    {
        private DataBaseContext _ctx;
        public CourseRepository(DataBaseContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<Course> GetCoursesBySubject(int subjectId)
        {
            return _ctx.Courses
                      .Include("CourseSubject")
                      .Include("CourseTutor")
                      .Where(c => c.CourseSubject.Id == subjectId)
                      .AsQueryable();
        }

        public IQueryable<Course> GetAllCourses()
        {
            return _ctx.Courses
                    .Include("CourseSubject")
                    .Include("CourseTutor")
                    .AsQueryable();
        }

        public Course GetCourse(int courseId, bool includeEnrollments = true)
        {
            if (includeEnrollments)
            {
                return _ctx.Courses
                    .Include("Enrollments")
                   .Include("CourseSubject")
                   .Include("CourseTutor")
                   .Where(c => c.Id == courseId)
                   .SingleOrDefault();
            }
            else
            {
                return _ctx.Courses
                       .Include("CourseSubject")
                       .Include("CourseTutor")
                       .Where(c => c.Id == courseId)
                       .SingleOrDefault();
            }
        }

        public bool CourseExists(int courseId)
        {
            return _ctx.Courses.Any(c => c.Id == courseId);  
        }

        public bool Insert(Course course)
        {
            try
            {
                _ctx.Courses.Add(course);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Course originalCourse, Course updatedCourse)
        {
            _ctx.Entry(originalCourse).CurrentValues.SetValues(updatedCourse);
            return true;
        }

        public bool DeleteCourse(int id)
        {
            try
            {
                var entity = _ctx.Courses.Find(id);
                if (entity != null)
                {
                    _ctx.Courses.Remove(entity);
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
