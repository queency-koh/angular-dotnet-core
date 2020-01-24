using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quantum_it.Core.Models;
using quantum_it.Core.Repositories;

namespace quantum_it.Persistence.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext context;

        public ClassRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Class>> GetAllClassess()
        {
            return await context.Classes.Include(c => c.Students).ToListAsync();
        }

        public async Task<Class> GetClassById(int classId)
        {
            return await context.Classes.FirstOrDefaultAsync(c => c.Id == classId);
        }

        public async Task Insert(Class entity)
        {
            await context.Classes.AddAsync(entity);
        }

        public void Delete(Class entity)
        {
            context.Remove(entity);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
            await context.DisposeAsync();
        }
    }
}