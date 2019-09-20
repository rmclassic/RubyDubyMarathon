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
    public class GetCustomerServiceController : Controller
    {
        [HttpGet]
        public IActionResult Get(string id)
        {
            CustomerServicesDAL.AddService(new CustomerService("Dwa", "dwa", "12", "dwa", "12", 0, 6, 6));
            return Ok(CustomerServicesDAL.GetService(id));
        }
    }
}