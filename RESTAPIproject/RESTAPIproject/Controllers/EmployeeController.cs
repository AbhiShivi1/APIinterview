using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTAPIproject.Models;
using RESTAPIproject.Repository;
using System.Threading.Tasks;

namespace RESTAPIproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var emp = await _employeeRepository.GetAllEmpAsync();
            return Ok(emp);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpById([FromRoute] int id)
        {
            var emp = await _employeeRepository.GetEmpByIdAsync(id);
            if(emp==null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewEmp([FromBody] EmployeeModel employeeModel)
        {
            var id = await _employeeRepository.AddEmpAsync(employeeModel);
            return CreatedAtAction(nameof(GetEmpById), new { id = id, Controller = "Employee" }, id);
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmp([FromRoute] int id, [FromBody] EmployeeModel employeeModel)
        {
            await _employeeRepository.UpdateEmpAsyc(id, employeeModel);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmp([FromRoute] int id)
        {
            await _employeeRepository.DeleteEmpAsync(id);
            return Ok();
        }




    }
}
