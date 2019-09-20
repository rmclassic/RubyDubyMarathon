using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cassandra;
using RubyDub.DAL;
using RubyDub.Models;

namespace RubyDub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class signupController : ControllerBase
    {

        [HttpPost]
        public StatusCodeResult Post([FromForm]string username, [FromForm]string phonenumber, [FromForm]string email, [FromForm]string password)
        {
           
            var user = new User(username, phonenumber, email, password, "", "", "");
            
            if (!UserAuthDAL.IsPhoneNumberAvailable(phonenumber))
            {
                return Unauthorized();
            }
            else
            {
                UserAuthDAL.SendUserVerificationCode(user);
            }
            return Ok();
        }
    }
}