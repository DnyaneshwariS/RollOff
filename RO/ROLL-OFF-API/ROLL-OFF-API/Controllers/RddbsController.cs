using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ROLL_OFF_API.Models;
using ROLL_OFF_API.Repository;
using ROLL_OFF_API.DTO;


namespace ROLL_OFF_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RollOffController : Controller
    {

        private readonly IRollOffRepository rollOffRepository;
        private readonly IMapper mapper; public RollOffController(IRollOffRepository rollOffRepository, IMapper mapper)
        {
            this.rollOffRepository = rollOffRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRollOffEmployees()
        {
            var rollOffDetails = await rollOffRepository.GetAllDetailsAsync();
            var rollOffDetailsDTO = mapper.Map<List<RollOffDTO>>(rollOffDetails); return Ok(rollOffDetailsDTO);
        }
        [HttpGet]
        [Route("{ggid:double}")]
        public async Task<IActionResult> GetDetailByGGID(double ggid)
        {
            var rollOffEmployee = await rollOffRepository.GetByGGIDAsync(ggid); if (rollOffEmployee == null)
            {
                return NotFound();
            }
            var rollOffEmployeeDTO = mapper.Map<RollOffDTO>(rollOffEmployee); return Ok(rollOffEmployeeDTO);
        }
        [HttpGet]
        [Route("{email}")]
        public async Task<IActionResult> GetDetailByEmail(string email)
        {
            var rollOffEmployee = await rollOffRepository.GetByEmailAsync(email); if (rollOffEmployee == null)
            {
                return NotFound();
            }
            var rollOffEmployeeDTO = mapper.Map<RollOffDTO>(rollOffEmployee); return Ok(rollOffEmployeeDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRollOffEmployee(RollOffDTO rollOffTableDTO)
        {
            //DTO to Model
            var rollOffEmployee = mapper.Map<RollOffDTO>(rollOffTableDTO);

            //Pass Detail to Repository
            var response = await rollOffRepository.AddEmployeeAsync(rollOffEmployee);

            //Convert back to DTO
            var rollOffTableDTO2 = mapper.Map<RollOffDTO>(response);

            return Ok(rollOffTableDTO2);
        }

        [HttpDelete]
        [Route("{ggid}")]
        public async Task<IActionResult> DeleteEmployeeByGGID(double ggid)
        {
            //Get Employee from Database
            var rollOffEmployee = await rollOffRepository.GetByGGIDAsync(ggid);

            //If null return not found
            if (rollOffEmployee == null)
            {
                return NotFound();
            }

            //Delete the employee
            var rollOffEmployee1 = await rollOffRepository.DeleteEmployeeAsync(rollOffEmployee);

            //Convert response back to DTO
            var rollOffTableDTO = mapper.Map<RollOffDTO>(rollOffEmployee1);

            //return Ok response
            return Ok(rollOffTableDTO);
        }

        [HttpPut]
        [Route("{ggid}")]
        public async Task<IActionResult> UpdateEmployeeByGGID(double ggid, UpdateEmployeeDTO updateEmployeeDTO)
        {
            //Convert DTO to model
            var emp = mapper.Map<Rddb>(updateEmployeeDTO);

            /*var emp = new RollOffTable()
            {
                Country = updateEmployeeDTO.Country,
                Email = updateEmployeeDTO.Email,
                EmployeeNo = updateEmployeeDTO.EmployeeNo,
                JoiningDate = updateEmployeeDTO.JoiningDate,
                Name = updateEmployeeDTO.Name,
                LocalGrade = updateEmployeeDTO.LocalGrade,
                MainClient = updateEmployeeDTO.MainClient,
                ProjectCode = updateEmployeeDTO.ProjectCode,
                ProjectName = updateEmployeeDTO.ProjectName,
                ProjectStartDate = updateEmployeeDTO.ProjectStartDate,
                ProjectEndDate = updateEmployeeDTO.ProjectEndDate,
                PeopleManagerPerformanceReviewer = updateEmployeeDTO.PeopleManagerPerformanceReviewer,
                Practice = updateEmployeeDTO.Practice,
                PspName = updateEmployeeDTO.PspName,
                NewGlobalPractice = updateEmployeeDTO.NewGlobalPractice,
                OfficeCity = updateEmployeeDTO.OfficeCity
             };*/

            //Update Employee using Repository
            var employee = await rollOffRepository.UpdateEmployeeAsync(ggid, emp);

            //If null return Not Found
            if (employee == null)
            {
                return NotFound();
            }

            //Convert Domain back to DTO
            var employeeDTO = mapper.Map<RollOffDTO>(employee);

            //return Ok response
            return Ok(employeeDTO);






        }
    }
}
