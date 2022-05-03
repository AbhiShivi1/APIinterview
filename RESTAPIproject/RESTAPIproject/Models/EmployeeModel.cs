using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPIproject.Models
{
    public class EmployeeModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public string Contact_Number { get; set; }
        [ForeignKey("DepartmentModel")]
        public int DId { get; set; }

        public virtual DepartmentModel Department { get; set; }
    }
}
//Name, Surname, Address, Qualification, Contact Number, Department.
