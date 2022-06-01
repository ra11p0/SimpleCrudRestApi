using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.DbModels
{
    public class Car : Vehicle
    {
        public int CarId { get; set; }
        [Required]
        [Range(1, 8)]
        public int MaxPeopleLimit { get; set; }
    }
}
