using Mamsys_Employee_API.DBContext;
using Mamsys_Employee_API.Model;
using Mamsys_Employee_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Mamsys_Employee_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeProcedureController : ControllerBase
    {
        private readonly EmployeeDbContext dbContext;
        public EmployeeProcedureController(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;   
        }
        [HttpGet("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            var employees = dbContext.Employees.FromSqlRaw("EXEC GetAllEmployee").ToList();
            return Ok(employees);
        }

        [HttpGet("GetEmplyeeById")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = dbContext.Employees.FromSqlRaw("EXEC GetEmployee @EmployeeId", new SqlParameter("@EmployeeId", id)).AsEnumerable().FirstOrDefault();

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost("CreateEmplyee")]
        public IActionResult InsertEmployee([FromBody] Employee employee)
        {
            dbContext.Database.ExecuteSqlRaw("EXEC InsertEmployee @EmployeeFirstName, @EmployeeMiddleName, @EmployeeLastName, @DepartmentID, @DepartmentName, @Status, @DateOfBirth",
                new SqlParameter("@EmployeeFirstName", employee.EmployeeFirstName),
                new SqlParameter("@EmployeeMiddleName", employee.EmployeeMiddleName),
                new SqlParameter("@EmployeeLastName", employee.EmployeeLastName),
                new SqlParameter("@DepartmentID", employee.DepartmentId),
                new SqlParameter("@DepartmentName", employee.DepartmentName),
                new SqlParameter("@Status", employee.Status),
                new SqlParameter("@DateOfBirth", employee.DateOfBirth));

            return Ok();
        }

        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            dbContext.Database.ExecuteSqlRaw("EXEC UpdateEmployee @EmployeeId, @EmployeeFirstName, @EmployeeMiddleName, @EmployeeLastName, @DepartmentID, @DepartmentName, @Status, @DateOfBirth",
                new SqlParameter("@EmployeeId", id),
                new SqlParameter("@EmployeeFirstName", employee.EmployeeFirstName),
                new SqlParameter("@EmployeeMiddleName", employee.EmployeeMiddleName),
                new SqlParameter("@EmployeeLastName", employee.EmployeeLastName),
                new SqlParameter("@DepartmentID", employee.DepartmentId),
                new SqlParameter("@DepartmentName", employee.DepartmentName),
                new SqlParameter("@Status", employee.Status),
                new SqlParameter("@DateOfBirth", employee.DateOfBirth));

            return Ok();
        }

        [HttpDelete("DeleteEmployeee")]
        public IActionResult DeleteEmployee(int id)
        {
            dbContext.Database.ExecuteSqlRaw("EXEC DeleteEmployee @EmployeeId", new SqlParameter("@EmployeeId", id));
            return Ok();
        }
    }
}
