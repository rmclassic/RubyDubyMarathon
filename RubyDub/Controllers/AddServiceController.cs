using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RubyDub.DAL;
using RubyDub.Models;
using Newtonsoft.Json;
namespace RubyDub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddServiceController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody]Service service)
        { 
            
            ServicesDAL.AddService(service);
            return Ok();
        }
    }
}