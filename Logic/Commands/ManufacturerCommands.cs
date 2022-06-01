using DatabaseAccess;
using Logic.Dtos;
using Logic.Dtos.Extensions;

namespace Logic.Commands
{
    public class ManufacturerCommands : CommandTemplate<ManufacturerDto>
    {
        public ManufacturerCommands(CarCrudDbContext context) : base(context)
        {
        }

        public override void Create(ManufacturerDto obj)
        {
            var entity = obj.ParseFromDto();
            Context.Add(entity);
            Context.SaveChanges();
            obj.ManufacturerId = entity.ManufacturerId;
        }

        public override void Update(ManufacturerDto obj)
        {
            var toUpdate = obj.ParseFromDto();
            Context.Update(toUpdate);
            Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var toDelete = Context.Manufacturers.First(e => e.ManufacturerId == id);
            toDelete.IsDeleted = true;
            Context.SaveChanges();
        }
    }
}
