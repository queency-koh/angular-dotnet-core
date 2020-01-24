using System.Collections.Generic;
using System.Threading.Tasks;
using quantum_it.Controllers.Resources;
using quantum_it.Core.Models;

namespace quantum_it.Core.Services
{
    public interface IStudentService
    {
        Task<Student> GetStudent(int studentId);
        Task<List<Student>> GetStudents();
        Task<List<Student>> GetStudentsByClassId(int classId);
        Task<Student> CreateStudent(StudentResource resource);
        Task<Student> UpdateStudent(int studentId, StudentResource resource);
        Task DeleteStudent(int studentId);
    }
}