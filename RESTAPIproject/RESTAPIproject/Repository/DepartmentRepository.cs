using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RESTAPIproject.Data;
using RESTAPIproject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace RESTAPIproject.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeMSContext _context;
        private readonly IMapper _mapper;

        public DepartmentRepository(EmployeeMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DepartmentModel>> GetAllDeptAsync()
        {
            var records = await _context.Department.Select(x =>new DepartmentModel()
            {
                DId=x.DId,
                DepartmentName=x.DepartmentName,
               
            }).ToListAsync();
            return records;


        }

        public async Task<DepartmentModel> GetDeptByIdAsync(int Id)
        {

            var dept = await _context.Department.FindAsync(Id);
            return _mapper.Map<DepartmentModel>(dept);
        }

        public async Task<int> AddDeptAsync(DepartmentModel departmentModel)
        {
            var dept = new Department()
            {
               DId= departmentModel.DId,
               DepartmentName= departmentModel.DepartmentName
               
            };

            _context.Department.Add(dept);
            
            await _context.SaveChangesAsync();
            return dept.DId;

        }
        public async Task UpdateDeptAsyc(int Id, DepartmentModel departmentModel)
        {
            var dept = new Department()
            {
               DId = departmentModel.DId,
                DepartmentName = departmentModel.DepartmentName

            };
            _context.Department.Update(dept);
            await _context.SaveChangesAsync();

        }
        public async Task DeleteDeptAsync(int Id)
        {
            var dept = new Department()
            {
                DId = Id,
            };

            _context.Department.Remove(dept);
            await _context.SaveChangesAsync();

        }

    }
}
