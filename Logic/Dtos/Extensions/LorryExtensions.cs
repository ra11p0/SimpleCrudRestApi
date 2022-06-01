using DatabaseAccess;
using DatabaseAccess.DbModels;

namespace Logic.Dtos.Extensions
{
    public static class LorryExtensions
    {
        public static LorryDto ParseDto(this Lorry lorry, CarCrudDbContext context)
        {
            var manufacturer = context.Manufacturers.First(e => e.ManufacturerId == lorry.ManufacturerId);
            var model = context.Models.First(e => e.ModelId == lorry.ModelId);
            return new LorryDto()
            {
                LorryId = lorry.LorryId,
                ManufactureYear = lorry.ManufactureYear,
                MaxLoad = lorry.MaxLoad,
                Manufacturer = manufacturer.ParseDto(),
                Model = model.ParseDto(),
            };
        }
        public static Lorry ParseFromDto(this LorryDto lorry)
        {

            return new Lorry()
            {
                LorryId = lorry.LorryId,
                ManufactureYear = lorry.ManufactureYear,
                MaxLoad = lorry.MaxLoad,
                ManufacturerId = lorry.Manufacturer.ManufacturerId,
                ModelId = lorry.Manufacturer.ManufacturerId
            };
        }
    }
}
