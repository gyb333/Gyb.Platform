using Gyb.Server.Data;
using Gyb.Server.Entities;
using Gyb.Server.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Server.Repository.Learn
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private DataBaseContext _ctx;
        public EnrollmentRepository(DataBaseContext ctx)
        {
            _ctx = ctx;
        }

        public int EnrollStudentInCourse(int studentId, int courseId, Enrollment enrollment)
        {
            try
            {
                if (_ctx.Enrollments.Any(e => e.Course.Id == courseId && e.Student.Id == studentId))
                {
                    return 2;
                }

                _ctx.Database.ExecuteSqlCommand("INSERT INTO Enrollments VALUES (@p0, @p1, @p2)",
                    enrollment.EnrollmentDate, courseId.ToString(), studentId.ToString());

                return 1;
            }
            catch ( DbEntityValidationException dbex)
            {
                foreach (var eve in dbex.EntityValidationErrors)
                {
                    string line = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        line = string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);

                    }
                }
                return 0;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
