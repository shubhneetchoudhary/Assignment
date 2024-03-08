using Mamsys_Employee_API.DBContext;
using Mamsys_Employee_API.Model;

namespace Mamsys_Employee_API.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly EmployeeDbContext dbContext;
        public EmployeeRepository(EmployeeDbContext dbContext) 
        { 
            this.dbContext = dbContext;
        }

        public int CreateEmployee(Employee emp)
        {
            dbContext.Add(emp);
            return dbContext.SaveChanges(); 
        }

        public int DeleteEmployee(int id)
        {
             Employee emp = dbContext.Employees.Where(x=>x.EmployeeId==id).SingleOrDefault();
            dbContext.Remove(emp);  
            return dbContext.SaveChanges();    
        }

        public Employee GetEmployeeById(int id)
        {
            Employee emp = dbContext.Employees.Where(x => x.EmployeeId == id).SingleOrDefault();
            return emp;
        }

        public List<Employee> GetEmployees()
        {
            return dbContext.Employees.ToList();
        }

        public int UpdateEmployee(Employee emp)
        {
            dbContext.Update(emp);
            return dbContext.SaveChanges(); 
        }
    }
}
