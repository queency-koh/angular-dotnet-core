using System.Collections.Generic;
using System.Threading.Tasks;
using quantum_it.Controllers.Resources;
using quantum_it.Core.Models;
using quantum_it.Core.Repositories;
using quantum_it.Core.Services;

namespace quantum_it.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository classRepository;

        public ClassService(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        public async Task<Class> GetClass(int id)
        {
            return await classRepository.GetClassById(id);
        }

        public async Task<List<Class>> GetClassess()
        {
            return await classRepository.GetAllClassess();
        }
        public async Task<Class> CreateClass(ClassResource resource)
        {
            Class entity = new Class
            {
                ClassName = resource.ClassName,
                Location = resource.Location,
                TeacherName = resource.TeacherName
            };

            await this.classRepository.Insert(entity);
            await this.classRepository.Save();

            return entity;
        }

        public async Task<Class> UpdateClass(int id, ClassResource resource)
        {
            var entity = await this.classRepository.GetClassById(id);

            entity.ClassName = resource.ClassName;
            entity.Location = resource.Location;
            entity.TeacherName = resource.TeacherName;

            await this.classRepository.Save();

            return entity;
        }

        public async Task DeleteClass(int classId)
        {
            var entity = await this.classRepository.GetClassById(classId);
            this.classRepository.Delete(entity);
            await this.classRepository.Save();
        }
    }
}