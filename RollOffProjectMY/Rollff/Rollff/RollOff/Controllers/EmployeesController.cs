using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using RollOff.Models.Domain;
using RollOff.Models.DTO;
using RollOff.Services;

namespace RollOff.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _context;
        private readonly IMapper _mapper;

        public EmployeesController(EmployeeService context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<IActionResult> GetDetails()
        {
            var data= await _context.GetAllEmployeeDetails();
            return Ok(_mapper.Map<List<GetEmployee>>(data));
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeByID(int id)
        {
            var result=await _context.GetEmployeeByID(id);
            if(result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee(string data)
        {
            //fetch employee
            var result = await _context.GetEmployee(data);
            if (result == null)
            {
                return NotFound();
            }
            var resultDTO = _mapper.Map<List<Models.DTO.GetEmployeeByID>>(result);
            return Ok(resultDTO);
        }
    }
}
