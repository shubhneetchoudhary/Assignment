using Mamsys_Employee_API.Model;

namespace Mamsys_Employee_API.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        int CreateEmployee(Employee emp);
        int UpdateEmployee(Employee emp);
        int DeleteEmployee(int id);
    }
}
