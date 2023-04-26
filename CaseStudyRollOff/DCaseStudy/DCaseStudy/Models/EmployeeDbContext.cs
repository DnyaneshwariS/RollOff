using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCaseStudy.Models
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext>options) : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
       // public object Employee { get; internal set; }
    }
}
