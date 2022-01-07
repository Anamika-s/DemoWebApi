using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StudentsResponseMessageController : ApiController
    {
        static List<Student> listStudents = null;
        public StudentsResponseMessageController()
        {
            if (listStudents == null)
            {
                listStudents = new List<Student>()
                {
                    new Student() { Id=1, Name= "Ajay", BatchCode ="B001", Marks=90 , Doj= DateTime.Parse("12/10/1991")},

                    new Student() { Id=2, Name= "Deepak", BatchCode ="B002", Marks=90 , Doj= DateTime.Parse("12/10/1991")},

                    new Student() { Id=3, Name= "Sagar", BatchCode ="B001", Marks=90 , Doj= DateTime.Parse("12/10/1991")},

                    new Student() { Id=4, Name= "Harpreet", BatchCode ="B001", Marks=90 , Doj= DateTime.Parse("12/10/1991")},

                    new Student() { Id=5, Name= "Meena", BatchCode ="B001", Marks=90 , Doj= DateTime.Parse("12/10/1991")}
                };
            }
        }

        public HttpResponseMessage Get()
        {
            if (listStudents == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Records found");
            else
                return Request.CreateResponse(HttpStatusCode.OK, listStudents);
        }
        public HttpResponseMessage Get(int id)
        {
            Student obj = listStudents.FirstOrDefault(x => x.Id == id);
            if (obj != null)
                return Request.CreateResponse(HttpStatusCode.OK, obj);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Student with this ID Not found");
        }
        public HttpResponseMessage Post(Student student)
        {
            listStudents.Add(student);
            return Request.CreateResponse(HttpStatusCode.Created, "Record inserted");
        }
        public HttpResponseMessage Put(int id, Student student)
        {
            Student obj = listStudents.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                foreach (Student temp in listStudents)
                {
                    if (temp.Id == id)
                    {
                        temp.BatchCode = student.BatchCode;
                        temp.Marks = student.Marks;
                        temp.Doj = student.Doj;
                        break;
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Record edited");
            }
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Record wit this ID do not exist");

        }
        public HttpResponseMessage Delete(int id)
        {
            Student obj = listStudents.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                listStudents.Remove(obj);
                return Request.CreateResponse(HttpStatusCode.OK, "Record deleted");
            }
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Record wit this ID do not exist");

        }
    }
}
