
using RollOff.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeeDetails();

        Task<Employee> GetEmployeeByID(int ID);
        Task<IEnumerable<Employee>> GetEmployee(string data);
    }
}
