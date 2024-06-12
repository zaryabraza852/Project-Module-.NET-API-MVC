using Core.Entities;
using Core.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    // To be used for Database Access
    public class ModuleRepository : IModuleRepository
    {
        private readonly ModuleContext _context;

        public ModuleRepository(ModuleContext context)
        {
            _context = context;
        }

        public void Add(Module model)
        {
             _context.Add(model);
             _context.SaveChanges();
        }

        public void Delete(int id)
        {
             var module = _context.ProjectModules.Where(x => x.Id == id).FirstOrDefault();
             if (module is not null)
             {
                _context.Remove(module);
                _context.SaveChanges();
             }
        }

        public async Task<List<Module>> GetAll()
        {
            return await _context.ProjectModules.ToListAsync(); 
        }

        public Module GetById(int id)
        {
            return  _context.ProjectModules
               .Where(x => x.Id == id).FirstOrDefault();
        }

        public void Update(Module model)
        {
            _context.Entry(_context.ProjectModules.FirstOrDefault(x => x.Id == model.Id)).CurrentValues.SetValues(model);
            _context.SaveChanges();
        }

        
    }
}
