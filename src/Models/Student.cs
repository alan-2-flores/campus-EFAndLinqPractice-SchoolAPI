
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EFAndLinqPractice_SchoolAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        //[JsonIgnore]
        //[IgnoreDataMember]
        public ICollection<Course> Courses { get; set; }
    }
}