
using RollOff.Models.Domain;
using RollOff.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff.Services
{
    public class EmployeeService
    {
        private IEmployeeRepository _EmpDetailsRepositoty;

        public EmployeeService(IEmployeeRepository EmpDetails)
        {
            _EmpDetailsRepositoty = EmpDetails;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeeDetails()
        {
            return await _EmpDetailsRepositoty.GetAllEmployeeDetails();
        }
        public async Task<Employee> GetEmployeeByID(int ID)
        {
            return await _EmpDetailsRepositoty.GetEmployeeByID(ID);
        }
        public async Task<IEnumerable<Employee>> GetEmployee(string data)
        {
            return await _EmpDetailsRepositoty.GetEmployee(data);
        }
    }
}
