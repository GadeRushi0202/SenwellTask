using Task_Senwell.Data;
using Task_Senwell.Models;

namespace Task_Senwell.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ApplicationDbContext db;
        public EmployeeRepo(ApplicationDbContext db) 
        {
            this.db = db;
        }
        public int AddEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            int result = db.SaveChanges();
            return result;
        }

        public int DeleteEmployee(int id)
        {
            int res = 0;
            var result = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                db.Employees.Remove(result);
                res = db.SaveChanges();
            }
            return res;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return db.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            var result = db.Employees.Where(x => x.Id == id).SingleOrDefault();
            return result;
        }

        public int UpdateEmployee(Employee employee)
        {
            int res = 0;


            var result = db.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();

            if (result != null)
            {
                result.Name = employee.Name; 
                result.Email = employee.Email;
                result.Password = employee.Password;
                result.ConfirmPassword = employee.ConfirmPassword;

                res = db.SaveChanges();
            }
            

            return res;
        }
    }
}
