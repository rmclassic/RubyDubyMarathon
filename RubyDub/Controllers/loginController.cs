using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RubyDub.Models;
using RubyDub.Util;

namespace RubyDub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromForm]string PhoneNumber, [FromForm]string Password)
        {

            if (PhoneNumber == Password)
            {
                string authtoken = StringGenerator.GenerateRandomString(50);
                //check for token collisions
                //Insert Token in database
                return Ok(new AuthenticationResponse(authtoken));

            }
            else
                return Unauthorized();
            
        }
    }
}
