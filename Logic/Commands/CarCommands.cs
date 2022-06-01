using DatabaseAccess;
using Logic.Dtos;
using Logic.Dtos.Extensions;

namespace Logic.Commands
{
    public class CarCommands : CommandTemplate<CarDto>
    {
        public CarCommands(CarCrudDbContext context) : base(context)
        {
        }

        public override void Create(CarDto obj)
        {
            if (obj.Model.ModelId == 0)
            {
                new ModelCommands(Context).Create(obj.Model);
            }
            if (obj.Manufacturer.ManufacturerId == 0)
            {
                new ManufacturerCommands(Context).Create(obj.Manufacturer);
            }
            var car = obj.ParseFromDto();
            Context.Add(car);
            Context.SaveChanges();
            obj.CarId = car.CarId;
        }

        public override void Update(CarDto obj)
        {
            var toUpdate = obj.ParseFromDto();
            Context.Update(toUpdate);
            Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var toDelete = Context.Cars.First(e => e.CarId == id);
            toDelete.IsDeleted = true;
            Context.SaveChanges();
        }
    }
}
