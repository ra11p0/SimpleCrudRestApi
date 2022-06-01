using DatabaseAccess;
using Logic.Dtos;
using Logic.Dtos.Extensions;

namespace Logic.Queries
{
    public class LorryQueries : QueryTemplate<LorryDto>
    {
        public LorryQueries(CarCrudDbContext context) : base(context)
        {
        }

        public override LorryDto? GetById(int id)
        {
            var result = Context.Lorries.FirstOrDefault(e => e.LorryId == id);
            return result?.ParseDto(Context);
        }
    }
}
