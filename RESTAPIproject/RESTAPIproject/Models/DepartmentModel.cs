using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace RESTAPIproject.Models
{
    public class DepartmentModel
    {
        [Required]
        public int DId { get; set; }
        [Required]
        public string DepartmentName { get; set; }

        //public virtual List<EmployeeModel> Employees { get; set; }
    }
}
