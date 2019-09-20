using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RubyDub.Models;
using RubyDub.DAL;

namespace RubyDub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteServiceController : Controller
    {
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            ServicesDAL.DeleteService(id);
            return Ok();
        }
    }
}