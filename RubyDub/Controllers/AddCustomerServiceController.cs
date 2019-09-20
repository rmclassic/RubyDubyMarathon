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
        public IActionResult Post([FromBody]CustomerService customerService)
        {
            if (customerService != null)
            {
                RubyDub.Util.Logger.LogCustomerService(customerService);
                CustomerServicesDAL.AddService(customerService);
                return Ok();
            }
            else return BadRequest();
        }
    }
}