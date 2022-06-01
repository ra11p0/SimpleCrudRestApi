using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.DbModels
{
    public class Vehicle
    {
        [Required]
        public int ManufacturerId { get; set; }
        [Required]
        public int ModelId { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        public string ManufactureYear { get; set; } = String.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}
