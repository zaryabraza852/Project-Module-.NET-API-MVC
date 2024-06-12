using Core.Entities;
using Core.IRepository;
using Core.IService;

namespace Infrastructure.Service
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _repository;

        public ModuleService(IModuleRepository repository)
        {
            _repository = repository;
        }

        public void Add(Module model)
        {
            try
            {
                if (model.Id == 0) _repository.Add(model);

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public void Delete(int id)
        {
            try
            {
                var existingModule = _repository.GetById(id);
                if (existingModule != null)
                {
                    _repository.Delete(id);
                }
            }
            catch (Exception)
            {

                throw new Exception("Module Not found");
            }
                     
        }

        public async Task<List<Module>> GetAll()
        {
            try
            {
                return await _repository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public Module GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public void Update(Module model)
        {
            try
            {
                _repository.Update(model);
            }
            catch (Exception)
            {

                throw new Exception("Module Not Found.");
            }
           
            
        }
    }
}
