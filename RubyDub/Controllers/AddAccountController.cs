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
    public class AddAccountController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody]Account account)
        {
            AccountsDAL.AddAccount(account);
            return Ok();
        }
    }
}