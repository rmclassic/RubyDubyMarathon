using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RubyDub.Models;
using RubyDub.DAL;
using Newtonsoft.Json;

namespace RubyDub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetGetServiceController : Controller
    {
        [HttpGet]
        public IActionResult Get(string id)
        {
           // var baseserv = ServicesDAL.GetService(id);
            var getserv = GetServicesDAL.GetService(id);
            return Ok();
            //return Ok('[' + JsonConvert.SerializeObject(baseserv) + ',' + JsonConvert.SerializeObject(getserv) + ']');
        }
    }
}