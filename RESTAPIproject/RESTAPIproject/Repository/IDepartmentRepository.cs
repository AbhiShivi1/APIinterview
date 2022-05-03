using RESTAPIproject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace RESTAPIproject.Repository
{
    public interface IDepartmentRepository
    {
        Task<List<DepartmentModel>> GetAllDeptAsync();
        Task<DepartmentModel> GetDeptByIdAsync(int Id);
        Task<int> AddDeptAsync(DepartmentModel departmentModel);
        Task UpdateDeptAsyc(int Id, DepartmentModel departmentModel);
        Task DeleteDeptAsync(int Id);
    }
}
