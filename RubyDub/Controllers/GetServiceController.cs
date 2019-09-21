using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RubyDub.DAL;
namespace RubyDub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetServiceController : Controller
    {
        [HttpGet]
        public object Get(string id)
        {
           var result = ServicesDAL.GetService(id);
            if (result == null)
                return NotFound();
            else return result;
        }
    }
}