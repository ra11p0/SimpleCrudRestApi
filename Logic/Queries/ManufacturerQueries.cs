using DatabaseAccess;
using Logic.Dtos;
using Logic.Dtos.Extensions;

namespace Logic.Queries
{
    public class ManufacturerQueries : QueryTemplate<ManufacturerDto>
    {
        public ManufacturerQueries(CarCrudDbContext context) : base(context)
        {
        }

        public override ManufacturerDto? GetById(int id)
        {
            return Context.Manufacturers.FirstOrDefault(e => e.ManufacturerId == id)?.ParseDto();
        }
    }
}
