using Gyb.Server.Data;
using Gyb.Server.Entities;
using Gyb.Server.IRepository;
using Gyb.Server.Repository.Learn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gyb.Server.WebAPI.Controllers
{
    /// <summary>
    ///  System.Web.HttpContext.Current.Response.Headers.Add("X-Pagination",Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));

    /// </summary>
    public class CustomCoursesController : ApiController
    {
        ICourseRepository _repository;
        public CustomCoursesController(ICourseRepository repository)
        {
            _repository = repository;
        }


        [Gyb.Server.WebAPI.filters.ForceHttps()]
        public List<Course> Get()
        {
            

            return _repository.GetAllCourses().ToList();
        }

        [Gyb.Server.WebAPI.filters.ForceHttps()]
        [Route("api/enrollments/{courseName}/{studentName?}")]
        public Course GetCourse(int id)
        {
             

            return _repository.GetCourse(id);
        }


    }
}
