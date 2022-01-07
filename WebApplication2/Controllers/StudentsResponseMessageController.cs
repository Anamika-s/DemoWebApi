using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StudentsController : ApiController
    {
        static List<Student> listStudents = null;
        public StudentsController()
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

        public List<Student> Get()
        {
            return listStudents;
        }
        public Student Get(int id)
        {
            return listStudents.FirstOrDefault(x => x.Id == id);
        }
        public void Post(Student student)
        {
            listStudents.Add(student);
        }
        public void Put(int id, Student student)
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
            }

        }
        public void Delete(int id)
        {
            Student obj = listStudents.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                listStudents.Remove(obj);
            }
        }
    }
}
