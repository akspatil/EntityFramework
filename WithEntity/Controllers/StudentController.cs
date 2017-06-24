using BusinessEntities;
using BusinessServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WithEntity.Controllers
{
    public class StudentController : ApiController
    {

        private readonly IStudentServices studentServices;

        public StudentController()
        {
            studentServices = new StudentServices();
        }
        // GET: api/Student
        public HttpResponseMessage Get()
        {
            var students = studentServices.GetAllStudents();
            if (students != null)
            {
                var studentEntities = students as List<StudentEntity> ?? students.ToList();
                if (studentEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, studentEntities);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No student details present");
        }

        // GET: api/Student/5
        public HttpResponseMessage Get(long id)
        {
            var student = studentServices.GetStudentById(id);
            if (student != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, student);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Not details were found fot the id " + student.StudentId);
        }

        // POST: api/Student
        public HttpResponseMessage Post(JObject json)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            try
            {
                StudentEntity studentEntity = JsonConvert.DeserializeObject<StudentEntity>(json.ToString());
                PaymentEntity paymentEntity = JsonConvert.DeserializeObject<PaymentEntity>(json.ToString());
                long studentId = studentServices.AddStudentDetails(studentEntity);
                if (studentEntity.StudentId > 0)
                {

                    message =  Request.CreateResponse(HttpStatusCode.OK, "Student details successfully entered for the Id " + studentId);
                }
            }
            catch (Exception e)
            {
                message = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
            return message;
        }

        // PUT: api/Student/5
        public HttpResponseMessage Put(long id, JObject json)
        {
            bool status = false;
            if (id > 0)
            {
                StudentEntity studentEntity = JsonConvert.DeserializeObject<StudentEntity>(json.ToString());
                status = studentServices.UpdateStudentDetails(id, studentEntity);
            }
            if (status)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Details for student with Id " + id + " updated successfully");
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Update failed for Id " + id);
        }

        // DELETE: api/Student/5
        public HttpResponseMessage Delete(long id)
        {
            bool status = false;
            if (id > 0)
                status = studentServices.DeleteStudentDetails(id);
            if (status)
                return Request.CreateResponse(HttpStatusCode.OK, "Student details for id " + id + " deleted successfully");
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Delete failed");
            
        }
    }
}
