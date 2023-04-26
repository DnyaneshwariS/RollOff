using DCaseStudy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCaseStudy.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            return await context.Employees.ToListAsync();
        }
    }
}
