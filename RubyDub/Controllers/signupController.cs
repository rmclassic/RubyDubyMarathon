using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RubyDub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class signupController : ControllerBase
    {
       
        [HttpPost]
        public IActionResult  sPost([FromForm]string PhoneNumber, [FromForm]string Password, [FromForm]string Name)
        {
            //TODO AFTER DATABASE IMPLEMENTATION
        }
    }
}