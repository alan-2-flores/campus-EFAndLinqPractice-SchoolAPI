using EFAndLinqPractice_SchoolAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFAndLinqPractice_SchoolAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly SchoolContext _dbContext;

        public StudentService(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Student Create(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
            return student;
        }

        public Student GetById(int id)
        {
            var search = _dbContext.Students.Where(s => s.Id == id).ToList();
            var result = new Student() {
                Id = search[0].Id,
                Name= search[0].Name,
                Birthday=search[0].Birthday,
                Height=search[0].Height,
                Weight=search[0].Weight,
                };
            return result;
        }

        public IEnumerable<Student> GetAll()
        {
            var result = _dbContext.Students.ToList();
            return result;
        }

        public IEnumerable<Student> GetStudentsByCourseId(int courseId)
        {
            var search = _dbContext.Students.Include(c=>c.Courses.Where(c => c.Id == courseId)).ToList();
            return search;
        }

        public void DeleteById(int id)
        {
            Student student = new Student() { Id=id};
            _dbContext.Students.Attach(student);
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
        }
    }
}