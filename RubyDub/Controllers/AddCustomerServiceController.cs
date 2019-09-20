using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RubyDub.DAL;
using RubyDub.Models;

namespace RubyDub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddCustomerServiceController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody]CustomerService customerService,[FromForm]string token)
        {
            if (customerService != null)
            {
                if (!UserAuthDAL.VerifyToken(customerService.phoneunumber, token))
                    return Unauthorized();
                CustomerServicesDAL.AddService(customerService);
                RubyDub.Util.Logger.LogCustomerService(customerService);
                return Ok();
            }
            else return BadRequest();
        }
    }
}