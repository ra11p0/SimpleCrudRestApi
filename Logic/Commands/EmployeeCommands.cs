using DatabaseAccess;
using Logic.Dtos;
using Logic.Dtos.Extensions;

namespace Logic.Commands
{
    public class EmployeeCommands : CommandTemplate<EmployeeDto>
    {
        public EmployeeCommands(CarCrudDbContext context) : base(context)
        {
        }

        public override void Create(EmployeeDto obj)
        {
            if (obj.Car.CarId == 0)
            {
                new CarCommands(Context).Create(obj.Car);
            }
            var employee = obj.ParseFromDto();
            Context.Add(employee);
            Context.SaveChanges();
            obj.EmployeeId = employee.CarId;
        }

        public override void Update(EmployeeDto obj)
        {
            var toUpdate = obj.ParseFromDto();
            Context.Update(toUpdate);
            Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var toDelete = Context.Employees.First(e => e.EmployeeId == id);
            toDelete.IsDeleted = true;
            Context.SaveChanges();
        }
    }
}
