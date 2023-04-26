using ROLL_OFF_API.DTO;
using ROLL_OFF_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROLL_OFF_API.Repository
{
  public  interface IRollOffRepository
    {
        Task<IEnumerable<Rddb>> GetAllDetailsAsync();

        Task<Rddb> GetByGGIDAsync(double ggid);

        Task<Rddb> GetByEmailAsync(string email);
        Task <Rddb>UpdateEmployeeAsync(double ggid, Rddb emp);

        Task<Rddb> AddEmployeeAsync(Rddb rollOffEmployee);

        Task<Rddb> DeleteEmployeeAsync(Rddb employee);
        //Task AddEmployeeAsync(RollOffDTO rollOffEmployee);
    }
}
