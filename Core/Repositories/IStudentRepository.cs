using System.Collections.Generic;
using System.Threading.Tasks;
using quantum_it.Core.Models;

namespace quantum_it.Core.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentById(int studentId);
        Task<List<Student>> GetAllStudents();
        Task<List<Student>> GetStudentsByClassId(int classId);
        Task Insert(Student student);
        void Delete(Student student);
        Task Save();
    }
}