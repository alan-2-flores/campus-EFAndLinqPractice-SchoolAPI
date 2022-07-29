
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EFAndLinqPractice_SchoolAPI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Student> Students { get; set; }
    }
}