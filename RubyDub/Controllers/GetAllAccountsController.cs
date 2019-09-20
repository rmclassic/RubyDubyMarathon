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
    public class GetAllAccountsController : Controller
    {
        [HttpGet]
        public IActionResult Get(string phonenumber, string token)
        {
            if (!UserAuthDAL.VerifyToken(phonenumber, token))
                return Unauthorized();
            var transactions = AccountsDAL.GetAccounts(phonenumber);
            return Ok(transactions);
        }


    }
}