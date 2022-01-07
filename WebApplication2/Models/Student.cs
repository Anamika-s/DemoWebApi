using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BatchCode { get; set; }
        public int Marks { get; set; }
        public DateTime Doj { get; set; }
    }
}