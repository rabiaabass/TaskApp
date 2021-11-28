using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Models;

namespace TaskApp.Repositories
{
    public class EmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public Employee Find(string ID)
        {
            return _db.Employees.Find(ID);
        }

        public List<Employee> List()
        {
            return _db.Employees.ToList();
        }

        public void Update(Employee employee)
        {
            _db.Employees.Update(employee);
            _db.SaveChanges();
        }
    }
}
