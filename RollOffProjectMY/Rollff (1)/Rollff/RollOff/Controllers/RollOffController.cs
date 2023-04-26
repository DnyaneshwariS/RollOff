using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollOff.Models.DTO;
using RollOff.Services;

namespace RollOff.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin, Accounts, SuperAdmin")]
    public class RollOffController : ControllerBase
    {
        private IRolloffFormService _rolloffFormService;

        public RollOffController(IRolloffFormService rolloffFormService)
        {
            _rolloffFormService = rolloffFormService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveRollOffForm(RollOffTransactionDto rollOffTransactionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _rolloffFormService.SaveRollOffForm(rollOffTransactionDto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetRollOffFormByEmpId(int employeeId)
        {
            if (employeeId < 1)
                return BadRequest();

            var result = await _rolloffFormService.GetRollOffFormByEmpId(employeeId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetRollOffFormList()
        {
            var result = await _rolloffFormService.GetRollOffFormList();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTransferedList()
        {
            var result = await _rolloffFormService.GetTransferedList();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> SaveTransfered(TransferedFromDto transferedFromDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _rolloffFormService.SaveTransfered(transferedFromDto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTransfered(TransferedFromDto transferedFromDto)
        {
            var result = await _rolloffFormService.UpdateTransfered(transferedFromDto);
            return Ok(result);
        }
    }
}
