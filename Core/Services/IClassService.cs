using System.Collections.Generic;
using System.Threading.Tasks;
using quantum_it.Controllers.Resources;
using quantum_it.Core.Models;

namespace quantum_it.Core.Services
{
    public interface IClassService
    {
        Task<Class> GetClass(int id);
        Task<List<Class>> GetClassess();
        Task<Class> CreateClass(ClassResource resource);
        Task<Class> UpdateClass(int id, ClassResource resource);
        Task DeleteClass(int classId);
    }
}