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
    public class AddGetServiceController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody]GetService getService)
        {
           // UserAuthDAL.Test();
            GetServicesDAL.AddService(getService);
            return Ok();
        }
    }
}