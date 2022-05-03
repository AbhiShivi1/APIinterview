using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RESTAPIproject.Data;
using RESTAPIproject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPIproject.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeMSContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(EmployeeMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EmployeeModel>> GetAllEmpAsync()
        {
            var all = await _context.Employee.Select(x => new EmployeeModel()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Address = x.Address,
                Qualification = x.Qualification,
                Contact_Number = x.Contact_Number,
                DId = x.DId,
                Department=new DepartmentModel()
                {   DId=x.DId,
                    DepartmentName=x.Department.DepartmentName,
                    
                   
                }

            }).ToListAsync();
            return all;

            //var records = await _context.Employee.ToListAsync();
            //return _mapper.Map<List<EmployeeModel>>(records);
  
        }


        public async Task<EmployeeModel> GetEmpByIdAsync(int Id)
        {
         
            var emp = await _context.Employee.FindAsync(Id);
            return _mapper.Map<EmployeeModel>(emp);
        }





        public async Task<int> AddEmpAsync(EmployeeModel employeeModel)
        {
            var emp = new Employee()
            {
                Id = employeeModel.Id,
                Name = employeeModel.Name,
                Surname = employeeModel.Surname,
                Address = employeeModel.Address,
                Qualification = employeeModel.Qualification,
                Contact_Number = employeeModel.Contact_Number,
                DId = employeeModel.DId,

            };

            _context.Employee.Add(emp);
            await _context.SaveChangesAsync();
            return emp.Id;

        }

        public async Task UpdateEmpAsyc(int Id,EmployeeModel employeeModel)
        {
            var emp = new Employee()
            {
                Id = employeeModel.Id,
                Name = employeeModel.Name,
                Surname = employeeModel.Surname,
                Address = employeeModel.Address,
                Qualification = employeeModel.Qualification,
                Contact_Number = employeeModel.Contact_Number,
                DId = employeeModel.DId,
            };
            _context.Employee.Update(emp);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteEmpAsync(int Id)
        {
            var emp = new Employee()
            {
                Id = Id,
            };

            _context.Employee.Remove(emp);
            await _context.SaveChangesAsync();

        }
       

    }
}
