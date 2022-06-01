using DatabaseAccess;
using Logic.Commands;
using Logic.Dtos;
using Logic.Queries;
using Microsoft.AspNetCore.Mvc;

namespace SimpleCrudRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarCrudDbContext _context;

        public CarController(CarCrudDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("{carId:int}")]
        public IActionResult GetCar(int carId)
        {
            CarDto? response;
            try
            {
                response = new CarQueries(_context).GetById(carId);
            }
            catch (Exception)
            {
                return NoContent();
            }
            return response == null ? NotFound() : new JsonResult(response);
        }
        [HttpPost]
        public IActionResult PostCar(CarDto car)
        {
            new CarCommands(_context).Create(car);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteCar(int carId)
        {
            try
            {
                new CarCommands(_context).Delete(carId);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPatch]
        public IActionResult UpdateCar(CarDto car)
        {
            try
            {
                new CarCommands(_context).Update(car);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
