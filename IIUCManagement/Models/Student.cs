using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IIUCManagement.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateofBirth { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        
    }
}