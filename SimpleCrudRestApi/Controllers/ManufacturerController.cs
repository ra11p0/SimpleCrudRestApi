using DatabaseAccess;
using Logic.Commands;
using Logic.Dtos;
using Logic.Queries;
using Microsoft.AspNetCore.Mvc;

namespace SimpleCrudRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly CarCrudDbContext _context;

        public ManufacturerController(CarCrudDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("{manuId:int}")]
        public IActionResult GetManu(int manuId)
        {
            ManufacturerDto? response;
            try
            {
                response = new ManufacturerQueries(_context).GetById(manuId);
            }
            catch (Exception)
            {
                return NoContent();
            }
            return response == null ? NotFound() : new JsonResult(response);
        }
        [HttpPost]
        public IActionResult PostManu(ManufacturerDto manufacturer)
        {
            new ManufacturerCommands(_context).Create(manufacturer);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteManu(int manuId)
        {
            try
            {
                new ManufacturerCommands(_context).Delete(manuId);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPatch]
        public IActionResult UpdateManu(ManufacturerDto manufacturer)
        {
            try
            {
                new ManufacturerCommands(_context).Update(manufacturer);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
