using Core.Entities;

namespace Core.IRepository
{
    public interface IModuleRepository
    {
        void Add(Module model);
        void Update( Module model);
        void Delete(int id);
        Module GetById(int id);
        Task<List<Module>> GetAll();
    }
}
