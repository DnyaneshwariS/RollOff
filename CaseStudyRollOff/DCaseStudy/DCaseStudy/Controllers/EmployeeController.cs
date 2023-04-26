using AutoMapper;
using DCaseStudy.DTO;
using DCaseStudy.Models;
using DCaseStudy.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCaseStudy.Controllers
{
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeRepository employeeRepository,IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult >GetAllEmployee()
        {
            var employee = await  employeeRepository.GetEmployees();
            /* var DTOemployee = new List<Employee>();
             foreach(var emp in employee )
             {
                 DTOemployee.Add(new Employee()
                 {
                     GlobalGroupId = emp.GlobalGroupId,
                     EmployeeNo = emp.EmployeeNo,
                     Name = emp.Name,
                     LocalGrade = emp.LocalGrade,
                     MainClient = emp.MainClient,
                     Email = emp.Email,
                     JoiningDate = emp.JoiningDate,
                     ProjectCode = emp.ProjectCode,
                     ProjectName = emp.ProjectName,
                     ProjectStartDate = emp.ProjectStartDate,
                     ProjectEndDate = emp.ProjectEndDate,
                     PeopleManagerPerformanceReviewer = emp.PeopleManagerPerformanceReviewer,
                     Practice = emp.Practice,
                     PspName = emp.PspName,
                     NewGlobalPractice = emp.NewGlobalPractice,
                     OfficeCity=emp.OfficeCity,
                     Country=emp.Country
                 });
 */
           
                
            return Ok(mapper.Map<List<EmployeeDTO>>(employee)); 
        }
    }
}
