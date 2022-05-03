using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTAPIproject.Models;
using RESTAPIproject.Repository;
using System.Threading.Tasks;

namespace RESTAPIproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var dept = await _departmentRepository.GetAllDeptAsync();
            return Ok(dept);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeptById([FromRoute] int id)
        {
            var dept = await _departmentRepository.GetDeptByIdAsync(id);
            if (dept == null)
            {
                return NotFound();
            }
            return Ok(dept);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddNewDept([FromBody] DepartmentModel departmentModel)
        {
            var id = await _departmentRepository.AddDeptAsync(departmentModel);
            return CreatedAtAction(nameof(GetDeptById), new { id = id, Controller = "Department" }, id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmp([FromRoute] int id, [FromBody] DepartmentModel departmentModel)
        {
            await _departmentRepository.UpdateDeptAsyc(id, departmentModel);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDept([FromRoute] int id)
        {
            await _departmentRepository.DeleteDeptAsync(id);
            return Ok();
        }


    }
}
