using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Models;

namespace TaskApp.Repositories
{
    public class CustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository()
        {
            _db = new ApplicationDbContext();
        }

        public Customer Find(string ID)
        {
            return _db.Customers.Find(ID);
        }

        public List<Customer> List()
        {
            return _db.Customers.ToList();
        }

    }
}
