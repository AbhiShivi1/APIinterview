using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPIproject.Data

{
    public class Employee
    {   [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        public string Contact_Number { get; set; }
        [ForeignKey("Department")]
        public int DId { get; set; }
        public virtual Department Department { get; set; }

    }
}
