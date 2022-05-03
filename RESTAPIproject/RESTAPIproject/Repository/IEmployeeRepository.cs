
using RESTAPIproject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTAPIproject.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> GetAllEmpAsync();
        Task<EmployeeModel> GetEmpByIdAsync(int Id);
        Task<int> AddEmpAsync(EmployeeModel employeeModel);
        Task UpdateEmpAsyc(int id, EmployeeModel employeeModel);
        Task DeleteEmpAsync(int Id);
    }
}
