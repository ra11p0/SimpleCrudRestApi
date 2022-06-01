using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.DbModels
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MinLength(6)]
        [MaxLength(12)]
        public string ServicePhoneNumber { get; set; } = String.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}
