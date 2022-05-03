using AutoMapper;
using RESTAPIproject.Data;
using RESTAPIproject.Models;

namespace RESTAPIproject.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Employee, EmployeeModel>().ReverseMap();
            CreateMap<Department, DepartmentModel>().ReverseMap();
        }

    }
}
