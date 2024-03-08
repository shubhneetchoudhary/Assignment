using Mamsys_Employee_API.Model;
using Mamsys_Employee_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mamsys_Employee_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employee;
        public EmployeeController(IEmployeeRepository employee)
        {
            this.employee = employee;
        }
        [HttpGet("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            var temp = employee.GetEmployees();
            return Ok(temp);    
        }
        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees(int id)
        {
            var temp = employee.GetEmployeeById(id);
            return Ok(temp);
        }
        [HttpPost("CreateEmployee")]
        public IActionResult CreateEmployees(Employee emp)
        {
            var temp = employee.CreateEmployee(emp);
            return Ok(temp);
        }
        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployees(Employee emp)
        {
            var temp = employee.UpdateEmployee(emp);
            return Ok(temp);
        }
        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteEmployees(int id)
        {
            var temp = employee.DeleteEmployee(id);
            return Ok(temp);
        }
    }
}
