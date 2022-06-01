using DatabaseAccess;
using Logic.Commands;
using Logic.Dtos;
using Logic.Queries;
using Microsoft.AspNetCore.Mvc;

namespace SimpleCrudRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly CarCrudDbContext _context;

        public EmployeeController(CarCrudDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("{empId:int}")]
        public IActionResult GetEmployee(int empId)
        {
            EmployeeDto? response;
            try
            {
                response = new EmployeeQueries(_context).GetById(empId);
            }
            catch (Exception)
            {
                return NoContent();
            }
            return new JsonResult(response);
        }
        [HttpPost]
        public IActionResult PostEmployee(EmployeeDto emp)
        {
            new EmployeeCommands(_context).Create(emp);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int empId)
        {
            try
            {
                new EmployeeCommands(_context).Delete(empId);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPatch]
        public IActionResult UpdateEmployee(EmployeeDto emp)
        {
            try
            {
                new EmployeeCommands(_context).Update(emp);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
