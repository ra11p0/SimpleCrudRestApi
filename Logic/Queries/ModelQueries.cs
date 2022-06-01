using DatabaseAccess;
using Logic.Dtos;
using Logic.Dtos.Extensions;

namespace Logic.Queries
{
    public class ModelQueries : QueryTemplate<ModelDto>
    {
        public ModelQueries(CarCrudDbContext context) : base(context)
        {
        }

        public override ModelDto? GetById(int id)
        {
            return Context.Models.FirstOrDefault(e => e.ModelId == id)?.ParseDto();
        }
    }
}
