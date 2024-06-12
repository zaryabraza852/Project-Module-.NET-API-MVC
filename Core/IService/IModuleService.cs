using Core.Entities;

namespace Core.IService
{
    public interface IModuleService
    {
        void Add(Module model);
        void Update(Module model);
        void Delete(int id);
        Module GetById(int id);
        Task<List<Module>> GetAll();
    }
}
