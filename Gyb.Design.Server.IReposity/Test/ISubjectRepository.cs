﻿using Gyb.Design.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Design.Server.IRepository 
{
    public interface ISubjectRepository
    {
        IQueryable<Subject> GetAllSubjects();
        Subject GetSubject(int subjectId);
 
    }
}