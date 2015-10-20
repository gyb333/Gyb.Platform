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
    public class SubjectRepository : ISubjectRepository
    {
        private DataBaseContext _ctx;
        public SubjectRepository(DataBaseContext ctx)
        {
            _ctx = ctx;
        }


        public IQueryable<Subject> GetAllSubjects()
        {
            return _ctx.Subjects
                 .Include("Courses")
                 .AsQueryable();
        }

        public Subject GetSubject(int subjectId)
        {
            return _ctx.Subjects
                    .Include("Courses")
                    .Where(s => s.Id == subjectId)
                    .SingleOrDefault();

        }
    }
}
