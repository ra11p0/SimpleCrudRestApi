using DatabaseAccess;
using Logic.Dtos;
using Logic.Dtos.Extensions;

namespace Logic.Commands
{
    public class LorryCommands : CommandTemplate<LorryDto>
    {
        public LorryCommands(CarCrudDbContext context) : base(context)
        {
        }

        public override void Create(LorryDto obj)
        {
            if (obj.Model.ModelId == 0)
            {
                new ModelCommands(Context).Create(obj.Model);
            }
            if (obj.Manufacturer.ManufacturerId == 0)
            {
                new ManufacturerCommands(Context).Create(obj.Manufacturer);
            }
            var lorry = obj.ParseFromDto();
            Context.Add(lorry);
            Context.SaveChanges();
            obj.LorryId = lorry.LorryId;
        }

        public override void Update(LorryDto obj)
        {
            var toUpdate = obj.ParseFromDto();
            Context.Update(toUpdate);
            Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var toDelete = Context.Lorries.First(e=>e.LorryId == id);
            toDelete.IsDeleted = true;
            Context.SaveChanges();
        }
    }
}
