using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAccess.DbModels
{
    public class Employee : Person
    {
        public int EmployeeId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Salary { get; set; }
        public int CarId { get; set; }
    }
}
