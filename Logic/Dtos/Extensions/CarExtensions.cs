using DatabaseAccess;
using DatabaseAccess.DbModels;

namespace Logic.Dtos.Extensions
{
    public static class CarExtensions
    {
        public static CarDto ParseDto(this Car car, CarCrudDbContext context)
        {
            var manufacturer = context.Manufacturers.First(e => e.ManufacturerId == car.ManufacturerId);
            var model = context.Models.First(e => e.ModelId == car.ModelId);
            return new CarDto()
            {
                CarId = car.CarId,
                ManufactureYear = car.ManufactureYear,
                MaxPeopleLimit = car.MaxPeopleLimit,
                Manufacturer = manufacturer.ParseDto(),
                Model = model.ParseDto(),
            };
        }
        public static Car ParseFromDto(this CarDto car)
        {

            return new Car()
            {
                CarId = car.CarId,
                ManufactureYear = car.ManufactureYear,
                MaxPeopleLimit = car.MaxPeopleLimit,
                ManufacturerId = car.Manufacturer.ManufacturerId,
                ModelId = car.Manufacturer.ManufacturerId
            };
        }
    }
}
