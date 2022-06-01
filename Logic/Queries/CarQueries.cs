using DatabaseAccess;
using Logic.Dtos;
using Logic.Dtos.Extensions;

namespace Logic.Queries
{
    public class CarQueries : QueryTemplate<CarDto>
    {
        public CarQueries(CarCrudDbContext context) : base(context)
        {
        }

        public override CarDto? GetById(int id)
        {
            var result = Context.Cars.FirstOrDefault(e => e.CarId == id);
            return result?.ParseDto(Context);
        }
    }
}
