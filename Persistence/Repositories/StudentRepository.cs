using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quantum_it.Core.Models;
using quantum_it.Core.Repositories;

namespace quantum_it.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;

        public StudentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await context.Students.ToListAsync();
        }

        public async Task<List<Student>> GetStudentsByClassId(int classId)
        {
            return await context.Students.Where(s => s.ClassId == classId).ToListAsync();
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            return await context.Students.FirstOrDefaultAsync(s => s.Id == studentId);
        }

        public async Task Insert(Student student)
        {
            await context.Students.AddAsync(student);

        }

        public void Delete(Student student)
        {
            context.Remove(student);

        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
            await context.DisposeAsync();
        }
    }
}