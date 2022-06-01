using DatabaseAccess;
using Logic.Commands;
using Logic.Dtos;
using Logic.Queries;
using Microsoft.AspNetCore.Mvc;

namespace SimpleCrudRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LorryController : ControllerBase
    {
        private readonly CarCrudDbContext _context;

        public LorryController(CarCrudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{lorryId:int}")]
        public IActionResult GetLorry(int lorryId)
        {
            LorryDto? response;
            try
            {
                response = new LorryQueries(_context).GetById(lorryId);
            }
            catch (Exception)
            {
                return NoContent();
            }
            return response == null ? NotFound() : new JsonResult(response);
        }
        [HttpPost]
        public IActionResult PostLorry(LorryDto lorry)
        {
            new LorryCommands(_context).Create(lorry);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteLorry(int lorryId)
        {
            try
            {
                new LorryCommands(_context).Delete(lorryId);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPatch]
        public IActionResult UpdateLorry(LorryDto lorry)
        {
            try
            {
                new LorryCommands(_context).Update(lorry);
            }catch (Exception)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
