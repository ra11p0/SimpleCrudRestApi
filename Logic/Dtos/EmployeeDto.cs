namespace Logic.Dtos
{
    public class EmployeeDto : PersonDto
    {
        public int EmployeeId { get; set; }
        public decimal Salary { get; set; }
        public CarDto Car { get; set; }
    }
}
