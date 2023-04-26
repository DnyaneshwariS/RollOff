using Microsoft.EntityFrameworkCore;
using ROLL_OFF_API.DTO;
using ROLL_OFF_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROLL_OFF_API.Repository
{
    public class RollOffRepository : IRollOffRepository
    {
        private readonly MydataContext context;

        public RollOffRepository(MydataContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Rddb>> GetAllDetailsAsync()
        {
            return await context.Rddbs.ToListAsync();
        }

        public async Task<Rddb> GetByEmailAsync(string email)
        {
            return await context.Rddbs.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Rddb> GetByGGIDAsync(double ggid)
        {
            return await context.Rddbs.FirstOrDefaultAsync(x => x.GlobalGroupId == ggid);
        }
        public async Task<Rddb> AddEmployeeAsync(Rddb rollOffEmployee)
        {
            await context.AddAsync(rollOffEmployee);
            await context.SaveChangesAsync();
            return rollOffEmployee;
        }

        public async Task<Rddb> DeleteEmployeeAsync(Rddb employee)
        {
            /*var employee = await context.RollOffTables.FirstOrDefaultAsync(x=>x.GlobalGroupId==ggid);

            if (employee == null)
            {
                return null;
            }*/

            context.Rddbs.Remove(employee);
            await context.SaveChangesAsync();
            return employee;
        }
        public async Task<Rddb> UpdateEmployeeAsync(double ggid, Rddb employee)
        {
            var existingEmployee = await context.Rddbs.FirstOrDefaultAsync(x => x.GlobalGroupId == ggid);

            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.Country = employee.Country;
            existingEmployee.Email = employee.Email;
            existingEmployee.EmployeeNo = employee.EmployeeNo;
            existingEmployee.JoiningDate = employee.JoiningDate;
            existingEmployee.Name = employee.Name;
            existingEmployee.LocalGrade = employee.LocalGrade;
            existingEmployee.MainClient = employee.MainClient;
            existingEmployee.ProjectCode = employee.ProjectCode;
            existingEmployee.ProjectName = employee.ProjectName;
            existingEmployee.ProjectStartDate = employee.ProjectStartDate;
            existingEmployee.ProjectEndDate = employee.ProjectEndDate;
            existingEmployee.PeopleManagerPerformanceReviewer = employee.PeopleManagerPerformanceReviewer;
            existingEmployee.Practice = employee.Practice;
            existingEmployee.PspName = employee.PspName;
            existingEmployee.NewGlobalPractice = employee.NewGlobalPractice;
            existingEmployee.OfficeCity = employee.OfficeCity;

            await context.SaveChangesAsync();
            return existingEmployee;

        }

        
    }
}
