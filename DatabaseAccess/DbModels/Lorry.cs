using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.DbModels
{
    public class Lorry : Vehicle
    {
        public int LorryId { get; set; }
        [Required]
        public int MaxLoad { get; set; }
    }
}
