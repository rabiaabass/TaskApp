using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaskApp.Models
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext()
        {

        }


        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=TaskApp;uid=sa;pwd=1234;MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Employee> Employees { get; set; }

        public DbSet<UnitManager> UnitManagers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
