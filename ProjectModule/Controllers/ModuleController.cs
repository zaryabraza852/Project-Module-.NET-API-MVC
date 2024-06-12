using Core.Entities;
using Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ProjectModule.Controllers
{
    public class ModuleController : Controller
    {
        private readonly IModuleService _service;


        public ModuleController(IModuleService service)
        {
            _service = service;
        }

        public async Task<ActionResult<List<Module>>> Index()
        {
            var modules = await _service.GetAll();
            return View(modules);
        }

        [HttpGet]
        public IActionResult GetById(int? id)
        {
            try
            {
               if (id == null) return NotFound();
               var module =  _service.GetById((int)id);
               if (module == null) return NotFound();
               return View(module);
            }
            catch (Exception)
            {

                throw;
            }
        }     

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([Bind("Name")] Module module)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.Add(module);
                    return RedirectToAction("Index", "Module");
                }
            }
            catch (Exception)
            {

                throw;
            }

            return View(module);

        }

        [HttpGet]
        public  IActionResult Update(int id)
        {
            try
            {
                if (id == 0) return NotFound();
                var projectModule =  _service.GetById(id);
                if (projectModule != null)
                {
                    return View(projectModule);
                }
                return NotFound(); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Update(Module module)
        {
            if (!ModelState.IsValid)
            {
                return View(module);
            }

            try
            {
                _service.Update(module);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            try
            {
                if (id == null) return NotFound();
                var projectModule =  _service.GetById((int)id);
                if (projectModule != null)
                {
                    return View(projectModule); 
                }
                return NotFound(); 
            }
            catch (Exception )
            {
                throw; 
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return RedirectToAction("Index", "Module");
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
