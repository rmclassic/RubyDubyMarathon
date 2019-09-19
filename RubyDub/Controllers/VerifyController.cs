using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RubyDub.DAL;
using RubyDub.Models;
using RubyDub.Util;
namespace RubyDub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerifyController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromForm]string passcode, [FromForm]string phonenumber)
        {
            if (UserAuthDAL.VerifyUser(passcode, phonenumber))
            {
                string token = UserAuthDAL.CreateToken(phonenumber);
                return Ok(new AuthenticationResponse(token));

            }
            return Unauthorized();
        }
    }
}