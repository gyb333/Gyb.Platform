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
    public class TutorRepository : ITutorRepository
    {
         private DataBaseContext _ctx;
         public TutorRepository(DataBaseContext ctx)
        {
            _ctx = ctx;
        }
        public  Tutor GetTutor(int tutorId)
        {
            //return _ctx.Tutors
            //    .Include("Courses")
            //    .Where(s => s.Id == tutorId)
            //    .SingleOrDefault();
            return _ctx.Tutors.Find(tutorId);
        }
    }
}
