using DatabaseAccess;
using Logic.Commands;
using Logic.Dtos;
using Logic.Queries;
using Microsoft.AspNetCore.Mvc;

namespace SimpleCrudRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly CarCrudDbContext _context;

        public ModelController(CarCrudDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("{modelId:int}")]
        public IActionResult GetModel(int modelId)
        {
            ModelDto? response;
            try
            {
                response = new ModelQueries(_context).GetById(modelId);
            }
            catch (Exception)
            {
                return NoContent();
            }
            return response == null ? NotFound() : new JsonResult(response);
        }
        [HttpPost]
        public IActionResult PostModel(ModelDto model)
        {
            new ModelCommands(_context).Create(model);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteModel(int modelId)
        {
            try
            {
                new ModelCommands(_context).Delete(modelId);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPatch]
        public IActionResult UpdateModel(ModelDto model)
        {
            try
            {
                new ModelCommands(_context).Update(model);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
