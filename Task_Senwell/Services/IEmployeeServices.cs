using Task_Senwell.Models;

namespace Task_Senwell.Services
{
    public interface IEmployeeServices
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeById(int id);
        int AddEmployee(Employee employee);
        int UpdateEmployee(Employee employee);
        int DeleteEmployee(int id);
    }
}
