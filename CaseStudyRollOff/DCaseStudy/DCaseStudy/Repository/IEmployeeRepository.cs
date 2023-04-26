using DCaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCaseStudy.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee> >GetEmployees();

    }
}
