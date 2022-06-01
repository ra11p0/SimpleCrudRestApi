using DatabaseAccess;
using Logic.Dtos;
using Logic.Dtos.Extensions;

namespace Logic.Commands
{
    public class ModelCommands : CommandTemplate<ModelDto>
    {
        public ModelCommands(CarCrudDbContext context) : base(context)
        {
        }

        public override void Create(ModelDto obj)
        {
            var entity = obj.ParseFromDto();
            Context.Add(entity);
            Context.SaveChanges();
            obj.ModelId = entity.ModelId;
        }

        public override void Update(ModelDto obj)
        {
            var toUpdate = obj.ParseFromDto();
            Context.Update(toUpdate);
            Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var toDelete = Context.Models.First(e => e.ModelId == id);
            toDelete.IsDeleted = true;
            Context.SaveChanges();
        }
    }
}
