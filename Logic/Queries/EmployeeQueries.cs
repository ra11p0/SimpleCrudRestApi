using DatabaseAccess;
using Logic.Dtos;
using Logic.Dtos.Extensions;

namespace Logic.Queries
{
    public class EmployeeQueries : QueryTemplate<EmployeeDto>

    {
        public EmployeeQueries(CarCrudDbContext context) : base(context)
        {
        }

        public override EmployeeDto GetById(int id)
        {
            return Context.Employees.First(e => e.EmployeeId == id).ParseDto(Context);
        }
    }
}
