using DatabaseAccess;
using DatabaseAccess.DbModels;

namespace Logic.Dtos.Extensions
{
    public static class EmployeeExtensions
    {
        public static EmployeeDto ParseDto(this Employee employee, CarCrudDbContext context)
        {
            var car = context.Cars.FirstOrDefault(e => e.CarId == employee.CarId);
            return new EmployeeDto()
            {
                EmployeeId = employee.EmployeeId,
                Salary = employee.Salary,
                Car = car!.ParseDto(context),
                Name = employee.Name,
                Surname = employee.Surname
            };
        }

        public static Employee ParseFromDto(this EmployeeDto employee)
        {
            return new Employee()
            {
                CarId = employee.Car.CarId,
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Salary = employee.Salary,
                Surname = employee.Surname
            };
        }

    }
}
