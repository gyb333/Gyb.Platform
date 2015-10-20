using Gyb.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Server.IRepository 
{
    public interface ICourseRepository
    {
        IQueryable<Course> GetCoursesBySubject(int subjectId);

        IQueryable<Course> GetAllCourses();
        Course GetCourse(int courseId, bool includeEnrollments = true);
        bool CourseExists(int courseId);



        bool Insert(Course course);
        bool Update(Course originalCourse, Course updatedCourse);

        bool DeleteCourse(int id);
    }
}
