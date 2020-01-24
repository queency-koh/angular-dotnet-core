using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using quantum_it.Controllers.Resources;
using quantum_it.Core.Models;
using quantum_it.Core.Repositories;
using quantum_it.Core.Services;

namespace quantum_it.Services
{
    public class StudentService : IStudentService
    {
        private readonly IClassRepository classRepository;
        private readonly IStudentRepository studentRepository;

        public StudentService(IClassRepository classRepository,
                              IStudentRepository studentRepository)
        {
            this.classRepository = classRepository;
            this.studentRepository = studentRepository;
        }

        public async Task<Student> GetStudent(int studentId)
        {
            return await studentRepository.GetStudentById(studentId);
        }

        public async Task<List<Student>> GetStudents()
        {
            return await studentRepository.GetAllStudents();
        }

        public async Task<List<Student>> GetStudentsByClassId(int classId)
        {
            return await studentRepository.GetStudentsByClassId(classId);
        }

        public async Task<Student> CreateStudent(StudentResource resource)
        {
            var student = new Student
            {
                ClassId = resource.classId,
                FirstName = resource.firstName,
                LastName = resource.lastName,
                Age = resource.age,
                GPA = resource.gpa
            };

            await this.studentRepository.Insert(student);
            await this.studentRepository.Save();

            return student;
        }

        public async Task<Student> UpdateStudent(int id, StudentResource resource)
        {
            var student = await this.studentRepository.GetStudentById(id);

            student.FirstName = resource.firstName;
            student.LastName = resource.lastName;
            student.Age = resource.age;
            student.GPA = Convert.ToDouble(resource.gpa);

            await this.studentRepository.Save();
            return student;
        }

        public async Task DeleteStudent(int studentId)
        {
            var student = await this.studentRepository.GetStudentById(studentId);
            this.studentRepository.Delete(student);

            await this.studentRepository.Save();
        }
    }
}