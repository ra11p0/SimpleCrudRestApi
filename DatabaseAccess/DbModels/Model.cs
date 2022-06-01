using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.DbModels
{
    public class Model
    {
        public int ModelId { get; set; }
        [Required] public string Name { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}
