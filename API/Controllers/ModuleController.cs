using Core.Entities;
using Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _service;

        public ModuleController(IModuleService service)
        {
            _service = service;
        }

        [HttpGet("get-all")]
        public async Task <ActionResult<List<Module>>> GetAll()
        {
            try
            {
                 return await _service.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("get-by-id")]
        public ActionResult<Module> GetById(int id)
        {
            try
            {
                return _service.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        [HttpPost]
        public IActionResult Add(Module module)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.Add(module);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Module module)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (module.Id != 0)
                    {
                        _service.Update(module);
                    }
                   
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    _service.Delete(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }
    }
}
