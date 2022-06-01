using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.DbModels
{
    public class Person
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Surname { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}
