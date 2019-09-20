using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RubyDub.Models;
using RubyDub.DAL;
using RubyDub.Util;

namespace RubyDub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromForm]string phonenumber, [FromForm]string password)
        {
            if (UserAuthDAL.Login(phonenumber, password))
            {
                string token = UserAuthDAL.CreateToken(phonenumber);
                return Ok(token);
            }

            return Unauthorized();

            
        }
    }
}
