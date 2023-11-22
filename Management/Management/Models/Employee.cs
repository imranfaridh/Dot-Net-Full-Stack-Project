using System.ComponentModel.DataAnnotations;

namespace Management.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string DOJ { get; set; }
    }
}
