using Microsoft.EntityFrameworkCore;

namespace RESTAPIproject.Data
{
    public class EmployeeMSContext :DbContext
    {
        public EmployeeMSContext(DbContextOptions<EmployeeMSContext> options):base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }

        


    }
}
