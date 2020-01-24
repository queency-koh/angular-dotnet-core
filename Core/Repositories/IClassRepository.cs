using System.Collections.Generic;
using System.Threading.Tasks;
using quantum_it.Core.Models;

namespace quantum_it.Core.Repositories
{
    public interface IClassRepository
    {
        Task<Class> GetClassById(int classId);
        Task<List<Class>> GetAllClassess();
        Task Insert(Class entity);
        void Delete(Class entity);
        Task Save();
    }
}