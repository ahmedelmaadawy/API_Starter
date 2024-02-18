using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPI_starter.Models
{
    public class Employee
    {
        [Column("EmployeeId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Employee Name is A required field")]
        [MaxLength(30, ErrorMessage = "Maximum length for the name is 30 characters")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Age is a required field")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Position is a required field")]
        [MaxLength(20, ErrorMessage = "Maximum length for position is 20 characters")]
        public string? Position { get; set; }
        //relations
        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }

    }
}
