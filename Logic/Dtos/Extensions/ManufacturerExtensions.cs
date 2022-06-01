using DatabaseAccess.DbModels;

namespace Logic.Dtos.Extensions
{
    public static class ManufacturerExtensions
    {
        public static ManufacturerDto ParseDto(this Manufacturer? manufacturer)
        {
            return manufacturer == null ? new ManufacturerDto(): new ManufacturerDto()
            {
                ManufacturerId = manufacturer.ManufacturerId,
                Name = manufacturer.Name,
                ServicePhoneNumber = manufacturer.ServicePhoneNumber
            };
        }
        public static Manufacturer ParseFromDto(this ManufacturerDto? manufacturer)
        {
            return manufacturer == null ? new Manufacturer() : new Manufacturer()
            {
                ManufacturerId = manufacturer.ManufacturerId,
                Name = manufacturer.Name,
                ServicePhoneNumber = manufacturer.ServicePhoneNumber
            };
        }
    }
}
