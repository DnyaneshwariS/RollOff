using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RollOff.Data;
using RollOff.Models.Domain;

namespace RollOff.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private IDbContextFactory<RollOffDBContext> _factory;
        public EmployeeRepository(IDbContextFactory<RollOffDBContext> factory)
        {
            _factory = factory;
        }

        #region GetAllEmployeeDetails
        public async Task<IEnumerable<Employee>> GetAllEmployeeDetails()
        {
            using (var context = _factory.CreateDbContext())
            {
                return await context.Employees.ToListAsync();
            }
        }
        #endregion

        public async Task<Employee> GetEmployeeByID(int ID)
        {
            using (var context = _factory.CreateDbContext())
            {
                return await context.Employees.FirstOrDefaultAsync(x => x.GlobalGroupID == ID);
            }
        }

         public async Task<IEnumerable<Employee>> GetEmployee(string data)
        {
            using (var context = _factory.CreateDbContext())
            {
                //var id = data;
                var Empquery = from x in context.Employees select x;
                if (!string.IsNullOrEmpty(data))
                {
                    Empquery = Empquery.Where(x => x.Name.Contains(data) || x.Email.Contains(data) || x.GlobalGroupID.ToString().Contains(data));
                }
                return await Empquery.AsNoTracking().ToListAsync();
            }
        }

    }
}

