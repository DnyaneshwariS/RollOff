using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROLL_OFF_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet ]
        public IActionResult GetAlldetails()
        {
            string[] arr = { "Dnyaneshwari" };
            return Ok(arr);
        }
    }
}
